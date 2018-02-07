using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levis
{
    class Car : IVehicle
    {
        public int speed { get; private set; }
        public string metricSpeed { get; private set; }
        public string name { get; private set; }

        public Car(int randomSpeed, string Name)
        {
            speed = randomSpeed;
            metricSpeed = "mph";
            name = Name;
        }

        public void SetSpeed(int Speed)
        {
            speed = Speed;
        }
        public void SetMetricSpeed(string MetricSpeed)
        {
            metricSpeed = MetricSpeed;
        }
        public void SetName (string Name)
        {
            name = Name;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public string GetMetricSpeed()
        {
            return metricSpeed;
        }
        public string GetName()
        {
            return name;
        }
    }
}
