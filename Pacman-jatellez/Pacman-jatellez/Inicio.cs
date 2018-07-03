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
        public event EventHandler<AgregarUsuarioEventArgs> OnAgregar;

        public Inicio()
        {
            InitializeComponent();
            Controller main = new Controller(this);
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != null)
            {
                AgregarUsuarioEventArgs nuevo = new AgregarUsuarioEventArgs();
                nuevo.Nombre = this.textBox1.Text;
                OnAgregar(this, nuevo);
                Juego juego = new Juego();
                this.Hide();
                juego.Show();
            }
        }
    }
}
