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

namespace FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                string message = "Please provide connection string and job name";
                string title = "Warning";
                MessageBox.Show(message, title);
                return;
            }
            // "Server = localhost; Database = Northwind; User Id = berk; Password = 12345678;"
            SqlConnection DbConn = new SqlConnection(textBox1.Text);
            SqlCommand ExecJob = new SqlCommand();
            ExecJob.CommandType = CommandType.StoredProcedure;
            ExecJob.CommandText = "msdb.dbo.sp_start_job";
            // "SourceToStagingJob"
            ExecJob.Parameters.AddWithValue("@job_name", textBox2.Text);
            ExecJob.Connection = DbConn; 
            
            try
            {
                using (DbConn)
                {
                    DbConn.Open();
                    using (ExecJob)
                    {
                        ExecJob.ExecuteNonQuery();
                        string message = textBox2.Text + " Job is started.";
                        string title = "Congrats!";
                        MessageBox.Show(message, title);
                    }
                }
            } catch (Exception ex)
            {
                string title = "Error!";
                MessageBox.Show(ex.Message, title);
            }

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
