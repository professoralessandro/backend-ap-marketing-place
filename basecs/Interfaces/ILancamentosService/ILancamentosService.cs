using basecs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Interfaces.ILancamentosService
{
    public interface ILancamentosService
    {
        #region FIND BY ID
        Task<Lancamento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Lancamento>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Lancamento>> ReturnListWithParameters(int? id,
                int? tipoLancamentoId,
                int? situacaoId,
                string referencia,
                decimal? valorLancamento,
                DateTime? dataBaixa,
                int? usuarioIdBaixa,
                int? usuarioIdInclusao,
                int? lancamentoIdPai,
                int? qtdeParcelas,
                bool? ativo);
        #endregion

        #region INSERT
        Task<Lancamento> Insert(Lancamento model);
        #endregion

        #region UPDATE
        Task<Lancamento> Update(Lancamento model);
        #endregion        

        #region DELETE
        Task<Lancamento> Delete(int id);
        #endregion
    }
}
