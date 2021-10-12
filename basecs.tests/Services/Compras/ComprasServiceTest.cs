
using basecs.Interfaces.IComprasService;
using basecs.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace basecs.tests.Services.Compras
{
    public class ComprasServiceTest
    {
        #region ATRIBUTTES
        ComprasService _service;
        Mock<IComprasService> _serviceMock;
        #endregion

        #region CONSTRUCTORS
        public ComprasServiceTest()
        {
            _serviceMock = new Mock<IComprasService>();
            _service = new ComprasService(new Data.MyDbContext());
        }
        #endregion

        #region INSERT
        [Fact(DisplayName = "Insert Send Valid Post")]
        public void Insert_SendValidPost()
        {
            var compra = new basecs.Models.Compra { CompraId = 0, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTest" };
            _serviceMock.Setup(x => x.Insert(It.IsAny<basecs.Models.Compra>())).ReturnsAsync(compra);
        }

        [Fact(DisplayName = "Insert Send Invalid PostId")]
        public async Task Insert_SendInvalidPostId()
        {
            var compra = new basecs.Models.Compra { CompraId = 200, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTest" };
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(compra));
        }

        [Fact(DisplayName = "Insert Send Invalid Post Description")]
        public async Task Insert_SendInvalidPostDescription()
        {
            var compra = new basecs.Models.Compra { CompraId = 0, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTestErroAbove20Caracter" };
            await Assert.ThrowsAsync<Exception>(() => _service.Insert(compra));
        }
        #endregion

        #region UPDATE
        [Fact(DisplayName = "Update Send Invalid Post Description")]
        public void Update_SendValidPut()
        {
            var compra = new basecs.Models.Compra { CompraId = 200, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTest" };
            _serviceMock.Setup(x => x.Update(It.IsAny<basecs.Models.Compra>())).ReturnsAsync(compra);
        }

        [Fact]
        public async Task Update_SendInvalidPostId()
        {
            var compra = new basecs.Models.Compra { CompraId = 0, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTest" };
            await Assert.ThrowsAsync<Exception>(() => _service.Update(compra));
        }

        [Fact]
        public async Task Update_SendInvalidPostDescription()
        {
            var compra = new basecs.Models.Compra { CompraId = 200, VendedorId = 1, StatusCompraId = 1, ProdutoId = 1, LancamentoPaiId = 1, TelefoneId = 1, IsPago = true, IsEntregue = true, IsAvaliado = true, GarantiaId = 1, FormaPagamentoId = 1, EntregaId = 1, Ativo = true, EnderecoId = 1, CompradorId = 1, CodigoCompra = "UnitTestErroAbove20Caracter" };
            await Assert.ThrowsAsync<Exception>(() => _service.Update(compra));
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
