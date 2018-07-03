using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_jatellez
{
    public partial class Inicio : Form
    {
        
        List<Usuario> Datos;

        public Inicio(List<Usuario> Data)
        {
            InitializeComponent();
            
            Datos = Data;
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != null)
            {
                Usuario user = new Usuario(textBox1.Text);
                Juego juego = new Juego(Datos, user);
                Controller main = new Controller(juego, Datos, user);
                this.Hide();
                juego.Show();
            }
        }
    }
}
