using Newtonsoft.Json;

namespace WEXO.Models
{
	public class Series
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
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

		public Series(int id, string title, string description)
		{
			this.Id = id;
			this.Title = title;
			this.Description = description;
		}
	}
}
