using SunPayments.API.DTOs;
using System.IO;
using System.Net.Http.Headers;

namespace SunPayments.API.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PublicKey> SaveAsync()
        {
            //string data;

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");

            //_httpClient.DefaultRequestHeaders.Add("X-24pay-User-Id", "murat");

            //HttpResponseMessage response = await _httpClient.GetAsync("api/v1/security/publicKey");

            //data = await response.Content.ReadAsStringAsync();

            //var x= response.Content;

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PublicKey>>("api/v1/security/publicKey");

            return response.Data;
        }
    }
}
