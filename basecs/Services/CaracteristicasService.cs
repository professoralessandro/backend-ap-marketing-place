using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.Caracteristicas;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ICaracteristicasService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class CaracteristicasService : ICaracteristicasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly CaracteristicasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public CaracteristicasService(MyDbContext context)
        {
            _context = context;
            _business = new CaracteristicasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Caracteristica> FindById(int id)
        {
            try
            {
                return await this._context.Caracteristicas.SingleOrDefaultAsync(c => c.CaracteristicaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar as caracteristicas desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Caracteristica>> ReturnListWithParametersPaginated(
                int? id,
                string descricao,
                int? tipoCaracteristicaId,
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
                    new SqlParameter("@TipoCaracteristicaId", tipoCaracteristicaId.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[CaracteristicasPaginated] @Id, @Descricao, TipoCaracteristicaId, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Caracteristicas.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por caracteristica: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Caracteristica>> ReturnListWithParameters(
                int? id,
                string descricao,
                int? tipoCaracteristicaId,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await _context.Caracteristicas.Where(c =>
                    (c.CaracteristicaId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.TipoCaracteristicaId == tipoCaracteristicaId || tipoCaracteristicaId == null) &&
                    (c.Ativo == ativo || ativo == null)
                    ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por caracteristica: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<Caracteristica> Insert(Caracteristica model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Caracteristicas.Add(model);
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
                throw new Exception("Houve um erro ao incluir caracteristicas: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Caracteristica> Update(Caracteristica model)
        {
            string validationMessage = _business.UpdateValidation(model);

            if (validationMessage.Equals(""))
            {
                this._context.Caracteristicas.Update(model);
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
        public async Task<Caracteristica> Delete(int id)
        {
            string validationMessage = _business.DeleteValidation(id);

            if (validationMessage.Equals(""))
            {
                Caracteristica model = await this.FindById(id);
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