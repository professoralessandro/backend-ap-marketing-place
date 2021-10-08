using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IProdutosService
{
    public interface IProdutosService
    {
        #region FIND BY ID
        Task<Produto> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Produto>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Produto>> ReturnListWithParameters(int? id, int? tipoProdutoId, string descricao, string codigoBarras, string marca, decimal? preco, bool? ativo);
        #endregion

        #region INSERT
        Task<Produto> Insert(Produto model);
        #endregion

        #region UPDATE
        Task<Produto> Update(Produto model);
        #endregion        

        #region DELETE
        Task<Produto> Delete(int id);
        #endregion
    }
}
