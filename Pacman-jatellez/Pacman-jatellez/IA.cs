using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_jatellez
{
    public abstract class IA : Jugador
    {
        int X_value;
        int Y_value;

        public IA()
        {
            X_value = 0;
            Y_value = 0;
        }
    }
}
