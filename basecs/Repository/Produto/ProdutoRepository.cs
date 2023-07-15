using basecs.Data;
using basecs.Dtos.Produtos;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Repository.Produto;
using basecs.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Repository.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region ATRIBUTTES
        private APDConnector _session;
        #endregion

        #region CONTRUCTORS
        public ProdutoRepository(APDConnector session)
        {
            _session = session;
        }
        #endregion

        #region FIND BY ID
        public async Task<ProdutoDto> FindById(Guid id)
        {
            string query = string.Empty;

            query = @"
                DELETE FROM [seg].[Compras]
                WHERE [UsuarioId]=@Id;
            ";

            return await _session.Connection.QuerySingleOrDefaultAsync<ProdutoDto>(query, new { Id = id });
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<IEnumerable<ProdutoDto>> ReturnListWithParametersPaginated(
                Guid? id,
                string descricao,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(descricao.RemoveInjections()) ? DBNull.Value : descricao.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

            var storedProcedure = $@"[dbo].[ProdutoPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

            return await _session.Connection.QueryAsync<ProdutoDto>(storedProcedure, Params);
        }
        #endregion

        #region INSERT
        public async Task<int> Insert(ProdutoDto model)
        {
            var Params = new {
                ProdutoId = model.ProdutoId,
                TipoProduto = model.TipoProduto,
                Descricao = model.Descricao,
                CodigoBarras = model.CodigoBarras,
                Marca = model.Marca,
                Quantidade = model.Quantidade,
                IsIlimitado = model.IsIlimitado,
                QuantidadeCritica = model.QuantidadeCritica,
                PrecoCusto = model.PrecoCusto,
                PrecoVenda = model.PrecoVenda,
                MargemLucro = model.MargemLucro,
                Bloqueado = model.Bloqueado,
                UsuarioInclusaoId = model.UsuarioInclusaoId,
                DataInclusao = model.DataInclusao,
                Ativo = model.Ativo,
                Peso = model.Peso,
            };

            string query = string.Empty;

            query = @"
                INSERT INTO APDBDev.dbo.Produtos
                (ProdutoId, TipoProduto, Descricao, CodigoBarras, Marca, Quantidade, IsIlimitado, QuantidadeCritica, PrecoCusto, PrecoVenda, MargemLucro, Bloqueado, UsuarioInclusaoId, DataInclusao, Ativo, Peso)
                VALUES(@ProdutoId, @TipoProduto, @Descricao, @CodigoBarras, @Marca, @Quantidade, @IsIlimitado, @QuantidadeCritica, @PrecoCusto, @PrecoVenda, @MargemLucro, @Bloqueado, @UsuarioInclusaoId, @DataInclusao, @Ativo, @Peso);
            ";

            return await _session.Connection.ExecuteAsync(query, Params);
        }
        #endregion

        #region UPDATE
        public async Task<int> Update(ProdutoDto model)
        {
            var Params = new
            {
                ProdutoId = model.ProdutoId,
                TipoProduto = model.TipoProduto,
                Descricao = model.Descricao,
                CodigoBarras = model.CodigoBarras,
                Marca = model.Marca,
                Quantidade = model.Quantidade,
                IsIlimitado = model.IsIlimitado,
                QuantidadeCritica = model.QuantidadeCritica,
                PrecoCusto = model.PrecoCusto,
                PrecoVenda = model.PrecoVenda,
                MargemLucro = model.MargemLucro,
                Bloqueado = model.Bloqueado,
                UsuarioUltimaAlteracaoId = model.UsuarioUltimaAlteracaoId,
                DataUltimaAlteracao = model.DataUltimaAlteracao,
                Ativo = model.Ativo,
                Peso = model.Peso,
            };

            string query = string.Empty;

            query = @"
                UPDATE APDBDev.dbo.Produtos
                SET TipoProduto=@TipoProduto, Descricao=@Descricao, CodigoBarras=@CodigoBarras, Marca=@Marca, Quantidade=@Quantidade, IsIlimitado=@IsIlimitado, QuantidadeCritica=@QuantidadeCritica, PrecoCusto=@PrecoCusto, PrecoVenda=@PrecoVenda, MargemLucro=@MargemLucro, Bloqueado=@Bloqueado, UsuarioInclusaoId=@UsuarioInclusaoId, UsuarioUltimaAlteracaoId=@UsuarioUltimaAlteracaoId, DataInclusao=@DataInclusao, DataUltimaAlteracao=@DataUltimaAlteracao, Ativo=@Ativo, Peso=@Peso
                WHERE ProdutoId=@ProdutoId;
            ";

            return await _session.Connection.ExecuteAsync(query, Params);
        }
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        public async Task<int> Delete(Guid id)
        {
            var Params = new
            {
                ProdutoId = id,
                Ativo = false
            };

            string query = string.Empty;

            query = @"
                UPDATE APDBDev.dbo.Produtos
                SET Ativo=@Ativo
                WHERE ProdutoId=@ProdutoId;
            ";

            return await _session.Connection.ExecuteAsync(query, Params);
        }
        #endregion
    }
}
