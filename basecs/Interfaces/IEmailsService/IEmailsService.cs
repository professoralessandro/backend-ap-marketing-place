using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IEmailsService
{
    public interface IEmailsService
    {
        #region FIND BY ID
        Task<Email> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Email>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Email>> ReturnListWithParameters(int? id, string nomeEmail, int? tipoEmailId, string destinatario, string assunto, int? statusEnvio, bool? ativo);
        #endregion

        #region INSERT
        Task<Email> Insert(Email model);
        #endregion

        #region UPDATE
        Task<Email> Update(Email model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Email> Delete(int id);
        #endregion
    }
}
