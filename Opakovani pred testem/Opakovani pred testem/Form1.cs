using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opakovani_pred_testem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] pole = new int[textBox1.Lines.Count()];

            int index = 0;
            int indexdva = 0;
            int b = 0;
            foreach (string radek in textBox1.Lines)
            {
                try
                {
                    b = Convert.ToInt32(radek);
                    pole[index] = b;
                    listBox1.Items.Add(b);
                }
                catch(FormatException ex)
                {
                    b = 0;
                    pole[index] = b;
                    listBox1.Items.Add(b);
                }
                catch(OverflowException ex)
                {
                    if (radek.ToString().Contains("-"))
                    {
                        b = Int32.MinValue;
                        pole[index] = b;
                        listBox1.Items.Add(b);
                    }
                    else {
                        b = Int32.MaxValue;
                        pole[index] = b;
                        listBox1.Items.Add(b);
                    }
                    
                }
                index++;
            }

            foreach(int cislo in pole)
            {
                try
                {
                    pole[indexdva] = cislo * 2;
                    listBox2.Items.Add(pole[indexdva]);
                }
                catch (OverflowException ex)
                {
                    
                    listBox2.Items.Add(cislo);

                }
                indexdva++;
            }
            
            
        }
    }
}
