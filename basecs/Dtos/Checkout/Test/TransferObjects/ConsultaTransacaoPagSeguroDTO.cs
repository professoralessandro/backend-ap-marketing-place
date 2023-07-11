using System;
using System.Collections.Generic;

namespace basecs.Dtos.Checkout.Test.TransferObjects
{
    public class ConsultaTransacaoPagSeguroDTO
    {
        public DateTime Date { get; set; }
        public int ResultsInThisPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public List<ConsultaTransacaoPagSeguroTransactionDTO> listTransaction { get; set;}
    }
}
