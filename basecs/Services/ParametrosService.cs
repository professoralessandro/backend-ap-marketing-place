using basecs.Business.Parametros;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IParametrosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ParametrosService : IParametrosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ParametrosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ParametrosService(MyDbContext context)
        {
            _context = context;
            _business = new ParametrosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Parametro> FindById(int id)
        {
            try
            {
                return await this._context.Parametros.SingleOrDefaultAsync(c => c.ParametroId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Parametro>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[ParametrosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Parametros.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Parametro>> ReturnListWithParameters(
                int? id,
                int? tipoParametroId,
                int? tipoDadoId,
                string descricao,
                string valor,
                bool? publico,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Parametros.Where(c =>
                    (c.ParametroId.Equals(id) || id.Equals(null)) &&
                    (c.TipoParametroId.Equals(tipoParametroId) || tipoParametroId.Equals(null)) &&
                    (c.TipoDadoId.Equals(tipoDadoId) || tipoDadoId.Equals(null)) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Valor.Contains(Validators.RemoveInjections(valor)) || string.IsNullOrEmpty(Validators.RemoveInjections(valor))) &&
                    (c.Publico.Equals(publico) || publico.Equals(null)) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(ativo))
                    ).OrderByDescending(x => x.ParametroId)
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
        public async Task<Parametro> Insert(Parametro model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Parametros.Add(model);
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
        public async Task<Parametro> Update(Parametro model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Parametros.Update(model);
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
        public async Task<Parametro> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Parametro model = await this.FindById(id);
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
