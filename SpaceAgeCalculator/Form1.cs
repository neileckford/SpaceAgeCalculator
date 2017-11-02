using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceAgeCalculator
{
    public partial class Form1 : Form
    {
        List<Planet> planets = new List<Planet>();
        long seconds;

        public Form1()
        {
            InitializeComponent();
            addPlanets();
            populateList();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            PictureBox imageControl = new PictureBox();
            imageControl.Width = 400;
            imageControl.Height = 300;

            imageControl.Dock = DockStyle.Fill;
            pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Images/" + "solarSystem.jpg"));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectPlanet();
        }

        private void addPlanets()
        {
            planets.Add(new Planet("Mercury", 0.2408467f, "mercury.jpg"));
            planets.Add(new Planet("Venus", 0.61519726f, "venus.jpg"));
            planets.Add(new Planet("Earth", 1.0f, "earth.jpg"));
            planets.Add(new Planet("Mars", 1.8808158f, "mars.jpg"));
            planets.Add(new Planet("Jupiter", 11.862610f, "jupiter.jpg"));
            planets.Add(new Planet("Saturn", 29.447498f, "saturn.jpg"));
            planets.Add(new Planet("Uranus", 84.016846f, "uranus.jpg"));
            planets.Add(new Planet("Neptune", 164.79132f, "neptune.jpg"));
            planets.Add(new Planet("Pluto", 248.0f, "pluto.jpg"));
        }

        private void populateList()
        {
            foreach (Planet p in planets)
            {
                cbxPlanet.Items.Add(p.getName());
            }
        }

        private void selectPlanet()
        {
            seconds = (DateTime.Now.Ticks - dateTimePicker1.Value.Ticks)/10000000;
            bool exists = false;
            
            try
            {
                foreach (Planet p in planets)
                {
                    if (cbxPlanet.Text == p.getName())
                    {
                        CalculateScreen calcScreen = new CalculateScreen(p.getName(), p.getPath(), seconds, p.calculateAge(seconds), p.getOrbital());
                        calcScreen.Show();
                        exists = true;
                    }
                }
                if (!exists)
                    MessageBox.Show("planet not found");
            }
            catch (Exception ex) { } 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
