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
    public partial class Form4 : Form
    {
        
            /*БЛОК ПОДКЛЮЧЕНИЯ*/
        //private const string databaseName = @"..\..\DB\aircraft.db";//Первая БД
        private const string databaseName2= @"..\..\DB\Airports.db";//Вторая БД(под курсач)
        //private SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
        private SQLiteConnection connection2 = new SQLiteConnection(string.Format("Data Source={0};",databaseName2));


        /*БЛОК ЗАПРОСОВ ДЛЯ БД*/
        //string cmd = "SELECT * FROM aircraft;";


        //string cmd = "SELECT * FROM Airports INNER JOIN Flights on Airports.id=Flights.id;";
        //string cmd = "SELECT * FROM Airports LEFT OUTER JOIN Flights on Airports.id=Flights.id;";
        //string cmd = "SELECT NumberFlight,City FROM Airports INNER JOIN Flights on Airports.id=Flights.id;";//fuck yeeeeeeee!!!
        string cmd = "SELECT NumberFlight,City,ModelAircraft,Time FROM Airports JOIN Flights on Airports.id=Flights.id JOIN Aircrafts on Airports.id=Aircrafts.id;";
        string cmd2 = "SELECT * FROM aircraft;";
        //string cmd1 = "SELECT City FROM Airports;";
        //string cmd3 = "SELECT ModelAircraft FROM Airports;";
        

        /*БЛОК УСТРОЙСТВ*/
        //SQLiteDataAdapter da;
        SQLiteDataAdapter da2;
        //SQLiteCommandBuilder commandBuilder;
        SQLiteCommandBuilder commandBuilder2;
        //DataSet ds;
        DataSet ds2;

        public Form4()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter adap = null;
        DataSet ds3 = new DataSet();


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form3 form3 = new Form3();
            form3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection2.Open();
            
            
            var dt = (DataTable)(dataGridView2.DataSource);

            foreach (DataRow dr in dt.Rows)
            {
                var City = dr["City"].ToString();
                var NumberFlight = dr["NumberFlight"].ToString();
                var ModelAircraft = dr["ModelAircraft"].ToString();
                var Time = dr["Time"].ToString();
                string sql = "insert into aircraft (NumberFlight,City,ModelAircraft,Time) values ( '" + NumberFlight + "','" + City + "','" + ModelAircraft + "','" + Time + "')";
                SQLiteCommand command = new SQLiteCommand(sql, connection2);
                command.ExecuteNonQuery();
            }
            connection2.Close();

            /*da = new SQLiteDataAdapter(cmd, connection);
                commandBuilder = new SQLiteCommandBuilder(da);
                dataGridView2.EndEdit();
                da.Update((DataTable)dataGridView2.DataSource);*/
            /*
           da2 = new SQLiteDataAdapter(cmd2, connection2);
           commandBuilder2 = new SQLiteCommandBuilder(da2);
           dataGridView2.EndEdit();
           da2.Update((DataTable)dataGridView2.DataSource);  */




        }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            /*БЛОК№1*/
            /*connection.Open();
            string cmd = "SELECT * FROM aircraft;";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "aircraft");
            dataGridView2.DataSource = ds.Tables["aircraft"];*
          
            /*НОВЫЙ БЛОК*/
            //string cmd11 = "SELECT NumberFlight FROM Flights,SELECT City FROM Airports;";

            connection2.Open();
            /*БЛОК№2*/
            
            SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd, connection2);
            DataTable dt = new DataTable();
            da2.Fill(dt);
            dataGridView2.DataSource = dt;
            // SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da2);
            connection2.Close();


        
            //SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd, connection2);
            //DataSet ds2 = new DataSet(); 
            //da2.Fill(ds2, "aircraft");
            // dataGridView2.DataSource = ds2.Tables["aircraft"];
            //



        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }

        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();

            form7.Show();
            Form4 form4 = new Form4();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            form8.Show();
            Form4 form4 = new Form4();
            Visible = false;
        }
    }
}
