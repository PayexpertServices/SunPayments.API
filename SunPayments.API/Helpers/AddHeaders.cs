namespace SunPayments.API.Helpers
{
    public class AddHeaders
    {
        public static Dictionary<string,string> AddHeaderValues(IHeaderDictionary  values)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            foreach (var header in values)
            {
                headers.Add(header.Key, header.Value);
            }
            return headers;
        }
    }
}
