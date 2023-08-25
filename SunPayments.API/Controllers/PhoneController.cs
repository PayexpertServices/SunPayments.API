using Microsoft.AspNetCore.Mvc;
using SunPayments.API.Services;
using System.Text;

namespace SunPayments.API.Controllers
{
    public class PhoneController : CustomBaseController
    {
        private readonly PhoneService _phoneService;

        public PhoneController(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpPost("{id}/[action]")]
        public async Task<string> Confirm(long id)
        {

            string rawContent = string.Empty;
            using (var reader = new StreamReader(Request.Body,
                          encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                rawContent = await reader.ReadToEndAsync();
            }

            //var headers= AddHeaders.AddHeaderValues(Request.Headers);

            var getHttpResponse = _phoneService.Confirm(rawContent, id,Request.Headers);

            var data=await getHttpResponse.Content.ReadAsStringAsync();

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return data;
        }

    }
}
