using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IEnderecosService
{
    public interface IEnderecosService
    {
        #region FIND BY ID
        Task<Endereco> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Endereco>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Endereco>> ReturnListWithParameters(int? id, int? tipoEnderecoId, string logradouro, string bairro, string cidade, string estado, string cep, bool? isPrincipal, bool? ativo);
        #endregion

        #region INSERT
        Task<Endereco> Insert(Endereco model);
        #endregion

        #region UPDATE
        Task<Endereco> Update(Endereco model);
        #endregion        

        #region DELETE
        Task<Endereco> Delete(int id);
        #endregion
    }
}
