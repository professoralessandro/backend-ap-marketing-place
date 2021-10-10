using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.TiposWorkflows;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposWorkflowsService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TiposWorkflowsService : ITiposWorkflowsService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposWorkflowsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposWorkflowsService(MyDbContext context)
        {
            _context = context;
            _business = new TiposWorkflowsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoWorkflow> FindById(int id)
        {
            try
            {
                return await this._context.TiposWorkflows.SingleOrDefaultAsync(c => c.TipoWorkflowId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao o tipo de workflow desejado! " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoWorkflow>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[TiposWorkflowsPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposWorkflows.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoWorkflow>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposWorkflows.Where(c =>
                    (c.TipoWorkflowId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo == ativo || ativo == null))
                    .OrderByDescending(x => x.TipoWorkflowId)
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
        public async Task<TipoWorkflow> Insert(TipoWorkflow model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposWorkflows.Add(model);
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
        public async Task<TipoWorkflow> Update(TipoWorkflow model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposWorkflows.Update(model);
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
        public async Task<TipoWorkflow> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoWorkflow model = await this.FindById(id);
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