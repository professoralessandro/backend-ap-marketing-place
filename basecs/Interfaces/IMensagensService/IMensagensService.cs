using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IMensagensService
{
    public interface IMensagensService
    {
        #region FIND BY ID
        Task<Mensagem> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Mensagem>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Mensagem>> ReturnListWithParameters(int? id, int? remetenteId, int? tipoMensagemId, int? destinatarioId, bool? ativo);
        #endregion

        #region INSERT
        Task<Mensagem> Insert(Mensagem model);
        #endregion

        #region UPDATE
        Task<Mensagem> Update(Mensagem model);
        #endregion        

        #region DELETE
        Task<Mensagem> Delete(int id);
        #endregion
    }
}
