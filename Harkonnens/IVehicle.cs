using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levis
{
    interface IVehicle
    {
        int speed { get; }
        string metricSpeed { get; }
        string name { get; }

        void SetSpeed(int Speed);
        int GetSpeed();

        void SetMetricSpeed(string MetricSpeed);
        string GetMetricSpeed();

        void SetName(string Name);
        string GetName();

    }
}
