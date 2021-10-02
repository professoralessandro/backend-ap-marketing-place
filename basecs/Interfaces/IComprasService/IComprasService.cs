
using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IComprasService
{
    public interface IComprasService
    {
        #region FIND BY ID
        Task<Compra> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Compra>> ReturnListWithParametersPaginated(
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
            );
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Compra>> ReturnListWithParameters(
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
            );
        #endregion

        #region INSERT
        Task<Compra> Insert(Compra model);
        #endregion

        #region UPDATE
        Task<Compra> Update(Compra model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Compra> Delete(int id);
        #endregion
    }
}
