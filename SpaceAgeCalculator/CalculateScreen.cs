using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceAgeCalculator
{
    public partial class CalculateScreen : Form
    {
        string planetName;
        string file;
        int age;
        float earthSeconds;
        float totalSeconds;
        float orbitalPeriod;

        int seconds;
        int minutes;
        int hours;
        int days;

        public CalculateScreen(string planetName, string file, float earthSeconds, float totalSeconds, float orbitalPeriod)
        {
            InitializeComponent();
            this.planetName = "Planet " + planetName;
            this.file = file;
            this.earthSeconds = earthSeconds;
            this.totalSeconds = totalSeconds;
            this.orbitalPeriod = orbitalPeriod;

            calculateTime();   
        }

        private void CalculateScreen_Load(object sender, EventArgs e)
        {
            age = Convert.ToInt32(Math.Truncate(totalSeconds / 60.0f / 60.0f / 24.0f / 365.25f));
            lblPlanetName.Text = planetName.ToString();
            lblSecondsOld.Text = "" + earthSeconds + " seconds old";
            lblSeconds.Text = seconds.ToString() + " seconds";
            lblMinutes.Text = minutes.ToString() + " minutes";
            lblHours.Text = hours.ToString() + " hours";
            lblDays.Text = days.ToString() + " days";

            PictureBox imageControl = new PictureBox();
            imageControl.Width = 400;
            imageControl.Height = 400;

            imageControl.Dock = DockStyle.Fill;
            planetImage.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Images/"+file));

            lblYearsOld.Text = age.ToString() + " years old!";
        }

        private void calculateTime()
        {
            seconds = Convert.ToInt32(earthSeconds % 60);
            minutes = Convert.ToInt32(Math.Truncate((earthSeconds % 3600) / 60));
            hours = Convert.ToInt32(Math.Truncate((earthSeconds % (orbitalPeriod * 86400)) / 3600));
            days = Convert.ToInt32(Math.Truncate((earthSeconds % (orbitalPeriod * 31557600)) / 86400));
        }
    }
}
