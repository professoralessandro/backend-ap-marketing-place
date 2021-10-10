using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IGruposService
{
    public interface IGruposService
    {
        #region FIND BY ID
        Task<Grupo> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Grupo>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Grupo>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Grupo> Insert(Grupo model);
        #endregion

        #region UPDATE
        Task<Grupo> Update(Grupo model);
        #endregion        

        #region DELETE
        Task<Grupo> Delete(int id);
        #endregion
    }
}
