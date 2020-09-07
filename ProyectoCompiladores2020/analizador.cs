using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime;
using System.Collections.Generic;

namespace ProyectoCompiladores2020
{
    public class analizador
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
        public bool correcto = true;
        public Queue<string> tokens = new Queue<string>();
        //Dictionary<string, string> Tokens = new Dictionary<string, string>();
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
            simbolosOtros.Add(":");
        }
        public List<string> errores = new List<string>();
        //Expresiones regulares para tokens
        Regex id = new Regex("^([a-z|A-Z]+([_]|[0-9]|[a-z|A-Z])*)$");
        Regex enterosB10 = new Regex("^[0-9]+$");
        Regex decimales1 = new Regex("^[0-9]+[.]([0-9]*)([eE][+-]?)?[0-9]*$");
        Regex decimales2 = new Regex("^[0-9]+[.]([0-9]*)([eE][+-]?[0-9]+)?$");
        Regex enterosB16 = new Regex("^([0][xX])([0-9]|[abcdefABCDEF])*$");
        Regex booleano = new Regex("true|false");
        Regex reservadas = new Regex(@"^(void|int|double|bool|string|class|const|interface|null|this|for|while|foreach|if|else|return|break|New|NewArray|Console|WriteLine|Print)$");
        Regex caracterNoValido = new Regex("^[a-z|A-Z|0-9|&|_]+$");
        bool comment = false;
        public List<string> Reconocedor()
        {

            int llave = 1;
            string concatpalabra = String.Empty;
            var salida = new List<string>();
            do
            {
                var linea = new Queue<char>();
                foreach (var item in archivo[llave].ToCharArray())//carga de caracteres de linea de archivo a la cola
                {
                    linea.Enqueue(item);
                }
                int inicio = 1;
                int fin = 1;
                string cadena = "";
                string inicioComments = "";
                int tamanio = linea.Count;
                for (int i = linea.Count; i > 0; i++)//analisis de linea
                {
                    if (fin > tamanio)// en caso de que fin sea mayor a tamaño
                    {
                        fin--;
                    }
                    if (linea.Count == 0 && cadena == "")// en caso de la cola estar vacia y no haya nada mas que analizar 
                    {
                        break;
                    }
                    else if (comment == true)// en caso de que un comentario de varias lineas se haya iniciado
                    {
                        inicioComments += linea.Dequeue().ToString();
                        while (comment == true)
                        {
                            if (inicioComments.Contains("*/"))//validación de cierre de comentarios de mcuhas lineas
                            {
                                comment = false;
                                break;
                            }
                            else if (linea.Count > 0)//Concantener al comentario todos los caracteres
                            {
                                inicioComments += linea.Dequeue().ToString();
                            }
                            else if (linea.Count == 0 && archivo.Count == llave)//En caso de no encontrar cierre de comentario, desplegara un error
                            {
                                salida.Add("*** EOF en Comentario");
                                errores.Add("*** EOF en Comentario");
                                correcto = false;
                                break;
                            }
                            else if (linea.Count == 0)// en caso de que la cola se haya vaciado y haya que hacer un cambio de linea
                            {
                                inicioComments += "\n";
                                llave++;
                                foreach (var item in archivo[llave].ToCharArray())//Cargar nueva luena en el comentario
                                {
                                    linea.Enqueue(item);
                                }

                            }

                        }
                        inicioComments = "";
                        comment = false;
                    }
                    else if (linea.Count == 0 && cadena != "") //en caso que la linea termine de ser leída y que la cadena en la que se concatena ya este vacia
                    {
                        if (fin < tamanio) //validación para tamaño de columnas
                            fin--;
                        else if (fin == tamanio && linea.Count != 0)
                        { fin--; }
                        ////////////////////////////////////////
                        if (validarCadena(cadena, llave, inicio, fin) == "")// validación en caso que al ir al metodo de validar lo que lleva cadena sea vacío
                        {
                            string dividir = cadena;
                            var error = dividir.ToCharArray();
                            int finError = inicio;
                            string palabras = "";
                            var colaPalabraDivirdir = new Queue<string>();
                            foreach (var item in error)// en caso que la cadena no haya sido analizada y cuente como error, se separa para su analisis en una cola
                            {
                                colaPalabraDivirdir.Enqueue(item.ToString());
                            }
                            do
                            {

                                if (validarCadena(palabras + colaPalabraDivirdir.Peek().ToString(), llave, inicio, fin) != "")//si la cadena a validar en qué token pertenece no es vacío y contiene algo
                                {
                                    palabras += colaPalabraDivirdir.Dequeue().ToString();// concatenamos la palabra
                                    finError++;
                                }
                                else
                                {
                                    if (finError < fin)//validación de columnas
                                        finError--;
                                    else if (fin == finError)
                                    { finError--; }
                                    salida.Add(validarCadena(palabras, llave, inicio, finError));//se manda a imprimir el error encontrado 
                                    tokens.Enqueue(palabras);
                                    finError++;
                                    inicio = finError;
                                    palabras = "";
                                }
                            } while (colaPalabraDivirdir.Count != 0); 
                            if (palabras != "")//En caso de no haber vaciado palabra, se evalua
                            {
                                if (finError > fin)//validación de columnas
                                    finError--;
                                else if (fin == finError)
                                { finError--; }
                                salida.Add(validarCadena(palabras, llave, inicio, finError));//se manda a imprimir el error encontrado 
                                tokens.Enqueue(palabras);
                                finError++;
                                inicio = finError;
                                fin = inicio;
                                palabras = "";
                            }
                        }
                        else// en caso de no tener error la cadena se agrega a la salida
                        {
                            salida.Add(validarCadena(cadena, llave, inicio, fin));
                            tokens.Enqueue(cadena);
                            fin = inicio;
                        }
                        cadena = "";
                        if (linea.Count != 0)
                        {
                            if (linea.Peek() == ' ' || linea.Peek() == '\t')// en caso de encontrar un espacio evalua las columnas y saca el caracter
                            {
                                linea.Dequeue();
                                inicio += 2;
                                fin = inicio;
                            }
                            else
                            {
                                //validación de columnas
                                inicio++;
                                fin = inicio;
                            }
                        }
                    }
                    else
                    {
                        if (cadena == "_") //reconoce caracter no valido en caso que no estuviera concatenado con letras al prinicipio como id
                        {
                            salida.Add("*** Error en linea " + llave + "caracter no reconocido: " + "'" + cadena + "'");//imprime error
                            errores.Add("*** Error en linea " + llave + "caracter no reconocido: " + "'" + cadena + "'");//se manda a errores
                            correcto = false;
                            inicio = fin;
                            cadena = "";

                        }
                        else if (linea.Peek() == '/')//encuentra al inicio de la cola si empieza con / para saber si es comentario lo que viene
                        {
                            if (cadena != "")//si cadena no es vacía para poder segui validando
                            {
                                if (fin < tamanio)//validacion de conteo de columnas
                                    fin--;
                                else if (fin == tamanio && linea.Count != 0)
                                { fin--; }
                                /////////////////////////////////////////////////////
                                if (validarCadena(cadena, llave, inicio, fin) == "")//se valida si lo que se envia a validar como token no está vacío
                                {
                                    string dividir = cadena;
                                    var error = dividir.ToCharArray();
                                    int finError = inicio;
                                    string palabras = "";
                                    var colaPalabraDivirdir = new Queue<string>();
                                    foreach (var item in error)//agregamos lo que esta en error para validar que error corresponde
                                    {
                                        colaPalabraDivirdir.Enqueue(item.ToString());
                                    }
                                    do
                                    {

                                        if (validarCadena(palabras + colaPalabraDivirdir.Peek().ToString(), llave, inicio, fin) != "")//validar  que palabra venga concatenado con lo que se dividió sea != null
                                        {
                                            palabras += colaPalabraDivirdir.Dequeue().ToString();
                                            finError++;
                                        }
                                        else
                                        {
                                            if (finError < fin)
                                                finError--;
                                            else if (fin == finError)
                                            { finError--; }
                                            salida.Add(validarCadena(palabras, llave, inicio, finError));
                                            tokens.Enqueue(palabras);
                                            finError++;
                                            inicio = finError;
                                            palabras = "";
                                        }
                                    } while (colaPalabraDivirdir.Count != 0); //proceso que se  termina mientras no sea fin de linea
                                    if (palabras != "") // si palabra donde concatenamos no es nula
                                    {
                                        if (finError > fin)//validamos conteo de cols
                                            finError--;
                                        else if (fin == finError) //si el fin que llevamos es igual al que tenia el error validado
                                        { finError--; }///le restamos el valor del final de cols de el error
                                        salida.Add(validarCadena(palabras, llave, inicio, finError));
                                        tokens.Enqueue(palabras);
                                        finError++;
                                        inicio = finError;
                                        fin = inicio;
                                        palabras = "";
                                    }
                                }
                                else//agregamos palabra para validar
                                {
                                    salida.Add(validarCadena(cadena, llave, inicio, fin));
                                    tokens.Enqueue(cadena);
                                    fin++;
                                    inicio = fin;
                                }
                                cadena = "";

                            }
                            inicioComments += linea.Dequeue().ToString(); //concatenamos lo que vemos desde inicio de comentarios
                            if(linea.Count != 0)
                            { 
                                if (linea.Peek() == '/') //si empezamos a validar un comentario
                                {
                                    do //mintras no sea fin de linea
                                    {
                                        inicioComments += linea.Dequeue().ToString(); //cpncatenamos el comentario
                                        fin++;
                                    } while (linea.Count > 0);
                                    inicio = fin; //igualamos cols para emepzar la siguiente palabra
                                }
                                else if (linea.Peek() == '*')//si miramos que viene un comentario de muchas lineas
                                {
                                    inicioComments += linea.Dequeue().ToString(); //continuamos concatenando comentario de varias lineas
                                    comment = true;
                                }
                                else
                                {
                                    if (cadena != "")
                                    {
                                        salida.Add(validarCadena(cadena, llave, inicio, fin));
                                        tokens.Enqueue(cadena);
                                        cadena = "";
                                        inicio = fin;
                                    }
                                    salida.Add(inicioComments + " en linea " + llave.ToString() + " cols " + inicio + " - " + fin + " es T_Operador");

                                    fin++;
                                    inicio = fin;
                                }
                            }
                            else
                            {
                                salida.Add(inicioComments +" en linea "+ llave +"cols "+inicio+" - "+fin+ "es T_operador");
                            }
                        }
                        else if (linea.Peek() == '*')// si encontramos  un inidicio de fin de comentario de fin de comentario de varias lineas
                        {
                            linea.Dequeue();
                            fin++;
                            inicio++;
                            if (linea.Count > 0)
                            {
                                if (linea.Peek() == '/') //aca encontramos que efectivamente es cierre de comentairo de varias lineas
                                {
                                    linea.Dequeue();
                                    fin++;
                                    inicio++;
                                    salida.Add("***Salida de comentario sin emparejar" + " en linea " + llave.ToString());
                                    errores.Add("***Salida de comentario sin emparejar" + " en linea " + llave.ToString());
                                    correcto = false;
                                }
                                else //como no es cierre de comentario de vaarias lineas se toma como operador aparte
                                {
                                    if (fin < tamanio)//validamos cols
                                        fin--;
                                    else if (fin == tamanio && linea.Count != 0)
                                    { fin--; }
                                    inicio = fin;
                                    salida.Add("simbolo : " + "*" + " en linea " + llave.ToString() + " cols " + inicio + " - " + fin); //mandamos operador a la salida
                                    tokens.Enqueue("*");
                                    fin++;
                                    inicio = fin;
                                }
                            }
                        }
                        else if (linea.Peek() == '"') //empezamos a validar si viene un string
                        {
                            bool correcto = true;
                            do
                            {
                                cadena += linea.Dequeue().ToString();//concatenamos los strings
                                fin++;
                                if (linea.Count == 0)
                                {
                                    salida.Add("Constante string sin terminar" + llave); 
                                    errores.Add("Constante string sin terminar" + llave);
                                    correcto = false;

                                    inicio = fin;
                                    break;
                                    correcto = false;
                                }

                            } while (linea.Peek() != '"'); //mientras no encuentre un cierre de string
                            if (correcto && linea.Count > 0) //mientras  el string no abarque mas de una linea
                            {
                                cadena += linea.Dequeue().ToString();//contiamos concatenando el string
                                
                                salida.Add( cadena + " en linea " + llave + " cols " + inicio + " - " + fin + " es T_ConstanteString" + " (valor = " +cadena+")"); //mandamos string a la salida de archivo
                                tokens.Enqueue(cadena);
                                fin++;
                                inicio = fin;
                                cadena = "";
                            }
                            cadena = "";
                        }
                        else if (enterosB10.IsMatch(cadena) && linea.Peek() == '.')//si viene 2.
                        {
                            cadena += linea.Dequeue().ToString();//continaumos concatenando el double
                            if (linea.Count == 0)//si la linea ya terminó
                            {
                                salida.Add(validarCadena(cadena, llave, inicio, fin));//se manda a validar el double que se tiene
                                tokens.Enqueue(cadena);
                                inicio = fin;
                                cadena = "";//vaciamos la cadena
                            }
                            else
                            {
                                while (linea.Peek() != ' ' && linea.Peek() != '.' && decimales1.IsMatch(cadena + linea.Peek().ToString()))//si cumple con la er permisiva se iran concatenando 
                                {
                                    cadena += linea.Dequeue().ToString();
                                    fin++;
                                    if (linea.Count == 0)
                                    {
                                        break;
                                    }

                                }
                                /////////////////////////////////////////
                                if (validarCadena(cadena, llave, inicio, fin) == "")//se valida si lo que se envia a validar como token no está vacío
                                {
                                    string dividir = cadena;
                                    var error = dividir.ToCharArray();
                                    int finError = inicio;
                                    string palabras = "";
                                    var colaPalabraDivirdir = new Queue<string>();
                                    foreach (var item in error)//agregamos lo que esta en error para validar que error corresponde
                                    {
                                        colaPalabraDivirdir.Enqueue(item.ToString());
                                    }
                                    do
                                    {

                                        if (validarCadena(palabras + colaPalabraDivirdir.Peek().ToString(), llave, inicio, fin) != "")//validar  que palabra venga concatenado con lo que se dividió sea != null
                                        {
                                            palabras += colaPalabraDivirdir.Dequeue().ToString();
                                            finError++;
                                        }
                                        else
                                        {
                                            if (finError < fin)
                                                finError--;
                                            else if (fin == finError)
                                            { finError--; }
                                            salida.Add(validarCadena(palabras, llave, inicio, finError));
                                            tokens.Enqueue(palabras);
                                            finError++;
                                            inicio = finError;
                                            palabras = "";
                                        }
                                    } while (colaPalabraDivirdir.Count != 0); //proceso que se  termina mientras no sea fin de linea
                                    if (palabras != "") // si palabra donde concatenamos no es nula
                                    {
                                        if (finError > fin)//validamos conteo de cols
                                            finError--;
                                        else if (fin == finError) //si el fin que llevamos es igual al que tenia el error validado
                                        { finError--; }///le restamos el valor del final de cols de el error
                                        salida.Add(validarCadena(palabras, llave, inicio, finError));
                                        tokens.Enqueue(palabras);
                                        finError++;
                                        inicio = finError;
                                        fin = inicio;
                                        palabras = "";
                                    }
                                }
                                else
                                {
                                    salida.Add(validarCadena(cadena, llave, inicio, fin));
                                    tokens.Enqueue(cadena);
                                    inicio = fin;
                                }
                                cadena = "";
                                if (linea.Count != 0)
                                {
                                    inicio++;
                                    fin = inicio;
                                }


                            }
                        }
                        //sacar caracter y concatenar en cadena
                        else if (linea.Peek() != '\n' && linea.Peek() != '\t' && linea.Peek() != ' ' && !simbolosOtros.Contains(linea.Peek().ToString()) && (caracterNoValido.IsMatch(linea.Peek().ToString()) || (linea.Peek() == '|' )) && cadena.Length <= 31)
                        {
                            cadena += linea.Dequeue().ToString();
                            fin++;
                        }
                        //Descartar caracteres en caso de ser identificadores muy largos (<31)
                        else if (linea.Peek() != '\n' && linea.Peek() != '\t' && linea.Peek() != ' ' && !simbolosOtros.Contains(linea.Peek().ToString()) && (caracterNoValido.IsMatch(linea.Peek().ToString()) || (linea.Peek() == '|')) && cadena.Length > 31)
                        {
                            linea.Dequeue();
                            fin++;
                        }
                        //en caso de que en la cola venga un simbolo
                        else if (simbolosOtros.Contains(linea.Peek().ToString()) || linea.Peek() == '+' || linea.Peek() == '-' || linea.Peek() == '.')
                        {
                            if (cadena != "")
                            {
                                if (fin < tamanio)
                                    fin--;
                                else if( fin==tamanio && linea.Count != 0)
                                { fin--; }
                                ///////////////////////////////////////
                                //validar en caso de que tenga error
                                if (validarCadena(cadena, llave, inicio, fin) == "")
                                {
                                    string dividir = cadena;
                                    var error = dividir.ToCharArray();
                                    int finError = inicio;
                                    string palabras = "";
                                    var colaPalabraDivirdir = new Queue<string>();
                                    //Caragar la cadena en caso de que tenga una cadena antes de un simbolo
                                    foreach (var item in error)
                                    {
                                        colaPalabraDivirdir.Enqueue(item.ToString());
                                    }
                                    do
                                    {
                                        //Si tiene error concatena
                                        if (validarCadena(palabras + colaPalabraDivirdir.Peek().ToString(), llave, inicio, fin) != "")
                                        {
                                            palabras += colaPalabraDivirdir.Dequeue().ToString();
                                            finError++;
                                        }
                                        //Si no tiene error agrega a la salida 
                                        else
                                        {
                                            if (finError < fin)
                                                finError--;
                                            else if (fin == finError)
                                            { finError--; }
                                            salida.Add(validarCadena(palabras, llave, inicio, finError));
                                            tokens.Enqueue(palabras);
                                            finError++;
                                            inicio = finError;
                                            palabras = "";
                                        }
                                    } while (colaPalabraDivirdir.Count != 0);
                                    //si palabra no esta vacia lo agreaga a la lista
                                    if (palabras != "")
                                    {
                                        if (finError > fin)
                                            finError--;
                                        else if (fin == finError)
                                        { finError--; }
                                        salida.Add(validarCadena(palabras, llave, inicio, finError));
                                        tokens.Enqueue(palabras);
                                        finError++;
                                        inicio = finError;
                                        fin = inicio;
                                        palabras = "";
                                    }
                                }
                                else// i no hay error agrega a la lista
                                {
                                    salida.Add(validarCadena(cadena, llave, inicio, fin));
                                    tokens.Enqueue(cadena);
                                    fin++;
                                    inicio = fin;
                                }
                                cadena = "";

                            }
                            string cadenaSimbolos = "";
                            //saca el primer caracter al ser un  simbolo
                            cadenaSimbolos = linea.Dequeue().ToString();
                            //La pila al estar vacia no agregara mas por lo que mostrara el simbolo
                            if (linea.Count == 0)
                            {
                                salida.Add(cadenaSimbolos + " en linea " + llave + " cols " + inicio + " - " + fin + " es T_Operador");
                                tokens.Enqueue(cadenaSimbolos);
                                inicio = fin;
                            }
                            //Si el simbolo lo persigue otro simbolo lo concatena 
                            else if (simbolosOtros.Contains(cadenaSimbolos + linea.Peek().ToString()) && cadenaSimbolos != "")
                            {
                                cadenaSimbolos += linea.Dequeue().ToString();
                                fin++;
                                salida.Add(cadenaSimbolos + " en linea " + llave.ToString() + " cols " + inicio + " - " + (fin).ToString() + " es T_Operador");
                                tokens.Enqueue(cadenaSimbolos);
                                inicio = fin;
                            }
                            //saca el cimbolo
                            else
                            {
                                salida.Add(cadenaSimbolos + " en linea " + llave.ToString() + " cols " + (inicio) + " - " + fin +" es T_Operador");
                                tokens.Enqueue(cadenaSimbolos);
                            }
                            //Sacar espacios y calibrar columnas 
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
                        //Si cadena No esta vacia lo evalua
                        else if (cadena != "")
                        {
                            if (fin < tamanio)
                                fin--;
                            else if (fin == tamanio && linea.Count != 0)
                            { fin--; }
                            //////////////////////////////////////
                            if (validarCadena(cadena, llave, inicio, fin) == "")
                            {
                                string dividir = cadena;
                                var error = dividir.ToCharArray();
                                int finError = inicio;
                                string palabras = "";
                                var colaPalabraDivirdir = new Queue<string>();
                                foreach (var item in error)
                                {
                                    colaPalabraDivirdir.Enqueue(item.ToString());
                                }
                                do
                                {

                                    if (validarCadena(palabras + colaPalabraDivirdir.Peek().ToString(), llave, inicio, fin) != "")
                                    {
                                        palabras += colaPalabraDivirdir.Dequeue().ToString();
                                        finError++;
                                    }
                                    else
                                    {
                                        if (finError < fin)
                                            finError--;
                                        else if (fin == finError)
                                        { finError--; }
                                        salida.Add(validarCadena(palabras, llave, inicio, finError));
                                        tokens.Enqueue(palabras);
                                        finError++;
                                        inicio = finError;
                                        palabras = "";
                                    }
                                } while (colaPalabraDivirdir.Count != 0);
                                if (palabras != "")
                                {
                                    if (finError > fin)
                                        finError--;
                                    else if (fin == finError)
                                    { finError--; }
                                    salida.Add(validarCadena(palabras, llave, inicio, finError));
                                    tokens.Enqueue(palabras);
                                    finError++;
                                    inicio = finError;
                                    fin = inicio;
                                    palabras = "";
                                }
                            }
                            else
                            {
                                salida.Add(validarCadena(cadena, llave, inicio, fin));
                                tokens.Enqueue(cadena);
                                inicio = fin;
                            }

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
                        //Saco los espacios en caso y calibra las columnas
                        else if (linea.Peek() == ' ' || linea.Peek() == '\t')
                        {
                                
                            linea.Dequeue();
                            inicio++;
                            fin = inicio;
                        }
                        //Caracter no valido en caso de no cumplir nada
                        else
                        {
                            string caracter = linea.Dequeue().ToString();
                            salida.Add("*** Error en linea " +  llave + "caracter no reconocido: "+ "'"+ caracter +"'");
                            errores.Add("*** Error en linea " + llave + "caracter no reconocido: " + "'" + caracter + "'");
                            correcto = false;
                            fin++;
                            inicio = fin;
                        }



                    }


                }

                //Cambia de linea
                llave++;
            } while (archivo.ContainsKey(llave));//En caso de que la linea exista en el archivo
            //Saca la salida de los tokens 
            return salida;
        }
        
        private string validarCadena(string cadena, int llave, int inicio, int final)
        {
            if (cadena.Length < 31)
            {

                if (reservadas.IsMatch(cadena))
                {

                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + " es T_reservada";
                }
                else if (booleano.IsMatch(cadena))
                {
                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + "es T_ConstanteBooleana";
                }
                else if (cadena == "&&" || cadena == "||")
                {
                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + "es T_Operador";
                }
                else if (id.IsMatch(cadena))
                {

                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + " es T_identificador";
                }
                else if (enterosB10.IsMatch(cadena))
                {

                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + " es T_ConstanteIntB10" + " (valor = " + cadena + ")";
                }
                else if (enterosB16.IsMatch(cadena))
                {
                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + " es T_ConstanteIntB16" + " (valor = " + cadena + ")";
                }
                else if (decimales2.IsMatch(cadena))
                {
                    return cadena + " en linea " + llave.ToString() + " Cols " + inicio + " - " + final + " es T_ConstanteDouble" + " (valor = " + cadena + ")";
                }
                else if (simbolosOtros.Contains(cadena))
                {
                    return cadena+ " en linea " + llave.ToString() + " cols " + inicio + " - " + final + " es T_Operador";
                }
                else
                {


                    return "";
                }
            }
            else
            {
                return "****Error T_identificador muy largo: " + cadena + " en linea " + llave.ToString() + "\n";

            }
        }//Valida si la cadena pertenece a reservadas, identificadores, enterosB10, Enteros B16, simbolos, o si e
    }
}
