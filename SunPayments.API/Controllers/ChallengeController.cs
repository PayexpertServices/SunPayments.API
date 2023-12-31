﻿using Microsoft.AspNetCore.Mvc;
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

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return data;

        }
    }
}
