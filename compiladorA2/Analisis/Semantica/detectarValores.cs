using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace compiladorA2.Analisis.Semantica
{
    class detectarValores
    {
       
        public static List<string> deteccion(List<elementoVariable> variables)
        {
            List<string> listaErrores=new List<string>();
            for (int i = 0; i < variables.Count; i++)
            {
                string nom = variables[i].getNombre();
                int cont = i + 1;
                for (int j = cont; j < variables.Count; j++)
                {
                    string nom2 = variables[j].getNombre();
                    if (nom.Equals(nom2))
                    {
                        listaErrores.Add("La variable en la linea " + variables[j].getLinea() + " ya esta declarada");
                    }
                }
            }
            
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].getTipo().Equals("int") && (!int.TryParse(variables[i].getValor(),out int entero)==true) && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
                else if (variables[i].getTipo().Equals("double") && !Regex.IsMatch(variables[i].getValor(), pattern: "\\d+[f|d]?(\\.\\d+[f|d]?)?") && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
                else if (variables[i].getTipo().Equals("float") && !Regex.IsMatch(variables[i].getValor(), pattern: "\\d+[f|d]?(\\.\\d+[f|d]?)?") && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
                else if (variables[i].getTipo().Equals("string") && !Regex.IsMatch(variables[i].getValor(), pattern: "\"[^\"]*\"") && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
                else if (variables[i].getTipo().Equals("char") && !Regex.IsMatch(variables[i].getValor(), pattern: "\'[^\']\'") && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
                else if (variables[i].getTipo().Equals("boolean") && !Regex.IsMatch(variables[i].getValor(), pattern: "true|false") && !variables[i].getValor().Equals(""))
                {
                    listaErrores.Add("El valor de la variable " + variables[i].getNombre() + " no es valido. Linea " + variables[i].getLinea());
                }
            }
            return listaErrores;
        }
    }
}
