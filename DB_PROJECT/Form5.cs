using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace DB_PROJECT
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BookRack;Integrated Security=True");
        public static string userEmail = "";
        int move;
        int X_axis;
        int Y_axis;

        public Form5()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            con.Open();
            string file_location = "";
            string query_text = @"SELECT userImage FROM [User_information] Where  email = '"+userEmail+"'";
            SqlCommand query = new SqlCommand(query_text, con);
            SqlDataReader Reader = query.ExecuteReader();
            if(Reader.Read())
            {
                file_location = Reader["userImage"].ToString();
                MessageBox.Show(file_location);
                // if there is no image the use the deafult one 
                if(file_location== "" || file_location == "NULL")  
                {
                   file_location = @"G: \UNIVERSITY\Smester no. 4\DB LAB\DB PROJECT\user_images\defautavatar.png";
                    profilePicture.ImageLocation = file_location;
                    profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    profilePicture.ImageLocation = file_location;
                    profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            con.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.instagram.com");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.twitter.com");

        }

        private void profilePicture_Click(object sender, EventArgs e)
        {

        }
    }
}
