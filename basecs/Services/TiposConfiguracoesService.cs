using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.TiposConfiguracoes;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposConfiguracoesService;

namespace basecs.Services
{
    public class TiposConfiguracoesService : ITiposConfiguracoesService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposConfiguracoesBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposConfiguracoesService(MyDbContext context)
        {
            _context = context;
            _business = new TiposConfiguracoesBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoConfiguracao> FindById(int id)
        {
            try
            {
                return await this._context.TiposConfiguracoes.SingleOrDefaultAsync(c => c.TipoConfiguracaoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o TipoConfiguracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoConfiguracao>> ReturnListWithParametersPaginated(
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
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(descricao) ? DBNull.Value : Validators.RemoveInjections(descricao)),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TiposConfiguracoesPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposConfiguracoes.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos configurações: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoConfiguracao>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposConfiguracoes.Where(c =>
                    (c.TipoConfiguracaoId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(descricao)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.TipoConfiguracaoId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos configurações: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<TipoConfiguracao> Insert(TipoConfiguracao model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposConfiguracoes.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos configuracoes: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoConfiguracao> Update(TipoConfiguracao model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposConfiguracoes.Update(model);
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

        #region DELETE SERVIÇO DE DELETE COMENTADO
        public async Task<TipoConfiguracao> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoConfiguracao model = await this.FindById(id);
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