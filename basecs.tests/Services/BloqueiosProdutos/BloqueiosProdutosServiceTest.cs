using basecs.Interfaces.IBloqueiosProdutosService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.BloqueioProdutos
{
    public class BloqueiosProdutosServiceTest
    {
        #region ATRIBUTTES
        BloqueiosProdutosService _service;
        Mock<IBloqueiosProdutosService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public BloqueiosProdutosServiceTest()
        {
            _serviceMock = new Mock<IBloqueiosProdutosService>();
            _service = new BloqueiosProdutosService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.BloqueioProduto { BloqueioProdutoId = 1, BloqueioId = 1, ProdutoId = 1 };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.BloqueioProduto>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.BloqueioProduto { BloqueioProdutoId = 200, BloqueioId = 1, ProdutoId = 1 }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.BloqueioProduto { BloqueioProdutoId = 0, BloqueioId = 1, ProdutoId = 1 }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.BloqueioProduto { BloqueioProdutoId = 200, BloqueioId = 1, ProdutoId = 1 };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.BloqueioProduto>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.BloqueioProduto { BloqueioProdutoId = 0, BloqueioId = 1, ProdutoId = 1 }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.BloqueioProduto { BloqueioProdutoId = 6, BloqueioId = 1, ProdutoId = 1 }));
        }
        #endregion

        #region DELETE
        [Fact(DisplayName = "Delete Send Valid Post")]
        public void Delete_SendValidDelete()
        {
            _serviceMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
        #endregion
    }
}
