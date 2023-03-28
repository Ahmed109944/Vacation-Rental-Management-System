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
    public partial class Form6 : Form
    {
        SqlConnection cn = new SqlConnection("Server=flash20-9-2018\\SQLEXPRESS;DataBase=Vacation Rental System;Integrated Security=True");
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        CurrencyManager Cm;
        SqlCommandBuilder Cmb;
        SqlCommand Cmd;
        SqlDataReader Dr;
        public Form6()
        {
            InitializeComponent();
            Da = new SqlDataAdapter("select * from Users", cn);
            Da.Fill(Dt);
            txtAdminID.DataBindings.Add("Text", Dt, "AdminID");
            txtUserID.DataBindings.Add("Text", Dt, "UserID");
            txtUserName.DataBindings.Add("Text", Dt, "UserName");
            txtPlaceName.DataBindings.Add("Text", Dt, "PlaceName");
            txtAdg.DataBindings.Add("Text", Dt, "Age");
            txtAddress.DataBindings.Add("Text", Dt, "Address");
            txtGender.DataBindings.Add("Text", Dt, "Gender");
            txtPhone.DataBindings.Add("Text", Dt, "Phone");
            txtPassword.DataBindings.Add("Text", Dt, "Password");
            Cm =(CurrencyManager) this.BindingContext[Dt];
            Cmd = new SqlCommand("Displayplaces", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            this.dataGridView1.DataSource = Dt;
        }

        private void First_Click(object sender, EventArgs e)
        {
            Cm.Position = 0;
            lblposition.Text = (Cm.Position + 1) + "/" + (Dt.Rows.Count);
        }

        private void previous_click_Click(object sender, EventArgs e)
        {
            Cm.Position -=1;
            lblposition.Text = (Cm.Position + 1) + "/" + (Dt.Rows.Count);
        }

        private void Next_Click_Click(object sender, EventArgs e)
        {
            Cm.Position += 1;
            lblposition.Text = (Cm.Position + 1) + "/" + (Dt.Rows.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cm.Position =Dt.Rows.Count-1;
            lblposition.Text = (Cm.Position + 1) + "/" + (Dt.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cm.AddNew();
            txtUserID.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            Cmd=new SqlCommand("INSERT INTO Users (AdminID,UserID,UserName,PlaceName,Age,Address,Gender,Phone,Password)VALUES('"+txtAdminID.Text+"','"+txtUserID.Text+"','"+txtUserName.Text+"','"+txtPlaceName.Text+"','"+txtAdg.Text+"','"+txtAddress.Text+"','"+txtGender.Text+"','"+txtPhone.Text+"','"+txtPassword.Text+"')",cn);
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Added Successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("DeleteUsers",cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param=new SqlParameter("@userid",SqlDbType.Int);
            param.Value=txtUserID.Text;
            Cmd.Parameters.Add(param);
            cn.Open();
            Cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                Cmd = new SqlCommand("Update Users set UserID ='" + txtUserID.Text + "',AdminID ='" + txtAdminID.Text + "',UserName='" + txtUserName.Text + "',Age='" + txtAdg.Text + "',Gender='" + txtGender.Text + "',Phone='" + txtPhone.Text + "',PlaceName='" + txtPlaceName.Text + "',Password='" + txtPassword.Text + "' where UserID='" + txtUserID.Text + "'", cn);
                Cmd.ExecuteNonQuery();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Cmd = new SqlCommand("select UserID,AdminID,UserName,Age,Address,Gender,Phone,PlaceName,Password from Users where UserID='" + txtsearch.Text + "'", cn);
                cn.Open();
                Dr = Cmd.ExecuteReader();
                Dr.Read();
                txtAdminID.Text = Dr["AdminID"].ToString();
                txtUserID.Text = Dr["UserID"].ToString();
                txtUserName.Text = Dr["UserName"].ToString();
                txtPlaceName.Text = Dr["PlaceName"].ToString();
                txtAdg.Text = Dr["Age"].ToString();
                txtAddress.Text = Dr["Address"].ToString();
                txtGender.Text = Dr["Gender"].ToString();
                txtPhone.Text = Dr["Phone"].ToString();
                txtPassword.Text = Dr["Password"].ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally 
            {
                Dr.Close();
                cn.Close();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
