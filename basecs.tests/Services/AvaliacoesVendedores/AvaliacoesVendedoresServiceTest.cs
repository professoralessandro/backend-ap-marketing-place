using basecs.Interfaces.IAvaliacoesVendedoresService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.AvaliacaoVendedores
{
    public class AvaliacoesVendedoresServiceTest
    {
        #region ATRIBUTTES
        AvaliacoesVendedoresService _service;
        Mock<IAvaliacoesVendedoresService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public AvaliacoesVendedoresServiceTest()
        {
            _serviceMock = new Mock<IAvaliacoesVendedoresService>();
            _service = new AvaliacoesVendedoresService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 1, AvaliacaoId = 1, VendedorId = 1 };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.AvaliacaoVendedor>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 200, AvaliacaoId = 1, VendedorId = 1 }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 0, AvaliacaoId = 1, VendedorId = 1 }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 200, AvaliacaoId = 1, VendedorId = 1 };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.AvaliacaoVendedor>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 0, AvaliacaoId = 1, VendedorId = 1 }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.AvaliacaoVendedor { AvaliacaoVendedorId = 6, AvaliacaoId = 1, VendedorId = 1 }));
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
