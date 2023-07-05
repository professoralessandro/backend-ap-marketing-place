using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.Usuarios;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IUsuariosService;

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
                throw new Exception("Houve um erro ao buscar o usuario desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Usuario>> ReturnListWithParametersPaginated(
                int? id,
                string nome,
                string email,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Nome", string.IsNullOrEmpty(nome.RemoveInjections()) ? DBNull.Value : nome.RemoveInjections()),
                    new SqlParameter("@Email", string.IsNullOrEmpty(email.RemoveInjections()) ? DBNull.Value : email.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[UsuariosPaginated] @Id, @Nome, @Email, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Usuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por usuarios: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Usuario>> ReturnListWithParameters(
                int? id,
                string nome,
                string email,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Usuarios.Where(c =>
                    (c.UsuarioId == id || id == null) &&
                    (c.Nome.Contains(nome.RemoveInjections()) || string.IsNullOrEmpty(nome.RemoveInjections())) &&
                    (c.Email.Contains(nome.RemoveInjections()) || string.IsNullOrEmpty(email.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.UsuarioId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por usuarios: " + ex.Message);
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
                throw new Exception("Houve um erro ao incluir usuarios: " + ex.Message);
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

        #region DELETE SERVIÇO DE DELETE
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