using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IRecursosService
{
    interface IRecursosService
    {
        #region FIND BY ID
        Task<Recurso> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Recurso>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Recurso>> ReturnListWithParameters(int? id, string nome, string chave, string route, string type, string tooltip, bool? ativo);
        #endregion

        #region INSERT
        Task<Recurso> Insert(Recurso model);
        #endregion

        #region UPDATE
        Task<Recurso> Update(Recurso model);
        #endregion        

        #region DELETE
        Task<Recurso> Delete(int id);
        #endregion
    }
}
