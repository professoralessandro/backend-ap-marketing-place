using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Business.Telefones;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ITelefonesService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class TelefonesService : ITelefonesService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly TelefonesBusiness _business;
        #endregion

        #region CONTRUCTORS
        public TelefonesService(MyDbContext context)
        {
            _context = context;
            _business = new TelefonesBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Telefone> FindById(int id)
        {
            try
            {
                return await this._context.Telefones.SingleOrDefaultAsync(c => c.TelefoneId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao o tipo de telefone desejado! " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Telefone>> ReturnListWithParametersPaginated(
                int? id,
                int? tipoTelefoneId,
                string telefone,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@TipoTelefoneId", tipoTelefoneId.Equals(null) ? DBNull.Value : tipoTelefoneId),
                    new SqlParameter("@Telefone", string.IsNullOrEmpty(Validators.RemoveInjections(telefone)) ? DBNull.Value : Validators.RemoveInjections(telefone)),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[TelefonesPaginated] @Id, @TipoTelefoneId, @Telefone, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Telefones.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos telefones: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Telefone>> ReturnListWithParameters(
                int? id,
                int? tipoTelefoneId,
                string telefone,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Telefones.Where(c =>
                    (c.TelefoneId == id || id == null) &&
                    (c.TelefoneId == tipoTelefoneId || tipoTelefoneId == null) &&
                    (c.Numero.Contains(Validators.RemoveInjections(telefone)) || string.IsNullOrEmpty(Validators.RemoveInjections(telefone))) &&
                    (c.Ativo == ativo || ativo == null))
                    .OrderByDescending(x => x.TelefoneId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos telefones: " + ex.Message);
            }

        }
        #endregion

        #region INSERT
        public async Task<Telefone> Insert(Telefone model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Telefones.Add(model);
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
                throw new Exception("Houve um erro ao incluir tipos telefones: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Telefone> Update(Telefone model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Telefones.Update(model);
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
        public async Task<Telefone> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Telefone model = await this.FindById(id);
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