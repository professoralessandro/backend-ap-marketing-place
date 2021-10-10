using basecs.Business.Recursos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IRecursosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class RecursosService : IRecursosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly RecursosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public RecursosService(MyDbContext context)
        {
            _context = context;
            _business = new RecursosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Recurso> FindById(int id)
        {
            try
            {
                return await this._context.Recursos.SingleOrDefaultAsync(c => c.RecursoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Recurso>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[RecursosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Recursos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Recurso>> ReturnListWithParameters(
                int? id,
                string nome, 
                string chave,
                string route,
                string type,
                string tooltip,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Recursos.Where(c =>
                    (c.RecursoId.Equals(id) || id.Equals(null)) &&
                    (c.Nome.Contains(Validators.RemoveInjections(nome)) || string.IsNullOrEmpty(Validators.RemoveInjections(nome))) &&
                    (c.Chave.Contains(Validators.RemoveInjections(chave)) || string.IsNullOrEmpty(Validators.RemoveInjections(chave))) &&
                    (c.Route.Contains(Validators.RemoveInjections(route)) || string.IsNullOrEmpty(Validators.RemoveInjections(route))) &&
                    (c.Type.Contains(Validators.RemoveInjections(type)) || string.IsNullOrEmpty(Validators.RemoveInjections(type))) &&
                    (c.ToolTip.Contains(Validators.RemoveInjections(tooltip)) || string.IsNullOrEmpty(Validators.RemoveInjections(tooltip))) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.RecursoId)
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
        public async Task<Recurso> Insert(Recurso model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Recursos.Add(model);
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
        public async Task<Recurso> Update(Recurso model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Recursos.Update(model);
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
        public async Task<Recurso> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Recurso model = await this.FindById(id);
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
