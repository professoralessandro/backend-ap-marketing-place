using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.IAvaliacoesService
{
    public interface IProdutoService
    {
        #region FIND BY ID
        Task<Produto> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Produto>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Produto>> ReturnListWithParameters(Guid? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Produto> Insert(Produto model);
        #endregion

        #region UPDATE
        Task<Produto> Update(Produto model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Produto> Delete(Guid id);
        #endregion
    }
}
