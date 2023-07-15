using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Services.IUsuariosService;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using basecs.Dtos.Usuarios;
using basecs.Interfaces.Repository;
using System.ComponentModel.DataAnnotations;

namespace basecs.Services
{
    public class UsuariosService : IUsuariosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly IUsuariosBusiness _business;
        private readonly IUsuariosRepository _repository;
        #endregion

        #region CONTRUCTORS
        public UsuariosService(MyDbContext context, IUsuariosBusiness business, IUsuariosRepository repository)
        {
            _context = context;
            _business = business;
            _repository = repository;
        }
        #endregion

        #region FIND BY ID
        public async Task<Usuario> FindById(Guid id)
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
                Guid? id,
                string nome,
                string nmrDocumento,
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
                    new SqlParameter("@NmrDocumento", string.IsNullOrEmpty(nmrDocumento.RemoveInjections()) ? DBNull.Value : nmrDocumento.RemoveInjections()),
                    new SqlParameter("@Email", string.IsNullOrEmpty(email.RemoveInjections()) ? DBNull.Value : email.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[seg].[UsuariosPaginated] @Id, @Nome, @NmrDocumento, @Email, @Ativo, @PageNumber, @RowspPage";

                return await this._context.Usuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por usuarios: " + ex.Message);
            }
        }
        public async Task<IEnumerable<UsuarioDto>> ReturnUsersWithParametersPaginated(Guid? id, string nome, string nmrDocumento, string email, bool? ativo, int? pageNumber, int? rowspPage)
        {
            try
            {
                return await _repository.ReturnUsersWithParametersPaginated(id, nome, nmrDocumento, email, ativo, pageNumber, rowspPage);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por usuarios: " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Usuario>> ReturnListWithParameters(
                Guid? id,
                string nome,
                string nmrDocumento,
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
                    (c.NmrDocumento.Contains(nmrDocumento.RemoveInjections()) || string.IsNullOrEmpty(nmrDocumento.RemoveInjections())) &&
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
        public async Task<int> Insert(InsertUserDto model)
        {
            try
            {
                string validationMessage = await _business.InsertValidation(model, this);

                if (validationMessage.Equals(""))
                {
                    return await _repository.InsertUserAsync(model);
                }
                else
                {
                    throw new ValidationException(validationMessage);
                }
            }
            catch (ValidationException ex)
            {
                throw new Exception("Houve um erro ao validar o usuario:\n" + ex.Message);
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

        #region DELETE
        public async Task<Usuario> Delete(Guid id)
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