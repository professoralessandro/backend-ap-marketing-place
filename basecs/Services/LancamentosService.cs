using basecs.Business.Lancamentos;
using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.ILancamentosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Services
{
    public class LancamentosService : ILancamentosService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly LancamentosBusiness _business;
        #endregion

        #region CONTRUCTORS
        public LancamentosService(MyDbContext context)
        {
            _context = context;
            _business = new LancamentosBusiness();
        }
        #endregion

        #region FIND BY ID
        public async Task<Lancamento> FindById(int id)
        {
            try
            {
                return await this._context.Lancamentos.SingleOrDefaultAsync(c => c.LancamentoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o registro desejado!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Lancamento>> ReturnListWithParametersPaginated(
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

                var storedProcedure = $@"[dbo].[LancamentosPaginated] @Param, @DateAdded, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Lancamentos.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por registros: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Lancamento>> ReturnListWithParameters(
                int? id,
                int? tipoLancamentoId,
                int? situacaoId,
                string referencia,
                decimal? valorLancamento,
                DateTime? dataBaixa,
                int? usuarioIdBaixa,
                int? usuarioIdInclusao,
                int? lancamentoIdPai,
                int? qtdeParcelas,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Lancamentos.Where(c =>
                    (c.LancamentoId.Equals(id) || id.Equals(null)) &&
                    (c.TipoLancamentoId.Equals(tipoLancamentoId) || tipoLancamentoId.Equals(null)) &&
                    (c.SituacaoId.Equals(situacaoId) || situacaoId.Equals(null)) &&
                    (c.Referencia.Contains(Validators.RemoveInjections(referencia)) || string.IsNullOrEmpty(Validators.RemoveInjections(referencia))) &&
                    (c.ValorLancamento.Equals(valorLancamento) || valorLancamento.Equals(null)) &&
                    (c.DataBaixa >= dataBaixa || dataBaixa.Equals(null)) &&
                    (c.UsuarioIdBaixa.Equals(usuarioIdBaixa) || usuarioIdBaixa.Equals(null)) &&
                    (c.UsuarioInclusaoId.Equals(usuarioIdInclusao) || usuarioIdInclusao.Equals(null)) &&
                    (c.LancamentoIdPai.Equals(lancamentoIdPai) || lancamentoIdPai.Equals(null)) &&
                    (c.QtdeParcelas.Equals(qtdeParcelas) || qtdeParcelas.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.LancamentoId)
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
        public async Task<Lancamento> Insert(Lancamento model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Lancamentos.Add(model);
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
        public async Task<Lancamento> Update(Lancamento model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Lancamentos.Update(model);
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
        public async Task<Lancamento> Delete(int id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Lancamento model = await this.FindById(id);
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
