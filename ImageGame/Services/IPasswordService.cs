using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Services
{
    public interface IPasswordService
    {
        public string Hash(string password);
        public bool Verify(string password, string hash);
    }
}
