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
        Task<Log> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Log>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Log>> ReturnListWithParameters(long? id, string request, string method, int? userAddedId, DateTime? dateAdded);
        #endregion

        #region CREATE
        Task<Log> Create(HttpRequest request, HttpResponse response, string message, int userId = 1);
        #endregion
    }
}
