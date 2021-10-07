
using basecs.Interfaces.IEnderecosService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.Enderecos
{
    public class EnderecosServiceTest
    {
        #region ATRIBUTTES
        EnderecosService _service;
        Mock<IEnderecosService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public EnderecosServiceTest()
        {
            _serviceMock = new Mock<IEnderecosService>();
            _service = new EnderecosService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var retorno = new basecs.Models.Endereco { EnderecoId = 1, Logradouro = "Unit Test", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Endereco>())).ReturnsAsync(retorno);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Endereco { EnderecoId = 200, Logradouro = "Unit Test", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(new basecs.Models.Endereco { EnderecoId = 0, Logradouro = "D", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var retorno = new basecs.Models.Endereco { EnderecoId = 200, Logradouro = "Unit Test", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.Endereco>())).ReturnsAsync(retorno);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Endereco { EnderecoId = 0, Logradouro = "Unit Test", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.Update(new basecs.Models.Endereco { EnderecoId = 6, Logradouro = "D", Complemento = "CASA", Bairro = "Unit Test", Cidade = "Sao Paulo", Cep = "123456", Estado = "SP", TipoEnderecoId = 1, Numero = "10", IsPrincipal = true, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now }));
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
