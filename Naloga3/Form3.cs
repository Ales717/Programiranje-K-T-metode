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
    public partial class Form3 : Form
    {
        public List<string> alternative = new List<string>();
        public List<string> parametri = new List<string>();
        public Form3(List<string> alternative, List<string> parametri)
        {
            InitializeComponent();
            this.alternative = alternative;
            this.parametri = parametri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView1.Rows.Count -1;
            int colsCount = dataGridView1.Columns.Count;

            string[,] data = new string[rowsCount, colsCount];
            string[] utezi = new string[colsCount];
            double[] rezultati = new double[alternative.Count];

            int rezultat1;

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    DataGridViewCell cell = dataGridView1.Rows[row].Cells[col];
                    if (cell.Value != null)
                    {
                        data[row, col] = cell.Value.ToString();
                    }
                    else
                    {
                        data[row, col] = " ";
                    }
                }
            }

            for (int i = 1; i < rowsCount; i++)
            {
                utezi[i]= data[i, 0].Substring(data[i, 0].Length -1);
            }
            for (int col = 1; col < alternative.Count + 1; col++)
            {
                rezultat1 = 0;
                for (int row = 1; row < rowsCount; row++)
                {
                    int r = int.Parse(utezi[row]) * int.Parse(data[row, col]);
                    rezultat1 += r;
                    rezultati[col - 1] = rezultat1;
                }
                
            }


            int maxIndex = Array.IndexOf(rezultati, rezultati.Max());

            this.Hide();
            Form4 form = new Form4(data[0, maxIndex + 1], rezultati.Max().ToString(), rezultati, alternative, parametri, data, rowsCount, colsCount,utezi);
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dataGridView1.RowCount = Math.Max(alternative.Count, parametri.Count) + 1;
            dataGridView1.ColumnCount = Math.Max(alternative.Count, parametri.Count) + 1;

            dataGridView1.Rows[0].Cells[0].Value = "   ";
            for (int i = 0; i < alternative.Count; i++)
            {
                dataGridView1.Rows[0].Cells[i + 1].Value = alternative[i];
            }

            for (int i = 0; i < parametri.Count; i++)
            {
                dataGridView1.Rows[i + 1].Cells[0].Value = parametri[i];
            }

        }
    }
}
