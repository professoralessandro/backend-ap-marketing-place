using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using basecs.Models;

namespace basecs.Interfaces.Repository.Produto
{
    public interface IProdutoRepository
    {
        #region FIND BY ID
        Task<ProdutoDto> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<IEnumerable<ProdutoDto>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region INSERT
        Task<int> Insert(ProdutoDto model);
        #endregion

        #region UPDATE
        Task<int> Update(ProdutoDto model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<int> Delete(Guid id);
        #endregion
    }
}
