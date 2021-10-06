using basecs.Interfaces.IConfiguracoesParametroService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.ConfiguracaoParametro
{
    public class ConfiguracoesParametroServiceTest
    {
        #region ATRIBUTTES
        ConfiguracoesParametroService _service;
        Mock<IConfiguracoesParametroService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public ConfiguracoesParametroServiceTest()
        {
            _serviceMock = new Mock<IConfiguracoesParametroService>();
            _service = new ConfiguracoesParametroService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 1, ConfiguracaoId = 1, ParametroId = 1 };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.ConfiguracaoParametro>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 200, ConfiguracaoId = 1, ParametroId = 1 }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 0, ConfiguracaoId = 1, ParametroId = 1 }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 200, ConfiguracaoId = 1, ParametroId = 1 };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.ConfiguracaoParametro>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 0, ConfiguracaoId = 1, ParametroId = 1 }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.ConfiguracaoParametro { ConfiguracaoParametroId = 6, ConfiguracaoId = 1, ParametroId = 1 }));
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
