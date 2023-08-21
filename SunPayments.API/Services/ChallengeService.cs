namespace SunPayments.API.Services
{
    public class ChallengeService
    {
        private readonly HttpClient _httpClient;

        public ChallengeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpResponseMessage GetChallengeService(long reference_id, IHeaderDictionary headers)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/referenceIds/{reference_id}/security/challenge");

            var find = headers.FirstOrDefault(x => x.Key == "X-User-Public-Key-Hash");

            if(find.Key is not null && find.Value.ToString() is not null)
                request.Headers.Add(find.Key.ToString(), find.Value.ToString());

            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }

    }
}
