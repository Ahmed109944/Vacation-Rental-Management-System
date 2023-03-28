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
    public partial class Form3 : Form
    {
        string connectionString = "Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True;";
        
        public Form3()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection CN = new SqlConnection(connectionString))
            {
                CN.Open();
                SqlCommand CMD = new SqlCommand("InsertUser", CN);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("AdminID", textBox1.Text.Trim());
                CMD.Parameters.AddWithValue("@UserID", textBox2.Text.Trim());
                CMD.Parameters.AddWithValue("@Name", textBox3.Text.Trim());
                CMD.Parameters.AddWithValue("@placeName", textBox8.Text.Trim());
                CMD.Parameters.AddWithValue("@Age", textBox4.Text.Trim());
                CMD.Parameters.AddWithValue("@Address", textBox5.Text.Trim());
                CMD.Parameters.AddWithValue("@Gender", textBox6.Text.Trim());
                CMD.Parameters.AddWithValue("@Phone", textBox7.Text.Trim());
                CMD.Parameters.AddWithValue("@password", textBox9.Text.Trim());
                CMD.ExecuteNonQuery();
                MessageBox.Show("Registrated Successfully", "Registrated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
                

        }
        void Clear()
    {
        textBox1.Text = textBox2.Text = textBox3.Text = textBox8.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox9.Text = "";
    }

        public SqlCommand CMD { get; set; }

        public SqlConnection CN { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }
;
