using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levis
{
    class Motorcycle : IVehicle
    {
        public int speed { get; private set; }
        public string metricSpeed { get; private set; }
        public string name { get; private set; }

        public Motorcycle(int randomSpeed, string Name)
        {
            speed = randomSpeed;
            metricSpeed = "km/h";
            name = Name;
        }

        public void SetSpeed(int Speed)
        {
            speed = Speed;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public string GetMetricSpeed()
        {
            return metricSpeed;
        }

        public void SetMetricSpeed(string MetricSpeed)
        {
            metricSpeed = MetricSpeed;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }
    }
}
