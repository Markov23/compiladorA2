using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;


namespace compiladorA2.Semantica
{
    class analisisSemantico
    {
        public static void evaluar(Irony.Parsing.ParseTree arbol)
        {
            List<string> variables = new List<string>();
            List<string> errores = new List<string>();

            string none = "!!00!!";
            string separador = "|";
            string fila;
            int linea = 0;

            for (int i = 0; i < arbol.Tokens.Count; i++)
            {
                //Verificar declaracion de variable
                if ((arbol.Tokens[i].Text.Equals("int") || arbol.Tokens[i].Text.Equals("float") || arbol.Tokens[i].Text.Equals("double") || arbol.Tokens[i].Text.Equals("string") || arbol.Tokens[i].Text.Equals("char") || arbol.Tokens[i].Text.Equals("boolean")) && !arbol.Tokens[i + 1].Text.Equals("["))
                {
                    //Verificar declaracion multiple
                    bool multiple = false;
                    string declaracion = arbol.Tokens[i].Text;

                    for (int j = i + 1; j < arbol.Tokens.Count; j++)
                    {
                        declaracion = declaracion + " " + arbol.Tokens[j].Text;

                        if (arbol.Tokens[j].Text.Equals(","))
                        {
                            multiple = true;
                        }

                        if (arbol.Tokens[j].Text.Equals(";"))
                        {
                            linea = arbol.Tokens[j].Location.Line + 1;
                            i = j;
                            j = arbol.Tokens.Count;
                        }
                    }

                    //Creacion de registro en variables
                    if (multiple == true)
                    {
                        //Tiene multiples definiciones
                        //Preparacion de datos
                        List<string> valoresString = new List<string>();
                        string[] auxiliar = declaracion.Split(',');
                        string tipo = auxiliar[0].Split(' ')[0];

                        if (tipo.Equals("string"))
                        {
                            valoresString = prevenirString(declaracion);

                            for (int j = 0; j < valoresString.Count; j++)
                            {

                                declaracion = declaracion.Replace(valoresString[j], j.ToString());
                            }

                        }
                        else if (tipo.Equals("char"))
                        {
                            valoresString = prevenirChar(declaracion);

                            for (int j = 0; j < valoresString.Count; j++)
                            {

                                declaracion = declaracion.Replace("'" + valoresString[j] + "'", "'char'");
                            }

                        }

                        auxiliar = declaracion.Split(',');
                        auxiliar[0] = auxiliar[0].Replace(tipo + " ", "");

                        for (int j = 0; j < auxiliar.Length; j++)
                        {
                            auxiliar[j] = auxiliar[j].Replace(" ", "");
                            auxiliar[j] = auxiliar[j].Replace(";", "");
                        }

                        //Creacion de filas de variables
                        for (int j = 0; j < auxiliar.Length; j++)
                        {
                            fila = tipo;
                            int contador = 0;

                            if (auxiliar[j].Contains("="))
                            {
                                if (tipo.Equals("string") && valoresString.Count > 0)
                                {
                                    fila = fila + separador + auxiliar[j].Split('=')[0] + separador + "\"" + valoresString[contador] + "\"" + separador + linea;
                                    contador++;
                                }
                                else if (tipo.Equals("char") && valoresString.Count > 0)
                                {
                                    fila = fila + separador + auxiliar[j].Split('=')[0] + separador + "'" + valoresString[contador] + "'" + separador + linea;
                                    contador++;
                                }
                                else
                                {
                                    fila = fila + separador + auxiliar[j].Split('=')[0] + separador + auxiliar[j].Split('=')[1] + separador + linea;
                                }

                            }
                            else
                            {
                                fila = fila + separador + auxiliar[j] + separador + none + separador + linea;
                            }

                            variables.Add(fila);
                        }
                    }
                    else
                    {
                        //No tiene multiples valores
                        //Preparacion de datos
                        List<string> valoresString = new List<string>();
                        declaracion = declaracion.Replace(" ;", "");
                        string[] auxiliar = declaracion.Split(' ');

                        if (auxiliar[0].Equals("string"))
                        {
                            valoresString = prevenirString(declaracion);

                            for (int j = 0; j < valoresString.Count; j++)
                            {

                                declaracion = declaracion.Replace(valoresString[j], j.ToString());
                            }

                        }
                        else if (auxiliar[0].Equals("char"))
                        {
                            valoresString = prevenirChar(declaracion);

                            for (int j = 0; j < valoresString.Count; j++)
                            {

                                declaracion = declaracion.Replace("'" + valoresString[j] + "'", "'char'");
                            }

                        }

                        auxiliar = declaracion.Split(' ');

                        if (auxiliar.Length > 2)
                        {

                            if (auxiliar[0].Equals("string") && valoresString.Count > 0)
                            {
                                fila = auxiliar[0] + separador + auxiliar[1] + separador + "\"" + valoresString[0] + "\"" + separador + linea;
                                variables.Add(fila);
                            }
                            else if (auxiliar[0].Equals("char") && valoresString.Count > 0)
                            {
                                fila = auxiliar[0] + separador + auxiliar[1] + separador + "'" + valoresString[0] + "'" + separador + linea;
                                variables.Add(fila);
                            }
                            else
                            {
                                fila = auxiliar[0] + separador + auxiliar[1] + separador + auxiliar[3] + separador + linea;
                                variables.Add(fila);
                            }

                        }
                        else
                        {
                            fila = auxiliar[0] + separador + auxiliar[1] + separador + none + separador + linea;
                            variables.Add(fila);
                        }
                    }
                }
                else if (arbol.Tokens[i].Terminal.Name.Equals("id") && !arbol.Tokens[i - 1].Text.Equals("]") && !arbol.Tokens[i - 1].Text.Equals("class"))
                {
                    linea = arbol.Tokens[i].Location.Line;
                    fila = none + separador + arbol.Tokens[i].Text + separador + arbol.Tokens[i + 2].Text + separador + linea;
                    variables.Add(fila);


                    for (int j = i; j < arbol.Tokens.Count; j++)
                    {
                        if (arbol.Tokens[j].Text.Equals(";"))
                        {
                            i = j;
                            j = arbol.Tokens.Count;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------Lista de Variables--------------------------------------------------------");
            //Imprimir lista de variables
            for (int i = 0; i < variables.Count; i++)
            {
                Console.WriteLine(variables[i]);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            //errores = erroresVariables(variables,separador);

        }

        private static List<string> prevenirString(string declaracion)
        {
            List<string> valores = new List<string>();
            string valor = "";
            int primerIncidencia = 0;
            int incidencias = 0;

            for (int i = 0; i < declaracion.Length; i++)
            {
                if (declaracion[i].Equals('"') && incidencias == 0)
                {
                    incidencias++;
                    primerIncidencia = i;
                }
                else if (declaracion[i].Equals('"') && incidencias == 1)
                {
                    incidencias = 0;
                    valor = declaracion.Substring(primerIncidencia + 1, (i - primerIncidencia - 1));
                    valores.Add(valor);
                }
            }

            return valores;
        }

        private static List<string> prevenirChar(string declaracion)
        {
            List<string> valores = new List<string>();
            string valor = "";

            for (int i = 0; i < declaracion.Length; i++)
            {
                if (declaracion[i].ToString().Contains("'"))
                {
                    valor = declaracion[i + 1].ToString();
                    valores.Add(valor);
                    i += 2;
                }
            }

            return valores;
        }

        private static List<string> erroresVariables(List<string> variables, string separador)
        {
            List<string> errores = new List<string>();



            return errores;
        }

    }
}
