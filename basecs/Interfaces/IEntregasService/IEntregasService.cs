using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IEntregasService
{
    public interface IEntregasService
    {
        #region FIND BY ID
        Task<Entrega> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Entrega>> ReturnListWithParametersPaginated(int? id, string nmrDocumento, int? tipoDocumentoId, string nomeRecebedor, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Entrega>> ReturnListWithParameters(int? id, string nmrDocumento, int? tipoDocumentoId, string nomeRecebedor, bool? ativo);
        #endregion

        #region INSERT
        Task<Entrega> Insert(Entrega model);
        #endregion

        #region UPDATE
        Task<Entrega> Update(Entrega model);
        #endregion        

        #region DELETE
        Task<Entrega> Delete(int id);
        #endregion
    }
}
