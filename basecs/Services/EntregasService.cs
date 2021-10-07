using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Data;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using basecs.Business.Entregas;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.IEntregasService;

namespace basecs.Services
{
    public class EntregasService : IEntregasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly EntregasBusiness _business;
        #endregion

        #region CONTRUCTORS
        public EntregasService(MyDbContext context)
        {
            _context = context;
            _business = new EntregasBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Entrega> FindById(int id)
        {
            try
            {
                return await this._context.Entregas.SingleOrDefaultAsync(c => c.EntregaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Entrega desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Entrega>> ReturnListWithParametersPaginated(
                int? id,
                string nmrDocumento,
                int? tipoDocumentoId,
                string nomeRecebedor,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@NmrDocumento", string.IsNullOrEmpty(Validators.RemoveInjections(nmrDocumento)) ? DBNull.Value : Validators.RemoveInjections(nmrDocumento)),
                    new SqlParameter("@TipoDocumentoId", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@NomeRecebedor", string.IsNullOrEmpty(Validators.RemoveInjections(nomeRecebedor)) ? DBNull.Value : Validators.RemoveInjections(nomeRecebedor)),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[EntregasPaginated] @Id, @NmrDocumento, @TipoDocumentoId, @NomeRecebedor, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Entregas.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Entrega>> ReturnListWithParameters(
                int? id,
                string nmrDocumento,
                int? tipoDocumentoId,
                string nomeRecebedor,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Entregas.Where(c =>
                    (c.EntregaId.Equals(id) || id.Equals(null)) &&
                    (c.NmrDocumento.Contains(Validators.RemoveInjections(nmrDocumento)) || string.IsNullOrEmpty(Validators.RemoveInjections(nmrDocumento))) &&
                    (c.TipoDocumentoId.Equals(tipoDocumentoId) || tipoDocumentoId.Equals(null)) &&
                    (c.NomeRecebedor.Contains(Validators.RemoveInjections(nomeRecebedor)) || string.IsNullOrEmpty(Validators.RemoveInjections(nomeRecebedor))) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.EntregaId)
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
        public async Task<Entrega> Insert(Entrega model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Entregas.Add(model);
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
        public async Task<Entrega> Update(Entrega model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Entregas.Update(model);
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
        public async Task<Entrega> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Entrega model = await this.FindById(id);
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