using basecs.Business.Produtos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IProdutosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ProdutosService : IProdutosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ProdutosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ProdutosService(MyDbContext context)
        {
            _context = context;
            _business = new ProdutosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Produto> FindById(int id)
        {
            try
            {
                return await this._context.Produtos.SingleOrDefaultAsync(c => c.ProdutoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Produto>> ReturnListWithParametersPaginated(
                string param,
                DateTime? dateAdded,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Param", string.IsNullOrEmpty(Validators.RemoveInjections(param)) ? DBNull.Value : param),
                    new SqlParameter("@DateAdded", dateAdded.Equals(null) ? DBNull.Value : dateAdded),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ProdutosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Produtos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Produto>> ReturnListWithParameters(
                int? id,
                int? tipoProdutoId,
                string descricao,
                string codigoBarras,
                string marca,
                decimal?preco,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Produtos.Where(c =>
                    (c.ProdutoId.Equals(id) || id.Equals(null)) &&
                    (c.TipoProdutoId.Equals(tipoProdutoId) || tipoProdutoId.Equals(null)) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.CodigoBarras.Contains(Validators.RemoveInjections(codigoBarras)) || string.IsNullOrEmpty(Validators.RemoveInjections(codigoBarras))) &&
                    (c.Marca.Contains(Validators.RemoveInjections(marca)) || string.IsNullOrEmpty(Validators.RemoveInjections(marca))) &&
                    (c.PrecoVenda.Equals(preco) || preco.Equals(null)) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.ProdutoId)
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
        public async Task<Produto> Insert(Produto model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Produtos.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Produto> Update(Produto model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Produtos.Update(model);
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
        public async Task<Produto> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Produto model = await this.FindById(id);
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
