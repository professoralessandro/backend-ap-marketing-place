using basecs.Interfaces.IImagensService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.Imagem
{
    public class ImagensServiceTest
    {
        #region ATRIBUTTES
        ImagensService _service;
        Mock<IImagensService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public ImagensServiceTest()
        {
            _serviceMock = new Mock<IImagensService>();
            _service = new ImagensService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.Imagem { ImagemId = 1, Titulo = "Unit test", Publico = true };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Imagem>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Imagem { ImagemId = 200, Titulo = "Unit test", Publico = true }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Imagem { ImagemId = 0, Titulo = "Unit test", Publico = true }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.Imagem { ImagemId = 200, Titulo = "Unit test", Publico = true };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.Imagem>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Imagem { ImagemId = 0, Titulo = "Unit test", Publico = true }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Imagem { ImagemId = 6, Titulo = "Unit test", Publico = true }));
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
