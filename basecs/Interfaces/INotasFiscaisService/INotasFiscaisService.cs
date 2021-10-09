using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.INotasFiscaisService
{
    public interface INotasFiscaisService
    {
        #region FIND BY ID
        Task<NotaFiscal> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<NotaFiscal>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<NotaFiscal>> ReturnListWithParameters(int? id, int? tipoNotaFiscalId, string chaveAcesso, int? usuarioId, int? destinatarioId, bool? ativo);
        #endregion

        #region INSERT
        Task<NotaFiscal> Insert(NotaFiscal model);
        #endregion

        #region UPDATE
        Task<NotaFiscal> Update(NotaFiscal model);
        #endregion        

        #region DELETE
        Task<NotaFiscal> Delete(int id);
        #endregion
    }
}
