using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.TiposGarantias;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposGarantiasService;

namespace basecs.Services
{
    public class TiposGarantiasService : ITiposGarantiasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposGarantiasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposGarantiasService(MyDbContext context)
        {
            _context = context;
            _business = new TiposGarantiasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoGarantia> FindById(int id)
        {
            try
            {
                return await this._context.TiposGarantias.SingleOrDefaultAsync(c => c.TipoGarantiaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o TipoGarantia desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoGarantia>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[TiposGarantiasPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposGarantias.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos bloqueios: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoGarantia>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposGarantias.Where(c =>
                    (c.TipoGarantiaId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.TipoGarantiaId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<TipoGarantia> Insert(TipoGarantia model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposGarantias.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoGarantia> Update(TipoGarantia model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposGarantias.Update(model);
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
        public async Task<TipoGarantia> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoGarantia model = await this.FindById(id);
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