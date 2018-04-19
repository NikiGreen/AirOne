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
    public partial class Form8 : Form
    {
        private const string databaseName = @"..\..\DB\Airports.db";
        private SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));

        string cmd = "SELECT * FROM Passenger2;";

        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form4 form4 = new Form4();
            form4.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection.Open();


            var dt = (DataTable)(dataGridView1.DataSource);

            foreach (DataRow dr in dt.Rows)
            {
                var id = dr["id"].ToString();
                var Passenger = dr["Passenger"].ToString();
                var NumberFlight = dr["NumberFlight"].ToString();
               
                string sql = "UPDATE Passengers SET Passenger='"+Passenger+"',NumberFlight='"+NumberFlight+"' where id='"+id+"' ";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
