using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Очищення графіку
            chart1.Series.Clear();

            // Введення коефіцієнтів з клавіатури
            double x0 = Convert.ToDouble(txt_a.Text);
            double y0 = Convert.ToDouble(txt_b.Text);
            double R = Convert.ToDouble(txt_r.Text);

            // Область визначення функції
            double[] t = new double[500];
            double dt = 2 * Math.PI / 500;
            for (int i = 0; i < 500; i++)
            {
                t[i] = i * dt;
            }

            // Параметричне рівняння кривої
            double[] x = new double[500];
            double[] y = new double[500];
            for (int i = 0; i < 500; i++)
            {
                x[i] = x0 + R * Math.Cos(t[i]);
                y[i] = y0 + R * Math.Sin(t[i]);
            }

            // Побудова графіку
            Series series = chart1.Series.Add("Функція");
            series.ChartType = SeriesChartType.Line;
            for (int i = 0; i < 500; i++)
            {
                series.Points.AddXY(x[i], y[i]);
            }

            // Налаштування вісей та заголовку
            chart1.ChartAreas[0].AxisX.Minimum = x0 - R;
            chart1.ChartAreas[0].AxisX.Maximum = x0 + R;
            chart1.ChartAreas[0].AxisX.Title = "x";
            chart1.ChartAreas[0].AxisY.Minimum = y0 - R;
            chart1.ChartAreas[0].AxisY.Maximum = y0 + R;
            chart1.ChartAreas[0].AxisY.Title = "y";
            chart1.Titles.Clear();
            chart1.Titles.Add("Графік функції");
        }

        
    }

}

