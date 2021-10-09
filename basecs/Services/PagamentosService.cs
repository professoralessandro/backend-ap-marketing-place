using basecs.Business.Pagamentos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IPagamentosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class PagamentosService : IPagamentosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly PagamentosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public PagamentosService(MyDbContext context)
        {
            _context = context;
            _business = new PagamentosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Pagamento> FindById(int id)
        {
            try
            {
                return await this._context.Pagamentos.SingleOrDefaultAsync(c => c.PagamentoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Pagamento>> ReturnListWithParametersPaginated(
                int? id,
                int? lancamentoId,
                string codigoPagamento,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@LancamentoId", lancamentoId.Equals(null) ? DBNull.Value : lancamentoId),
                    new SqlParameter("@CodigoPagamento", string.IsNullOrEmpty(Validators.RemoveInjections(codigoPagamento)) ? DBNull.Value : codigoPagamento),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[PagamentosPaginated] @id, @LancamentoId, @DateAdded, @CodigoPagamento, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Pagamentos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Pagamento>> ReturnListWithParameters(
                int? id,
                int? lancamentoId,
                string codigoPagamento,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Pagamentos.Where(c =>
                    (c.PagamentoId == id || id == null) &&
                    (c.LancamentoId == lancamentoId || lancamentoId == null) &&
                    (c.CodigoPagamento.Contains(Validators.RemoveInjections(codigoPagamento)) || string.IsNullOrEmpty(Validators.RemoveInjections(codigoPagamento))) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.PagamentoId)
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
        public async Task<Pagamento> Insert(Pagamento model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Pagamentos.Add(model);
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
        public async Task<Pagamento> Update(Pagamento model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Pagamentos.Update(model);
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
        public async Task<Pagamento> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Pagamento model = await this.FindById(id);
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
