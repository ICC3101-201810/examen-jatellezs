using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Pacman_jatellez
{
    class Controller
    {
        Juego juego;
        List<Usuario> Data;
        Usuario usuario;

        public Controller(Juego MiJuego, List<Usuario> Datos, Usuario user)
        {
            juego = MiJuego;
            Data = Datos;
            usuario = user;
            juego.OnModificar += Juego_OnModificar;
        }

        private void Juego_OnModificar(object sender, AgregarUsuarioEventArgs e)
        {
            usuario.Score = e.Score;
            Data.Add(usuario);
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }
    }
}
