using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SunPayments.API.DTOs;
using SunPayments.API.Services;

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
        public async Task<IActionResult> GetPublicKey()
        {

            var getHttpResponse = await _authenticationService.GetPublicKey();
            var data = await getHttpResponse.Content.ReadAsStringAsync();

            if (!getHttpResponse.IsSuccessStatusCode)
            {
                return CreateActionResult(CustomResponseDto<string>.Fail((int)getHttpResponse.StatusCode, data));
            }
            else
            {
                return CreateActionResult(CustomResponseDto<string>.Success((int)getHttpResponse.StatusCode, data));
            }


        }

        

    }
}
