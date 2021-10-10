using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IParametrosService
{
    interface IParametrosService
    {
        #region FIND BY ID
        Task<Parametro> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Parametro>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Parametro>> ReturnListWithParameters(int? id, int? tipoParametroId, int? tipoDadoId, string Descricao, string Valor, bool? publico, bool? ativo);
        #endregion

        #region INSERT
        Task<Parametro> Insert(Parametro model);
        #endregion

        #region UPDATE
        Task<Parametro> Update(Parametro model);
        #endregion        

        #region DELETE
        Task<Parametro> Delete(int id);
        #endregion
    }
}
