using basecs.Business.ConfiguracoesParametros;
using basecs.Data;
using basecs.Interfaces.IConfiguracoesParametroService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class ConfiguracoesParametrosService : IConfiguracoesParametrosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly ConfiguracoesParametrosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public ConfiguracoesParametrosService(MyDbContext context)
        {
            _context = context;
            _business = new ConfiguracoesParametrosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<ConfiguracaoParametro> FindById(int id)
        {
            try
            {
                return await this._context.ConfiguracoesParametros.SingleOrDefaultAsync(c => c.ConfiguracaoParametroId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<ConfiguracaoParametro>> ReturnListWithParametersPaginated(
                int? id,
                int? configuracaoId,
                int? parametroId,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@ConfiguracaoId", configuracaoId.Equals(null) ? DBNull.Value : configuracaoId),
                    new SqlParameter("@ParametroId", parametroId.Equals(null) ? DBNull.Value : parametroId),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ConfiguracoesParametrosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.ConfiguracoesParametros.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<ConfiguracaoParametro>> ReturnListWithParameters(
                int? id,
                int? configuracaoId,
                int? parametroId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.ConfiguracoesParametros.Where(c =>
                    (c.ConfiguracaoParametroId == id || id == null) &&
                    (c.ConfiguracaoId == configuracaoId || configuracaoId == null) &&
                    (c.ParametroId == parametroId || parametroId == null)
                    ).OrderByDescending(x => x.ConfiguracaoParametroId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<ConfiguracaoParametro> Insert(ConfiguracaoParametro model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.ConfiguracoesParametros.Add(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir o registro: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<ConfiguracaoParametro> Update(ConfiguracaoParametro model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.ConfiguracoesParametros.Update(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar editar o registro: " + ex.Message);
            }
        }
        #endregion        

        #region DELETE
        public async Task<ConfiguracaoParametro> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    ConfiguracaoParametro model = await this.FindById(id);
                    this._context.ConfiguracoesParametros.Remove(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
        #endregion
    }
}
