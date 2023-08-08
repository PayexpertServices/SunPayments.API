using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using SunPayments.API.DTOs;
using SunPayments.API.Services;
using System.Text;

namespace SunPayments.API.Controllers
{

    public class InitializeController : CustomBaseController
    {
        private readonly InitializeService _initializeService;

        public InitializeController(InitializeService initializeService)
        {
            _initializeService = initializeService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EncryptedPayload()
        {
            // BURADA SANA ENCRYPTED Payload gelecek.
            // BURADA GELEN HEADER KISMINI DA OKU??????????

            var challenge = Request.Headers["X-Challenge"];
            var publicKeyHash = Request.Headers["X-User-Public-Key-Hash"];
            var TimeStamp = Request.Headers["X-Timestamp"];
            var Signature = Request.Headers["X-Signature"];

            //StreamReader reader =new StreamReader(Request.Body);
            //string data=await reader.ReadToEndAsync();

            string rawContent = string.Empty;
            using (var reader = new StreamReader(Request.Body,
                          encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                rawContent = await reader.ReadToEndAsync();
            }

            //var apiData = JsonConvert.DeserializeObject(data);

            //StringContent postContent = new StringContent(data, Encoding.UTF8, "application/json");
            //Dictionary<string, StringValues> dict = QueryHelpers.ParseQuery(data);

            var getHttpResponse = await _initializeService.EncryptedPayload(rawContent);
            var x = getHttpResponse.Content.ReadAsStringAsync();

            return Ok();
        }
    }
}
