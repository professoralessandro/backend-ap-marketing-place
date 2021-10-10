using basecs.Business.Workflows;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IWorkflowsService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class WorkflowsService : IWorkflowsService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly WorkflowsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public WorkflowsService(MyDbContext context)
        {
            _context = context;
            _business = new WorkflowsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Workflow> FindById(int id)
        {
            try
            {
                return await this._context.Workflows.SingleOrDefaultAsync(c => c.WorkflowId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Workflow>> ReturnListWithParametersPaginated(
                int? id,
                int? tipoWorkflowId,
                int? statusAprovacaoId,
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
                    new SqlParameter("@TipoWorkflowId", tipoWorkflowId.Equals(null) ? DBNull.Value : tipoWorkflowId),
                    new SqlParameter("@StatusAprovacaoId", statusAprovacaoId.Equals(null) ? DBNull.Value : statusAprovacaoId),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(Validators.RemoveInjections(descricao)) ? DBNull.Value : descricao),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[WorkflowsPaginated] @Id, @TipoWorkflowId, @StatusAprovacaoId, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Workflows.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Workflow>> ReturnListWithParameters(
                int? id,
                int? tipoWorkflowId,
                int? statusAprovacaoId,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Workflows.Where(c =>
                    (c.WorkflowId.Equals(id) || id.Equals(null)) &&
                    (c.TipoWorkflowId.Equals(tipoWorkflowId) || tipoWorkflowId.Equals(null)) &&
                    (c.StatusAprovacaoId.Equals(statusAprovacaoId) || statusAprovacaoId.Equals(null)) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.WorkflowId)
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
        public async Task<Workflow> Insert(Workflow model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Workflows.Add(model);
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
        public async Task<Workflow> Update(Workflow model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Workflows.Update(model);
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
        public async Task<Workflow> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Workflow model = await this.FindById(id);
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
