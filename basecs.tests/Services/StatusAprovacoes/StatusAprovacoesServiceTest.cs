using basecs.Interfaces.IStatusAprovacaosService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.StatusAprovacoe
{
    public class StatusAprovacoesServiceTest
    {
        #region ATRIBUTTES
        StatusAprovacoesService _service;
        Mock<IStatusAprovacaosService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public StatusAprovacoesServiceTest()
        {
            _serviceMock = new Mock<IStatusAprovacaosService>();
            _service = new StatusAprovacoesService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.StatusAprovacao { StatusAprovacaoId = 1, Descricao = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.StatusAprovacao>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.StatusAprovacao { StatusAprovacaoId = 200, Descricao = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.StatusAprovacao { StatusAprovacaoId = 0, Descricao = "D", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.StatusAprovacao { StatusAprovacaoId = 200, Descricao = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.StatusAprovacao>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.StatusAprovacao { StatusAprovacaoId = 0, Descricao = "Unit Test", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.StatusAprovacao { StatusAprovacaoId = 6, Descricao = "D", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
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
