using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace vacation_rental_system
{
    public partial class Form8 : Form
    {
        SqlConnection cn = new SqlConnection("Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True");
        SqlCommand cmD;
        SqlDataAdapter dA;
        CurrencyManager Cm;
        DataTable Dt = new DataTable();
        SqlCommandBuilder CMB;
        SqlCommand cmB;
        SqlDataReader DR;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regestaring f2 = new Regestaring();
            this.Hide();
            f2.ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmD = new SqlCommand("select PlaceName,AdminID,Kind,StreetAddress,PostalCode,PlacePhone,Rating,Review from places where PlaceName='" + textBox1.Text + "'", cn);
                cn.Open();
                DR = cmD.ExecuteReader();
                DR.Read();
                textBox2.Text = DR["PlaceName"].ToString();
                textBox3.Text = DR["AdminID"].ToString();
                textBox4.Text = DR["Kind"].ToString();
                textBox5.Text = DR["StreetAddress"].ToString();
                textBox6.Text = DR["PostalCode"].ToString();
                textBox7.Text = DR["PlacePhone"].ToString();
                textBox8.Text = DR["Rating"].ToString();
                textBox9.Text = DR["Review"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                DR.Close();
                cn.Close();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
        }
        void fillDataGridview()
        {
            Dt.Clear();
            Cm = (CurrencyManager)this.BindingContext[Dt];
            cmD = new SqlCommand("DisplayPlaces", cn);
            cmD.CommandType = CommandType.StoredProcedure;
            dA = new SqlDataAdapter(cmD);
            dA.Fill(Dt);
            this.dataGridView3.DataSource = Dt;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillDataGridview();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmD= new SqlCommand("INSERT INTO places (PlaceName,AdminID,Kind,StreetAddress,PostalCode,PlacePhone,Rating,Review)values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", cn);

            cmD.ExecuteNonQuery();
            MessageBox.Show("Added Successfully Please Visit Us Again ^_^ ", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cm.AddNew();
            textBox2.Focus();
        }

        
    }
}
