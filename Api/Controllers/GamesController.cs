using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
		[ApiController]
		[Route("api/[controller]")]
	
	public class GamesController : ControllerBase
	{
		private readonly IGameRepository _gameRepository;

		public GamesController(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}


		[HttpGet]
		public async Task<IActionResult> GetGames()
		{
			var games = await _gameRepository.GetAllGamesAsync();
			return Ok(games);
		}



		[HttpPost]
		public async Task<IActionResult> AddGame(Game game)
		{
			await _gameRepository.AddAsync(game);
			return Ok();
		}




	}

}
