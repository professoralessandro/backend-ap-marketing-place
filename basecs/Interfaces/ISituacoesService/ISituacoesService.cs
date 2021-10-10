using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ISituacoesService
{
    public interface ISituacoesService
    {
        #region FIND BY ID
        Task<Situacao> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Situacao>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Situacao>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Situacao> Insert(Situacao model);
        #endregion

        #region UPDATE
        Task<Situacao> Update(Situacao model);
        #endregion        

        #region DELETE
        Task<Situacao> Delete(int id);
        #endregion
    }
}
