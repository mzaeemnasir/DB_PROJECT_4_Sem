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
    public partial class Main_Screen : Form
    {
        int move;
        int X_axis;
        int Y_axis;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BookRack;Integrated Security=True");
        public Main_Screen()
        {
            InitializeComponent();
        }

        private void Main_Screen_Load(object sender, EventArgs e)
        {

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

        private void close_picture_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void minimize_pictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
   
        }

        private void panel3_Click(object sender, EventArgs e)
        {
           // login.ForeColor = Color.White;
        }
        private void label8_Click(object sender, EventArgs e)
        {
            SignUp_panel.BringToFront();
            SignUp_panel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            SignUp_panel.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel_Forget_pass.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            SignUp_panel.Hide();
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

        private void panel_Forget_pass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sign_up_btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(email_input.Text) && String.IsNullOrEmpty(name_input.Text) &&
                String.IsNullOrEmpty(phone_number_input.Text) && String.IsNullOrEmpty(Address_input.Text) ||
                String.IsNullOrEmpty(pass_input.Text) && String.IsNullOrEmpty(cnfrm_pass_input.Text))
            {
                MessageBox.Show("Please Input Details");
            }
            else
            {
                if (pass_input.Text.ToString() != cnfrm_pass_input.Text.ToString())
                {
                    MessageBox.Show("Please Enter Correct Password ");
                }
                else
                {
                    con.Open();
                    // Query to Insert into the Data base 
                    string qurery_text = @"INSERT INTO BookRack.dbo.User_information (email,fullName,userPhone,userAddress,userPassword) VALUES ('"+email_input.Text+"', '"+name_input.Text+"' , '"+phone_number_input.Text+"','"+Address_input.Text+"','"+pass_input.Text+"');";
                    SqlCommand query = new SqlCommand(qurery_text,con);
                    //Initilizing the SQL QUERY TO Insert Data to the Data base
                    int i = query.ExecuteNonQuery();
                    if(i!=0)
                    {
                        MessageBox.Show("You Account Has Been Created");
                        MessageBox.Show("Go Back and Log In to our System 😊😊");
                        con.Close();
                        panel3.BringToFront();
                        SignUp_panel.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Error with the Database Please Check ");
                    }
                    con.Close();
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        // Opening the connection with the database

            con.Open();
            // SQL - Server Query
            string query_text = @"SELECT * FROM BookRack.dbo.User_information Where email = '"+Email.Text+"' AND userPassword = '"+password.Text+"' ";
            SqlDataAdapter query = new SqlDataAdapter(query_text,con);

        //creating virtual table For Password or Email Validation

            DataTable dataTable = new DataTable();
            query.Fill(dataTable);

        // When Successfully LOGED IN

            if(dataTable.Rows.Count == 1)
            {
                MessageBox.Show(Email.Text);
                MessageBox.Show("Successfully Login \n");
                MessageBox.Show(query_text);
                Form4 f4 = new Form4();
                f4.Show();
            }

        // Error While Loged in 
            else
            {
                MessageBox.Show("Please Check You Email or Password \n");
            }

        // Closing the connection with the database

            con.Close();
        }

        private void SignUp_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            button1_Click(sender,e);
        }
    }
}
