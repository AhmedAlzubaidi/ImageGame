using ImageGame.Data;
using ImageGame.Models;
using ImageGame.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGame.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ImageGameDbContext Context;
        private readonly IGameService GameService;
        private readonly IPasswordService PasswordService;

        public GameController(IGameService gameService, IPasswordService passwordService, ImageGameDbContext context)
        {
            GameService = gameService;
            PasswordService = passwordService;
            Context = context;
        }

        // GET: api/v1/<GameController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(GameService.GetAllGames(Context));
        }

        // GET api/v1/<GameController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Game game = GameService.GetGameById(Context, id);

            if(game != null)
            {
                return Ok(game);
            } else
            {
                return NotFound();
            }
            
        }

        // POST api/v1/<GameController>
        [HttpPost]
        public ActionResult Post([FromBody] Game game)
        {
            return Ok(GameService.CreateGame(Context, PasswordService, game));
        }

        // PUT api/v1/<GameController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Game game)
        {
            Game target = GameService.GetGameById(Context, id);

            if(target == null)
            {
                return NotFound();
            }

            // maybe pass target Game instead of querying it twice
            if (!GameService.Auth(Context, PasswordService, id, game.Password))
                return Unauthorized();

            return Ok(GameService.UpdateGame(Context, PasswordService, id, game));
        }

        // DELETE api/v1/<GameController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromBody] string password)
        {
            Game target = GameService.GetGameById(Context, id);

            if (target == null)
            {
                return NotFound();
            }

            // maybe pass target Game instead of querying it twice
            if (!GameService.Auth(Context, PasswordService, id, "password"))
                return Unauthorized();

            return Ok(GameService.DeleteGameById(Context, id));
        }
    }
}
