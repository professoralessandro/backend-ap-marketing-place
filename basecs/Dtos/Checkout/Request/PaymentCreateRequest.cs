using System.Collections.Generic;

namespace basecs.Dtos.Checkout.Request
{
    public class PaymentCreateRequest
    {
        public int UsuarioId { get; set; }
        public List<ItemPaymentRequest> Product { get; set; }
    }

    public class ItemPaymentRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
