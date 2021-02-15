using ImageGame.Data;
using ImageGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Services
{
    public interface IGameService
    {
        public Game CreateGame(ImageGameDbContext context, IPasswordService service, Game game);
        public ICollection<Game> GetAllGames(ImageGameDbContext context);
        public Game GetGameById(ImageGameDbContext context, int gameId);
        public Game UpdateGame(ImageGameDbContext context, IPasswordService service, int id, Game game);
        public Game DeleteGameById(ImageGameDbContext context, int gameId);
        public bool Auth(ImageGameDbContext context, IPasswordService service, int gameId, string password);
    }
}
