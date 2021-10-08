using basecs.Business.Imagens;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IImagensService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ImagensService : IImagensService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ImagensBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ImagensService(MyDbContext context)
        {
            _context = context;
            _business = new ImagensBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Imagem> FindById(int id)
        {
            try
            {
                return await this._context.Imagens.SingleOrDefaultAsync(c => c.ImagemId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Imagem>> ReturnListWithParametersPaginated(
                int? id,
                string titulo,
                bool? imagemPrincipal,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Titulo", string.IsNullOrEmpty(Validators.RemoveInjections(titulo)) ? DBNull.Value : Validators.RemoveInjections(titulo)),
                    new SqlParameter("@ImagemPrincipal", imagemPrincipal.Equals(null) ? DBNull.Value : imagemPrincipal),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ImagensPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Imagens.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Imagem>> ReturnListWithParameters(
                int? id,
                string titulo,
                bool? imagemPrincipal
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Imagens.Where(c =>
                    (c.ImagemId.Equals(id)   ||  id.Equals(null)) &&
                    (c.Titulo.Contains(Validators.RemoveInjections(titulo)) || string.IsNullOrEmpty(Validators.RemoveInjections(titulo))) &&
                    (c.ImagemPrincipal.Equals(imagemPrincipal)  || imagemPrincipal.Equals(null))
                    ).OrderByDescending(x => x.ImagemId)
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
        public async Task<Imagem> Insert(Imagem model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Imagens.Add(model);
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
        public async Task<Imagem> Update(Imagem model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Imagens.Update(model);
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
        public async Task<Imagem> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Imagem model = await this.FindById(id);
                    this._context.Imagens.Remove(model);
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
