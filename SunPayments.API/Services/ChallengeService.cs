namespace SunPayments.API.Services
{
    public class ChallengeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ChallengeService> _logger;

        public ChallengeService(HttpClient httpClient, ILogger<ChallengeService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public HttpResponseMessage GetChallengeService(long reference_id, IHeaderDictionary headers)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/referenceIds/{reference_id}/security/challenge");

            var find = headers.FirstOrDefault(x => x.Key == "X-User-Public-Key-Hash");

            if (find.Key is null)
                _logger.LogInformation("X-User-Public-Key-Hash can not find!");


            if(find.Key is not null && find.Value.ToString() is not null)
            {
                request.Headers.Add(find.Key.ToString(), find.Value.ToString());
                _logger.LogInformation(find.Key + " " + "added to header section");
            }
                

            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }

    }
}
