using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.Garantias;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IGarantiasService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class GarantiasService : IGarantiasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly GarantiasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public GarantiasService(MyDbContext context)
        {
            _context = context;
            _business = new GarantiasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Garantia> FindById(int id)
        {
            try
            {
                return await this._context.Garantias.SingleOrDefaultAsync(c => c.GarantiaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registro :" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Garantia>> ReturnListWithParametersPaginated(
                int? id,
                string descricao,
                DateTime? inicio,
                DateTime? fim,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(Validators.RemoveInjections(descricao)) ? DBNull.Value : Validators.RemoveInjections(descricao)),
                    new SqlParameter("@Inicio", inicio.Equals(null) ? DBNull.Value : inicio),
                    new SqlParameter("@Fim", fim.Equals(null) ? DBNull.Value : fim),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[GarantiasPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                { 
                    return await context.Garantias.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Garantia>> ReturnListWithParameters(
                int? id,
                string descricao,
                DateTime? inicio,
                DateTime? fim,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await _context.Garantias.Where(c =>
                    (c.GarantiaId.Equals(id) || id.Equals(null)) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.Inicio >= inicio || inicio.Equals(null)) &&
                    (c.Fim >= fim || fim.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<Garantia> Insert(Garantia model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Garantias.Add(model);
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
                throw new Exception("Houve um erro ao incluir o registro :" + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Garantia> Update(Garantia model)
        {
            string validationMessage = _business.UpdateValidation(model);

            if (validationMessage.Equals(""))
            {
                this._context.Garantias.Update(model);
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
        public async Task<Garantia> Delete(int id)
        {
            string validationMessage = _business.DeleteValidation(id);

            if (validationMessage.Equals(""))
            {
                Garantia model = await this.FindById(id);
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