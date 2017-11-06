using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class Player
    {
        public char Normal { get; set; }
        public char King { get; set; }

        public Player(char normal, char king)
        {
            Normal = normal;
            King = king;
        }

    }
}
