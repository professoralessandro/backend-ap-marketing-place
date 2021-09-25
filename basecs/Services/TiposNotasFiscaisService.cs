using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.TiposNotasFiscais;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposNotasFiscaisService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TiposNotasFiscaisService : ITiposNotasFiscaisService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposNotasFiscaisBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposNotasFiscaisService(MyDbContext context)
        {
            _context = context;
            _business = new TiposNotasFiscaisBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoNotaFiscal> FindById(int id)
        {
            try
            {
                return await this._context.TiposNotasFiscais.SingleOrDefaultAsync(c => c.TipoNotaFiscalId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao o tipo de telefone desejado! " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoNotaFiscal>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[TiposNotasFiscaisPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposNotasFiscais.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos telefones: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoNotaFiscal>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposNotasFiscais.Where(c =>
                    (c.TipoNotaFiscalId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo == ativo || ativo == null))
                    .OrderByDescending(x => x.TipoNotaFiscalId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos telefones: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<TipoNotaFiscal> Insert(TipoNotaFiscal model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposNotasFiscais.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos telefones: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoNotaFiscal> Update(TipoNotaFiscal model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposNotasFiscais.Update(model);
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

        #region DELETE SERVIÇO DE DELETE
        public async Task<TipoNotaFiscal> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoNotaFiscal model = await this.FindById(id);
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