using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using NTBanking.Models; // Thay đổi namespace nếu cần

namespace NTBanking.Services // Thay đổi namespace nếu cần
{
    public class CurrencyService
    {
        private const string Url = "https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=10";

        public async Task<XDocument> GetExchangeRateAsync()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync(Url);
                return XDocument.Parse(response);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CurrencyRate> ParseExchangeRate(XDocument xmlDocument)
        {
            if (xmlDocument == null)
                return Enumerable.Empty<CurrencyRate>();

            return xmlDocument.Descendants("Exrate")
                .Select(rate => new CurrencyRate
                {
                    CurrencyCode = rate.Attribute("CurrencyCode")?.Value ?? "N/A",
                    CurrencyName = rate.Attribute("CurrencyName")?.Value?.Trim() ?? "N/A",
                    BuyRate = rate.Attribute("Buy")?.Value ?? "N/A",
                    TransferRate = rate.Attribute("Transfer")?.Value ?? "N/A",
                    SellRate = rate.Attribute("Sell")?.Value ?? "N/A"

                })
                .ToList();
        }
    }
}
