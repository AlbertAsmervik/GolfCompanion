using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace GolfApi.Services 
{
    public class GolfApiService
    {
        private readonly HttpClient _client;

        public GolfApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Player>> GetGolfStatsAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://live-golf-data.p.rapidapi.com/stats?year=2023&statId=186"),
                Headers =
                {
                    { "X-RapidAPI-Key", "e74c2d12dfmsh2e3b8dcaae79221p1e803cjsn82706fd61640" },
                    { "X-RapidAPI-Host", "live-golf-data.p.rapidapi.com" },
                    {"X-RapidAPI-App", "default-application_8752163" },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var golfData = JsonSerializer.Deserialize<GolfData>(body);
                return golfData.Rankings;
            }
        }

        public class GolfData
        {
            public List<Player> Rankings { get; set; }
        }

        public class Player
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Rank { get; set; }
            public double TotalPoints { get; set; }
        }
    }
}
