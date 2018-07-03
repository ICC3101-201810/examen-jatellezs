using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_jatellez
{
    [Serializable]
    public class Usuario
    {
        string Nombre { get; set; }
        int Score { get; set; }

        public Usuario(string MiNombre)
        {
            Nombre = MiNombre;
            Score = 0;
        }
    }
}
