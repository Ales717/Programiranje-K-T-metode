using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Naloga3
{
    public partial class Form5 : Form
    {
        public string izbira;
        public int index;
        public string[] alt;
        public string[,] data;
        double[] rezultati1;
        public Form5(string izbira, int index, string[] alt, string[,] data, double[] rezultati1)
        {
            InitializeComponent();
            this.izbira = izbira;
            this.index = index;
            this.alt = alt;
            this.data = data;
            this.rezultati1 = rezultati1;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = "Izbran parameter: " + izbira;
            string[,] graf = new string[2, alt.Length];
            double[,] dataY = new double[11, alt.Length];
            double[] dataX = new double[10];

            string[,] data2 = new string[data.GetLength(0) - 2, data.GetLength(1) -1];
            


            for (int i = 0; i < alt.Length; i++)
            {
                graf[0, i] = alt[i];
                graf[1, i] = data[index+1,i+1];
            }

            for (int i = 0; i < alt.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dataX[j] = j + 1;
                    dataY[j, i] = (int.Parse(graf[1, i]) * j) + rezultati1[i];
                }
            }
            for (int i = 0; i < alt.Length; i++)
            {
                double[] row = new double[10];
                for (int j = 0; j < 10; j++)
                {
                    row[j] = dataY[j, i];
                }
                formsPlot1.plt.PlotScatter(dataX, row, label: alt[i]);
            }

            formsPlot1.plt.Legend();
            formsPlot1.Render();

        }
    }
}
