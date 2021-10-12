using basecs.Business.BloqueiosUsuarios;
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
    public class BloqueiosUsuariosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly BloqueiosUsuariosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public BloqueiosUsuariosService(MyDbContext context)
        {
            _context = context;
            _business = new BloqueiosUsuariosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<BloqueioUsuario> FindById(int id)
        {
            try
            {
                return await this._context.BloqueiosUsuarios.SingleOrDefaultAsync(c => c.BloqueioUsuarioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<BloqueioUsuario>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[BloqueiosUsuariosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.BloqueiosUsuarios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<BloqueioUsuario>> ReturnListWithParameters(
                int? id,
                int? avaliacaoId,
                int? produtoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.BloqueiosUsuarios.Where(c =>
                    (c.BloqueioUsuarioId == id || id == null) &&
                    (c.BloqueioId == avaliacaoId || avaliacaoId == null) &&
                    (c.UsuarioId == produtoId || produtoId == null)
                    ).OrderByDescending(x => x.BloqueioUsuarioId)
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
        public async Task<BloqueioUsuario> Insert(BloqueioUsuario model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.BloqueiosUsuarios.Add(model);
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
        public async Task<BloqueioUsuario> Update(BloqueioUsuario model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.BloqueiosUsuarios.Update(model);
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
        public async Task<BloqueioUsuario> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    BloqueioUsuario model = await this.FindById(id);
                    this._context.BloqueiosUsuarios.Remove(model);
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
