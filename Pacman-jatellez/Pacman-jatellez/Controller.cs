using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_jatellez
{
    class Controller
    {
        Inicio Menu;

        public Controller(Inicio MiMenu)
        {
            Menu = MiMenu;
            Menu.OnAgregar += Menu_OnAgregar;
        }

        private void Menu_OnAgregar(object sender, AgregarUsuarioEventArgs e)
        {
            Usuario user = new Usuario(e.Nombre);
        }
    }
}
