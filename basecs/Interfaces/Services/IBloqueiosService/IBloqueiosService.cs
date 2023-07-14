using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.IBloqueiosService
{
    public interface IBloqueiosService
    {
        #region FIND BY ID
        Task<Bloqueio> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Bloqueio>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Bloqueio>> ReturnListWithParameters(Guid? id, string descricao,bool isBloqueiaAcesso, bool? ativo);
        #endregion

        #region INSERT
        Task<Bloqueio> Insert(Bloqueio model);
        #endregion

        #region UPDATE
        Task<Bloqueio> Update(Bloqueio model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Bloqueio> Delete(Guid id);
        #endregion
    }
}
