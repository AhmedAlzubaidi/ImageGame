using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
