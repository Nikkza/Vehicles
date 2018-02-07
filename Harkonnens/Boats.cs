using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harkonnens
{
    class Boats : IVehicle
    {
        public string name { get; private set; }
        public int speed { get; private set; }
        public string metricSpeed { get; private set; }

        public Boats(int randomSpeed, string Name)
        {
            speed = randomSpeed;
            metricSpeed = "knots";
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

        public void SetName(string Name)
        {
            name = Name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
