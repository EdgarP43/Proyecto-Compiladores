using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores2020
{
    class analizador
    {
        public analizador()
        {
            simbolos();
        }
        private Dictionary<int, string> archivo = new Dictionary<int, string>();
        public void guardarArchivo(Dictionary<int, string> lineas)
        {
            archivo = lineas ;
        }

        List<string> simbolosOtros = new List<string>();
        public void simbolos()
        {
            simbolosOtros.Add("+");
            simbolosOtros.Add("-");
            simbolosOtros.Add("*");
            simbolosOtros.Add("/");
            simbolosOtros.Add("%");
            simbolosOtros.Add("<");
            simbolosOtros.Add("<=");
            simbolosOtros.Add(">");
            simbolosOtros.Add(">=");
            simbolosOtros.Add("=");
            simbolosOtros.Add("==");
            simbolosOtros.Add("!=");
            simbolosOtros.Add("&&");
            simbolosOtros.Add("||");
            simbolosOtros.Add("!");
            simbolosOtros.Add(";");
            simbolosOtros.Add(",");
            simbolosOtros.Add(".");
            simbolosOtros.Add("(");
            simbolosOtros.Add(")");
            simbolosOtros.Add("()");
            simbolosOtros.Add("[");
            simbolosOtros.Add("]");
            simbolosOtros.Add("[]");
            simbolosOtros.Add("{");
            simbolosOtros.Add("}");
            simbolosOtros.Add("{}");
        }
        Regex id = new Regex("^[a-z|A-Z]+([_]|[0-9]|[a-z|A-Z])*");
        Regex enterosB10 = new Regex("^[0-9]+$");
        Regex decimales = new Regex("[0-9]+[.]([0-9]*)([eE][+-]?)?[0-9]*$");
        Regex enterosB16 = new Regex("^([0][xX])([0-9]|[abcdefABCDEF])*$");
        Regex booleano = new Regex("true|false");
        Regex reservadas = new Regex("void|int|double|bool|string|class|const|interface|null|this|for|while|foreach|if|else|return|break|New|NewArray|Console|WriteLine");

        private string validarCadena(string cadena, int llave)
        {
            if (reservadas.IsMatch(cadena))
            {
                return "reservada : " + cadena + " en linea " + llave.ToString();
            }
            else if (booleano.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Constante Booleana: " + cadena + " en linea " + llave.ToString();
            }
            else if (id.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Identificador: " + cadena + " en linea " + llave.ToString();
            }
            else if (enterosB10.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Entero base 10: " + cadena + " en linea " + llave.ToString();
            }
            else if (enterosB16.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Entero base 16 : " + cadena + " en linea " + llave.ToString();
            }
            else if (decimales.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Decimal: " + cadena + " en linea " + llave.ToString();
            }
            else
            {
                //La cago en todo
                return "Error : " + cadena + " en linea " + llave.ToString();
            }
        }

        public List<string> Reconocedor()
        {

        }
    }
}
