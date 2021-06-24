using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_PROJECT
{
    public partial class Form3 : Form
    {
        int move;
        int X_axis;
        int Y_axis;

        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            X_axis = e.X;
            Y_axis = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - X_axis, MousePosition.Y - Y_axis);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                textBox1.Text = "Search by Aurtor name, Book name";
                textBox1.ForeColor = Color.Gray;
            }
            else
            {
                textBox1.Text = null;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search by Aurtor name, Book name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(textBox1.Enabled == false)
            {
                textBox1.Enabled = true;    
            }
            else
            {
                // Search
            }
        }

        private void close_picture_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void minimize_pictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
