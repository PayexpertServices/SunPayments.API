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
        public async Task<IActionResult> GetPublicKey()
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


            var getHttpResponse = await _authenticationService.GetPublicKey();

            string data = await getHttpResponse.Content.ReadAsStringAsync();

            return CreateActionResult(CustomResponseDto<string>.Success((int)getHttpResponse.StatusCode,data));


        }

        

    }
}
