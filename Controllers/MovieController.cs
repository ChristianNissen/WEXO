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

		[HttpGet("movies")]
		public async Task<MovieResponse> Get(int? pageNumber = null)
		{
			pageNumber ??= 1;

			MovieResponse currentPageMovies = new MovieResponse();

			string result = await _movieService.GetMovies(pageNumber);
			currentPageMovies = JsonConvert.DeserializeObject<MovieResponse>(result);

			return currentPageMovies;
		}

	}
}
