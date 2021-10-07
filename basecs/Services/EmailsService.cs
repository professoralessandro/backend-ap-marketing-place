using basecs.Business.Emails;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IEmailsService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class EmailsService : IEmailsService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly EmailsBusiness _business;
        #endregion

        #region CONTRUCTORS
        public EmailsService(MyDbContext context)
        {
            _context = context;
            _business = new EmailsBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Email> FindById(int id)
        {
            try
            {
                return await this._context.Emails.SingleOrDefaultAsync(c => c.EmailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Email desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Email>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[EmailsPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Emails.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Email>> ReturnListWithParameters(
                int? id,
                string nomeEmail,
                int? tipoEmailId,
                string destinatario,
                string assunto,
                int? statusEnvio,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Emails.Where(c =>
                    (c.EmailId == id || id == null) &&
                    (c.NomeEmail.Contains(Validators.RemoveInjections(nomeEmail)) || string.IsNullOrEmpty(Validators.RemoveInjections(nomeEmail))) &&
                    (c.TipoEmailId == tipoEmailId || tipoEmailId == null) &&
                    (c.Destinatario.Contains(Validators.RemoveInjections(destinatario)) || string.IsNullOrEmpty(Validators.RemoveInjections(destinatario))) &&
                    (c.Assunto.Contains(Validators.RemoveInjections(assunto)) || string.IsNullOrEmpty(Validators.RemoveInjections(assunto))) &&
                    (c.StatusEnvio.Equals(statusEnvio) || statusEnvio.Equals(null)) &&
                    (c.Ativo.Equals(ativo) || ativo.Equals(null))
                    ).OrderByDescending(x => x.EmailId)
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
        public async Task<Email> Insert(Email model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Emails.Add(model);
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
        public async Task<Email> Update(Email model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Emails.Update(model);
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
        public async Task<Email> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Email model = await this.FindById(id);
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
