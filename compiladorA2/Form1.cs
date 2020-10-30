using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compiladorA2.Gramatica;
using Irony.Parsing;
using compiladorA2.Semantica;

namespace compiladorA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            string codigo = entrada.Text;
            var gramatica = new gramaticaJava();

            var parser = new Parser(gramatica);
            var arbol = parser.Parse(codigo);

            if (arbol.Root == null)
            {
                for(int i = 0; i < arbol.ParserMessages.Count;i++)
                {
                    Console.WriteLine(arbol.ParserMessages[i].Message);
                }
                MessageBox.Show("Error");
            }
            else
            {
                //MessageBox.Show("Analisis Exitoso");
                analisisSemantico.evaluar(arbol);
                /*
                PrintParseTree(arbol.Root, lista);
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine(lista[i]);
                }*/
                MessageBox.Show("Exito");
            }
        }

        public void PrintParseTree(ParseTreeNode node, List<string> lista, int index = 0, int level = 0)
        {
            /*
            for (var levelIndex = 0; levelIndex < level; levelIndex++)
            {
                Console.Write("\t");
            }*/

            lista.Add(node.ToString() + " [" + index + "]");

            var childIndex = 0;
            foreach (var child in node.ChildNodes)
            {
                PrintParseTree(child, lista, childIndex, level + 1);
                childIndex++;
            }
        }
    }
}
