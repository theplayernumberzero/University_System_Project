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

namespace UniversitySystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display1();
            display2();
            display3();
            display4();
        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count > 0)
            {
                lblCountStudent.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCountStudent.Text = "0";
            }
            con.Close();
        }
        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM subtab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCountSubject.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCountSubject.Text = "0";
            }
            con.Close();
        }
        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM teachertab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCountTeacher.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCountTeacher.Text = "0";
            }
            con.Close();
        }
        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ITDVNJL;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM entab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCountEnrollment.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCountEnrollment.Text = "0";
            }
            con.Close();
        }
    }
}
