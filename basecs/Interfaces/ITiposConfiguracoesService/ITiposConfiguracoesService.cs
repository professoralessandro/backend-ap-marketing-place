using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposConfiguracoesService
{
    public interface ITiposConfiguracoesService
    {
        #region FIND BY ID
        Task<TipoConfiguracao> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoConfiguracao>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoConfiguracao>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoConfiguracao> Insert(TipoConfiguracao model);
        #endregion

        #region UPDATE
        Task<TipoConfiguracao> Update(TipoConfiguracao model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<TipoConfiguracao> Delete(int id);
        #endregion
    }
}
