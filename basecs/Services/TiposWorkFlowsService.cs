using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.TiposWorkFlows;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposWorkFlowsService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TiposWorkFlowsService : ITiposWorkFlowsService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposWorkFlowsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposWorkFlowsService(MyDbContext context)
        {
            _context = context;
            _business = new TiposWorkFlowsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoWorkFlow> FindById(int id)
        {
            try
            {
                return await this._context.TiposWorkFlows.SingleOrDefaultAsync(c => c.TipoWorkFlowId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao o tipo de workflow desejado! " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoWorkFlow>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[TiposWorkFlowsPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposWorkFlows.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoWorkFlow>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposWorkFlows.Where(c =>
                    (c.TipoWorkFlowId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo == ativo || ativo == null))
                    .OrderByDescending(x => x.TipoWorkFlowId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<TipoWorkFlow> Insert(TipoWorkFlow model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposWorkFlows.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos workflows: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoWorkFlow> Update(TipoWorkFlow model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposWorkFlows.Update(model);
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
        public async Task<TipoWorkFlow> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoWorkFlow model = await this.FindById(id);
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