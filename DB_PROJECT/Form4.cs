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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void minimize_pictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_picture_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bookName_Enter(object sender, EventArgs e)
        {
            bookName.Text = null;
            bookName.ForeColor = Color.Gray;
            

        }

        private void bookName_Leave(object sender, EventArgs e)
        {
            if (bookName.Text == "")
            {
                bookName.Text = "Enter Book Title ";
                bookName.ForeColor = Color.Gray;
            }
        }

        private void bookarthor_Enter(object sender, EventArgs e)
        {
            bookarthor.Text = null;
            bookarthor.ForeColor = Color.Gray;
        }

        private void bookarthor_Leave(object sender, EventArgs e)
        {
            if (bookarthor.Text == "")
            {
                bookarthor.Text = "Enter Arthor Name  ";
                bookarthor.ForeColor = Color.Gray;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
