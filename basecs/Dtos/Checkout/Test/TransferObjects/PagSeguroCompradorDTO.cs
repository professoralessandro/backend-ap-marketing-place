using System.Collections.Generic;

namespace basecs.Dtos.Checkout.Test.TransferObjects
{
    public class PagSeguroCompradorDTO
    {
        public string SenderName { get; set; }
        public string SenderAreaCode { get; set; }
        public string senderPhone { get; set; }
        public string senderEmail { get; set; }
        public List<PagSeguroItemDTO> itens { get; set; }
    }
}