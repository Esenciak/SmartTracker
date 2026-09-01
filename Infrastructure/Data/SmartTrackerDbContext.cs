using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
	public class SmartTrackerDbContext : DbContext
	{
		public SmartTrackerDbContext(DbContextOptions<SmartTrackerDbContext> options) : base(options)
		{

		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Achievement> Achievements { get; set; }
	}


}
