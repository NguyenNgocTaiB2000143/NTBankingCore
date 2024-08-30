using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTBanking.Models
{
    public class CurrencyRate
    {
        public string? CurrencyCode { get; set; }
        public string? CurrencyName { get; set; }
        public string? BuyRate { get; set; }
        public string? TransferRate { get; set; }
        public string? SellRate { get; set; }
        public string? Datetime { get; set; }
    }


}
