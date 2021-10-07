using basecs.Business.Enderecos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class EnderecosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly EnderecosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public EnderecosService(MyDbContext context)
        {
            _context = context;
            _business = new EnderecosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Endereco> FindById(int id)
        {
            try
            {
                return await this._context.Enderecos.SingleOrDefaultAsync(c => c.EnderecoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Endereco>> ReturnListWithParametersPaginated(
                string param,
                DateTime? dateAdded,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Param", string.IsNullOrEmpty(Validators.RemoveInjections(param)) ? DBNull.Value : param),
                    new SqlParameter("@DateAdded", dateAdded.Equals(null) ? DBNull.Value : dateAdded),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[EnderecosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Enderecos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Endereco>> ReturnListWithParameters(
                int? id,
                string descricao,
                bool isBloqueiaAcesso,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Enderecos.Where(c =>
                    (c.EnderecoId == id || id == null) &&
                    (c.NomeEndereco.Contains(Validators.RemoveInjections(descricao)) || string.IsNullOrEmpty(Validators.RemoveInjections(descricao))) &&
                    (c.IsBloqueiaAcesso.Equals(isBloqueiaAcesso) || !isBloqueiaAcesso.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.EnderecoId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<Endereco> Insert(Endereco model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Enderecos.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Endereco> Update(Endereco model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Enderecos.Update(model);
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
        public async Task<Endereco> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Endereco model = await this.FindById(id);
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
