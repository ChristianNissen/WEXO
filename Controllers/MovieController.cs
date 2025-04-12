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

        [HttpGet("api/movies/{pageNumber}")]
        public async Task<List<Movie>> GetMovies(int pageNumber)
        {
            List<Movie> movies = new List<Movie>();

            string result = await _movieService.GetMovies(pageNumber);

            MovieResponse currentPageMovies = JsonConvert.DeserializeObject<MovieResponse>(result);

            if (currentPageMovies != null)
            {
                movies.AddRange(currentPageMovies.Results);
            }

            return movies;
        }


        [HttpGet("api/movie/{movieId}")]
        public async Task<Movie> GetMovieDetails(int movieId)
        {
            string result = await _movieService.GetMovieDetails(movieId);
			Console.WriteLine("MOVIE DETAILS! _____________________________________");
            Console.WriteLine(result);

            Movie movieDetails = JsonConvert.DeserializeObject<Movie>(result);

            return movieDetails;
        }

    }
}
