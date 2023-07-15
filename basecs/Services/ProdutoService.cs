using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using basecs.Interfaces.Services.IAvaliacoesService;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using basecs.Interfaces.Repository.Produto;
using basecs.Dtos.Produtos;

namespace basecs.Services
{
    public class ProdutoService : IProdutoService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly IProdutosBusiness _business;
        private readonly IProdutoRepository _repository;
        #endregion

        #region CONTRUCTORS
        public ProdutoService(MyDbContext context, IProdutosBusiness business, IProdutoRepository repository)
        {
            _context = context;
            _business = business;
            _repository = repository;
        }
        #endregion

        #region FIND BY ID
        public async Task<Produto> FindById(Guid id)
        {
            try
            {
                return await this._context.Produtos.SingleOrDefaultAsync(c => c.ProdutoId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o avaliação desejada!" + ex.Message);
            }
        }
        #endregion

        #region FIND BY ID
        public async Task<ProdutoDto> GetById(Guid id)
        {
            try
            {
                return await _repository.FindById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o avaliação desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<IEnumerable<ProdutoDto>> ReturnListWithParametersPaginated(
                Guid? id,
                string descricao,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                return await _repository.ReturnListWithParametersPaginated(id, descricao, ativo, pageNumber, rowspPage);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos bloqueios: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Produto>> ReturnListWithParameters(
                Guid? id,
                string descricao,
                bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Produtos.Where(c =>
                    (c.ProdutoId == id || id == null) &&
                    (c.Descricao.Contains(descricao.RemoveInjections()) || string.IsNullOrEmpty(descricao.RemoveInjections())) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.ProdutoId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<Produto> Insert(Produto model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Produtos.Add(model);
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

        public async Task<int> Insert(ProdutoDto model)
        {
            try
            {
                return await _repository.Insert(model);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir tipos bloqueios: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Produto> Update(Produto model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Produtos.Update(model);
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

        public async Task<int> Update(ProdutoDto model)
        {
            try
            {
                return await _repository.Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao editar o registro: " + ex.Message);
            }
        }
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        public async Task<Produto> Delete(Guid id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Produto model = await this.FindById(id);
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

        public async Task<int> Remove(Guid id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar o registro: " + ex.Message);
            }
        }
        #endregion
    }
}
