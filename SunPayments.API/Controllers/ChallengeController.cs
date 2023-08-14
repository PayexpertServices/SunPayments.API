using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SunPayments.API.DTOs;
using SunPayments.API.Services;

namespace SunPayments.API.Controllers
{

    public class ChallengeController : CustomBaseController
    {
        private readonly ChallengeService _challengeService;

        public ChallengeController(ChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet("{id}/[action]")]
        public async Task<IActionResult> GetChallenge(long id)
        {

            var userId = Request.Headers["X-User-Public-Key-Hash"];

            Dictionary<string, string> headers = new Dictionary<string, string>();
            var x = Request.Headers;

            foreach (var header in Request.Headers)
            {
                headers.Add(header.Key, header.Value);
            }

            var getHttpResponse = _challengeService.GetChallengeService(id,userId,Request.Headers);

            string data = await getHttpResponse.Content.ReadAsStringAsync();

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
