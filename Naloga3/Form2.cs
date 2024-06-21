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
    public partial class Form2 : Form
    {
        public List<string> alternative = new List<string>();
        public List<string> parametri = new List<string>();
        public Form2(List<string> alternative)
        {
            InitializeComponent();
            this.alternative = alternative;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text +" "+ numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                parametri.Add(item.ToString());

            }
            this.Hide();
            Form3 form = new Form3(alternative, parametri);
            form.Show();
        }
    }
}
