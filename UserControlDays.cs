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
using Calendar;
using System.Diagnostics.Tracing;
using MySql.Data.MySqlClient;

namespace Calendar
{
    public partial class UserControlDays : UserControl
    {
        public static string statick_day;
        String connString = "server=localhost;user id=root;password=root;database=calendar;sslmode=none";



        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            statick_day = lblDays.Text;

            //spuštení timeru
            timer1.Start();

            FormEvent formEvent = new FormEvent();
            formEvent.Show();
        }

        public void Days(int numDay)
        {
            lblDays.Text = numDay + "";
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        //vytvoření nové metody pro zobrazení události
        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT nazev FROM tbl_event WHERE datum = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("datum", lblDays.Text + "-" + Form1.static_month + "-" + Form1.static_year);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lblEvent.Text = reader["nazev"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
    }
}
