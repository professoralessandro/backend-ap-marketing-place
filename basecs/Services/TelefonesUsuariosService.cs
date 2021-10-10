using basecs.Business.TelefonesUsuarios;
using basecs.Data;
using basecs.Interfaces.ITelefonesUsuariosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class TelefonesUsuariosService : ITelefonesUsuariosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TelefonesUsuariosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TelefonesUsuariosService(MyDbContext context)
        {
            _context = context;
            _business = new TelefonesUsuariosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TelefoneUsuario> FindById(int id)
        {
            try
            {
                return await this._context.TelefonesUsuarios.SingleOrDefaultAsync(c => c.TelefoneUsuarioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TelefoneUsuario>> ReturnListWithParametersPaginated(
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
                    new SqlParameter("@TelefoneId", telefoneId.Equals(null) ? DBNull.Value : telefoneId),
                    new SqlParameter("@UsuarioId", usuarioId.Equals(null) ? DBNull.Value : usuarioId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TelefonesUsuariosPaginated] @Id, @TelefoneId, @UsuarioId, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TelefonesUsuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TelefoneUsuario>> ReturnListWithParameters(
                int? id,
                int? telefoneId,
                int? usuarioId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TelefonesUsuarios.Where(c =>
                    (c.TelefoneUsuarioId == id || id == null) &&
                    (c.TelefoneId == telefoneId || telefoneId == null) &&
                    (c.UsuarioId == usuarioId || usuarioId == null)
                    ).OrderByDescending(x => x.TelefoneUsuarioId)
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
        public async Task<TelefoneUsuario> Insert(TelefoneUsuario model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TelefonesUsuarios.Add(model);
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
        public async Task<TelefoneUsuario> Update(TelefoneUsuario model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TelefonesUsuarios.Update(model);
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
        public async Task<TelefoneUsuario> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TelefoneUsuario model = await this.FindById(id);
                    this._context.TelefonesUsuarios.Remove(model);
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
