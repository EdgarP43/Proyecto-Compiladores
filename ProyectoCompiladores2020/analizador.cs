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
            archivo = lineas;
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
        Regex id = new Regex("^([a-z|A-Z]+([_]|[0-9]|[a-z|A-Z])*)$");
        Regex enterosB10 = new Regex("^[0-9]+$");
        Regex decimales = new Regex("^[0-9]+[.]([0-9]*)([eE][+-]?)?[0-9]*$");
        Regex enterosB16 = new Regex("^([0][xX])([0-9]|[abcdefABCDEF])*$");
        Regex booleano = new Regex("true|false");
        Regex reservadas = new Regex(@"^(void|int|double|bool|string|class|const|interface|null|this|for|while|foreach|if|else|return|break|New|NewArray|Console|WriteLine)$");
        Regex caracterNoValido = new Regex("^[a-z|A-Z|0-9|&|_]+$");
        bool comment = false;
        public List<string> Reconocedor()
        {

            int llave = 1;
            char suma = 's';
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
                string inicioComments = "";
                int tamanio = linea.Count;
                for (int i = linea.Count; i > 0; i++)
                {
                    if (fin > tamanio)
                    {
                        fin--;
                    }
                    if (linea.Count == 0 && cadena == "" /*&& comment == false*/)
                    {
                        break;
                    }
                    else if (comment == true)
                    {
                        inicioComments += linea.Dequeue().ToString();
                        while (comment == true)
                        {
                            if (inicioComments.Contains("*/"))
                            {
                                comment = false;
                                //salida.Add("Comentario : " + inicioComments);
                                break;
                            }
                            else if (linea.Count > 0)
                            {
                                inicioComments += linea.Dequeue().ToString();
                            }
                            else if (linea.Count == 0 && archivo.Count == llave)
                            {
                                salida.Add("EOF en Comentario");
                                break;
                            }
                            else if (linea.Count == 0)
                            {
                                inicioComments += "\n";
                                llave++;
                                foreach (var item in archivo[llave].ToCharArray())
                                {
                                    linea.Enqueue(item);
                                }

                            }

                        }
                        comment = false;
                        //salida.Add(comentariosMuchasLineas());
                    }
                    else if (linea.Count == 0 && cadena != "")
                    {
                        if (fin < tamanio)
                            fin--;
                        else if (fin == tamanio && linea.Count != 0)
                        { fin--; }
                        salida.Add(validarCadena(cadena, llave, inicio, fin));

                        inicio = fin;
                        cadena = "";
                        if (linea.Count != 0)
                        {
                            if (linea.Peek() == ' ' || linea.Peek() == '\t')
                            {
                                linea.Dequeue();
                                inicio += 2;
                                fin = inicio;
                            }
                            else
                            {
                                inicio ++;
                                fin = inicio;
                            }
                        }
                    }
                    else
                    {
                        if (linea.Peek() == '/')
                        {
                            if (cadena != "")
                            {
                                if (fin < tamanio)
                                    fin--;
                                else if(fin == tamanio && linea.Count != 0)
                                { fin--; }
                                salida.Add(validarCadena(cadena, llave, inicio, fin));
                                fin++;
                                inicio = fin;
                                suma = 'n';
                                cadena = "";

                            }
                            inicioComments += linea.Dequeue().ToString();
                            if (linea.Peek() == '/')
                            {
                                do
                                {
                                    inicioComments += linea.Dequeue().ToString();
                                    fin++;
                                } while (linea.Count > 0);
                                //salida.Add("Comentario :" + inicioComments + ". En linea " + llave.ToString() + " cols:" + inicio + " - " + fin);
                                inicio = fin;
                            }
                            else if (linea.Peek() == '*')
                            {
                                inicioComments += linea.Dequeue().ToString();
                                comment = true;
                            }
                            else
                            {
                                if (cadena != "")
                                {
                                    salida.Add(validarCadena(cadena, llave, inicio, fin));
                                    cadena = "";
                                    inicio = fin;
                                }
                                salida.Add("simbolo : " + inicioComments + " en linea " + llave.ToString() + " cols " + inicio + " - " + fin);
                                fin++;
                                inicio = fin;
                                suma = 'n';
                            }
                        }
                        else if (linea.Peek() == '*')
                        {
                            linea.Dequeue();
                            if (linea.Count > 0)
                            {
                                if (linea.Peek() == '/')
                                {
                                    linea.Dequeue();
                                    salida.Add("Salida de comentario sin emparejar" + " en linea " + llave.ToString());
                                }
                                else
                                {
                                    salida.Add("simbolo : " + "*" + " en linea " + llave.ToString() + " cols " + inicio + " - " + fin);
                                    fin++;
                                    inicio = fin;
                                }
                            }
                        }
                        else if (linea.Peek() == '"')
                        {
                            bool correcto = true;
                            do
                            {
                                cadena += linea.Dequeue().ToString();
                                fin++;
                                if (linea.Count == 0)
                                {
                                    salida.Add("EOF en una cadena en linea: " + llave); ;
                                    inicio = fin;
                                    break;
                                    correcto = false;
                                }

                            } while (linea.Peek() != '"');
                            if (correcto && linea.Count > 0)
                            {
                                cadena += linea.Dequeue().ToString();
                                
                                salida.Add("string " + cadena + " en linea " + llave + " cols " + inicio + " - " + fin);
                                fin++;
                                inicio = fin;
                                cadena = "";
                            }
                            cadena = "";
                        }
                        else if (enterosB10.IsMatch(cadena) && linea.Peek() == '.')
                        {
                            cadena += linea.Dequeue().ToString();
                            if (linea.Count == 0)
                            {
                                //if (fin < tamanio)
                                //    fin--;
                                salida.Add(validarCadena(cadena, llave, inicio, fin));

                                inicio = fin;
                                suma = 'n';
                                cadena = "";
                            }
                            else
                            {
                                while (linea.Peek() != ' ' && linea.Peek() != '.')
                                {
                                    cadena += linea.Dequeue().ToString();
                                    fin++;
                                    if (linea.Count == 0)
                                    {
                                        break;
                                    }

                                }
                                //if (fin < tamanio)
                                //    fin--;
                                //else if (fin == tamanio && linea.Count != 0)
                                //{ fin--; }
                                salida.Add(validarCadena(cadena, llave, inicio, fin));

                                inicio = fin;
                                suma = 'n';
                                cadena = "";

                            }
                        }
                        else if (linea.Peek() != '\n' && linea.Peek() != '\t' && linea.Peek() != ' ' && !simbolosOtros.Contains(linea.Peek().ToString()) && (caracterNoValido.IsMatch(linea.Peek().ToString()) || (linea.Peek() == '|' )) && cadena.Length < 31)
                        {
                            cadena += linea.Dequeue().ToString();
                            fin++;
                        }
                        else if (simbolosOtros.Contains(linea.Peek().ToString()) || linea.Peek() == '+' || linea.Peek() == '-' || linea.Peek() == '.')
                        {
                            if (cadena != "")
                            {
                                if (fin < tamanio)
                                    fin--;
                                else if( fin==tamanio && linea.Count != 0)
                                { fin--; }

                                salida.Add(validarCadena(cadena, llave, inicio, fin));
                                fin++;
                                inicio = fin;
                                suma = 'n';
                                cadena = "";

                            }
                            string cadenaSimbolos = "";
                            cadenaSimbolos = linea.Dequeue().ToString();
                            if (linea.Count == 0)
                            {
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave + " cols " + inicio + " - " + fin);
                                inicio = fin;
                                suma = 'n';
                            }
                            else if (simbolosOtros.Contains(cadenaSimbolos + linea.Peek().ToString()) && cadenaSimbolos != "")
                            {
                                cadenaSimbolos += linea.Dequeue().ToString();
                                fin++;
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString() + " cols " + inicio + " - " + (fin).ToString());
                                inicio = fin;
                                suma = 'n';
                            }
                            else
                            {
                                
                                salida.Add("simbolo : " + cadenaSimbolos + " en linea " + llave.ToString() + " cols " + (inicio) + " - " + fin);
                                inicio = fin;
                                suma = 'n';
                            }
                            if (linea.Count != 0)
                            {
                                if (linea.Peek() == ' ' || linea.Peek() == '\t')
                                {
                                    inicio += 2;
                                    fin = inicio;
                                    linea.Dequeue();
                                }
                                else
                                {
                                    inicio++;
                                    fin = inicio;
                                }
                            }
                        }
                        else if (cadena != "")
                        {
                            if (fin < tamanio)
                                fin--;
                            else if (fin == tamanio && linea.Count != 0)
                            { fin--; }

                            salida.Add(validarCadena(cadena, llave, inicio, fin));

                            inicio = fin;
                            suma = 'n';

                            cadena = "";
                            if (linea.Count != 0)
                            {
                                if (linea.Peek() == ' ' || linea.Peek() == '\t')
                                {
                                    linea.Dequeue();
                                    inicio += 2;
                                    fin = inicio;
                                }
                                else
                                {
                                    inicio++;
                                    fin = inicio;
                                }
                            }
                        }
                        else if (linea.Peek() == ' ' || linea.Peek() == '\t')///////
                        {
                                
                            linea.Dequeue();
                            inicio++;
                            fin = inicio;
                            suma = 'n';
                        }
                        else
                        {
                            salida.Add("Caracter no válido " + linea.Dequeue().ToString() + "en linea " + llave);
                            fin++;
                            inicio = fin;
                            suma = 'n';
                        }



                    }


                }


                llave++;
            } while (archivo.ContainsKey(llave));
            return salida;
        }
        private string validarCadena(string cadena, int llave, int inicio, int final)
        {
            //final--;
            if (cadena.Length < 31)
            {
                //if (inicio != final)
                //{
                //    final--;
                //}
                if (reservadas.IsMatch(cadena))
                {

                    return "reservada : " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final;
                }
                else if (booleano.IsMatch(cadena))
                {
                    //Agregar palabra correcta
                    return "Constante Booleana: " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final; ;
                }
                else if (cadena == "&&" || cadena == "||")
                {
                    //Error para arreglar en caso de que esta en una linea sola
                    return "Simbolo: " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final;
                }
                else if (id.IsMatch(cadena))
                {
                    //Agregar palabra correcta
                    return "Identificador: " + cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final;
                }
                else if (enterosB10.IsMatch(cadena))
                {
                    //Agregar palabra correcta
                    return "Entero base 10: " + cadena + " en linea " + llave.ToString() + " (valor = " + cadena + ")" + " Cols " + inicio + " - " + final; ;
                }
                else if (enterosB16.IsMatch(cadena))
                {
                    //Agregar palabra correcta
                    decimal numerohexa = new decimal(Convert.ToInt32(cadena, 16));
                    return "Entero base 16 : " + cadena + " en linea " + llave.ToString() + " (valor = " + numerohexa.ToString() + ")" + " Cols " + inicio + " - " + final; ; ;
                }
                else if (decimales.IsMatch(cadena))
                {
                    //Agregar palabra correcta
                    //decimal numeroDouble = new decimal(Convert.ToDouble(cadena));
                    return "Decimal: " + cadena + " en linea " + llave.ToString() + " (valor = " + cadena + ")" + " Cols " + inicio + " - " + final; ;
                }

                else
                {
                    return "Error : " + cadena + " en linea " + llave.ToString();
                }
            }
            else
            {
                return "Error : " + cadena + " en linea " + llave.ToString();
            }
        }
    }
}
