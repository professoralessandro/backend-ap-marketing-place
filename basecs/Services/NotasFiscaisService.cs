using basecs.Business.NotasFiscais;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.INotasFiscaisService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class NotasFiscaisService : INotasFiscaisService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly NotasFiscaisBusiness _business;
        #endregion

        #region CONTRUCTORS
        public NotasFiscaisService(MyDbContext context)
        {
            _context = context;
            _business = new NotasFiscaisBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<NotaFiscal> FindById(int id)
        {
            try
            {
                return await this._context.NotasFiscais.SingleOrDefaultAsync(c => c.NotaFiscalId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao o tipo de telefone desejado! " + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<NotaFiscal>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[NotasFiscaisPaginated] @Id, @Descricao, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.NotasFiscais.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos telefones: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<NotaFiscal>> ReturnListWithParameters(
                int? id,
                int? tipoNotaFiscalId,
                string chaveAcesso,
                int? emitenteId,
                int? destinatarioId,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.NotasFiscais.Where(c =>
                    (c.NotaFiscalId.Equals(id) || id.Equals(null)) &&
                    (c.TipoNotaFiscalId.Equals(tipoNotaFiscalId) || tipoNotaFiscalId.Equals(null)) &&
                    (c.ChaveAcesso.Contains(Validators.RemoveInjections(chaveAcesso)) || string.IsNullOrEmpty(Validators.RemoveInjections(chaveAcesso))) &&
                    (c.UsuarioId.Equals(emitenteId) || emitenteId.Equals(null)) &&
                    (c.DestinatarioId.Equals(destinatarioId) || destinatarioId.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null))
                    .OrderByDescending(x => x.NotaFiscalId)
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
        public async Task<NotaFiscal> Insert(NotaFiscal model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.NotasFiscais.Add(model);
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
        public async Task<NotaFiscal> Update(NotaFiscal model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.NotasFiscais.Update(model);
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
        public async Task<NotaFiscal> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    NotaFiscal model = await this.FindById(id);
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
