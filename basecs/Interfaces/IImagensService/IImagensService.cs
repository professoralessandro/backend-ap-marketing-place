using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IImagensService
{
    public interface IImagensService
    {
        #region FIND BY ID
        Task<Imagem> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Imagem>> ReturnListWithParametersPaginated(int? id, string titulo, bool? imagemPrincipal, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Imagem>> ReturnListWithParameters(int? id, string titulo, bool? imagemPrincipal);
        #endregion

        #region INSERT
        Task<Imagem> Insert(Imagem model);
        #endregion

        #region UPDATE
        Task<Imagem> Update(Imagem model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Imagem> Delete(int id);
        #endregion
    }
}
