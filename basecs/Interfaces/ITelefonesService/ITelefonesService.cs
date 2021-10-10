﻿using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITelefonesService
{
    public interface ITelefonesService
    {
        #region FIND BY ID
        Task<Telefone> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Telefone>> ReturnListWithParametersPaginated(int? id, int? tipoTelefoneId, string telefone, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Telefone>> ReturnListWithParameters(int? id, int? tipoTelefoneId, string telefone, bool? ativo);
        #endregion

        #region INSERT
        Task<Telefone> Insert(Telefone model);
        #endregion

        #region UPDATE
        Task<Telefone> Update(Telefone model);
        #endregion        

        #region DELETE
        Task<Telefone> Delete(int id);
        #endregion
    }
}