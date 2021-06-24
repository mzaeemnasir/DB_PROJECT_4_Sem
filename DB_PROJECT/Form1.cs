using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace DB_PROJECT
{
    public partial class Form1 : Form
    {
        int move;
        int X_axis;
        int Y_axis;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            X_axis = e.X;
            Y_axis = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - X_axis, MousePosition.Y - Y_axis);

            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
        }

        private void Title_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Width += 5;
            if(flowLayoutPanel1.Width >= 600)
            { 
                timer1.Stop();
                Main_Screen f2 = new Main_Screen();
                f2.Show();
                this.Hide();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
