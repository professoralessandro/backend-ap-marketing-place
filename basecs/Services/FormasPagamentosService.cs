using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.FormasPagamentos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IFormasPagamentosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class FormasPagamentosService : IFormasPagamentosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly FormasPagamentosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public FormasPagamentosService(MyDbContext context)
        {
            _context = context;
            _business = new FormasPagamentosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<FormaPagamento> FindById(int id)
        {
            try
            {
                return await this._context.FormasPagamentos.SingleOrDefaultAsync(c => c.FormaPagamentoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registro :" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<FormaPagamento>> ReturnListWithParametersPaginated(
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
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(Validators.RemoveInjections(descricao)) ? DBNull.Value : Validators.RemoveInjections(descricao)),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[FormasPagamentosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                { 
                    return await context.FormasPagamentos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<FormaPagamento>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await _context.FormasPagamentos.Where(c =>
                    (c.FormaPagamentoId == id || id == null) &&
                    (c.Descricao.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
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
        public async Task<FormaPagamento> Insert(FormaPagamento model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.FormasPagamentos.Add(model);
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
        public async Task<FormaPagamento> Update(FormaPagamento model)
        {
            string validationMessage = _business.UpdateValidation(model);

            if (validationMessage.Equals(""))
            {
                this._context.FormasPagamentos.Update(model);
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
        public async Task<FormaPagamento> Delete(int id)
        {
            string validationMessage = _business.DeleteValidation(id);

            if (validationMessage.Equals(""))
            {
                FormaPagamento model = await this.FindById(id);
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