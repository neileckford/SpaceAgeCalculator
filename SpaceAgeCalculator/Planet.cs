using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgeCalculator
{
    class Planet
    {
        string name;
        float orbitalPeriod;
        string filePath;

        public Planet(string n, float orbit, string path)
        {
            name = n;
            orbitalPeriod = orbit;
            filePath = path;
        }

        public float calculateAge(long seconds)
        {
            return seconds / orbitalPeriod;
        }

        public string getName()
        {
            return name;
        }

        public float getOrbital()
        {
            return orbitalPeriod;
        }

        public string getPath()
        {
            return filePath;
        }
    }
}
