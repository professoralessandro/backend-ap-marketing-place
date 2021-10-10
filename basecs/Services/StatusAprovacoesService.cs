using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.StatusAprovacoes;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IStatusAprovacaosService;

namespace basecs.Services
{
    public class StatusAprovacoesService : IStatusAprovacaosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly StatusAprovacoesBusiness _business;
        #endregion

        #region CONTRUCTORS
        public StatusAprovacoesService(MyDbContext context)
        {
            _context = context;
            _business = new StatusAprovacoesBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<StatusAprovacao> FindById(int id)
        {
            try
            {
                return await this._context.StatusAprovacoes.SingleOrDefaultAsync(c => c.StatusAprovacaoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o status aprovacao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<StatusAprovacao>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[StatusAprovacaosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.StatusAprovacoes.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<StatusAprovacao>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.StatusAprovacoes.Where(c =>
                    (c.StatusAprovacaoId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.StatusAprovacaoId)
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
        public async Task<StatusAprovacao> Insert(StatusAprovacao model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.StatusAprovacoes.Add(model);
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
        public async Task<StatusAprovacao> Update(StatusAprovacao model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.StatusAprovacoes.Update(model);
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
        public async Task<StatusAprovacao> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    StatusAprovacao model = await this.FindById(id);
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