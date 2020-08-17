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
        Regex numeros = new Regex("[0,1,2,3,4,5,6,7,8,9]");
        Regex letraHexa = new Regex("[a,A,b,B,c,C,d,D,e,E,f,F]");

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
                    linea.Enqueue(item);
                }
                string cadena = "";
                for(int i = linea.Count; i>0; i++)
                {
                    if(linea.Count == 0)
                    {
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
                            int contPuntos = 0;
                            if (!numeros.IsMatch(cadena.ToCharArray()[0].ToString()) && (cadena.Length <=31)&&(cadena != "true" || cadena != "false"))
                            {
                                prueba.Add("Identificidador : " + cadena + " en linea " + llave.ToString());
                            }
                            else if (cadena == "true" || cadena == "false")
                            {
                                prueba.Add("constante : " + cadena + " en linea " + llave.ToString());
                            }
                            else
                            {
                                if ( (cadena.ToCharArray()[0].ToString() =="0") && (cadena.ToCharArray()[1].ToString()=="x"  || cadena.ToCharArray()[1].ToString() == "X"))
                                {
                                    if (numeros.IsMatch(cadena.ToCharArray()[i].ToString()) || letraHexa.IsMatch(cadena.ToCharArray()[i].ToString()))
                                    {
                                        prueba.Add("Entero(Base 16) : " + cadena + " en linea " + llave.ToString());
                                    }
                                }
                                else
                                {
                                    bool esDecimal= false;
                                    for (int j=linea.Count;  j>0; j++)
                                    {
                                        if (linea.Count > 0)
                                        {
                                            if ((numeros.IsMatch(linea.Peek().ToString()) && linea.ToArray()[1].ToString()==".") || linea.Peek() == '.' || linea.Peek() == 'E') 
                                            {
                                                if (linea.Peek() == '.' && contPuntos < 1)
                                                {
                                                    contPuntos++;
                                                    esDecimal = true;
                                                    cadena += linea.Dequeue();
                                                }
                                                if ((linea.Peek()=='e' || linea.Peek()=='E') && cadena.Contains("."))
                                                {
                                                    cadena += linea.Dequeue();
                                                    if (linea.Peek()=='+' || linea.Peek()=='-')
                                                    {
                                                        cadena += linea.Dequeue();
                                                    }
                                                }
                                                else
                                                {
                                                    cadena += linea.Dequeue();
                                                }

                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                       
                                    }
                                    if (esDecimal == true)
                                    {
                                        prueba.Add("double : " + cadena + " en linea " + llave.ToString());
                                    }
                                    else
                                    {
                                        prueba.Add("Entero(base 10): " + cadena + " en linea " + llave.ToString());
                                    }
                                   

                                }//
                            }
                            
                            
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
                    }
                }
                llave++;
            } while (archivo.ContainsKey(llave));
            return prueba;
        }
    }
}
