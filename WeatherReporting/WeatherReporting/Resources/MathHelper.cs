using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting.Resources
{
    public class MathHelper
    {
        public static bool CheckVariance(double actualValue, int varianceVal)
        {
            if (actualValue >= -varianceVal && actualValue <= varianceVal)
                return true;
            else
                return false;
        }
    }
}
