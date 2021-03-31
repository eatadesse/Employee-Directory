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

namespace Employee
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection("Data Source=ELSHU-YOGA\nSQLEXPRESS01;Initial Catalog=Employee;Persist Security Info=True;User ID = username;Password = password");


        private void button1_Click(object sender, EventArgs e)
        {
            
                con.Open();
                SqlCommand command = new SqlCommand("insert into Employee_detail('" + int.Parse(textBoxID.Text) + "','" + textBoxFname.Text + "','" + textBoxLname.Text + "','" + textBoxTitle.Text + "','" + textBoxEmail.Text + "','" + int.Parse(textBoxPhone.Text) + "','" + comboBoxGender.Text + " ')", con);
            command.ExecuteNonQuery();
                MessageBox.Show("Succesfully Inserted.");
                con.Close();
                BindData();
            }
            void BindData()
        {
            SqlCommand command = new SqlCommand("select * from employee_detail", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable x = new DataTable();
            sd.Fill(x);
            dataGridView1.DataSource = x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update employee_detail set firstName = '"+ textBoxFname.Text + "', lastName = '" + textBoxLname.Text + "', title = '" + textBoxTitle.Text + "', email = '" + textBoxEmail.Text + "', phone = '" + +int.Parse(textBoxPhone.Text) + "', gender = '" + comboBoxGender.Text  + "' where EmployerID = '" + int.Parse(textBoxID.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesfully Updated.");
            BindData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text != "")
            {
                if (MessageBox.Show("Are you sre you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete Employee_detail where EmployeeID = '" + int.Parse(textBoxID.Text) + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Deleted.");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Put Employee ID");
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Employee_detail where EmployerID = '" + int.Parse(textBoxID.Text) + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable x = new DataTable();
            sd.Fill(x);
            dataGridView1.DataSource = x;
        }
    }
    
}
