using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Integral.Classes;

namespace WPF_Integral
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        private void DoCalculate()
        {
            double a = Convert.ToDouble(tbLower.Text);
            double b = Convert.ToDouble(tbUpper.Text);
            int n = Convert.ToInt32(tbCount.Text);
            ICalculator calc = GetCalculator();
            Func<double, double> F = x => 2 * x - Math.Log(2 * x) + 234;
            double result = calc.Intagrate(a, b, n, F); 
            tbResult.Text = result.ToString();
        }

        private ICalculator GetCalculator()
        {
            ICalculator calculator = null;
            if (cbMethod.SelectedIndex == 0)
            {
                calculator= new SimpsonCalculator();
            }
            else if (cbMethod.SelectedIndex == 1)
            {
                calculator = new TrapezoidCalculator();
            }
            return calculator;
        }
    }
}