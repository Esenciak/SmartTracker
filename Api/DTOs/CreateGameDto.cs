using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
	public class CreateGameDto
	{
		[Required]
		[StringLength(100, MinimumLength = 1)]
		public string Title { get; set; }
		[Required]
		public string Platform { get; set; }
	}
}
