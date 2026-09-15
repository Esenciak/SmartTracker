using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
	public interface IGameRepository
	{
		Task<IEnumerable<Game>> GetAllGamesAsync();
		Task AddAsync(Game game);
	}
}
