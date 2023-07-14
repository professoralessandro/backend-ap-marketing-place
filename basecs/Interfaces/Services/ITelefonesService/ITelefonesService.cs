﻿using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.ITelefonesService
{
    public interface ITelefonesService
    {
        #region FIND BY ID
        Task<Telefone> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Telefone>> ReturnListWithParametersPaginated(Guid? id, string numero, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Telefone>> ReturnListWithParameters(Guid? id, string numero, bool? ativo);
        #endregion

        #region INSERT
        Task<Telefone> Insert(Telefone model);
        #endregion

        #region UPDATE
        Task<Telefone> Update(Telefone model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Telefone> Delete(Guid id);
        #endregion
    }
}
