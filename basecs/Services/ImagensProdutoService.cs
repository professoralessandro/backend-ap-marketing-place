using basecs.Business.ImagensProdutos;
using basecs.Data;
using basecs.Interfaces.IImagensProdutosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ImagensProdutosService : IImagensProdutosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ImagensProdutosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ImagensProdutosService(MyDbContext context)
        {
            _context = context;
            _business = new ImagensProdutosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<ImagemProduto> FindById(int id)
        {
            try
            {
                return await this._context.ImagensProdutos.SingleOrDefaultAsync(c => c.ImagemProdutoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<ImagemProduto>> ReturnListWithParametersPaginated(
                int? id,
                int? imagemId,
                int? produtoId,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@ImagemId", imagemId.Equals(null) ? DBNull.Value : imagemId),
                    new SqlParameter("@ProdutoId", produtoId.Equals(null) ? DBNull.Value : produtoId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ImagensProdutosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.ImagensProdutos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<ImagemProduto>> ReturnListWithParameters(
                int? id,
                int? imagemId,
                int? produtoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.ImagensProdutos.Where(c =>
                    (c.ImagemProdutoId.Equals(id)   ||  id.Equals(null)) &&
                    (c.ImagemId.Equals(imagemId)    ||  imagemId.Equals(null)) &&
                    (c.ProdutoId.Equals(produtoId)  ||  produtoId.Equals(produtoId))
                    ).OrderByDescending(x => x.ImagemProdutoId)
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
        public async Task<ImagemProduto> Insert(ImagemProduto model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.ImagensProdutos.Add(model);
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
        public async Task<ImagemProduto> Update(ImagemProduto model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.ImagensProdutos.Update(model);
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
        public async Task<ImagemProduto> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    ImagemProduto model = await this.FindById(id);
                    this._context.ImagensProdutos.Remove(model);
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
