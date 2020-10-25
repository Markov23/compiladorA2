using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace compiladorA2.Gramatica
{
    class gramaticaJava : Grammar
    {
        public static class noTerminales
        {
            public const string Raiz = "<raiz>";
            public const string DeclaracionClase = "<declaracion-clase>";
            public const string ImportacionLibrerias = "<importacion-librerias>";
            public const string UbicacionLibrerias = "<ubicacion-librerias>";
            public const string MetodoMain = "<main>";
            public const string CuerpoPrograma = "<cuerpo-programa>";
            public const string DeclaracionVariable = "<declaracion-variable>";
            public const string ListaVariables = "<lista-variables>";
            public const string AsignacionVariable = "<asignacion-variable>";
            public const string AsignacionValor = "<asignacion-valor>";
            public const string TipoDato = "<tipo-dato>";
            public const string Valor = "<valor>";
            public const string ValorLogico = "<valor-logico>";
            public const string ExpresionAritmetica = "<expresion-aritmetica>";
            public const string OperadorAritmetico = "<operador-aritmetico>";
            public const string Concatenacion = "<concatenacion>";
        }

        public static class terminales
        {
            public const string Void = "void";
            public const string Return = "return";
            public const string Null = "null";
            public const string True = "true";
            public const string False = "false";
            public const string System = "System";
            public const string Out = "out";
            public const string Print = "print";
            public const string Println = "println";
            public const string Break = "break";
            public const string Main = "main";
            public const string Static = "static";
            public const string Public = "public";
            public const string Private = "private";
            public const string Class = "class";
            public const string Scanner = "Scanner";
            public const string New = "new";
            public const string In = "in";
            public const string Import = "import";

            public const string If = "if";
            public const string Else = "else";
            public const string Default = "default";
            public const string While = "while";
            public const string Do = "do";
            public const string For = "for";
            public const string Switch = "switch";
            public const string Case = "case";

            public const string Int = "int";
            public const string Float = "float";
            public const string Double = "double";
            public const string Boolean = "boolean";
            public const string String = "string";
            public const string Char = "char";

            public const string And = "&&";
            public const string Or = "||";
            public const string Not = "!";

            public const string Sumar = "+=";
            public const string Restar = "-=";
            public const string Multiplicar = "*=";
            public const string Dividir = "/=";
            public const string Modular = "%=";

            public const string IgualIgual = "==";
            public const string Diferente = "!=";
            public const string Mayor = ">";
            public const string MayorIgual = ">=";
            public const string Menor = "<";
            public const string MenorIgual = "<=";

            public const string Mas = "+";
            public const string Menos = "-";
            public const string Por = "*";
            public const string Entre = "/";
            public const string Modulo = "%";

            public const string Punto = ".";
            public const string Coma = ",";
            public const string DosPuntos = ":";
            public const string PuntoComa = ";";
            public const string ParentesisAbrir = "(";
            public const string ParentesisCerrar = ")";
            public const string CorcheteAbrir = "[";
            public const string CorcheteCerrar = "]";
            public const string LlavesAbrir = "{";
            public const string LlavesCerrar = "}";
            public const string Igual = "=";

            public const string NextInt = "nextInt";
            public const string NextFloat = "nextFloat";
            public const string NextDouble = "nextDouble";
            public const string NextBoolean = "nextBoolean";
            public const string NextChar = "nextChar";
            public const string Next = "next";

        }

        public static class expresionesRegulares
        {
            public const string Comentario = "comentario";
            public const string ComentarioRegex = "(\\/\\*(\\s*|.*?)*\\*\\/)|(\\/\\/.*)";
            public const string Nombre = "id";
            public const string NombreRegex = "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*";
            public const string Numero = "numero";
            public const string NumeroRegex = "\\d+[f|d]?(\\.\\d+[f|d]?)?";
            public const string String = "string";
            public const string StringRegex = "\"[^\"]*\"";
            public const string Char = "string";
            public const string CharRegex = "\'[^\']*\'";
        }

        public gramaticaJava() : base()
        {
            #region noTerminales
            var raiz = new NonTerminal(noTerminales.Raiz);
            var declaracionClase = new NonTerminal(noTerminales.DeclaracionClase);
            var importacionLibrerias = new NonTerminal(noTerminales.ImportacionLibrerias);
            var ubicacionLibrerias = new NonTerminal(noTerminales.UbicacionLibrerias);
            var metodoMain = new NonTerminal(noTerminales.MetodoMain);
            var cuerpoPrograma = new NonTerminal(noTerminales.CuerpoPrograma);
            var declaracionVariable = new NonTerminal(noTerminales.DeclaracionVariable);
            var listaVariables = new NonTerminal(noTerminales.ListaVariables);
            var asignacionVariable = new NonTerminal(noTerminales.AsignacionVariable);
            var asignacionValor = new NonTerminal(noTerminales.AsignacionValor);
            var tipoDato = new NonTerminal(noTerminales.TipoDato);
            var valor = new NonTerminal(noTerminales.Valor);
            var valorLogico = new NonTerminal(noTerminales.ValorLogico);
            var expresionAritmetica = new NonTerminal(noTerminales.ExpresionAritmetica);
            var operadorAritmetico = new NonTerminal(noTerminales.OperadorAritmetico);
            var concatenacion = new NonTerminal(noTerminales.Concatenacion);
            #endregion

            #region Terminales

            #region Palabras Reservadas
            var void_ = ToTerm(terminales.Void);
            var return_ = ToTerm(terminales.Return);
            var null_ = ToTerm(terminales.Null);
            var true_ = ToTerm(terminales.True);
            var false_ = ToTerm(terminales.False);
            var system_ = ToTerm(terminales.System);
            var out_ = ToTerm(terminales.Out);
            var print_ = ToTerm(terminales.Print);
            var println_ = ToTerm(terminales.Println);
            var break_ = ToTerm(terminales.Break);
            var main_ = ToTerm(terminales.Main);
            var static_ = ToTerm(terminales.Static);
            var public_ = ToTerm(terminales.Public);
            var private_ = ToTerm(terminales.Private);
            var class_ = ToTerm(terminales.Class);
            var scanner_ = ToTerm(terminales.Scanner);
            var new_ = ToTerm(terminales.New);
            var in_ = ToTerm(terminales.In);
            var import_ = ToTerm(terminales.Import);

            MarkReservedWords(terminales.Void,terminales.Return,terminales.Null,terminales.True,terminales.False,
                terminales.System,terminales.Out,terminales.Print,terminales.Println,terminales.Break,terminales.Main,
                terminales.Static,terminales.Public,terminales.Private,terminales.Class,terminales.Scanner,
                terminales.New,terminales.In,terminales.Import);
            #endregion

            #region Control de flujo
            var if_ = ToTerm(terminales.If);
            var else_ = ToTerm(terminales.Else);
            var default_ = ToTerm(terminales.Default);
            var while_ = ToTerm(terminales.While);
            var do_ = ToTerm(terminales.Do);
            var for_ = ToTerm(terminales.For);
            var switch_ = ToTerm(terminales.Switch);
            var case_ = ToTerm(terminales.Case);

            MarkReservedWords(terminales.If,terminales.Else,terminales.Default,terminales.While,terminales.Do,
                terminales.For,terminales.Switch,terminales.Case);
            #endregion

            #region Tipos de dato
            var int_ = ToTerm(terminales.Int);
            var float_ = ToTerm(terminales.Float);
            var double_ = ToTerm(terminales.Double);
            var boolean_ = ToTerm(terminales.Boolean);
            var string_ = ToTerm(terminales.String);
            var char_ = ToTerm(terminales.Char);

            MarkReservedWords(terminales.Int,terminales.Float,terminales.Double,terminales.Boolean,terminales.String,
                terminales.Char);
            #endregion

            #region Simbolos
            var punto_ = ToTerm(terminales.Punto);
            var coma_ = ToTerm(terminales.Coma);
            var dosPuntos_ = ToTerm(terminales.DosPuntos);
            var puntoComa_ = ToTerm(terminales.PuntoComa);
            var parentesisAbrir_ = ToTerm(terminales.ParentesisAbrir);
            var parentesisCerrar_ = ToTerm(terminales.ParentesisCerrar);
            var corcheteAbrir_ = ToTerm(terminales.CorcheteAbrir);
            var corcheteCerrar_ = ToTerm(terminales.CorcheteCerrar);
            var llavesAbrir_ = ToTerm(terminales.LlavesAbrir);
            var llavesCerrar_ = ToTerm(terminales.LlavesCerrar);
            var igual_ = ToTerm(terminales.Igual);

            MarkPunctuation(terminales.Punto,terminales.Coma,terminales.DosPuntos,terminales.PuntoComa,terminales.ParentesisAbrir,
                terminales.ParentesisCerrar,terminales.CorcheteAbrir,terminales.CorcheteCerrar,terminales.LlavesAbrir,terminales.LlavesCerrar);
            #endregion

            #region Operadores logicos
            var and_ = ToTerm(terminales.And);
            var or_ = ToTerm(terminales.Or);
            var not_ = ToTerm(terminales.Not);
            #endregion

            #region Operadores matematicos
            var sumar_ = ToTerm(terminales.Sumar);
            var restar_ = ToTerm(terminales.Restar);
            var multiplicar_ = ToTerm(terminales.Multiplicar);
            var dividir_ = ToTerm(terminales.Dividir);
            var modular_ = ToTerm(terminales.Modular);
            #endregion

            #region Operadores relacionales
            var igualIgual_ = ToTerm(terminales.IgualIgual);
            var diferente_ = ToTerm(terminales.Diferente);
            var mayor_ = ToTerm(terminales.Mayor);
            var mayorIgual_ = ToTerm(terminales.MayorIgual);
            var menor_ = ToTerm(terminales.Menor);
            var menorIgual_ = ToTerm(terminales.MenorIgual);
            #endregion

            #region Operadores aritmeticos
            var mas_ = ToTerm(terminales.Mas);
            var menos_ = ToTerm(terminales.Menos);
            var por_ = ToTerm(terminales.Por);
            var entre_ = ToTerm(terminales.Entre);
            var modulo_ = ToTerm(terminales.Modulo);
            #endregion

            #region Entrada de datos
            var nextInt_ = ToTerm(terminales.NextInt);
            var nextFloat_ = ToTerm(terminales.NextFloat);
            var nextDouble_ = ToTerm(terminales.NextDouble);
            var nextBoolean_ = ToTerm(terminales.NextBoolean);
            var next_ = ToTerm(terminales.Next);
            var nextChar_ = ToTerm(terminales.NextChar);

            MarkReservedWords(terminales.NextInt,terminales.NextFloat,terminales.NextDouble,terminales.NextBoolean,terminales.Next,
                terminales.NextChar);
            #endregion

            #endregion

            #region ExpresionesRegulares
            var comentario = new RegexBasedTerminal(expresionesRegulares.Comentario, expresionesRegulares.ComentarioRegex);
            var nombre = new RegexBasedTerminal(expresionesRegulares.Nombre, expresionesRegulares.NombreRegex);
            var numero = new RegexBasedTerminal(expresionesRegulares.Numero, expresionesRegulares.NumeroRegex);
            var stringRegex = new RegexBasedTerminal(expresionesRegulares.String, expresionesRegulares.StringRegex);
            var charRegex = new RegexBasedTerminal(expresionesRegulares.Char, expresionesRegulares.CharRegex);
            #endregion

            #region Reglas

            raiz.Rule = importacionLibrerias + declaracionClase |
                declaracionClase;
            raiz.ErrorRule = SyntaxError + "}";
            raiz.ErrorRule = SyntaxError + ";";

            importacionLibrerias.Rule = import_ + ubicacionLibrerias + puntoComa_;

            ubicacionLibrerias.Rule = nombre | nombre + punto_ + ubicacionLibrerias;

            declaracionClase.Rule = public_ + class_ + nombre + llavesAbrir_ + llavesCerrar_ |
                public_ + class_ + nombre + llavesAbrir_ + metodoMain + llavesCerrar_;

            metodoMain.Rule = public_ + static_ + void_ + main_ + parentesisAbrir_ + string_ + corcheteAbrir_ + corcheteCerrar_ + nombre + parentesisCerrar_ + llavesAbrir_ + llavesCerrar_ |
                public_ + static_ + void_ + main_ + parentesisAbrir_ + string_ + corcheteAbrir_ + corcheteCerrar_ + nombre + parentesisCerrar_ + llavesAbrir_ + cuerpoPrograma + llavesCerrar_;

            cuerpoPrograma.Rule = declaracionVariable | declaracionVariable + cuerpoPrograma |
                asignacionVariable | asignacionVariable + cuerpoPrograma;

            tipoDato.Rule = int_ | string_ | float_ | char_ | double_ | boolean_;

            declaracionVariable.Rule = tipoDato + listaVariables + puntoComa_;

            listaVariables.Rule = nombre | nombre + coma_ + listaVariables |
                asignacionValor | asignacionValor + coma_ + listaVariables;
 

            asignacionVariable.Rule = asignacionValor + puntoComa_;

            asignacionValor.Rule = nombre + igual_ + valor;

            valor.Rule = nombre | charRegex | valorLogico | expresionAritmetica | concatenacion;

            valorLogico.Rule = true_ | false_;

            expresionAritmetica.Rule = numero;

            operadorAritmetico.Rule = mas_ | menos_ | por_ | entre_ | modulo_;

            concatenacion.Rule = stringRegex;

            #endregion
            Root = raiz;
        }

    }
}
