using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UniversitySystem
{
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }

        private void Section_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select s.SectionId, st.StudentName, st.Gender, st.Email, s.Section from sectiontab s inner join studentab st on s.StudentId = st.StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into sectiontab values(@sectionid,@studentid,@section)", con);
            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentid", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@section", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select s.SectionId, st.StudentName, st.Gender, st.Email, s.Section from sectiontab s inner join studentab st on s.StudentId = st.StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("update sectiontab set StudentId=@studentid,Section=@section where SectionId=@sectionid", con);
            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentid", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@section", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete sectiontab where SectionId=@sectionid", con);
            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select s.SectionId, st.StudentName, st.Gender, st.Email, s.Section from sectiontab s inner join studentab st on s.StudentId = st.StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
