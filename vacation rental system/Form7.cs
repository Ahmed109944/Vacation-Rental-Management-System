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
    public partial class Form7 : Form
    {
        SqlConnection cn = new SqlConnection("Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True");
        SqlDataAdapter DA;
        CurrencyManager CM;
        DataTable DT = new DataTable();
        SqlCommandBuilder CMB;
        SqlCommand CMD;
        SqlDataReader DR;
        public Form7()
        {
            InitializeComponent();
            DA = new SqlDataAdapter("select*from places", cn);
            DA.Fill(DT);
            textBox1.DataBindings.Add("Text", DT, "PlaceName");
            textBox2.DataBindings.Add("Text", DT, "AdminID");
            textBox3.DataBindings.Add("Text", DT, "Kind");
            textBox4.DataBindings.Add("Text", DT, "StreetAddress");
            textBox5.DataBindings.Add("Text", DT, "PostalCode");
            textBox6.DataBindings.Add("Text", DT, "PlacePhone");
            textBox7.DataBindings.Add("Text", DT, "Rating");
            textBox8.DataBindings.Add("Text", DT, "Review");
            CM = (CurrencyManager)this.BindingContext[DT];
            CMD = new SqlCommand("DisplayUsers", cn);
            CMD.CommandType = CommandType.StoredProcedure;
            DA = new SqlDataAdapter(CMD);
            DA.Fill(DT);
            this.dataGridView2.DataSource = DT;
        }
        

        private void FirstOne_Click(object sender, EventArgs e)
        {
            CM.Position = 0;
            lblPosition.Text = (CM.Position + 1) + "/" + (DT.Rows.Count);
        }

        private void previous_Click(object sender, EventArgs e)
        {
            CM.Position -= 1;
            lblPosition.Text = (CM.Position + 1) + "/" + (DT.Rows.Count);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            CM.Position += 1;
            lblPosition.Text = (CM.Position + 1) + "/" + (DT.Rows.Count);
        }

        private void LastOne_Click(object sender, EventArgs e)
        {
            CM.Position =DT.Rows.Count-1;
            lblPosition.Text = (CM.Position + 1) + "/" + (DT.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CM.AddNew();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                cn.Open();
                CMD = new SqlCommand("INSERT INTO places (PlaceName,AdminID,Kind,StreetAddress,PostalCode,PlacePhone,Rating,Review)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", cn);
                
                CMD.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CMD = new SqlCommand("DeletePlaces", cn);
            CMD.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@placeName", SqlDbType.NVarChar, 50);
            param.Value = textBox1.Text;
            CMD.Parameters.Add(param);
            cn.Open();
            CMD.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                CMD = new SqlCommand("Update places set PlaceName ='" + textBox1.Text + "',AdminID ='" + textBox2.Text + "',Kind='" + textBox3.Text + "',StreetAddress='" + textBox4.Text + "',PostalCode='" + textBox5.Text + "',PlacePhone='" + textBox6.Text + "',Rating='" + textBox7.Text + "',Review='" + textBox8.Text + "' where PlaceName='" + textBox1.Text + "'", cn);
                
                CMD.ExecuteNonQuery();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CMD = new SqlCommand("select PlaceName,AdminID,Kind,StreetAddress,PostalCode,PlacePhone,Rating,Review from places where PlaceName='" + textBox9.Text + "'", cn);
                cn.Open();
                DR = CMD.ExecuteReader();
                DR.Read();
                textBox1.Text = DR["PlaceName"].ToString();
                textBox2.Text = DR["AdminID"].ToString();
                textBox3.Text = DR["Kind"].ToString();
                textBox4.Text = DR["StreetAddress"].ToString();
                textBox5.Text = DR["PostalCode"].ToString();
                textBox6.Text = DR["PlacePhone"].ToString();
                textBox7.Text = DR["Rating"].ToString();
                textBox8.Text = DR["Review"].ToString();

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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }
          

    }
}