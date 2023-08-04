using Org.BouncyCastle.Crypto.Parameters;
using SunPayments.API.DTOs;
using SunPayments.API.Key;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

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
            // RSA key DER format


            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PublicKey>>("api/v1/security/publicKey");
            GenerateKey.GenerateKeys(out string _private, out string _public);

            //byte[] byteArray = Convert.FromBase64String(response.Data.apiPublicKey);
            //string outputByteArray= Encoding.UTF8.GetString(byteArray);

            var importToRSA = ImportRsaKey.ImportRsaPublicKeyFromDer(Convert.FromBase64String(_public));

            return response.Data;
        }
    }
}
