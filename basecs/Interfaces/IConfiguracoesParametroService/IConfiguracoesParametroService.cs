

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IConfiguracoesParametroService
{
    public interface IConfiguracoesParametroService
    {
        #region FIND BY ID
        Task<ConfiguracaoParametro> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<ConfiguracaoParametro>> ReturnListWithParametersPaginated(int? id, int? configuracaoId, int? parametroId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<ConfiguracaoParametro>> ReturnListWithParameters(int? id, int? configuracaoId, int? parametroId);
        #endregion

        #region INSERT
        Task<ConfiguracaoParametro> Insert(ConfiguracaoParametro model);
        #endregion

        #region UPDATE
        Task<ConfiguracaoParametro> Update(ConfiguracaoParametro model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<ConfiguracaoParametro> Delete(int id);
        #endregion
    }
}
