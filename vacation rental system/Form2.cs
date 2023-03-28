using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace vacation_rental_system
{
    public partial class Regestaring : Form
    {
        public Regestaring()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlConnection con = new SqlConnection("Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True");
                string query = "Select * from Admin where FirstName = '" + txtUserName.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable DAdmin = new DataTable();
                sda.Fill(DAdmin);
                if (DAdmin.Rows.Count == 1)
                {
                    Form4 f4 = new Form4();
                    this.Hide();
                    f4.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error.Enter your Data Again");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection("Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True");
                string query = "Select * from Users where UserName = '" + txtUserName.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable DUsers = new DataTable();
                sda.Fill(DUsers);
                if (DUsers.Rows.Count == 1)
                {
                    Form8 f8 = new Form8();
                    this.Hide();
                    f8.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error.Enter your Data Again");
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog(this);
            this.Close();
        }
        int m=1;
        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (m== 1)
            {
                txtUserName.Text = "";
                m++;
            }
        }
       
        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (m == 2)
            {
                txtPassword.Text = "";
                m++;
                txtPassword.PasswordChar = '*';
            }
        }
    }
}

