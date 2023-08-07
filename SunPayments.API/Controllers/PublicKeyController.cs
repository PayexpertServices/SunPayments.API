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


            var getHttpResponse = await _authenticationService.SaveAsync();

            string data = await getHttpResponse.Content.ReadAsStringAsync();
            var apiData = JsonConvert.DeserializeObject<CustomResponseDto<PublicKey>>(data);

            // burada mapleme yapabilirsin belki

            // Sen burada NoContentDto nun yerine body deki alanları yollayacaksın.
            // x.StatusCode un yerine de x den gelen body i eklersin.

            return CreateActionResult(CustomResponseDto<PublicKey>.Success((int)getHttpResponse.StatusCode,apiData.Data));


        }

        

    }
}
