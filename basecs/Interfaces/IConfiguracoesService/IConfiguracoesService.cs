using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IConfiguracoesService
{
    public interface IConfiguracoesService
    {
        #region FIND BY ID
        Task<Configuracao> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Configuracao>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Configuracao>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Configuracao> Insert(Configuracao model);
        #endregion

        #region UPDATE
        Task<Configuracao> Update(Configuracao model);
        #endregion        

        #region DELETE
        Task<Configuracao> Delete(int id);
        #endregion
    }
}
