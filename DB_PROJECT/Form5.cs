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
using System.Reflection;
namespace DB_PROJECT
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BookRack;Integrated Security=True");
        public static string userEmail = "";
        public static string fullName = "";
        public static string Address = "";
        public static string Phone = "";
        int move;
        int X_axis;
        int Y_axis;
        int id;

        public Form5()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            buyPanel.Hide();
            email_txbox_disabled.Text = userEmail;
            profie_address_input.Text = Address;
            profile_ph_input.Text = Phone;
            profile_name_input.Text = fullName;
            Email_box_disabled_cng_pass.Text = userEmail;

            // TODO: This line of code loads data into the 'bookRackDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.bookRackDataSet.Books);
            con.Open();
            string file_location = "";
            string query_text = @"SELECT userImage FROM [User_information] Where  email = '"+userEmail+"'";
            SqlCommand query = new SqlCommand(query_text, con);
            SqlDataReader Reader = query.ExecuteReader();
            if(Reader.Read())
            {
                file_location = Reader["userImage"].ToString();
                // if there is no image the use the deafult one 
                if(file_location== "" || file_location == "NULL")  
                {
                   file_location = @"G:\UNIVERSITY\Smester no. 4\DB LAB\DB PROJECT\user_images\defautavatar.png";
                    profilePicture.ImageLocation = file_location;
                    update_profile_picture.ImageLocation = file_location;
                    update_profile_picture.SizeMode = PictureBoxSizeMode.Zoom;
                    profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    update_profile_picture.ImageLocation = file_location;
                    update_profile_picture.SizeMode = PictureBoxSizeMode.Zoom;
                    profilePicture.ImageLocation = file_location;
                    profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            con.Close();
            profile_panel.Hide();
            password_chng_panel.Hide();
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

        

        private void label3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            profile_panel.Hide();
            password_chng_panel.Show();
            password_chng_panel.BringToFront();
        }

        private void email_txbox_disabled_TextChanged(object sender, EventArgs e)
        {
            email_txbox_disabled.Enabled = true;
            email_txbox_disabled.ReadOnly = false;
            email_txbox_disabled.Text = userEmail;
            email_txbox_disabled.ReadOnly = true;
            email_txbox_disabled.Enabled = false;
        }

        private void profile_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void save_changes_pass_chng_Click(object sender, EventArgs e)
        {
            // if the inputed passwords are correct then chnge the password in the database 
            if(password_input.Text == cnfrm_pas_input.Text && password_input.Text != "" )
            {
                con.Open();
                string query_txt = @"Update User_information Set userPassword = '" +password_input.Text+"'  where email = '"+userEmail+"'";
                SqlCommand query = new SqlCommand(query_txt, con);
                query.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Password has been Updated");
            }
            else
            {
                MessageBox.Show("Please check You Password");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            password_chng_panel.Hide();
            profile_panel.Show();
        }

        private void show_pass_boX_CheckedChanged(object sender, EventArgs e)
        {
            // if the check box is checked then simply show the password
            if(show_pass_boX.Checked)
            {
                password_input.PasswordChar = '\0';
                cnfrm_pas_input.PasswordChar = '\0';
            }

            // or else simple hide the password when the check box is unchecked
            else if (!show_pass_boX.Checked)
            {
                password_input.PasswordChar = '*';
                cnfrm_pas_input.PasswordChar = '*';
            }
        }

        private void Upload_picture_lbl_Click(object sender, EventArgs e)
        {
            OpenFileDialog upload_profile_pic = new OpenFileDialog();
            upload_profile_pic.Title = "Select Profile Picture ";
            upload_profile_pic.Filter = "Image Files(*.JPEG;*.JPG;*.PNG)|*.JPG;*.PNG;*.JPEG;";
            if(upload_profile_pic.ShowDialog() == DialogResult.OK)
            {
                // updating the user image to our database 
                con.Open();
                string file_location = upload_profile_pic.FileName;
                string query_txt = @"Update User_information Set userImage = '"+file_location+"' where email = '"+userEmail+"' ";
                SqlCommand query = new SqlCommand(query_txt,con);
                query.ExecuteNonQuery();
                con.Close();

                //now refreshing the profile picturess
                profilePicture.ImageLocation = file_location;
                update_profile_picture.ImageLocation = file_location;
                update_profile_picture.SizeMode = PictureBoxSizeMode.Zoom;
                profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            profile_panel.Hide();
        }

        private void save_changes_btn_Click(object sender, EventArgs e)
        {
            int i = 0;
            // if the Profile name is not empty then update it in our data base
            if(profile_name_input.Text != "")
            {
                con.Open();
                string query_txt = @"Update User_information Set fullName = '"+profile_name_input.Text+"' where email = '"+userEmail+"' ";
                SqlCommand query = new SqlCommand(query_txt,con);
                query.ExecuteNonQuery();
                con.Close();
                i++;
            }
            if(profie_address_input.Text != "")
            {
                con.Open();
                string query_txt = @"Update User_information Set userAddress = '" +profie_address_input.Text + "' where email = '" + userEmail + "' ";
                SqlCommand query = new SqlCommand(query_txt, con);
                query.ExecuteNonQuery();
                con.Close();
                i++;
            }
            if (profile_ph_input.Text != "")
            {
                con.Open();
                string query_txt = @"Update User_information Set userPhone = '" + profile_ph_input.Text + "' where email = '" + userEmail + "' ";
                SqlCommand query = new SqlCommand(query_txt, con);
                query.ExecuteNonQuery();
                con.Close();
                i++; 
            }
            if(i >0)
            {
                MessageBox.Show("Changes Saved!!!");
            }
            else if(i == 0)
            {
                MessageBox.Show("Please input data for changes");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            password_chng_panel.Hide();
            profile_panel.Show();
            profile_panel.BringToFront();
        }

        private void update_profile_picture_Click(object sender, EventArgs e)
        {

        }

        private void profilePicture_Click(object sender, EventArgs e)
        {

        }

        private void edit_profile_Click(object sender, EventArgs e)
        {
            profile_panel.Show();
            profile_panel.BringToFront();
        }

        private void s(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_img_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && comboBox2.Text != "" && search_input.Text != "")
            {
                con.Open();
                string query_txt = @"Select * From Books where genre = '" + comboBox1.Text + "' AND bookFormat = '" + comboBox2.Text + "' AND bookName = '"+search_input.Text+"' ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DGV.DataSource = dataTable;

                con.Close();
            }
            else if (comboBox1.Text != "" && search_input.Text != "")
            {
                con.Open();
                // if only combobox has txt
                string query_txt = @"Select * From Books where genre = '" + comboBox1.Text + "' AND bookName = '" + search_input.Text + "' ";
                SqlCommand query = new SqlCommand(query_txt, con);
                // Gether data
                con.Close();
            }
            else if (comboBox2.Text != "" && search_input.Text != "")
            {
                con.Open();
                // if only combobox has txt
                string query_txt = @"Select * From Books where bookFormat = '" + comboBox2.Text + "' AND bookName = '" + search_input.Text + "' ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DGV.DataSource = dataTable;
                con.Close();
            }
            else if (search_input.Text != "")
            {
                con.Open();
                // if only combobox has txt
                string query_txt = @"Select * From Books where bookName LIKE '%"+search_input.Text +"%' ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
               
                DGV.DataSource = dataTable;

                con.Close();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                con.Open();
                string query_txt = @"Select * From Books where genre = '" + comboBox1.Text + "' AND bookFormat = '"+comboBox2.Text+"' ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
               
                DataTable dataTable  = new DataTable();
                dataAdapter.Fill(dataTable);
                DGV.DataSource= dataTable;
                
                con.Close();
            }
            else if (comboBox1.Text != "")
            {
                con.Open();
                // if only combobox has txt
                string query_txt = @"Select * From Books where genre = '" + comboBox1.Text + "' ";
                SqlCommand query = new SqlCommand(query_txt, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DGV.DataSource = dataTable;
                con.Close();
            }
            else if (comboBox2.Text != "")
            {
                con.Open();
                // if only combobox has txt
                string query_txt = @"Select * From Books where bookFormat = '" + comboBox2.Text + "' ";
                SqlCommand query = new SqlCommand(query_txt, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DGV.DataSource = dataTable;

                con.Close();
            }
            else
                MessageBox.Show("Filters are empty");
        }

        private void PS1_MouseHover(object sender, EventArgs e)
        {
            PS1.BackColor = Color.DarkRed;
            PS1.ForeColor = Color.White;
        }

        private void PS1_MouseLeave(object sender, EventArgs e)
        {
            PS1.BackColor = Color.Transparent;
            PS1.ForeColor = Color.Black;
        }

        private void PS2_MouseHover(object sender, EventArgs e)
        {

            PS2.BackColor = Color.DarkRed;
            PS2.ForeColor = Color.White;
        }

        private void PS2_MouseLeave(object sender, EventArgs e)
        {
            PS2.BackColor = Color.Transparent;
            PS2.ForeColor = Color.Black;
        }

        private void PS3_MouseHover(object sender, EventArgs e)
        {
            PS3.BackColor = Color.DarkRed;
            PS3.ForeColor = Color.White;
        }

        private void PS3_MouseLeave(object sender, EventArgs e)
        {
            PS3.BackColor = Color.Transparent;
            PS3.ForeColor = Color.Black;
        }

        private void PS4_MouseHover(object sender, EventArgs e)
        {
            PS4.BackColor = Color.DarkRed;
            PS4.ForeColor = Color.White;
        }

        private void PS4_MouseLeave(object sender, EventArgs e)
        {
            PS4.BackColor = Color.Transparent;
            PS4.ForeColor = Color.Black;
        }

        private void PS5_MouseHover(object sender, EventArgs e)
        {
            PS5.BackColor = Color.DarkRed;
            PS5.ForeColor = Color.White;
        }

        private void PS5_MouseLeave(object sender, EventArgs e)
        {
            PS5.BackColor = Color.Transparent;
            PS5.ForeColor = Color.Black;
        }

        private void PS1_Click(object sender, EventArgs e)
        {
            con.Open();
            // if only combobox has txt
            string query_txt = @"Select * From Books where genre = 'Science fiction' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DGV.DataSource = dataTable;

            con.Close();
        }

        private void PS2_Click(object sender, EventArgs e)
        {
            con.Open();
            // if only combobox has txt
            string query_txt = @"Select * From Books where genre = 'Action & Adventure' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
          //  DGV.RowTemplate.Height = 140;
            DGV.DataSource = dataTable;
            con.Close();
        }

        private void PS3_Click(object sender, EventArgs e)
        {
            con.Open();
            // if only combobox has txt
            string query_txt = @"Select * From Books where genre = 'History' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            
            DGV.DataSource = dataTable;

            con.Close();
        }

        private void PS4_Click(object sender, EventArgs e)
        {
            con.Open();
            // if only combobox has txt
            string query_txt = @"Select * From Books where genre = 'Crime' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            
            DGV.DataSource = dataTable;

            con.Close();
        }

        private void PS5_Click(object sender, EventArgs e)
        {
            con.Open();
            string query_txt = @"Select * From Books Where genre = 'Encyclopedia' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_txt, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            
            DGV.DataSource = dataTable;
            con.Close();
        }

        private void clrFltr_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            name_ofBook.Text = DGV.Rows[e.RowIndex].Cells["bookName"].FormattedValue.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         //   con.Open();
            buyPanel.Show();
            if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {

                id =Convert.ToInt32( DGV.Rows[e.RowIndex].Cells["bookId"].FormattedValue);
                name_ofBook.Text = DGV.Rows[e.RowIndex].Cells["bookName"].FormattedValue.ToString();
                price_ofBook.Text ="$ "+DGV.Rows[e.RowIndex].Cells["bookprice"].FormattedValue.ToString();
                Author_of_book.Text = DGV.Rows[e.RowIndex].Cells["bookAuthor"].FormattedValue.ToString();
                Bookpreview.ImageLocation = DGV.Rows[e.RowIndex].Cells["bookImg"].FormattedValue.ToString();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            buyPanel.Hide();
        }

        private void buy_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string url = "";
            string query_txt = @"Select bookUrl From buyBooks Where bookId = (Select bookId From Books Where bookName = '"+name_ofBook.Text+"' AND  bookAuthor = '"+Author_of_book.Text+"' )";
            SqlCommand query = new SqlCommand(query_txt, con);
            SqlDataReader reader = query.ExecuteReader();
            if(reader.Read())
            {
                url = reader["bookUrl"].ToString();
            }
            System.Diagnostics.Process.Start(url);
            con.Close();
        }
    }
}
