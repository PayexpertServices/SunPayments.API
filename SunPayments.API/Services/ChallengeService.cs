namespace SunPayments.API.Services
{
    public class ChallengeService
    {
        private readonly HttpClient _httpClient;

        public ChallengeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpResponseMessage GetChallengeService(long reference_id,string userId)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/referenceIds/{reference_id}/security/challenge");

            request.Headers.Add("X-User-Public-Key-Hash", userId);

            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }

    }
}
