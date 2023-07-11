using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Services.ILogsService;
using basecs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class LogsService : ILogsService
    {
        #region ATRIBUTTES
        private MyDbContext _context;
        #endregion

        #region CONTRUCTORS
        public LogsService(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        #region FIND BY ID
        public async Task<Log> FindById(int id)
        {
            try
            {
                return await this._context.Logs.SingleOrDefaultAsync(c => c.LogId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Log desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Log>> ReturnListWithParametersPaginated(
                string param,
                DateTime? dateAdded,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Param", string.IsNullOrEmpty(param.RemoveInjections()) ? DBNull.Value : param.RemoveInjections()),
                    new SqlParameter("@DateAdded", dateAdded.Equals(null) ? DBNull.Value : dateAdded),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[log].[LogsPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Logs.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Log>> ReturnListWithParameters(
                long? id,
                string request,
                string method,
                int? userAddedId,
                DateTime? dateAdded
            )
        {
            try
            {
                List<Log> lstRetorno = await _context.Logs.Where(c =>
                    (c.LogId == id || id == null) &&
                    (c.Request.Contains(request.RemoveInjections()) || string.IsNullOrEmpty(request.RemoveInjections())) &&
                    (c.Method.Contains(method.RemoveInjections()) || string.IsNullOrEmpty(method.RemoveInjections())) &&
                    (c.UserAddedId == userAddedId || userAddedId == null) &&
                    (c.DateAdded == dateAdded || dateAdded == null)
                    ).ToListAsync();
                return lstRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Logs: " + ex.Message);
            }

        }
        #endregion

        #region CREATE
        public async Task<Log> Create(HttpRequest request, HttpResponse response, string message, int userId = 1)
        {
            try
            {
                var model = new Log
                {
                    Method = request.Method.ToString(),
                    Request = $"{request.Scheme}://{request.Host.ToString()}{request.Path.ToString()}",
                    Response = response.StatusCode,
                    Message = message,
                    UserAddedId = userId,
                    DateAdded = DateTime.Now
                };

                using (var context = this._context)
                {
                    context.Logs.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Enderecos desejada: " + ex.Message);
            }
        }
        #endregion
    }
}