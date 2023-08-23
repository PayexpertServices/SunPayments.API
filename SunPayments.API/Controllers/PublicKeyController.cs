using Microsoft.AspNetCore.Mvc;
using SunPayments.API.Services;
using System.Text;

namespace SunPayments.API.Controllers
{
    public class PublicKeyController : CustomBaseController
    {
        private readonly PublickeyService _authenticationService;

        public PublicKeyController(PublickeyService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("[action]")]
        public async Task<string> GetPublicKey()
        {

            var getHttpResponse = await _authenticationService.GetPublicKey();
            var data = await getHttpResponse.Content.ReadAsStringAsync();
            byte[] encodedBytes = Encoding.UTF8.GetBytes(data);
            string decodedText = Encoding.UTF8.GetString(encodedBytes);

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return decodedText;


        }

        

    }
}
