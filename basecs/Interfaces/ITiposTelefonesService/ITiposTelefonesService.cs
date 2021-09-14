using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposTelefonesService
{
    public interface ITiposTelefonesService
    {
        #region FIND BY ID
        Task<TipoTelefone> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoTelefone>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoTelefone>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoTelefone> Insert(TipoTelefone model);
        #endregion

        #region UPDATE
        Task<TipoTelefone> Update(TipoTelefone model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE COMENTADO
        Task<TipoTelefone> Delete(int id);
        #endregion
    }
}
