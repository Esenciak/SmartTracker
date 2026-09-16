using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class GameRepository : IGameRepository
	{
		private readonly SmartTrackerDbContext _context;

		public GameRepository(SmartTrackerDbContext context)
		{
			_context = context;
		}


		public async Task AddAsync(Game game)
		{
			//throw new NotImplementedException();
			await _context.Games.AddAsync(game);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Game>> GetAllGamesAsync()
		{
			//throw new NotImplementedException();

			return await _context.Games.ToListAsync();
		}

		public async Task<Game?> GetByIdAsync(Guid id)
		{
			return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
		}
	}
}
