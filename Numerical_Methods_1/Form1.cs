using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Methods_1
{
    public partial class Form1 : Form
    {
        const double Pi = 3.141592653589793;
        const double h = Pi / 7;
        public Form1()
        {
            InitializeComponent();
        }

        double f(double x)
        {
            return Math.Sin(x)*Math.Sqrt(x) + 1;
        }

        double Phi(double x, int i)
        {
            double[] x_array = new double[5] { h / 2, h * 3 / 2, h * 5 / 2, h * 9 / 2, h * 13 / 2 };
            double Phi_Result = 1;
            int j = 1;

            while (j <= 5)
            {
                if (i != j) Phi_Result *= (x - x_array[j - 1]) /(x_array[i - 1] - x_array[j - 1]);
                j++;
            }

            return Phi_Result;
        }

        double L(double x)
        {
            double[] x_array = new double[5] { h / 2, h * 3 / 2, h * 5 / 2, h * 9 / 2, h * 13 / 2 };
            int i = 1;
            double L_Result = 0;

            while (i <= 5)
            {
                L_Result += f(x_array[i - 1]) * Phi(x, i);
                i++;
            }

            return L_Result;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            double[] x_array = new double[5] { h / 2, h * 3 / 2, h * 5 / 2, h * 9 / 2, h * 13 / 2 };
            double a = 0, b = 2 * Pi, step = 0.1;
            double x = a + step, y;
            this.chart1.Series[0].Points.Clear();

            while (x < b)
            {
                y = L(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += step;
            }
        }
    }
}
