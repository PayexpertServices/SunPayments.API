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
        public async Task<string> EncryptedPayload()
        {

            string rawContent = string.Empty;
            using (var reader = new StreamReader(Request.Body,
                          encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                rawContent = await reader.ReadToEndAsync();
            }

            var getHttpResponse =  _initializeService.EncryptedPayload(rawContent);

            var data = await getHttpResponse.Content.ReadAsStringAsync();


            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return data;
        }
    }
}
