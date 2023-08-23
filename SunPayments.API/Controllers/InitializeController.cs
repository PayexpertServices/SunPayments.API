using Microsoft.AspNetCore.Mvc;
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
            byte[] encodedBytes = Encoding.UTF8.GetBytes(data);
            string decodedText = Encoding.UTF8.GetString(encodedBytes);

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return decodedText;
        }
    }
}
