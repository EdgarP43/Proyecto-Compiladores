using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

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
        Regex id = new Regex("(^[a-z|A-Z]+([_]|[0-9]|[a-z|A-Z])*)");
        Regex enterosB10 = new Regex("^[0-9]+$");
        Regex decimales = new Regex("[0-9]+[.]([0-9]*)([eE][+-]?)?[0-9]*$");
        Regex enterosB16 = new Regex("^([0][xX])([0-9]|[abcdefABCDEF])*$");
        Regex booleano = new Regex("true|false");
        Regex reservadas = new Regex("void|int|double|bool|string|class|const|interface|null|this|for|while|foreach|if|else|return|break|New|NewArray|Console|WriteLine");

        public List<string> Reconocedor()
        {

            int llave = 1;
            string concatpalabra = String.Empty;
            var salida = new List<string>();
            do
            {
                var linea = new Queue<char>();
                foreach (var item in archivo[llave].ToCharArray())
                {
                    linea.Enqueue(item);
                }
                int inicio = 1;
                int fin = 1;
                string cadena = "";
                int tamanio = linea.Count;
                for (int i = linea.Count; i > 0; i++)
                {
                    //if (iniciaPalabra == true)
                    //{
                    //    posInicio = i;

                    //}
                    if(fin>tamanio)
                    {
                        fin--;
                    }
                    if (linea.Count == 0 && cadena == "")
                    {
                        break;
                    }
                    else if (linea.Count == 0 && cadena != "")
                    {

                        salida.Add(validarCadena(cadena, llave,inicio,fin));
                        inicio = fin;
                        cadena = "";
                        if (linea.Count != 0)
                        {
                            if (linea.Peek() == ' ' || linea.Peek() == '\t')
                            {
                                linea.Dequeue();
                                inicio++;
                            }
                        }
                    }
                    else
                    {
                        if( linea.Peek()=='/')
                        {
                            string inicioComments = linea.Dequeue().ToString();
                            fin++;///
                            if(linea.Peek() == '/')
                            {
                                do
                                {
                                    inicioComments += linea.Dequeue().ToString();
                                    fin++;
                                } while (linea.Count >0);
                                salida.Add("Comentario :" + inicioComments + ". En linea " + llave.ToString() + " cols:" + inicio + " - " + fin);
                                inicio = fin;
                            }
                            else
                            {
                                if (cadena != "")
                                {
                                    salida.Add(validarCadena( cadena,llave, inicio, fin));
                                    fin++;
                                    cadena = "";
                                    inicio = fin;
                                }
                                salida.Add("simbolo : " + inicioComments + " en linea " + llave.ToString() + "cols " + inicio + " - " + fin);
                                inicio = fin;
                            }
                        }
                        else if (linea.Peek() == '"')
                        {
                            bool correcto = true;
                            do
                            {
                                cadena += linea.Dequeue().ToString();
                                fin++;//////
                                if(linea.Count == 0)
                                {
                                    salida.Add("cadena sin terminar " + cadena + " en linea " + llave + "cols " + inicio + " - " + fin);
                                    inicio = fin;
                                    break;
                                    correcto = false;
                                }
                               // fin++;
                            }while (linea.Peek() != '"');
                            if(correcto && linea.Count >0)
                            { 
                                cadena += linea.Dequeue().ToString();
                                fin++;
                                salida.Add("string "+ cadena + " en linea "+ llave + " cols " + inicio + " - " + fin);
                                
                                inicio = fin;
                                cadena = "";
                            }
                            cadena = "";
                        }
                        else if (linea.Peek() != '\n' && linea.Peek() != '\t' && linea.Peek() != ' ' && !simbolosOtros.Contains(linea.Peek().ToString()))
                        {
                            cadena += linea.Dequeue().ToString();
                        }
                        else if (simbolosOtros.Contains(linea.Peek().ToString()) || linea.Peek() == '+' || linea.Peek() == '-' || linea.Peek() == '.')
                        {
                            if (cadena != "")
                            {
                                
                                salida.Add(validarCadena(cadena, llave, inicio, fin));
                                inicio = fin;
                                cadena = "";

                            }
                            string cadenaSimbolos = "";
                            cadenaSimbolos = linea.Dequeue().ToString();
                            if (linea.Count == 0)
                            {
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave+"cols "+inicio+" - "+fin);
                                inicio = fin;
                            }
                            else if (simbolosOtros.Contains(cadenaSimbolos + linea.Peek().ToString()) && cadenaSimbolos != "")
                            {
                                cadenaSimbolos += linea.Dequeue().ToString();
                                //fin--;
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString() + "cols " + inicio + " - " + (fin++));
                                inicio = fin;
                            }
                            else
                            {
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString() + "cols " + (inicio++) + " - " + fin);
                                inicio = fin;
                            }
                            if (linea.Count != 0)
                            {
                                if (linea.Peek() == ' ' || linea.Peek() == '\t')
                                {
                                    inicio++;
                                    linea.Dequeue();
                                }
                            }
                        }
                        else if (cadena != "")
                        {
                            salida.Add(validarCadena(cadena, llave, inicio, fin));
                            inicio = fin;

                            cadena = "";
                            if (linea.Count != 0)
                            {
                                if (linea.Peek() == ' ' || linea.Peek() == '\t')
                                {
                                    linea.Dequeue();
                                    inicio++;
                                    fin = inicio;
                                }
                            }
                        }
                        else if (linea.Peek() == ' ' || linea.Peek() == '\t')
                        {
                            linea.Dequeue();
                            inicio++;
                            fin = inicio;
                        }



                    }
                    fin++;
                }

              
                llave++;
            } while (archivo.ContainsKey(llave));
            return salida;
        }
        private string validarCadena(string cadena, int llave, int inicio, int final)
        {
            if (reservadas.IsMatch(cadena))
            {

                return "reservada : " + cadena + " en linea " + llave.ToString()+" Cols "+inicio+" - "+ final;
            }
            else if (booleano.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Constante Booleana: " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final; ;
            }
            else if (id.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Identificador: " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final; ;
            }
            else if (enterosB10.IsMatch(cadena))
            {
                //Agregar palabra correcta
                return "Entero base 10: " + cadena + " en linea " + llave.ToString()+"(valor = "+cadena+")" + " Cols " + inicio + " - " + final; ;
            }
            else if (enterosB16.IsMatch(cadena))
            {
                //Agregar palabra correcta
                decimal numerohexa = new decimal(Convert.ToInt32(cadena,16));
                return "Entero base 16 : " + cadena + " en linea " + llave.ToString() + "(valor = " + numerohexa.ToString() + ")" + " Cols " + inicio + " - " + final; ; ;
            }
            else if (decimales.IsMatch(cadena))
            {
                //Agregar palabra correcta
                decimal numeroDouble = new decimal(Convert.ToDouble(cadena));
                return "Decimal: " + cadena + " en linea " + llave.ToString()+"(valore = "+numeroDouble.ToString()+")" + " Cols " + inicio + " - " + final; ;
            }
            else
            {
                return "Error : " + cadena + " en linea " + llave.ToString();
            }
        }
    }
}
