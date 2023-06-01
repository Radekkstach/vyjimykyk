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
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);

                double discriminant = b * b - 4 * a * c;

                if (discriminant < 0)
                {
                    throw new NoRealRootsException();
                }
                else if (discriminant == 0)
                {
                    double root = -b / (2 * a);
                    MessageBox.Show($"Rovnice má jeden dvojnásobný kořen: {root}");
                }
                else
                {
                    double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    MessageBox.Show($"Rovnice má dva kořeny: {root1} a {root2}");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Chyba: Neplatný formát dat v textBox.");
            }
            catch (QuadraticEquationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public class QuadraticEquationException : Exception
        {
            public QuadraticEquationException(string message) : base(message)
            {
            }
        }

        public class NoRealRootsException : QuadraticEquationException
        {
            public NoRealRootsException() : base("Rovnice nemá řešení v oboru reálných čísel.")
            {
            }
        }

        public class LinearEquationException : Exception
        {
            public LinearEquationException(string message) : base(message)
            {
            }
        }

        public class NoUniqueSolutionException : LinearEquationException
        {
            public NoUniqueSolutionException() : base("Rovnice má nekonečně mnoho řešení.")
            {
            }
        }

        public class NoSolutionException : LinearEquationException
        {
            public NoSolutionException() : base("Rovnice nemá řešení.")
            {
            }
        }
    }
}
