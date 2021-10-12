using basecs.Business.AvaliacoesProdutos;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class AvaliacoesProdutosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly AvaliacoesProdutosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public AvaliacoesProdutosService(MyDbContext context)
        {
            _context = context;
            _business = new AvaliacoesProdutosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<AvaliacaoProduto> FindById(int id)
        {
            try
            {
                return await this._context.AvaliacoesProdutos.SingleOrDefaultAsync(c => c.AvaliacaoProdutoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<AvaliacaoProduto>> ReturnListWithParametersPaginated(
                int? id,
                int? configuracaoId,
                int? parametroId,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@ConfiguracaoId", configuracaoId.Equals(null) ? DBNull.Value : configuracaoId),
                    new SqlParameter("@ParametroId", parametroId.Equals(null) ? DBNull.Value : parametroId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[AvaliacoesProdutosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.AvaliacoesProdutos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<AvaliacaoProduto>> ReturnListWithParameters(
                int? id,
                int? avaliacaoId,
                int? produtoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.AvaliacoesProdutos.Where(c =>
                    (c.AvaliacaoProdutoId == id || id == null) &&
                    (c.AvaliacaoId == avaliacaoId || avaliacaoId == null) &&
                    (c.ProdutoId == produtoId || produtoId == null)
                    ).OrderByDescending(x => x.AvaliacaoProdutoId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<AvaliacaoProduto> Insert(AvaliacaoProduto model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.AvaliacoesProdutos.Add(model);
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
        public async Task<AvaliacaoProduto> Update(AvaliacaoProduto model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.AvaliacoesProdutos.Update(model);
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
        public async Task<AvaliacaoProduto> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    AvaliacaoProduto model = await this.FindById(id);
                    this._context.AvaliacoesProdutos.Remove(model);
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
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
        #endregion
    }
}
