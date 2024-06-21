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

namespace Naloga3
{
    public partial class Form4 : Form
    {
        public string alternativa;
        public string tocke;
        double[] rezultati;
        string[,] data;
        int rowsCount;
        int colsCount;
        string[] utezi;
        public List<string> alternative = new List<string>();
        public List<string> parametri = new List<string>();
        public Form4(string alternativa, string tocke, double[] rezultati, List<string> alternative, List<string> parametri, string[,] data, int rowsCount, int colsCount, string[] utezi)
        {
            InitializeComponent();
            this.alternativa = alternativa;
            this.tocke = tocke;
            this.rezultati = rezultati;
            this.alternative = alternative;
            this.parametri = parametri;
            this.data = data;
            this.rowsCount = rowsCount;
            this.colsCount = colsCount;
            this.utezi = utezi;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Najboljša alternativa je: " + alternativa + " z " + tocke + " točkami.";

            string[] array = alternative.ToArray();
            double[] position = new double[rezultati.Length];

            for (int i = 0; i < rezultati.Length; i++)
            {
                position[i] = (i + 1);
            }
            formsPlot1.Plot.AddBar(rezultati, position);
            formsPlot1.Plot.XTicks(position, array);
            formsPlot1.Plot.SetAxisLimits(yMin: 0);
            formsPlot1.Refresh();


            double[] values = new double[parametri.Count];
            string[] labels = parametri.ToArray();

            for (int i = 0; i < parametri.Count; i++)
            {
                values[i] = double.Parse(parametri[i].Substring(parametri[i].Length - 1));
            }

            var pie = formsPlot2.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            formsPlot2.Refresh();

            foreach (string item in parametri)
            {
                comboBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string izbira = comboBox1.SelectedItem.ToString();
            string[] array = parametri.ToArray();
            string[] alt = alternative.ToArray();

            int index = parametri.IndexOf(izbira);

            int rezultat1;
            double[] rezultati1 = new double[alternative.Count];

            for (int col = 1; col < alternative.Count + 1; col++)
            {
                rezultat1 = 0;
                for (int row = 1; row <= rowsCount -1 ; row++)
                {
                    if(row != index+1)
                    {
                        int r = int.Parse(utezi[row]) * int.Parse(data[row, col]);
                        rezultat1 += r;
                        rezultati1[col - 1] = rezultat1;
                    }
                    
                }
                

            }

            this.Hide();
            Form5 form = new Form5(izbira, index, alt, data, rezultati1);
            form.ShowDialog();
        }
    }
}
