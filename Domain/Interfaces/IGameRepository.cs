using Domain.Entities;


namespace Domain.Interfaces
{
	public interface IGameRepository
	{
		Task<IEnumerable<Game>> GetAllGamesAsync();
		Task AddAsync(Game game);
	}
}
