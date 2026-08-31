namespace Domain.Entities
{
	public class Game
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Platform { get; set; }
		//public Guid Achievement { get; set; }

		public List<Achievement> Achievements { get; set; } = new List<Achievement>();
	}
}
