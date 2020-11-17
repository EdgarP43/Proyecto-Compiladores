using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores2020
{
    class TablaSimbolos 
    {
        public Queue<Token> cadenas = new Queue<Token>();
        public List<Variable> variables = new List<Variable>();
        public Dictionary<string, string> variablesPerAmbito = new Dictionary<string, string>();

        public void Inicar()
        {

            do
            {

                if (cadenas.Peek().contenido == "const")
                {
                    var temp = new Variable();
                    temp.ambito = cadenas.Dequeue().contenido + "Global";
                    temp.tipo = cadenas.Dequeue().contenido;
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.valor = "";
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    cadenas.Dequeue();
                    variables.Add(temp);
                }
                else if (cadenas.Peek().contenido == "int" || cadenas.Peek().contenido == "double" || cadenas.Peek().contenido == "bool" || cadenas.Peek().contenido == "string" || cadenas.Peek().tipo == "ident")
                {
                    var temp = new Variable();
                    string aux = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == "[]")
                        cadenas.Dequeue();
                    string auxIdentificador = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == ";")
                    {
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = "Variable Global";
                        temp.valor = "";
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        variables.Add(temp);
                        cadenas.Dequeue();
                    }
                    else if (cadenas.Peek().contenido == "(")
                    {
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = "Metodo" + auxIdentificador;
                        temp.valor = "";
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        cadenas.Dequeue();
                        AnalizarParametros(temp.ambito);
                        AnalizarFuncion(temp.ambito);
                    }
                }
                else if (cadenas.Peek().contenido == "void")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Funcion";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = "Metodo" + temp.identificador;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    cadenas.Dequeue();
                    AnalizarParametros(temp.ambito);
                    AnalizarFuncion(temp.ambito);
                }
                else if (cadenas.Peek().contenido == "class")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Clase";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = "clase" + temp.identificador;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    if(cadenas.Peek().contenido == ":")
                    {
                        cadenas.Dequeue();
                        heredados();
                    }
                    clase(temp.ambito);
                }
                else if (cadenas.Peek().contenido == "interface")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Interfaz";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = "Interfaz" + temp.identificador;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    interfaz(temp.ambito);
                }

            } while (cadenas.Count > 0);
        }

        public void AnalizarParametros(string ambito)
        {
            do
            {

                var temp = new Variable();
                temp.ambito = ambito;
                temp.tipo = cadenas.Dequeue().contenido;
                temp.identificador = cadenas.Dequeue().contenido;
                temp.valor = "";
                variables.Add(temp);
                variablesPerAmbito.Add(temp.identificador, ambito);
                if (cadenas.Peek().contenido == ",")
                    cadenas.Dequeue();
            } while (cadenas.Peek().contenido == ")");
            cadenas.Dequeue();
        }
        public void AnalizarFuncion(string ambito)
        {
            cadenas.Dequeue();
            do
            {
                if (cadenas.Peek().contenido == "const")
                {
                    var temp = new Variable();
                    temp.ambito = cadenas.Dequeue().contenido + ambito;
                    temp.tipo = cadenas.Dequeue().contenido;
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.valor = "";
                    variablesPerAmbito.Add(temp.identificador, ambito);
                    cadenas.Dequeue();
                    variables.Add(temp);
                }
                else if (cadenas.Peek().contenido == "int" || cadenas.Peek().contenido == "double" || cadenas.Peek().contenido == "bool" || cadenas.Peek().contenido == "string" || cadenas.Peek().tipo == "ident")
                {
                    var temp = new Variable();
                    string aux = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == "[]")
                        cadenas.Dequeue();
                    string auxIdentificador = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == ";")
                    {
                        cadenas.Dequeue();
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = "Variable " + ambito;
                        temp.valor = "";
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, ambito);
                    }
                }
                else if (cadenas.Peek().contenido == "while")
                {
                    cadenas.Dequeue();
                    cadenas.Dequeue();
                    expresion(ambito);
                    if (cadenas.Peek().contenido == "{")
                    {
                        //{
                        AnalizarFuncion(ambito);

                    }

                }
                else if (cadenas.Peek().contenido == "if")
                {
                    cadenas.Dequeue();
                    expresion(ambito);
                    if (cadenas.Peek().contenido == "{")
                    {
                        //{
                        AnalizarFuncion(ambito);

                    }
                }
                else if (cadenas.Peek().contenido == "break")
                {
                    cadenas.Dequeue();
                    cadenas.Dequeue();//;
                }
                else if (cadenas.Peek().contenido == "return")
                {

                    cadenas.Dequeue();
                    expresion(ambito);
                    cadenas.Dequeue();//;
                }
                else if (cadenas.Peek().contenido == "Console")
                {
                    cadenas.Dequeue();
                    cadenas.Dequeue();
                    cadenas.Dequeue();
                    expresion(ambito);
                    if (cadenas.Peek().contenido == ",")
                    {
                        do
                        {
                            cadenas.Dequeue();
                            expresion(ambito);
                        } while (cadenas.Peek().contenido == ",");
                    }
                    cadenas.Dequeue();//;
                    cadenas.Dequeue();

                }
                else if (cadenas.Peek().contenido == "for")
                {
                    cadenas.Dequeue();
                    cadenas.Dequeue();
                    expresion(ambito);
                    cadenas.Dequeue();//;
                    expresion(ambito);
                    cadenas.Dequeue();//;
                    expresion(ambito);
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "{")
                    {
                        //{
                        AnalizarFuncion(ambito);

                    }
                    else if (cadenas.Peek().contenido == ";")
                    {
                        cadenas.Dequeue(); //;  muere
                    }
                }

            } while (cadenas.Peek().contenido == "}");
            cadenas.Dequeue();
        }
        public Variable obtenerVariable(string identificador, string ambito)
        {
            Variable encontrado = new Variable();
            encontrado.identificador = identificador;
            encontrado.ambito = ambito;
            foreach (var item in variables)
            {
                if (encontrado.identificador == item.identificador && item.ambito == ambito)
                {
                    encontrado = item;
                    break;
                }

            }

            return encontrado;
        }
        public void expresion(string ambito)
        {
            if (cadenas.Peek().contenido == "(")
            {
                var varTemp = obtenerVariable(cadenas.Peek().contenido, ambito);
                cadenas.Dequeue();
                if (cadenas.Peek().contenido == "==" || cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == ".")
                {
                    cadenas.Dequeue();
                    if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                    {
                        var temp = obtenerVariable(cadenas.Peek().contenido, ambito);
                        if (varTemp.tipo == temp.tipo)
                        {
                            cadenas.Dequeue();
                            cadenas.Dequeue();
                        }
                        else
                        {
                            //validacion de tipos mala
                        }
                    }
                    else
                    {
                        //error  no tiene nada con que comparar u operar
                    }
                }
                cadenas.Dequeue();
            }
            else
            {
                if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                {

                    var varTemp = obtenerVariable(cadenas.Peek().contenido, ambito);
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "==" || cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == ".")
                    {
                        cadenas.Dequeue();
                        if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                        {
                            var temp = obtenerVariable(cadenas.Peek().contenido, ambito);
                            if (varTemp.tipo == temp.tipo)
                            {
                                cadenas.Dequeue();
                                cadenas.Dequeue();
                            }

                        }
                    }
                }
            }
        }
        public void clase(string ambito)
        {
            cadenas.Dequeue(); //{
            if (cadenas.Peek().contenido == "const")
            {
                var temp = new Variable();
                temp.ambito = cadenas.Dequeue().contenido + "Global";
                temp.tipo = cadenas.Dequeue().contenido;
                temp.identificador = cadenas.Dequeue().contenido;
                temp.valor = "";
                variablesPerAmbito.Add(temp.identificador, temp.ambito);
                cadenas.Dequeue();
                variables.Add(temp);
            }
            else if (cadenas.Peek().contenido == "int" || cadenas.Peek().contenido == "double" || cadenas.Peek().contenido == "bool" || cadenas.Peek().contenido == "string" || cadenas.Peek().tipo == "ident")
            {
                var temp = new Variable();
                string aux = cadenas.Dequeue().contenido;
                if (cadenas.Peek().contenido == "[]")
                    cadenas.Dequeue();
                string auxIdentificador = cadenas.Dequeue().contenido;
                if (cadenas.Peek().contenido == ";")
                {
                    cadenas.Dequeue();
                    temp.tipo = aux;
                    temp.identificador = auxIdentificador;
                    temp.ambito = "Variable Global";
                    temp.valor = "";
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    variables.Add(temp);
                }
                else if (cadenas.Peek().contenido == "(")
                {
                    cadenas.Dequeue();
                    temp.tipo = aux;
                    temp.identificador = auxIdentificador;
                    temp.ambito = "Metodo" + auxIdentificador;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    cadenas.Dequeue();
                    AnalizarParametros(temp.ambito);
                    AnalizarFuncion(temp.ambito);
                }
            }
            else if (cadenas.Peek().contenido == "void")
            {
                cadenas.Dequeue();
                var temp = new Variable();
                temp.tipo = "Funcion";
                temp.identificador = cadenas.Dequeue().contenido;
                temp.ambito = "Metodo" + temp.identificador;
                temp.valor = "";
                variables.Add(temp);
                variablesPerAmbito.Add(temp.identificador, temp.ambito);
                cadenas.Dequeue();
                AnalizarParametros(temp.ambito);
                AnalizarFuncion(temp.ambito);
            }
            cadenas.Dequeue();//}
        }   
        public void heredados()
        {
            do
            {
                var temp = new Variable();
                temp.tipo = "Clase";
                temp.identificador = cadenas.Dequeue().contenido;
                temp.ambito = "Clase" + temp.identificador;
                temp.valor = "";
                variables.Add(temp);
                variablesPerAmbito.Add(temp.identificador, temp.ambito);
                if (cadenas.Peek().contenido == ",")
                    cadenas.Dequeue();
            } while (cadenas.Peek().contenido == "{");
        }

        public void interfaz(string ambito)
        {
            cadenas.Dequeue(); //{
            do
            {
                if (cadenas.Peek().contenido == "int" || cadenas.Peek().contenido == "double" || cadenas.Peek().contenido == "bool" || cadenas.Peek().contenido == "string" || cadenas.Peek().tipo == "ident")
                {
                    var temp = new Variable();
                    string aux = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == "[]")
                        cadenas.Dequeue();
                    string auxIdentificador = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == "(")
                    {
                        cadenas.Dequeue();
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = ambito + "Metodo" + auxIdentificador;
                        temp.valor = "";
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        cadenas.Dequeue();
                        AnalizarParametros(temp.ambito);
                        cadenas.Dequeue();//;
                    }
                }
                else if (cadenas.Peek().contenido == "void")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Funcion";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = ambito + "Metodo" + temp.identificador;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    cadenas.Dequeue();
                    AnalizarParametros(temp.ambito);
                    cadenas.Dequeue();//
                }
            } while (cadenas.Peek().contenido == "}");

            cadenas.Dequeue();//}
        }
    }
}
