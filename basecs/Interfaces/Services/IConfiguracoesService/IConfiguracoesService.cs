using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.IConfiguracoesService
{
    public interface IConfiguracoesService
    {
        #region FIND BY ID
        Task<Configuracao> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Configuracao>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Configuracao>> ReturnListWithParameters(Guid? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Configuracao> Insert(Configuracao model);
        #endregion

        #region UPDATE
        Task<Configuracao> Update(Configuracao model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Configuracao> Delete(Guid id);
        #endregion
    }
}
