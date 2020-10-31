﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using compiladorA2.Gramatica;
using Irony.Parsing;
using System.IO;
using System.Security;
using compiladorA2.Semantica;

namespace compiladorA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string resultado;
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
                areaResultado.AppendText("Su codigo contiene errores"+"\n");
            }
            else
            {
                //MessageBox.Show("Analisis Exitoso");        
                PrintParseTree(arbol.Root, lista);
                analisisSemantico.evaluar(arbol);
                //for (int i = 0; i < lista.Count; i++)
                //{
                //    Console.WriteLine(lista[i]);
                //}
                //MessageBox.Show("Exito");
                areaResultado.AppendText("Analis correcto"+"\n");
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            restaurar.Visible = false;
            maximizar.Visible = true;
        }

        private void maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximizar.Visible = false;
            restaurar.Visible = true;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = true;
            if (menuTuto.Visible==true) {
                menuTuto.Visible = false;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader leer = new StreamReader(open.FileName);
                    string linea;
                    linea = leer.ReadLine();
                    while (linea != null)
                    {
                        entrada.AppendText(linea + '\n');
                        linea = leer.ReadLine();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            panelMenu.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            if (guardar.ShowDialog()==DialogResult.OK)
            {
                entrada.Text = guardar.FileName;
            }
            panelMenu.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menuTuto.Visible = true;
            if (panelMenu.Visible == true)
            {
                panelMenu.Visible = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            menuTuto.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            menuTuto.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            menuTuto.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            menuTuto.Visible = false;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
