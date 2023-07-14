using basecs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.ILogsService
{
    public interface ILogsService
    {
        #region FIND BY ID
        Task<Log> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Log>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Log>> ReturnListWithParameters(Guid? id, string request, string method, Guid? userAddedId, DateTime? dateAdded);
        #endregion

        #region CREATE
        Task<Log> Create(HttpRequest request, HttpResponse response, string message, string userId = "00000000-0000-0000-0000-000000000000");
        #endregion
    }
}
