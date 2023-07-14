using System;
using System.Collections.Generic;

namespace basecs.Dtos.Checkout.Request
{
    public class PaymentCreateRequest
    {
        public Guid UsuarioId { get; set; }
        public List<ItemPaymentRequest> Product { get; set; }
    }

    public class ItemPaymentRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
