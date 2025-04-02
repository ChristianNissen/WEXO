using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEXO.Models;
using WEXO.Services;

namespace WEXO.Controllers
{
	public class SeriesController
	{
		private readonly ISeriesService _seriesService;
		public int? pageNumber;

		public SeriesController(ISeriesService seriesService)
		{
			_seriesService = seriesService;
		}

		[HttpGet("series")]
		public async Task<SeriesResponse> Get(int? pageNumber = null)
		{
			pageNumber ??= 1;

			SeriesResponse currentPageSeries = new SeriesResponse();

			string result = await _seriesService.GetSeries(pageNumber);
			currentPageSeries = JsonConvert.DeserializeObject<SeriesResponse>(result);

			return currentPageSeries;
		}
	}
}
