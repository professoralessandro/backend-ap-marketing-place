using basecs.Business.AvaliacoesVendedores;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class AvaliacoesVendedoresService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly AvaliacoesVendedoresBusiness _business;
        #endregion

        #region CONTRUCTORS
        public AvaliacoesVendedoresService(MyDbContext context)
        {
            _context = context;
            _business = new AvaliacoesVendedoresBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<AvaliacaoVendedor> FindById(int id)
        {
            try
            {
                return await this._context.AvaliacoesVendedores.SingleOrDefaultAsync(c => c.AvaliacaoVendedorId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o configuracao desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<AvaliacaoVendedor>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[AvaliacoesVendedoresPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.AvaliacoesVendedores.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a buscar os registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<AvaliacaoVendedor>> ReturnListWithParameters(
                int? id,
                int? avaliacaoId,
                int? produtoId
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.AvaliacoesVendedores.Where(c =>
                    (c.AvaliacaoVendedorId == id || id == null) &&
                    (c.AvaliacaoId == avaliacaoId || avaliacaoId == null) &&
                    (c.VendedorId == produtoId || produtoId == null)
                    ).OrderByDescending(x => x.AvaliacaoVendedorId)
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
        public async Task<AvaliacaoVendedor> Insert(AvaliacaoVendedor model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.AvaliacoesVendedores.Add(model);
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
        public async Task<AvaliacaoVendedor> Update(AvaliacaoVendedor model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.AvaliacoesVendedores.Update(model);
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
        public async Task<AvaliacaoVendedor> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    AvaliacaoVendedor model = await this.FindById(id);
                    this._context.AvaliacoesVendedores.Remove(model);
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
