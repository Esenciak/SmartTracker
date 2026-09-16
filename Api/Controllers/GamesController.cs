using Api.DTOs;
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

			var gameDTOs = games.Select(g => new GameResponseDto
			{
				Id = g.Id,
				Title = g.Title,
				Platform = g.Platform
			}).ToList();

			return Ok(gameDTOs);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetGameById(Guid id)
		{
			var game = await _gameRepository.GetByIdAsync(id);
			if (game == null)
			{
				return NotFound();
			}
			else
			{
				var gameDTO = new GameResponseDto
				{
					Id = game.Id,
					Title = game.Title,
					Platform = game.Platform
				};
				return Ok(gameDTO);
			}
		}


		[HttpPost]
		public async Task<IActionResult> AddGame(CreateGameDto dto)
		{
			var game = new Game
			{
				Title = dto.Title,
				Platform = dto.Platform
			};
			await _gameRepository.AddAsync(game);
			return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
		}




	}

}
