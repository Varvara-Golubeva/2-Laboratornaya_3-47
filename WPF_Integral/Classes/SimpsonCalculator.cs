using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPF_Integral.Classes
{
    internal class SimpsonCalculator : ICalculator
    {
        public double Intagrate(double a, double b, int count, Func<double, double> F)
        {
            
            if (count % 2 != 0)
            {
                throw new ArgumentException("Количество разбиений (count) должно быть чётным для метода Симпсона.", nameof(count));
            }

            double h = (b - a) / count;
            double sum = F(a) + F(b); 

            for (int i = 1; i < count; i++)
            {
                double x = a + i * h;

                if (i % 2 == 0)
                {
                    // Чётные индексы (кроме 0 и count) имеют коэффициент 2
                    sum += 2 * F(x);
                }
                else
                {
                    // Нечётные индексы имеют коэффициент 4
                    sum += 4 * F(x);
                }
            }

            return (h / 3) * sum;
        }
    }
}
