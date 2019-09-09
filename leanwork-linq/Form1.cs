using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var manipulator = new Manipulator();
            richTextBox1.Text = manipulator.CalcularSequenciaMaxima2(1, 1000000).ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var lista = new List<int>() { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 114 };

            var manipulator = new Manipulator();
            lista = manipulator.FiltrarImpares(lista);

            richTextBox1.Text = Regex.Replace(
                lista.Aggregate(String.Empty, (x, y) => x + ", " + y.ToString()),
                "^, ",
                "");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var listaA = new List<int>() { 1, 3, 7, 29, 42, 98, 234, 93 };
            var listaB = new List<int>() { 4, 6, 93, 7, 55, 32, 3 };

            var manipulator = new Manipulator();

            richTextBox1.Text = Regex.Replace(
                manipulator.FiltrarItensAusentes(listaA, listaB)
                    .Aggregate(String.Empty, (x, y) => x + ", " + y.ToString()),
                    "^, ",
                    "");
        }
    }
}
