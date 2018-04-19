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
    public partial class Form2 : Form
    {
        private const string databaseName = @"..\..\DB\Airports.db";
        private SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
        string cmd = "SELECT * FROM aircraft;";
        SQLiteDataAdapter da;
        SQLiteCommandBuilder commandBuilder;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form1 form1 = new Form1();
            form1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection.Open();
            string cmd = "SELECT * FROM aircraft;";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "aircraft");
            dataGridView1.DataSource = ds.Tables["aircraft"];
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.Columns[0].Visible = false;
            DataGridViewRow row = this.dataGridView1.RowTemplate;
            row.Height = 40;

            dataGridView1.Columns[1].HeaderText = "Номер Рейса";
            dataGridView1.Columns[2].HeaderText = "Город";
            dataGridView1.Columns[3].HeaderText = "Модель самолёта";
            dataGridView1.Columns[4].HeaderText = "Время";


            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 176;
            dataGridView1.Columns[3].Width = 176;
            dataGridView1.Columns[4].Width = 120;
            //dataGridView1.Columns[5].Width = 188;


          
        }
    }
}
