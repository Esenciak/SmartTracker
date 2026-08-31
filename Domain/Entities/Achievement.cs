namespace Domain.Entities
{
	public class Achievement
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsUnlocked { get; set; } = false;
		public DateTime? UnlockedAt { get; set; } = null;

		public Guid GameId { get; set; }

		public Game Game { get; set; }

	}
}
