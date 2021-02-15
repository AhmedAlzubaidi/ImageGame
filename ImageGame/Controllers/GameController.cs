using ImageGame.Data;
using ImageGame.Models;
using ImageGame.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGame.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService Service;
        private readonly ImageGameDbContext Context;

        public GameController(GameService service, ImageGameDbContext context)
        {
            Service = service;
            Context = context;
        }

        // GET: api/v1/<GameController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Service.GetAllGames(Context));
        }

        // GET api/v1/<GameController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(Service.GetGameById(Context, id));
        }

        // POST api/v1/<GameController>
        [HttpPost]
        public ActionResult Post([FromBody] Game game)
        {
            // Todo validate request data
            return Ok(Service.CreateGame(Context, game));
        }

        // PUT api/v1/<GameController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Game game)
        {
            // Todo validate request data
            if (!Service.auth(Context, id, game.Password))
                return Unauthorized();

            return Ok(Service.UpdateGame(Context, id, game));
        }

        // DELETE api/v1/<GameController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromBody] string password)
        {
            if(!Service.auth(Context, id, "password"))
                return Unauthorized();

            return Ok(Service.DeleteGameById(Context, id));
        }
    }
}
