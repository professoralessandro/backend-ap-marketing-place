using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IStatusAprovacaosService
{
    public interface IStatusAprovacaosService
    {
        #region FIND BY ID
        Task<StatusAprovacao> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<StatusAprovacao>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<StatusAprovacao>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<StatusAprovacao> Insert(StatusAprovacao model);
        #endregion

        #region UPDATE
        Task<StatusAprovacao> Update(StatusAprovacao model);
        #endregion        

        #region DELETE
        Task<StatusAprovacao> Delete(int id);
        #endregion
    }
}
