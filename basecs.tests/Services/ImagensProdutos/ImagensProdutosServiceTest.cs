using basecs.Interfaces.IImagensProdutosService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.ImagemProduto
{
    public class ImagensProdutosServiceTest
    {
        #region ATRIBUTTES
        ImagensProdutosService _service;
        Mock<IImagensProdutosService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public ImagensProdutosServiceTest()
        {
            _serviceMock = new Mock<IImagensProdutosService>();
            _service = new ImagensProdutosService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.ImagemProduto { ImagemProdutoId = 1, ImagemId = 1, ProdutoId = 1 };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.ImagemProduto>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.ImagemProduto { ImagemProdutoId = 200, ImagemId = 1, ProdutoId = 1 }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.ImagemProduto { ImagemProdutoId = 0, ImagemId = 1, ProdutoId = 1 }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.ImagemProduto { ImagemProdutoId = 200, ImagemId = 1, ProdutoId = 1 };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.ImagemProduto>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.ImagemProduto { ImagemProdutoId = 0, ImagemId = 1, ProdutoId = 1 }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.ImagemProduto { ImagemProdutoId = 6, ImagemId = 1, ProdutoId = 1 }));
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
