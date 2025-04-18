﻿using Newtonsoft.Json;

namespace WEXO.Models
{
	public class MovieResponse
	{
		[JsonProperty("page")]
		public int Page { get; set; }
		[JsonProperty("results")]
		public List<Movie> Results { get; set; }
		[JsonProperty("total_pages")]
		public int TotalPages { get; set; }
		[JsonProperty("total_results")]
		public int TotalResults { get; set; }

		public MovieResponse()
		{
			
		}
	}
}
