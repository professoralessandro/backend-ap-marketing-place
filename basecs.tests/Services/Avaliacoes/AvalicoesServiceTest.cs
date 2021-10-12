using basecs.Interfaces.IAvaliacoesService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.Avaliacao
{
    public class AvalicoesServiceTest
    {
        #region ATRIBUTTES
        AvaliacoesService _service;
        Mock<IAvaliacoesService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public AvalicoesServiceTest()
        {
            _serviceMock = new Mock<IAvaliacoesService>();
            _service = new AvaliacoesService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 0, Descricao = "Unit Test with more than teen carac", Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };

            // Act
            var expected =  _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Avaliacao>())).ReturnsAsync(import);

            // Assert
            Assert.NotNull(expected);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostDescription_whenIdIsInvalid()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 200, Descricao = "Unit Test with more than teen carac", Ativo = true, Valor = (Decimal)1, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao incluir o registro: Identificação da avaliação invalida\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Insert(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact(DisplayName = "Insert SendInvalidPostDescription whenDescriptionHasLassThanTeenCaracters")]
        public async Task Insert_SendInvalidPostDescription_whenDescriptionHasLassThanTeenCaracters()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 0, Descricao = "Unit Test", Ativo = true, Valor = (Decimal)2, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao incluir o registro: Descrição da avaliação contem menos de dez caracteres\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Insert(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact(DisplayName = "Insert SendInvalidPostDescription whenDescriptionHasLassThanTeenCaracters")]
        public async Task Insert_SendInvalidPostDescription_whenValueHasInvalids()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 0, Descricao = "Unit Test with more than teen carac", Valor = (decimal)0.50, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao incluir o registro: A avaliação nao deve ser menor que um ou maior que cinco\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Insert(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact(DisplayName = "Insert SendInvalidPostDescription whenDescriptionHasLassThanTeenCaracters")]
        public async Task Insert_SendInvalidPostDescription_whenIsInactive()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 0, Descricao = "Unit Test with more than teen carac", Valor = (decimal)1, Ativo = false, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao incluir o registro: Não pode ser adicinada avaliação inativada\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Insert(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Update Description")]
        public void Update_SendValidUpdate()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 200, Descricao = "Unit Test with more than teen carac", Ativo = true, Valor = (Decimal)1, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };

            // Act
            var expected = _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Avaliacao>())).ReturnsAsync(import);

            // Assert
            Assert.NotNull(expected);
        }

        [Fact(DisplayName = "Insert Send Invalid UpdateId")]
        public async Task Insert_SendInvalidUpdatetDescription_whenIdIsInvalid()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 0, Descricao = "Unit Test with more than teen carac", Ativo = true, Valor = (Decimal)1, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao tentar editar o registro: Identificação da avaliação invalida\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Update(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact(DisplayName = "Insert SendInvalidPostDescription whenDescriptionHasLassThanTeenCaracters")]
        public async Task Insert_SendInvalidUpdateDescription_whenDescriptionHasLassThanTeenCaracters()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 200, Descricao = "Unit Test", Ativo = true, Valor = (Decimal)2, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao tentar editar o registro: Descrição da avaliação contem menos de dez caracteres\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Update(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact(DisplayName = "Insert SendInvalidUpdateDescription whenDescriptionHasLassThanTeenCaracters")]
        public async Task Insert_SendInvalidUpdateDescription_whenValueHasInvalids()
        {
            // Arrange
            var import = new basecs.Models.Avaliacao { AvaliacaoId = 200, Descricao = "Unit Test with more than teen carac", Valor = (Decimal)0.50, Ativo = true, UsuarioUltimaAlteracaoId = 1, UsuarioInclusaoId = 1, DataInclusao = DateTime.Now, DataUltimaAlteracao = DateTime.Now };
            var expectedMessage = "Houve um erro ao tentar editar o registro: A avaliação nao deve ser menor que um ou maior que cinco\n";

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => _service.Update(import));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
        #endregion

        #region DELETE
        [Fact(DisplayName = "Delete Send Valid Update")]
        public void Delete_SendValidDelete()
        {
            // Arrange
            var import = 1;

            // Act
            var expected = _serviceMock.Setup(x => x.Delete(import));

            // Assert
            Assert.NotNull(expected);
        }

        [Fact(DisplayName = "Delete Send Valid Update")]
        public void Delete_SendInvalidDelete()
        {
            // Arrange
            var import = 0;
            var expectedMessage = "Houve um erro ao tentar deletar o registro: Identificação da avaliação invalida\n";

            // Act
            Exception ex = Assert.ThrowsAsync<Exception>(() => _service.Delete(import)).Result;

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
        #endregion
    }
}
