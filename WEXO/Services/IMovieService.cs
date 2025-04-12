
namespace WEXO.Services
{
	public interface IMovieService
	{
		Task<string> GetMovies(int? pageNumber);
		Task<string> GetMovieDetails(int movieId);
    }
}
