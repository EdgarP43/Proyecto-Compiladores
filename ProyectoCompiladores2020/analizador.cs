using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private List<string> reservadas = new List<string>();
        private Dictionary<int, string> archivo = new Dictionary<int, string>();
        public void guardarReservadas(List<string> palabras)
        {
            reservadas = palabras;
        }
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
        public List<string> Reconocedor()
        {
            int llave = 1;
            string concatpalabra = String.Empty;
            var prueba = new List<string>();
            do
            {
                var linea = new Queue<char>();
                foreach( var item in archivo[llave].ToCharArray())
                {
                    //if (item != '\n')
                    //{

                    //}
                    linea.Enqueue(item);
                }
                string cadena = "";
                for(int i = linea.Count; i>0; i++)
                {
                    if(linea.Count == 0)
                    {
                        //if()
                        break;
                    }
                    if (linea.Peek() != '\n' && linea.Peek() != '\t' && linea.Peek() != '(' && linea.Peek() != '[' && linea.Peek() != '{' && linea.Peek() != ' ' && !simbolosOtros.Contains(linea.Peek().ToString()))
                    {
                        cadena += linea.Dequeue().ToString();
                    }
                    else if (reservadas.Contains(cadena))
                    {
                        prueba.Add("reservada : " + cadena + " en linea " + llave.ToString());
                        cadena = "";
                    }
                    else
                    {
                        if (cadena != "")
                        {
                            prueba.Add("Identificidador : " + cadena + " en linea " + llave.ToString());
                        }
                        else if (linea.Peek() == ' ' || linea.Peek() == '\t')
                        {
                            linea.Dequeue();
                        }
                        else if (simbolosOtros.Contains(linea.Peek().ToString()))
                        {
                            string cadenaSimbolos = "";
                            cadenaSimbolos = linea.Dequeue().ToString();
                            if(linea.Count==0)
                            {
                                prueba.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString());
                            }
                            else if(simbolosOtros.Contains(cadenaSimbolos+ linea.Peek().ToString()))
                            {
                                cadenaSimbolos += linea.Dequeue().ToString();
                                prueba.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString());
                            }
                            else
                            {
                                prueba.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString());
                            }
                        }
                        //if (linea.Peek() == '(' || linea.Peek() == '[' || linea.Peek() == '{')
                        //{
                        //    prueba.Add("operador : " + linea.Dequeue().ToString() + " en linea " + llave.ToString());
                        //}

                        cadena = "";
                    }
                    if (linea.Count == 0 && cadena != "" )
                    {
                         if (reservadas.Contains(cadena))
                        {
                            prueba.Add("reservada : " + cadena + " en linea " + llave.ToString());
                            cadena = "";
                        }
                        else
                        {
                            prueba.Add("Identificidador : " + cadena + " en linea " + llave.ToString());
                            cadena = "";
                        }
                        break;
                    } //"\""
                }
                //\n,\t,' ', (,[,{ 
                llave++;
            } while (archivo.ContainsKey(llave));
            return prueba;
        }
    }
}
