using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IGruposRecursosService
{
    public interface IGruposRecursosService
    {
        #region FIND BY ID
        Task<GrupoRecurso> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<GrupoRecurso>> ReturnListWithParametersPaginated(
                int? id,
                int? grupoId,
                int? recursoId,
                int? pageNumber,
                int? rowspPage
            );
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<GrupoRecurso>> ReturnListWithParameters(
                int? id,
                int? grupoId,
                int? recursoId
            );
        #endregion

        #region INSERT
        Task<GrupoRecurso> Insert(GrupoRecurso model);
        #endregion

        #region UPDATE
        Task<GrupoRecurso> Update(GrupoRecurso model);
        #endregion        

        #region DELETE
        Task<GrupoRecurso> Delete(int id);
        #endregion
    }
}
