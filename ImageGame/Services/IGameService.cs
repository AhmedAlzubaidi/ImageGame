using ImageGame.Data;
using ImageGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Services
{
    interface IGameService
    {
        public Game CreateGame(ImageGameDbContext context, Game game);
        public ICollection<Game> GetAllGames(ImageGameDbContext context);
        public Game GetGameById(ImageGameDbContext context, int gameId);
        public Game UpdateGame(ImageGameDbContext context, int id, Game game);
        public Game DeleteGameById(ImageGameDbContext context, int gameId);
        public bool auth(ImageGameDbContext context, int gameId, string password);
    }
}
