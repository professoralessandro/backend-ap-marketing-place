
using basecs.Interfaces.IMensagensService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.Mensagems
{
    public class mensagensServiceTest
    {
        #region ATRIBUTTES
        MensagensService _service;
        Mock<IMensagensService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public mensagensServiceTest()
        {
            _serviceMock = new Mock<IMensagensService>();
            _service = new MensagensService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.Mensagem { MensagemId = 1, MensagemContexto = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Mensagem>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Mensagem { MensagemId = 200, MensagemContexto = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Mensagem { MensagemId = 0, MensagemContexto = "D", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.Mensagem { MensagemId = 200, MensagemContexto = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.Mensagem>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Mensagem { MensagemId = 0, MensagemContexto = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Mensagem { MensagemId = 6, MensagemContexto = "D", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
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
