namespace SunPayments.API.Services
{
    public class ChallengeService
    {
        private readonly HttpClient _httpClient;

        public ChallengeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpResponseMessage GetChallengeService(long reference_id,string userId,Dictionary<string,string> headers)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/referenceIds/{reference_id}/security/challenge");
            //request.Headers.Add("X-User-Public-Key-Hash",userId);

            foreach (var item in headers)
            {
                if (item.Key.Contains("X-User-Public-Key-Hash"))
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }


            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }
    }
}
