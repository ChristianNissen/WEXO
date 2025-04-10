using System.Net.Http.Headers;

namespace WEXO.Services
{
	public class MovieService : IMovieService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public MovieService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["ApiKey"];
		}

		public async Task<string> GetMovies(int? pageNumber)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://api.themoviedb.org/3/movie/popular?language=en-US&page={pageNumber}"),
				Headers =
				{
					{ "accept", "application/json" },
					{ "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwYTI4YWJjZThhZjBjNzQyZjM4Y2Q2MGI1NGY2MzcyNiIsIm5iZiI6MTc0MzUzMjEwNi4yMzgwMDAyLCJzdWIiOiI2N2VjMzA0YTE5ZjFiMWNiNGVmYTBjODciLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.80ccqlHfNWRkItT3xie61-hxGRpqPa4sCYO_ALpj2yM" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
				return body;
			}
		}

		public async Task<string> GetMovieDetails(string movieId)
		{
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}"),
                Headers =
				{
					{ "accept", "application/json" },
				},
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
				return body;
            }
        }
	}
}
