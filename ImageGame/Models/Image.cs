using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Models
{
    public class Image
    {
        public int Id { get; set; }
        public Game Game { get; set; }

        [Required]
        public int GameId { get; set; }
        
        [Required]
        public string Key { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
