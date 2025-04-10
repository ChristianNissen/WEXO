using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEXO.Models;
using WEXO.Services;

namespace WEXO.Controllers
{
	public class MovieController
	{
		private readonly IMovieService _movieService;
		public int? pageNumber;

		public MovieController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet("api/movies")]
		public async Task<MovieResponse> Get(int? pageNumber = null)
		{
			pageNumber ??= 1;

			MovieResponse currentPageMovies = new MovieResponse();

			string result = await _movieService.GetMovies(pageNumber);
            Console.WriteLine(result); // This is the full JSON from the API

            currentPageMovies = JsonConvert.DeserializeObject<MovieResponse>(result);

			return currentPageMovies;
		}

        [HttpGet("api/movie/{movieId}")]
        public async Task<Movie> GetMovieDetails(int movieId)
        {
            string result = await _movieService.GetMovieDetails(movieId);
            Console.WriteLine(result); // This is the full JSON from the API

            Movie movieDetails = JsonConvert.DeserializeObject<Movie>(result);

            return movieDetails;
        }

    }
}
