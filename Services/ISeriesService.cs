namespace WEXO.Services
{
	public interface ISeriesService
	{
		Task<string> GetSeries(int? pageNumber);
	}
}
