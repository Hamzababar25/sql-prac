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
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
       
        //2.establish connection 
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True");

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    string ConnectionString = "Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True";
 //2.establish connection 
          //SqlConnection con = new SqlConnection(ConnectionString);
            //3.Open connection
            con.Open();
            //4.query
            string roll = textBox1.Text;
            string name = textBox2.Text;
            string fname = textBox3.Text;
            string dep = textBox4.Text;
            string Query = "INSERT INTO studentt (rollno, name,fathername,depatment)VALUES('" + roll + "', '" + name + "', '" + fname + "', '" + dep + "')";
 //5.execute
          SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //6.close
            con.Close();
            MessageBox.Show("data saved");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  string ConnectionString = "Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True";
           // SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "select * from studentt ";
            
            SqlCommand cmd = new SqlCommand(Query, con);
              
           // var reader = cmd.ExecuteReader();
            DataTable data = new DataTable();
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
          
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // string ConnectionString = "Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True";
           // SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            /*string roolid = textBox1.Text;
            string namee = textBox2.Text;
            string fnamee = textBox3.Text;
            string depp = textBox4.Text;*/
            string Query = "update studentt set name='" + textBox1.Text + "',fathername='" +
           textBox2.Text + "',depatment='" + textBox3.Text + "'where rollno='" + textBox4.Text + "'";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string ConnectionString = "Data Source=DESKTOP-OT87DKU\\SQLEXPRESS;Initial Catalog=emp;Integrated Security=True";
            //SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string roolid = textBox1.Text;
           
            string Query = "delete from studentt where rollno='" + roolid + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data deleted");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string Query = "select * from studentt ";

            SqlCommand cmd = new SqlCommand(Query, con);

            // var reader = cmd.ExecuteReader();
            DataTable data = new DataTable();

            SqlDataReader da = cmd.ExecuteReader();
            // DataTable dd = new DataTable();
            // dd.Load(da);
            Form2 form = new Form2(da);
            form.Show();

           // dataGridView1.DataSource = da;
            con.Close();
           
        }
    }
}
