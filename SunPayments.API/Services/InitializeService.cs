﻿using Microsoft.AspNetCore.Mvc;


namespace SunPayments.API.Services
{
    public class InitializeService
    {
        private readonly HttpClient _httpClient;

        public InitializeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> EncryptedPayload(object data)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/v1/signups/payPointMvp/initialize","cdshvcdshvchsdvchjdsvchdsvjcvsdhcvhdsvchsdvchsdvchdsvcdvdscjdsjcds");

            return response;
        }
    }
}
