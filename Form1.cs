using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        int today, month, year;


        //vytvoření statických proměnnych pro předání mezi formuláři

        public static int static_month, static_year;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDays();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //vyprázdění kontejneru
            dayContainer.Controls.Clear();
            
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            { 
                month++;
            }
                static_month = month;
                static_year = year;
            
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonthYear.Text = monthname + " / " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);


            int days = DateTime.DaysInMonth(year, month);


            int dayOfTheWeek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 2; i < dayOfTheWeek; i++)
            {
                UserControlBlanks ucblanks = new UserControlBlanks();
                dayContainer.Controls.Add(ucblanks);

            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);
                
                dayContainer.Controls.Add(ucdays);

                if (month == DateTime.Now.Month)
                {
                    if (i == today)
                    {
                        ucdays.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        ucdays.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //vyprázdění kontejneru
            dayContainer.Controls.Clear();
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonthYear.Text = monthname + " / " + year;


            DateTime startofthemonth = new DateTime(year, month, 1);


            int days = DateTime.DaysInMonth(year, month);


            int dayOfTheWeek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 2; i < dayOfTheWeek; i++)
            {                
                UserControlBlanks ucblanks = new UserControlBlanks();
                dayContainer.Controls.Add(ucblanks);
            }

            for (int i = 1; i <= days; i++)
            {
                    UserControlDays ucdays = new UserControlDays();
                    ucdays.Days(i);
                    dayContainer.Controls.Add(ucdays);

                if (month == DateTime.Now.Month)
                {
                    if (i == today)
                    {
                        ucdays.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        ucdays.BackColor = Color.LightGray;
                    }
                }

            }
        }

        private void GetDays()
        {

            DateTime now = DateTime.Now;
            today = DateTime.Today.Day;
            month = now.Month;
            year = now.Year;


            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonthYear.Text = monthname + " / " + year;

            static_month = month;
            static_year = year;

            //get první den v měsíci
            DateTime startofthemonth = new DateTime(year, month, 1);

            //get dny v měsíci
            int days = DateTime.DaysInMonth(year, month);

            //překonvertování dayOfTheMonth na int
            int dayOfTheWeek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            //vytvoření čtverečků pro userCOntrolBlanks
            for (int i = 2; i < dayOfTheWeek; i++) 
            {
                UserControlBlanks ucblanks = new UserControlBlanks();
                dayContainer.Controls.Add(ucblanks);
            }

            for (int i = 1; i <= days; i++)
            {
                
                
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);
                dayContainer.Controls.Add(ucdays);
                
                if (i == today)
                {
                    ucdays.BackColor = Color.LawnGreen;
                }
                else
                {
                    ucdays.BackColor = Color.LightGray;
                }

            }
        }
    }
}
