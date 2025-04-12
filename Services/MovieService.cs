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
					{ "Authorization", "Bearer using Microsoft.AspNetCore.Mvc;\r\nusing Newtonsoft.Json;\r\nusing System.IO.Pipelines;\r\nusing WEXO.Models;\r\nusing WEXO.Services;\r\n\r\nnamespace WEXO.Controllers\r\n{\r\n\tpublic class MovieController\r\n\t{\r\n\t\tprivate readonly IMovieService _movieService;\r\n\t\tpublic int? pageNumber;\r\n\r\n\t\tpublic MovieController(IMovieService movieService)\r\n\t\t{\r\n\t\t\t_movieService = movieService;\r\n\t\t}\r\n\r\n        [HttpGet(\"api/movies/{pageNumber}\")]\r\n        public async Task<List<Movie>> GetMovies(int pageNumber)\r\n        {\r\n            // Your existing logic for fetching movies, just using the pageNumber as an input\r\n            List<Movie> movies = new List<Movie>();\r\n\r\n            string result = await _movieService.GetMovies(pageNumber);\r\n\r\n            MovieResponse currentPageMovies = JsonConvert.DeserializeObject<MovieResponse>(result);\r\n\r\n            if (currentPageMovies != null)\r\n            {\r\n                movies.AddRange(currentPageMovies.Results);\r\n            }\r\n\r\n            return movies;\r\n        }\r\n\r\n\r\n        [HttpGet(\"api/movie/{movieId}\")]\r\n        public async Task<Movie> GetMovieDetails(int movieId)\r\n        {\r\n            string result = await _movieService.GetMovieDetails(movieId);\r\n\t\t\tConsole.WriteLine(\"MOVIE DETAILS! _____________________________________\");\r\n            Console.WriteLine(result); // This is the full JSON from the API\r\n\r\n            Movie movieDetails = JsonConvert.DeserializeObject<Movie>(result);\r\n\r\n            return movieDetails;\r\n        }\r\n\r\n    }\r\n}\r\n" },
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

		public async Task<string> GetMovieDetails(int movieId)
		{
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}"),
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
	}
}
