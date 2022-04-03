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

namespace sql_prac
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand(con);
        //SqlDataReader dt = cmd.ExecuteReader();
        public Form2(SqlDataReader dt)
        {
            InitializeComponent();
            DataTable dd = new DataTable();
            dd.Load(dt);
            dataGridView1.DataSource = dd;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
