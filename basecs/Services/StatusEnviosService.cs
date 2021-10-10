using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IStatusEnviosService;
using basecs.Business.StatusEnvio;

namespace basecs.Services
{
    public class StatusEnviosService : IStatusEnviosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly StatusEnviosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public StatusEnviosService(MyDbContext context)
        {
            _context = context;
            _business = new StatusEnviosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<StatusEnvio> FindById(int id)
        {
            try
            {
                return await this._context.StatusEnvios.SingleOrDefaultAsync(c => c.StatusEnvioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o status aprovacao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<StatusEnvio>> ReturnListWithParametersPaginated(
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
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(Validators.RemoveInjections(descricao)) ? DBNull.Value : Validators.RemoveInjections(descricao)),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[StatusEnviosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.StatusEnvios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<StatusEnvio>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.StatusEnvios.Where(c =>
                    (c.StatusEnvioId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.StatusEnvioId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<StatusEnvio> Insert(StatusEnvio model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.StatusEnvios.Add(model);
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
                throw new Exception("Houve um erro ao incluir o registro: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<StatusEnvio> Update(StatusEnvio model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.StatusEnvios.Update(model);
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
                throw new Exception("Houve um erro ao tentar editar o registro: " + ex.Message);
            }
        }
        #endregion        

        #region DELETE
        public async Task<StatusEnvio> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    StatusEnvio model = await this.FindById(id);
                    model.Ativo = false;
                    await this.Update(model);
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
        #endregion
    }
}