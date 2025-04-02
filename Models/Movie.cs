using Newtonsoft.Json;

namespace WEXO.Models
{
	public class Movie
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonIgnore]
		public string Genre { get; set; }
		[JsonProperty("release_date")]
		public string ReleaseDate { get; set; }
		[JsonIgnore]
		public string Director { get; set; }
		[JsonIgnore]
		public List<string> Actors { get; set; }
		[JsonProperty("overview")]
		public string Description { get; set; }
		[JsonIgnore]
		public string Cover { get; set; }
		[JsonIgnore]
		public string Backdrop { get; set; }

		public Movie (int id, string title, string description)
		{
			this.Id = id;
			this.Title = title;
			this.Description = description;
		}

	}
}
