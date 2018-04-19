using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirOne
{
    public partial class Form7 : Form
    {
        private const string databaseName = @"..\..\DB\Airports.db";
        private SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
        string City;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            connection.Open();
            /*БЛОК№2*/

            string cmd = "SELECT * FROM Passengers;";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Passengers");
            dataGridView1.DataSource = ds.Tables["Passengers"];
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form4 form4 = new Form4();
            form4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Поиск по рейсу*/
            connection.Open();
            string NumberFlight = textBox1.Text;
            string cmd = "SELECT Passenger FROM Passengers where NumberFlight='" + NumberFlight + "';";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Passengers");
            dataGridView1.DataSource = ds.Tables["Passengers"];
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

            panel3.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            panel3.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
                    }

        private void button7_Click(object sender, EventArgs e)
        {
            

            panel3.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            /*Поиск по модели самолёта*/
            connection.Open();

            string cmd_1 = "SELECT NumberFlight FROM aircraft where ModelAircraft='" + textBox3.Text + "';";
            SQLiteDataAdapter Model1 = new SQLiteDataAdapter(cmd_1, connection);
            SQLiteDataReader sqlRead = Model1.SelectCommand.ExecuteReader();
            if (sqlRead.Read())
                City = sqlRead[0].ToString();

            string cmd = "SELECT Passenger FROM Passengers where NumberFlight='" + City + "';";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Passengers");
            dataGridView1.DataSource = ds.Tables["Passengers"];
            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            /*Поиск по месту назначения*/
            connection.Open();
           
            string cmd_1 = "SELECT NumberFlight FROM aircraft where City='" + textBox2.Text + "';";
            SQLiteDataAdapter City1 = new SQLiteDataAdapter(cmd_1,connection);
            SQLiteDataReader sqlRead = City1.SelectCommand.ExecuteReader();
            if (sqlRead.Read())
                City = sqlRead[0].ToString();
            
            string cmd = "SELECT Passenger FROM Passengers where NumberFlight='" + City + "';";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Passengers");
            dataGridView1.DataSource = ds.Tables["Passengers"];
            connection.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            connection.Open();
            /*БЛОК№2*/

            string cmd = "SELECT * FROM Passengers;";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Passengers");
            dataGridView1.DataSource = ds.Tables["Passengers"];
            connection.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
