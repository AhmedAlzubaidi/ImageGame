using ImageGame.Data;
using ImageGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageGame.Services
{
    public class GameService : IGameService
    {
        public Game CreateGame(ImageGameDbContext context, Game game)
        {
            // TODO improve password encryption
            game.Password = game.Password.GetHashCode().ToString();
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
            return context.Games.Where(game => game.Id == gameId).FirstOrDefault();
        }

        public Game UpdateGame(ImageGameDbContext context, int id, Game game)
        {
            Game target = GetGameById(context, id);
            target.copy(game);
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

        public bool auth(ImageGameDbContext context, int gameId, string password)
        {
            // TODO improve password encryption
            Game Game = GetGameById(context, gameId);
            return Game.Password == password.GetHashCode().ToString();
        }
    }
}
