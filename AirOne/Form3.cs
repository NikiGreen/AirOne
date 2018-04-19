using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirOne
{
    public partial class Form3 : Form
    {
        private const string databaseName = @"..\..\DB\Login.db";
        private SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form1 form1 = new Form1();
            form1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Password';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Form4 form4 = new Form4();


            string login = textBox1.Text;
            string password = textBox2.Text;

            string title = "";
            string pass = "";

            foreach (DbDataRecord record in reader)
            {
                title = record["NickName"].ToString();
                pass = record["Password"].ToString();
            }

            if (textBox1.Text == title && textBox2.Text == pass)
            {
                form4.Show();
                Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            connection.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
