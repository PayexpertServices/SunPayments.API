﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunPayments.API.DTOs;
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
        public async Task<IActionResult> Confirm(long id)
        {
            // HEADER DAN GELEN DATALAR OKUNACAK

            string rawContent = string.Empty;
            using (var reader = new StreamReader(Request.Body,
                          encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                rawContent = await reader.ReadToEndAsync();
            }

            var getHttpResponse = _phoneService.Confirm(rawContent, id);

            var body=await getHttpResponse.Content.ReadAsStringAsync();

            return CreateActionResult(CustomResponseDto<string>.Success((int)getHttpResponse.StatusCode, body));
        }

    }
}