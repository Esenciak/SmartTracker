namespace Api.DTOs
{
	public class GameResponseDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Platform { get; set; }
	}
}
