using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SunPayments.API.DTOs;
using SunPayments.API.Services;

namespace SunPayments.API.Controllers
{
    public class AuthenticationController : CustomBaseController
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            // HEADER KISMI OKUMAYA BAK...
            // BODY KISMI OKUMAYA BAK...
            //var token= Request.Headers["token"];
            //var userId = Request.Headers["userId"];

            //Dictionary<string,string> headers= new Dictionary<string,string>();

            //foreach (var header in Request.he)
            //{
            //    headers.Add(header.Key, header.Value);
            //}

            // Body kısmı okuma
            //var reader = new StreamReader(Request.Body);
            //reader.BaseStream.Seek(0, SeekOrigin.Begin);
            //var rawMessage = reader.ReadToEnd();


            var x = await _authenticationService.SaveAsync();

            // Sen burada NoContentDto nun yerine body deki alanları yollayacaksın.
            // x.StatusCode un yerine de x den gelen body i eklersin.

            return CreateActionResult(CustomResponseDto<PublicKey>.Success(200,x));
        }

        

    }
}
