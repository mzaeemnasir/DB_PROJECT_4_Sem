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
namespace DB_PROJECT
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BookRack;Integrated Security=True");

        public static string SetValueForText3 = "";
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

        private void publicationYear_Enter(object sender, EventArgs e)
        {
            publicationYear.Text = null;
            publicationYear.ForeColor = Color.Gray;
        }

        private void publicationYear_Leave(object sender, EventArgs e)
        {
            if (publicationYear.Text == "")
            {
                publicationYear.Text = "Enter Publication Year  ";
                publicationYear.ForeColor = Color.Gray;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Upload the Book Record in our database

            OpenFileDialog upload_profile_pic = new OpenFileDialog();
            upload_profile_pic.Title = "Select Profile Picture ";
            upload_profile_pic.Filter = "Image Files(*.JPEG;*.JPG;*.PNG)|*.JPG;*.PNG;*.JPEG;";
            if (upload_profile_pic.ShowDialog() == DialogResult.OK)
            {
                // updating the record to our database 
                 con.Open();
                string file_name = System.IO.Path.GetFileName(upload_profile_pic.FileName); //geting the file name 
                string file_location = upload_profile_pic.FileName;                         // file Location 
                string dest = @"G:\UNIVERSITY\Smester no. 4\DB LAB\DB PROJECT\bookimgs\" + file_name;

                // Moving the File to our Folder

                System.IO.File.Copy(file_location,dest);

                // Generating SQL Query 

                string query_txt = @"INSERT INTO Books(bookName,bookAuthor,publicationYear,bookFormat,bookPrice,genre,bookImg) Values('"+bookName.Text+"','"+bookarthor.Text+"','"+publicationYear.Text+"','"+bookFormatBox.Text+"','"+bookPrice.Text+"','"+bookgenreBox.Text+"','"+dest+"');";
                SqlCommand query = new SqlCommand(query_txt, con);
                query.ExecuteNonQuery();
                con.Close();
            }
        }

        private void bookPrice_Enter(object sender, EventArgs e)
        {
            bookPrice.Text = null;
            bookPrice.ForeColor = Color.Gray;
        }

        private void bookPrice_Leave(object sender, EventArgs e)
        {

            if (bookPrice.Text == "")
            {
                bookPrice.Text = "Enter Book Price  ";
                bookPrice.ForeColor = Color.Gray;
            }
        }
    }
}
