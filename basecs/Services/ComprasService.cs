using basecs.Business.Compras;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IComprasService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ComprasService : IComprasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ComprasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ComprasService(MyDbContext context)
        {
            _context = context;
            _business = new ComprasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Compra> FindById(int id)
        {
            try
            {
                return await this._context.Compras.SingleOrDefaultAsync(c => c.CompraId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Compra desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Compra>> ReturnListWithParametersPaginated(
                int? id,
                string codigoCompra,
                int? produtoId,
                int? compradorId,
                int? formaPagamentoId,
                int? statusCompraId,
                int? entregaId,
                int? lancamentoPaiId,
                int? enderecoId,
                int? garantiaId,
                int? telefoneId,
                int? vendedorId,
                int? avaliacaoId,
                bool? isPago,
                bool? isEntregue,
                bool? isAvaliado,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@CodigoCompra", string.IsNullOrEmpty(codigoCompra.RemoveInjections()) ? DBNull.Value : codigoCompra.RemoveInjections()),
                    new SqlParameter("@ProdutoId", produtoId.Equals(null) ? DBNull.Value : produtoId),
                    new SqlParameter("@CompradorId", compradorId.Equals(null) ? DBNull.Value : compradorId),
                    new SqlParameter("@FormaPagamentoId", produtoId.Equals(null) ? DBNull.Value : formaPagamentoId),
                    new SqlParameter("@StatusCompraId", statusCompraId.Equals(null) ? DBNull.Value : statusCompraId),
                    new SqlParameter("@EntregaId", entregaId.Equals(null) ? DBNull.Value : entregaId),
                    new SqlParameter("@LancamentoPaiId", entregaId.Equals(null) ? DBNull.Value : lancamentoPaiId),
                    new SqlParameter("@EnderecoId", enderecoId.Equals(null) ? DBNull.Value : enderecoId),
                    new SqlParameter("@GarantiaId", garantiaId.Equals(null) ? DBNull.Value : garantiaId),
                    new SqlParameter("@TelefoneId", telefoneId.Equals(null) ? DBNull.Value : telefoneId),
                    new SqlParameter("@VendedorId", vendedorId.Equals(null) ? DBNull.Value : vendedorId),
                    new SqlParameter("@AvaliacaoId", avaliacaoId.Equals(null) ? DBNull.Value : avaliacaoId),
                    new SqlParameter("@IsPago", isPago.Equals(null) ? DBNull.Value : isPago),
                    new SqlParameter("@IsEntregue", isEntregue.Equals(null) ? DBNull.Value : isEntregue),
                    new SqlParameter("@IsAvaliado", isAvaliado.Equals(null) ? DBNull.Value : isAvaliado),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ComprasPaginated] @Id, @CodigoCompra, @ProdutoId, @FormaPagamentoId, @StatusCompraId, @EntregaId, @LancamentoPaiId, @EnderecoId, @GarantiaId, @TelefoneId, @VendedorId, @AvaliacaoId, @IsPago, @IsEntregue, @IsAvaliado, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Compras.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Compra>> ReturnListWithParameters(
                int? id,
                string codigoCompra,
                int? produtoId,
                int? compradorId,
                int? formaPagamentoId,
                int? statusCompraId,
                int? entregaId,
                int? lancamentoPaiId,
                int? enderecoId,
                int? garantiaId,
                int? telefoneId,
                int? vendedorId,
                int? avaliacaoId,
                bool? isPago,
                bool? isEntregue,
                bool? isAvaliado,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Compras.Where(c =>
                    (c.CompraId == id || id == null) &&
                    (c.CodigoCompra.Contains(codigoCompra.RemoveInjections()) || string.IsNullOrEmpty(codigoCompra.RemoveInjections())) &&
                    (c.ProdutoId.Equals(produtoId) || !produtoId.Equals(null)) &&
                    (c.CompradorId.Equals(compradorId) || !compradorId.Equals(null)) &&
                    (c.FormaPagamentoId.Equals(formaPagamentoId) || !formaPagamentoId.Equals(null)) &&
                    (c.StatusCompraId.Equals(statusCompraId) || !statusCompraId.Equals(null)) &&
                    (c.EntregaId.Equals(entregaId) || !entregaId.Equals(null)) &&
                    (c.LancamentoPaiId.Equals(lancamentoPaiId) || !lancamentoPaiId.Equals(null)) &&
                    (c.EnderecoId.Equals(enderecoId) || !enderecoId.Equals(null)) &&
                    (c.GarantiaId.Equals(garantiaId) || !garantiaId.Equals(null)) &&
                    (c.TelefoneId.Equals(telefoneId) || !telefoneId.Equals(null)) &&
                    (c.VendedorId.Equals(vendedorId) || !vendedorId.Equals(null)) &&
                    (c.AvaliacaoId.Equals(avaliacaoId) || !avaliacaoId.Equals(null)) &&
                    (c.IsPago.Equals(isPago) || !isPago.Equals(null)) &&
                    (c.IsEntregue.Equals(isEntregue) || !isEntregue.Equals(null)) &&
                    (c.IsAvaliado.Equals(isAvaliado) || !isAvaliado.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.CompraId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos compras: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<Compra> Insert(Compra model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Compras.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos compras: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Compra> Update(Compra model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Compras.Update(model);
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
        public async Task<Compra> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Compra model = await this.FindById(id);
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
