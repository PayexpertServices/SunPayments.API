namespace SunPayments.API.Services
{
    public class PublickeyService
    {
        private readonly HttpClient _httpClient;

        public PublickeyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetPublicKey()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/security/publicKey");

            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }
    }
}
