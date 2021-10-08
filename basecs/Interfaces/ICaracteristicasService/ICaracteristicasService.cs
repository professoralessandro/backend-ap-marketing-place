
using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ICaracteristicasService
{
    public interface ICaracteristicasService
    {
        #region FIND BY ID
        Task<Caracteristica> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Caracteristica>> ReturnListWithParametersPaginated(int? id, string descricao, int? tipoCaracteristicaId, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Caracteristica>> ReturnListWithParameters(int? id, string descricao, int? tipoCaracteristicaId, bool? ativo);
        #endregion

        #region INSERT
        Task<Caracteristica> Insert(Caracteristica model);
        #endregion

        #region UPDATE
        Task<Caracteristica> Update(Caracteristica model);
        #endregion        

        #region DELETE
        Task<Caracteristica> Delete(int id);
        #endregion
    }
}
