using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Models
{
    public class Image
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
    }
}
