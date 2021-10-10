using basecs.Business.EnderecosUsuarios;
using basecs.Data;
using basecs.Interfaces.IEnderecosUsuariosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class EnderecosUsuariosService : IEnderecosUsuariosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly EnderecosUsuariosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public EnderecosUsuariosService(MyDbContext context)
        {
            _context = context;
            _business = new EnderecosUsuariosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<EnderecoUsuario> FindById(int id)
        {
            try
            {
                return await this._context.EnderecosUsuarios.SingleOrDefaultAsync(c => c.EnderecoUsuarioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<EnderecoUsuario>> ReturnListWithParametersPaginated(
                int? id,
                int? telefoneId,
                int? usuarioId,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@EnderecoId", telefoneId.Equals(null) ? DBNull.Value : telefoneId),
                    new SqlParameter("@UsuarioId", usuarioId.Equals(null) ? DBNull.Value : usuarioId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[EnderecosUsuariosPaginated] @Id, @EnderecoId, @UsuarioId, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.EnderecosUsuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<EnderecoUsuario>> ReturnListWithParameters(
                int? id,
                int? telefoneId,
                int? usuarioId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.EnderecosUsuarios.Where(c =>
                    (c.EnderecoUsuarioId == id || id == null) &&
                    (c.EnderecoId == telefoneId || telefoneId == null) &&
                    (c.UsuarioId == usuarioId || usuarioId == null)
                    ).OrderByDescending(x => x.EnderecoUsuarioId)
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
        public async Task<EnderecoUsuario> Insert(EnderecoUsuario model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.EnderecosUsuarios.Add(model);
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
        public async Task<EnderecoUsuario> Update(EnderecoUsuario model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.EnderecosUsuarios.Update(model);
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
        public async Task<EnderecoUsuario> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    EnderecoUsuario model = await this.FindById(id);
                    this._context.EnderecosUsuarios.Remove(model);
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
