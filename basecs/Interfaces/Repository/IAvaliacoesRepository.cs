﻿using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace basecs.Interfaces.Repository
{
    public interface IAvaliacoesRepository
    {
        #region FIND BY ID
        Task<Avaliacao> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Avaliacao>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Avaliacao>> ReturnListWithParameters(Guid? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Avaliacao> Insert(Avaliacao model);
        #endregion

        #region UPDATE
        Task<Avaliacao> Update(Avaliacao model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Avaliacao> Delete(Guid id);
        #endregion
    }
}