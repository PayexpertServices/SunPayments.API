using Microsoft.AspNetCore.Mvc;
using SunPayments.API.Services;
using System.Text;

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
        public async Task<string> GetChallenge(long id)
        {

            //var headers = AddHeaders.AddHeaderValues(Request.Headers);

            var getHttpResponse = _challengeService.GetChallengeService(id,Request.Headers);

            string data = await getHttpResponse.Content.ReadAsStringAsync();
            byte[] encodedBytes = Encoding.UTF8.GetBytes(data);
            string decodedText = Encoding.UTF8.GetString(encodedBytes);

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return decodedText;

        }
    }
}
