using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.TiposCaracteristicas;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposCaracteristicasService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TiposCaracteristicasService : ITiposCaracteristicasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposCaracteristicasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposCaracteristicasService(MyDbContext context)
        {
            _context = context;
            _business = new TiposCaracteristicasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoCaracteristica> FindById(int id)
        {
            try
            {
                return await this._context.TiposCaracteristicas.SingleOrDefaultAsync(c => c.TipoCaracteristicaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar os Tipos Caracteristicas desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoCaracteristica>> ReturnListWithParametersPaginated(
                int? id,
                string descricao,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(descricao.RemoveInjections()) ? DBNull.Value : descricao.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TiposCaracteristicasPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                { 
                    return await context.TiposCaracteristicas.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por TipoCaracteristica: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoCaracteristica>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await _context.TiposCaracteristicas.Where(c =>
                    (c.TipoCaracteristicaId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por TipoCaracteristica: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<TipoCaracteristica> Insert(TipoCaracteristica model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposCaracteristicas.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos caracteristicas: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoCaracteristica> Update(TipoCaracteristica model)
        {
            string validationMessage = _business.UpdateValidation(model);

            if (validationMessage.Equals(""))
            {
                this._context.TiposCaracteristicas.Update(model);
                await this._context.SaveChangesAsync();
                return model;
            }
            else
            {
                throw new Exception(validationMessage);
            }
        }
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        public async Task<TipoCaracteristica> Delete(int id)
        {
            string validationMessage = _business.DeleteValidation(id);

            if (validationMessage.Equals(""))
            {
                TipoCaracteristica model = await this.FindById(id);
                model.Ativo = false;
                await this.Update(model);
                return model;
            }
            else
            {
                throw new Exception(validationMessage);
            }
        }
        #endregion
    }
}