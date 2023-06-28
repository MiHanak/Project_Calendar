using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar;
using MySql.Data.MySqlClient;

namespace Calendar
{
    public partial class FormEvent : Form
    {
        //Vytvoření spojení

        String connString = "server=localhost;user id=root;password=root;database=calendar;sslmode=none";


        public FormEvent()
        {
            InitializeComponent();
        }

        private void Event_Load(object sender, EventArgs e)
        {
            //generování datumu v textboxu
            txtDate.Text = UserControlDays.statick_day + "-" + Form1.static_month + "-" + Form1.static_year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "INSERT INTO tbl_event(datum,nazev,popis)values(?,?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("datum", txtDate.Text);
            cmd.Parameters.AddWithValue("nazev", txtNameEvent.Text);
            cmd.Parameters.AddWithValue("popis", txtDescription.Text);
            cmd.ExecuteNonQuery();

            //Informační zpráva
            MessageBox.Show("Událost přidána");
            cmd.Dispose();
            conn.Close();

            FormEvent.ActiveForm.Close();

        }
    }
}
