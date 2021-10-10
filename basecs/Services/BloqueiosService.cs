using basecs.Business.Bloqueios;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IBloqueiosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class BloqueiosService : IBloqueiosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly BloqueiosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public BloqueiosService(MyDbContext context)
        {
            _context = context;
            _business = new BloqueiosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Bloqueio> FindById(int id)
        {
            try
            {
                return await this._context.Bloqueios.SingleOrDefaultAsync(c => c.BloqueioId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Bloqueio>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[BloqueiosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Bloqueios.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Bloqueio>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool isBloqueiaAcesso,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Bloqueios.Where(c =>
                    (c.BloqueioId.Equals(id) || id.Equals(null)) &&
                    (c.NomeBloqueio.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.IsBloqueiaAcesso.Equals(isBloqueiaAcesso) || isBloqueiaAcesso.Equals(null)) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.BloqueioId)
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
        public async Task<Bloqueio> Insert(Bloqueio model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Bloqueios.Add(model);
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
        public async Task<Bloqueio> Update(Bloqueio model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Bloqueios.Update(model);
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
        public async Task<Bloqueio> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Bloqueio model = await this.FindById(id);
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
