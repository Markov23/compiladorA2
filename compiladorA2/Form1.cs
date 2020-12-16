using compiladorA2.Analisis.Gramaticas;
using compiladorA2.Analisis.Semantica;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            List<elementoToken> lista = new List<elementoToken>();
            List<elementoVariable> variables = new List<elementoVariable>();
            List<string> listaErrores = new List<string>();
            List<string> auxiliarErrores = new List<string>();

            string codigo = entrada.Text;
            var gramatica = new gramaticaJava();

            var parser = new Parser(gramatica);
            var arbol = parser.Parse(codigo);

            if (arbol.Root == null)
            {
                for (int i = 0; i < arbol.ParserMessages.Count; i++)
                {
                    Console.WriteLine(arbol.ParserMessages[i].Message);
                }
                MessageBox.Show("Error");
                areaResultado.AppendText("Su codigo contiene errores" + "\n");
            }
            else
            {
                elementoToken auxiliar;

                for (int i = 0; i < arbol.Tokens.Count-1; i++)
                {
                    auxiliar = new elementoToken();
                    auxiliar.setNombre(arbol.Tokens[i].Text);
                    auxiliar.setTipo(arbol.Tokens[i].ToString().Split('(')[1].Replace("(", "").Replace(")", "").Replace("}", ""));
                    auxiliar.setLinea(arbol.Tokens[i].Location.Line+1);
                    lista.Add(auxiliar);
                }

                variables = deteccionVariables.detectarVariables(lista);

                
                for(int i = 0; i < variables.Count; i++)
                {
                    //Console.WriteLine((i + 1) + "- Tipo: " + variables[i].getTipo() + " Nombre: " + variables[i].getNombre() + " Valor: " + variables[i].getValor() + " Linea: " + variables[i].getLinea());
                }
                

                auxiliarErrores = verificarDeclaracionVariables.verificarDeclaracion(variables);

                for(int i = 0; i < auxiliarErrores.Count; i++)
                {
                    listaErrores.Add(auxiliarErrores[i]);
                }

                auxiliarErrores.Clear();

                auxiliarErrores = verificarDeclaracionArreglos.verificarDeclaracion(variables);

                for (int i = 0; i < auxiliarErrores.Count; i++)
                {
                    listaErrores.Add(auxiliarErrores[i]);
                }

                auxiliarErrores.Clear();

                
                auxiliarErrores = detectarValores.deteccion(variables);

                for (int i = 0; i < auxiliarErrores.Count; i++)
                {
                    listaErrores.Add(auxiliarErrores[i]);
                }

                auxiliarErrores.Clear();

                areaResultado.AppendText("Analis correcto" + "\n");

                for (int i = 0; i < listaErrores.Count; i++)
                {
                    areaResultado.AppendText(listaErrores[i] + "\n");
                }
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
            this.WindowState = FormWindowState.Minimized;
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
        }

       

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                entrada.Text = guardar.FileName;
            }
            //panelMenu.Visible = false;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        bool down = false;
        Point inicial;
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (down)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
            }
        }
        private void Ctr_MouseUp(object sender, MouseEventArgs e) => down = false;
        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
            }
        }
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void file_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = file.SelectedIndex;

            switch (index)
            {
                case 0:
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
                    break;
                case 1:
                    break;
                case 2:
                    SaveFileDialog guardar = new SaveFileDialog();
                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        entrada.Text = guardar.FileName;
                    }
                    break;
                case 3:
                    break;
            }
        }
        //Con el metodo de arriba se mueve el formulario

    }
}
