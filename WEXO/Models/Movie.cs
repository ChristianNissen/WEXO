using Newtonsoft.Json;

namespace WEXO.Models
{
	public class Movie
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		public string Genre { get; set; }
		[JsonProperty("release_date")]
		public string release_date { get; set; }
		public string Director { get; set; }
		public List<string> Actors { get; set; }
		[JsonProperty("overview")]
		public string overview { get; set; }
		[JsonProperty("poster_path")]
		public string poster_path { get; set; }
		public string Backdrop { get; set; }

        public Movie() 
		{ 
		
		}


    }
}
