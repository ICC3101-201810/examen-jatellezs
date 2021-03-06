﻿using System;
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
    public partial class Juego : Form
    {
        public event EventHandler<AgregarUsuarioEventArgs> OnModificar;

        Timer timer = new Timer();
        Timer timer2 = new Timer();
        Timer timer3 = new Timer();
        int xdif = 0;
        int ydif = 0;
        List<Usuario> Data;
        Usuario usuario;

        public Juego(List<Usuario> Datos, Usuario user)
        {
            InitializeComponent();
            Data = Datos;
            usuario = user;
            KeyDown += new KeyEventHandler(Juego_KeyDown);
            timer.Interval = 30;
            timer.Tick += timer_Tick;
            timer.Start();
            timer2.Interval = 30000;
            timer2.Tick += timer2_Tick;
            timer2.Start();
            timer3.Interval = 9999;
            timer3.Tick += timer3_Tick;
            Random random = new Random();
            pictureBox2.Location = new System.Drawing.Point(random.Next(0,560), random.Next(0,580));
            pictureBox4.Location = new System.Drawing.Point(random.Next(0,560), random.Next(0,580));
        }

        private void Juego_Load(object sender, EventArgs e)
        {

        }

        private void Juego_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if(e.KeyCode == Keys.Left)
            {
                pictureBox1.Image = Pacman_jatellez.Properties.Resources.pacman_left;
                if (x - 4 <= 0)
                {
                    x = 0;
                }
                else { x -= 4; }
                xdif = -4;
                ydif = 0;
            }
            else if(e.KeyCode == Keys.Right)
            {
                pictureBox1.Image = Pacman_jatellez.Properties.Resources.pacman_right;
                if (x + 4 >= 560)
                {
                    x = 560;
                }
                else { x += 4; }
                xdif = 4;
                ydif = 0;
            }
            else if(e.KeyCode == Keys.Up)
            {
                pictureBox1.Image = Pacman_jatellez.Properties.Resources.pacman_up;
                if (y - 4 <= 0)
                {
                    y = 0;
                }
                else { y -= 4; }
                xdif = 0;
                ydif = -4;
            }
            else if(e.KeyCode == Keys.Down)
            {
                pictureBox1.Image = Pacman_jatellez.Properties.Resources.pacman_down;
                if (y + 4 >= 580)
                {
                    y = 580;
                }
                else { y += 4; }
                xdif = 0;
                ydif = 4;
            }

            pictureBox1.Location = new System.Drawing.Point(x, y);
        }

        private void pictureBox5_LocationChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LocationChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pictureBox2.Location = new System.Drawing.Point(800, 800);
                pictureBox4.Location = new System.Drawing.Point(800, 800);
                MessageBox.Show("Juego Terminado\nPuntuacion: "+label2.Text);
                timer.Interval = 10000;
                timer.Stop();
                AgregarUsuarioEventArgs mod = new AgregarUsuarioEventArgs();
                mod.Score = Convert.ToInt32(label2.Text);
                OnModificar(this, mod);
                Inicio main = new Inicio(Data);
                main.Show();
                this.Close();
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                pictureBox2.Location = new System.Drawing.Point(800, 800);
                pictureBox4.Location = new System.Drawing.Point(800, 800);
                MessageBox.Show("Juego Terminado\nPuntuacion: "+label2.Text);
                timer.Interval = 10000;
                timer.Stop();
                AgregarUsuarioEventArgs mod = new AgregarUsuarioEventArgs();
                mod.Score = Convert.ToInt32(label2.Text);
                OnModificar(this, mod);
                Inicio main = new Inicio(Data);
                main.Show();
                this.Close();
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                pictureBox3.Hide();
                pictureBox3.Location = new System.Drawing.Point(800, 800);
                label2.Text = (Convert.ToInt32(label2.Text) + 15).ToString();
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                pictureBox5.Hide();
                pictureBox5.Location = new System.Drawing.Point(800, 800);
                label2.Text = (Convert.ToInt32(label2.Text) + 10).ToString();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Location.X >= 560 || pictureBox1.Location.X <= 0)
            {
                xdif = 0;
            }
            if(pictureBox1.Location.Y >= 580 || pictureBox1.Location.Y <= 0)
            {
                ydif = 0;
            }
            pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + xdif, pictureBox1.Location.Y + ydif);
            if (pictureBox1.Location.X != pictureBox2.Location.X)
            {
                if(pictureBox1.Location.X > pictureBox2.Location.X)
                {
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X + 2,pictureBox2.Location.Y);
                }
                if (pictureBox1.Location.X < pictureBox2.Location.X)
                {
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X - 2, pictureBox2.Location.Y);
                }
            }
            if (pictureBox1.Location.Y != pictureBox2.Location.Y)
            {
                if (pictureBox1.Location.Y > pictureBox2.Location.Y)
                {
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X, pictureBox2.Location.Y + 2);
                }
                if (pictureBox1.Location.Y < pictureBox2.Location.Y)
                {
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X, pictureBox2.Location.Y - 2);
                }
            }

            if (pictureBox1.Location.X != pictureBox4.Location.X)
            {
                if (pictureBox1.Location.X > pictureBox4.Location.X)
                {
                    pictureBox4.Location = new System.Drawing.Point(pictureBox4.Location.X + 2, pictureBox4.Location.Y);
                }
                if (pictureBox1.Location.X < pictureBox4.Location.X)
                {
                    pictureBox4.Location = new System.Drawing.Point(pictureBox4.Location.X - 2, pictureBox4.Location.Y);
                }
            }
            if (pictureBox1.Location.Y != pictureBox4.Location.Y)
            {
                if (pictureBox1.Location.Y > pictureBox4.Location.Y)
                {
                    pictureBox4.Location = new System.Drawing.Point(pictureBox4.Location.X, pictureBox4.Location.Y + 2);
                }
                if (pictureBox1.Location.Y < pictureBox4.Location.Y)
                {
                    pictureBox4.Location = new System.Drawing.Point(pictureBox4.Location.X, pictureBox4.Location.Y - 2);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random random2 = new Random();
            pictureBox3.Location = new System.Drawing.Point(random2.Next(0, 560), random2.Next(0, 580));
            pictureBox5.Location = new System.Drawing.Point(random2.Next(0, 560), random2.Next(0, 580));
            pictureBox3.Show();
            pictureBox5.Show();
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox3.Location = new System.Drawing.Point(800,800);
            pictureBox5.Location = new System.Drawing.Point(800,800);
            pictureBox3.Hide();
            pictureBox5.Hide();
        }

        private void pictureBox4_LocationChanged(object sender, EventArgs e)
        {
            if (pictureBox4.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                
            }
        }
    }
}
