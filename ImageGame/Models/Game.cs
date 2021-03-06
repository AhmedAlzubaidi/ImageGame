﻿using ImageGame.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImageGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        
        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public ICollection<Image> Images { get; set; }

        public bool Copy(IPasswordService service, Game game)
        {
            Password = service.Hash(game.Password);
            Name = game.Name;
            Images = Images;
            return true;
        }
    }
}
