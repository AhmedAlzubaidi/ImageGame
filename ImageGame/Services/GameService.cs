using ImageGame.Data;
using ImageGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageGame.Services
{
    public class GameService : IGameService
    {
        public Game CreateGame(ImageGameDbContext context, IPasswordService service, Game game)
        {
            game.Password = service.Hash(game.Password);
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        public ICollection<Game> GetAllGames(ImageGameDbContext context)
        {
            return context.Games.ToList();
        }

        public Game GetGameById(ImageGameDbContext context, int gameId)
        {
            return context.Games.Find(gameId);
        }

        public Game UpdateGame(ImageGameDbContext context, IPasswordService service, int id, Game game)
        {
            Game target = GetGameById(context, id);
            target.Copy(service, game);
            context.SaveChanges();
            return target;
        }

        public Game DeleteGameById(ImageGameDbContext context, int gameId)
        {
            Game game = GetGameById(context, gameId);
            context.Remove(game);
            context.SaveChanges();
            return game;
        }

        public bool Auth(ImageGameDbContext context, IPasswordService service, int gameId, string password)
        {
            Game game = GetGameById(context, gameId);
            return service.Verify(password, game.Password);
        }
    }
}
