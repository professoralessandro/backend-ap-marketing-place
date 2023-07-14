﻿using basecs.Enuns;
using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.ICaracteristicasService
{
    public interface ICaracteristicasService
    {
        #region FIND BY ID
        Task<Caracteristica> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Caracteristica>> ReturnListWithParametersPaginated(Guid? id, string descricao, TipoCaracteristicaEnum? tipoCaracteristica, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Caracteristica>> ReturnListWithParameters(Guid? id, string descricao, TipoCaracteristicaEnum? tipoCaracteristica, bool? ativo);
        #endregion

        #region INSERT
        Task<Caracteristica> Insert(Caracteristica model);
        #endregion

        #region UPDATE
        Task<Caracteristica> Update(Caracteristica model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Caracteristica> Delete(Guid id);
        #endregion
    }
}
