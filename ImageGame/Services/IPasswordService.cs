using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Services
{
    interface IPasswordService
    {
        public string hash(string password);
    }
}
