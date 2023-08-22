﻿using Microsoft.AspNetCore.Http;
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
        public async Task<string> GetPublicKey()
        {

            var getHttpResponse = await _authenticationService.GetPublicKey();
            var data = await getHttpResponse.Content.ReadAsStringAsync();

            Response.StatusCode = (int)getHttpResponse.StatusCode;
            return data;


        }

        

    }
}
