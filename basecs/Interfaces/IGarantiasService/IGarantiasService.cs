using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IGarantiasService
{
    public interface IGarantiasService
    {
        #region FIND BY ID
        Task<Garantia> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Garantia>> ReturnListWithParametersPaginated(int? id, string descricao, DateTime inicio, DateTime fim, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Garantia>> ReturnListWithParameters(int? id, string descricao, DateTime inicio, DateTime fim, bool? ativo);
        #endregion

        #region INSERT
        Task<Garantia> Insert(Garantia model);
        #endregion

        #region UPDATE
        Task<Garantia> Update(Garantia model);
        #endregion        

        #region DELETE
        Task<Garantia> Delete(int id);
        #endregion
    }
}
