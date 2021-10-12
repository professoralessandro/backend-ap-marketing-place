using basecs.Business.BloqueiosProdutos;
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
    public class BloqueiosProdutosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly BloqueiosProdutosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public BloqueiosProdutosService(MyDbContext context)
        {
            _context = context;
            _business = new BloqueiosProdutosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<BloqueioProduto> FindById(int id)
        {
            try
            {
                return await this._context.BloqueiosProdutos.SingleOrDefaultAsync(c => c.BloqueioProdutoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<BloqueioProduto>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[BloqueiosProdutosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.BloqueiosProdutos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<BloqueioProduto>> ReturnListWithParameters(
                int? id,
                int? avaliacaoId,
                int? produtoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.BloqueiosProdutos.Where(c =>
                    (c.BloqueioProdutoId == id || id == null) &&
                    (c.BloqueioId == avaliacaoId || avaliacaoId == null) &&
                    (c.ProdutoId == produtoId || produtoId == null)
                    ).OrderByDescending(x => x.BloqueioProdutoId)
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
        public async Task<BloqueioProduto> Insert(BloqueioProduto model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.BloqueiosProdutos.Add(model);
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
        public async Task<BloqueioProduto> Update(BloqueioProduto model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.BloqueiosProdutos.Update(model);
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
        public async Task<BloqueioProduto> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    BloqueioProduto model = await this.FindById(id);
                    this._context.BloqueiosProdutos.Remove(model);
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
