using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.Tipoemails;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposEmailsService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TiposEmailsService : ITiposEmailsService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposEmailsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposEmailsService(MyDbContext context)
        {
            _context = context;
            _business = new TiposEmailsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoEmail> FindById(int id)
        {
            try
            {
                return await this._context.TiposEmails.SingleOrDefaultAsync(c => c.TipoEmailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar os Tipos Emails desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoEmail>> ReturnListWithParametersPaginated(
                int? id,
                string descricao,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(descricao.RemoveInjections()) ? DBNull.Value : descricao.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TiposEmailsPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                { 
                    return await context.TiposEmails.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por TipoEmail: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoEmail>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await _context.TiposEmails.Where(c =>
                    (c.TipoEmailId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por TipoEmail: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<TipoEmail> Insert(TipoEmail model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposEmails.Add(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir tipos Emails: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoEmail> Update(TipoEmail model)
        {
            string validationMessage = _business.UpdateValidation(model);

            if (validationMessage.Equals(""))
            {
                this._context.TiposEmails.Update(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            else
            {
                throw new Exception(validationMessage);
            }
        }
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        public async Task<TipoEmail> Delete(int id)
        {
            string validationMessage = _business.DeleteValidation(id);

            if (validationMessage.Equals(""))
            {
                TipoEmail model = await this.FindById(id);
                model.Ativo = false;
                await this.Update(model);
                return model;
            }
            else
            {
                throw new Exception(validationMessage);
            }
        }
        #endregion
    }
}