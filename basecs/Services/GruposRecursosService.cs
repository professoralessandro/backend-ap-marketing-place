using basecs.Business.GruposRecursos;
using basecs.Data;
using basecs.Interfaces.IGruposRecursosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class GruposRecursosService : IGruposRecursosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly GruposRecursosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public GruposRecursosService(MyDbContext context)
        {
            _context = context;
            _business = new GruposRecursosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<GrupoRecurso> FindById(int id)
        {
            try
            {
                return await this._context.GruposRecursos.SingleOrDefaultAsync(c => c.GrupoRecursoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<GrupoRecurso>> ReturnListWithParametersPaginated(
                int? id,
                int? grupoId,
                int? recursoId,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@GrupoId", grupoId.Equals(null) ? DBNull.Value : grupoId),
                    new SqlParameter("@RecursoId", recursoId.Equals(null) ? DBNull.Value : recursoId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[GruposRecursosPaginated] @Id, @EnderecoId, @UsuarioId, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.GruposRecursos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<GrupoRecurso>> ReturnListWithParameters(
                int? id,
                int? grupoId,
                int? recursoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.GruposRecursos.Where(c =>
                    (c.GrupoRecursoId == id || id == null) &&
                    (c.GrupoId == grupoId || grupoId == null) &&
                    (c.RecursoId == recursoId || recursoId == null)
                    ).OrderByDescending(x => x.GrupoRecursoId)
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
        public async Task<GrupoRecurso> Insert(GrupoRecurso model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.GruposRecursos.Add(model);
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
        public async Task<GrupoRecurso> Update(GrupoRecurso model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.GruposRecursos.Update(model);
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
        public async Task<GrupoRecurso> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    GrupoRecurso model = await this.FindById(id);
                    this._context.GruposRecursos.Remove(model);
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
