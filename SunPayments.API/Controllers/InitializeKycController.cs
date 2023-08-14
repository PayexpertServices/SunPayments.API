using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunPayments.API.DTOs;
using SunPayments.API.Services;
using System.Text;

namespace SunPayments.API.Controllers
{
    public class InitializeKycController : CustomBaseController
    {
        private readonly InitializeKycService _initializeKycService;

        public InitializeKycController(InitializeKycService initializeKycService)
        {
            _initializeKycService = initializeKycService;
        }

        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> InitializeKyc(long id)
        {
            // Header dan gelen datalar okunacak

            string rawContent = string.Empty;
            using (var reader = new StreamReader(Request.Body,
                          encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                rawContent = await reader.ReadToEndAsync();
            }


            var getHttpResponse=_initializeKycService.InitializeKyc(rawContent,id,Request.Headers);

            var data=await getHttpResponse.Content.ReadAsStringAsync();

            if (!getHttpResponse.IsSuccessStatusCode)
            {
                return CreateActionResult(CustomResponseDto<string>.Fail((int)getHttpResponse.StatusCode,data));
            }
            else
            {
                return CreateActionResult(CustomResponseDto<string>.Success((int)getHttpResponse.StatusCode, data));
            }
            
        }
    }
}
