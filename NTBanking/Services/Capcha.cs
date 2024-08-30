using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTBanking.Services
{
   public class Capcha
    {
        private string _captchaCode = string.Empty;
        public string  GenerateCaptcha()
        {
            _captchaCode = GenerateRandomCode();
            return _captchaCode;
        }

        private string GenerateRandomCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
