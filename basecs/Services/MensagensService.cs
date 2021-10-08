using basecs.Business.Mensagems;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IMensagensService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class MensagensService : IMensagensService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly MensagemsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public MensagensService(MyDbContext context)
        {
            _context = context;
            _business = new MensagemsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Mensagem> FindById(int id)
        {
            try
            {
                return await this._context.Mensagens.SingleOrDefaultAsync(c => c.MensagemId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Mensagem>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[MensagemsPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Mensagens.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Mensagem>> ReturnListWithParameters(
                int? id,
                int? remetenteId,
                int? tipoMensagemId,
                int? destinatarioId,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Mensagens.Where(c =>
                    (c.MensagemId.Equals(id) || id.Equals(id)) &&
                    (c.RemetenteId.Equals(remetenteId) || remetenteId.Equals(remetenteId)) &&
                    (c.DestinatarioId.Equals(destinatarioId) || remetenteId.Equals(destinatarioId)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.MensagemId)
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
        public async Task<Mensagem> Insert(Mensagem model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Mensagens.Add(model);
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
        public async Task<Mensagem> Update(Mensagem model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Mensagens.Update(model);
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
        public async Task<Mensagem> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Mensagem model = await this.FindById(id);
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
