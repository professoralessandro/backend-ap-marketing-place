using basecs.Interfaces.Repository;
using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Repository.Avaliacoes
{
    public class AvaliacoesRepository : IAvaliacoesRepository
    {
        public Task<Avaliacao> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> Insert(Avaliacao model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Avaliacao>> ReturnListWithParameters(Guid? id, string descricao, bool? ativo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Avaliacao>> ReturnListWithParametersPaginated(Guid? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> Update(Avaliacao model)
        {
            throw new NotImplementedException();
        }
    }
}
