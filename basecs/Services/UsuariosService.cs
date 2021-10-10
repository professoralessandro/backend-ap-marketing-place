using basecs.Business.Usuarios;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IUsuariosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class UsuariosService : IUsuariosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly UsuariosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public UsuariosService(MyDbContext context)
        {
            _context = context;
            _business = new UsuariosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Usuario> FindById(int id)
        {
            try
            {
                return await this._context.Usuarios.SingleOrDefaultAsync(c => c.UsuarioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Usuario>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[UsuariosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Usuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Usuario>> ReturnListWithParameters(
                int? id,
                int? grupoUsaruiId,
                string login,
                string nome,
                string email,
                bool bloqueado,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Usuarios.Where(c =>
                    (c.UsuarioId.Equals(id) || id.Equals(null)) &&
                    (c.GrupoUsaruiId.Equals(grupoUsaruiId) || grupoUsaruiId.Equals(null)) &&
                    (c.Login.Contains(Validators.RemoveInjections(login)) || string.IsNullOrEmpty(Validators.RemoveInjections(login))) &&
                    (c.Nome.Contains(Validators.RemoveInjections(nome)) || string.IsNullOrEmpty(Validators.RemoveInjections(nome))) &&
                    (c.Email.Contains(Validators.RemoveInjections(email)) || string.IsNullOrEmpty(Validators.RemoveInjections(email))) &&
                    (c.Bloqueado.Equals(bloqueado) || bloqueado.Equals(null)) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.UsuarioId)
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
        public async Task<Usuario> Insert(Usuario model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Usuarios.Add(model);
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
        public async Task<Usuario> Update(Usuario model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Usuarios.Update(model);
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
        public async Task<Usuario> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Usuario model = await this.FindById(id);
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
