using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Integral.Classes
{
    internal interface ICalculator
    {
        public double Intagrate(double a, double b, int count, Func<double, double> F);
    }
}
