using basecs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Interfaces.ILancamentos
{
    interface ILancamentos
    {
        #region FIND BY ID
        Task<Lancamento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Lancamento>> ReturnListWithParametersPaginated(int? id, string titulo, bool? imagemPrincipal, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Lancamento>> ReturnListWithParameters(int? id, string titulo, bool? imagemPrincipal);
        #endregion

        #region INSERT
        Task<Lancamento> Insert(Lancamento model);
        #endregion

        #region UPDATE
        Task<Lancamento> Update(Lancamento model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Lancamento> Delete(int id);
        #endregion
    }
}
