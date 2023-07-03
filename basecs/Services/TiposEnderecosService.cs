using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.TiposEnderecos;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITiposEnderecosService;

namespace basecs.Services
{
    public class TiposEnderecosService : ITiposEnderecosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TiposEnderecosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TiposEnderecosService(MyDbContext context)
        {
            _context = context;
            _business = new TiposEnderecosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<TipoEndereco> FindById(int id)
        {
            try
            {
                return await this._context.TiposEnderecos.SingleOrDefaultAsync(c => c.TipoEnderecoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o TipoEndereco desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<TipoEndereco>> ReturnListWithParametersPaginated(
                int? id,
                string descricao,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(descricao.RemoveInjections()) ? DBNull.Value : descricao.RemoveInjections()),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TiposEnderecosPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.TiposEnderecos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos enderecos: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<TipoEndereco>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.TiposEnderecos.Where(c =>
                    (c.TipoEnderecoId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.TipoEnderecoId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos enderecos: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<TipoEndereco> Insert(TipoEndereco model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposEnderecos.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos enderecos: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<TipoEndereco> Update(TipoEndereco model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.TiposEnderecos.Update(model);
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

        #region DELETE SERVIÇO DE DELETE
        public async Task<TipoEndereco> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    TipoEndereco model = await this.FindById(id);
                    model.Ativo = false;
                    await this.Update(model);
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