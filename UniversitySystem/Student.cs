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

namespace UniversitySystem
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back) 
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into studentab values(@studentid,@studentname,@dob,@gender,@phone,@email)", con);
            cnn.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
            cnn.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@email", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("update studentab set StudentName=@studentname,Dob=@dob,Gender=@gender,Phone=@phone,Email=@email where StudentId=@studentid", con);
            cnn.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
            cnn.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@email", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete studentab where StudentId=@studentid", con);
            cnn.Parameters.AddWithValue("@studentid", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student Deleted Succesfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
