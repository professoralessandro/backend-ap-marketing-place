using basecs.Dtos.Checkout.Request;
using basecs.Enuns;
using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.IComprasService
{
    public interface IComprasService
    {
        #region FIND BY ID
        Task<Compra> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Compra>> ReturnListWithParametersPaginated(
            Guid? id,
            string codigoCompra,
            int? produtoId,
            int? compradorId,
            FormaPagamentoEnum? formaPagamento,
            StatusCompraEnum? statusCompra,
            int? entregaId,
            int? lancamentoPaiId,
            int? enderecoId,
            int? garantiaId,
            int? vendedorId,
            int? avaliacaoId,
            bool? isPago,
            bool? isEntregue,
            bool? isAvaliado,
            bool? ativo,
            int? pageNumber,
            int? rowspPage
            );
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Compra>> ReturnListWithParameters(
            Guid? id,
            string codigoCompra,
            int? produtoId,
            int? compradorId,
            FormaPagamentoEnum? formaPagamento,
            StatusCompraEnum? statusCompra,
            int? entregaId,
            int? lancamentoPaiId,
            int? enderecoId,
            int? garantiaId,
            int? vendedorId,
            int? avaliacaoId,
            bool? isPago,
            bool? isEntregue,
            bool? isAvaliado,
            bool? ativo
            );
        #endregion

        #region INSERT
        Task<Compra> Insert(Compra model);
        #endregion

        #region UPDATE
        Task<Compra> Update(Compra model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Compra> Delete(Guid id);
        #endregion

        #region CHECKOUT
        Task<string> Checkout(PaymentCreateRequest model);
        #endregion
    }
}
