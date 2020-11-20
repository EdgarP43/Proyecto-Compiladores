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
        public List<string> ambitos = new List<string>();

        public void Inicar()
        {

            do
            {

                if (cadenas.Peek().contenido == "const")
                {
                    var temp = new Variable();
                    temp.ambito = "Global";
                    temp.tipo = cadenas.Dequeue().contenido + " " + cadenas.Dequeue().contenido;
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.valor = "";
                    if (variablesPerAmbito.Count == 0)
                    {
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        ambitos.Add(temp.ambito);
                        cadenas.Dequeue();
                    }
                    else if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        cadenas.Dequeue();
                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                        cadenas.Dequeue();
                    }
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
                        temp.tipo = "Variable " + aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = "Global";
                        temp.valor = "";
                        if (variablesPerAmbito.Count == 0)
                        {
                            variables.Add(temp);
                            variablesPerAmbito.Add(temp.identificador, temp.ambito);
                            ambitos.Add(temp.ambito);
                            cadenas.Dequeue();
                        }
                        else if (!EvaluarRepetido(temp.ambito, temp.identificador))
                        {
                            variables.Add(temp);
                            variablesPerAmbito.Add(temp.identificador, temp.ambito);
                            cadenas.Dequeue();
                        }
                        else
                        {
                            string prueba = "Sa mierda ya la repetiste";
                            cadenas.Dequeue();
                        }
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


                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, temp.ambito);
                        cadenas.Dequeue();
                        AnalizarParametros(temp.ambito);
                        AnalizarFuncion(temp.ambito);

                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                        cadenas.Dequeue();
                    }

                }
                else if (cadenas.Peek().contenido == "class")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Clase";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = "clase" + temp.identificador;
                    temp.valor = "";
                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);

                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                        cadenas.Dequeue();
                    }

                    //variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    if (cadenas.Peek().contenido == ":")
                    {
                        cadenas.Dequeue();
                        heredados(temp.ambito);
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
                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                        interfaz(temp.ambito);

                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                        cadenas.Dequeue();
                    }
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
                if (!EvaluarRepetido(ambito, temp.identificador))
                {
                    variables.Add(temp);
                }
                else
                {
                    string prueba = "Sa mierda ya la repetiste";
                }
                if (cadenas.Peek().contenido == ",")
                {
                    cadenas.Dequeue();
                }
            } while (cadenas.Peek().contenido != ")");
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
                    if (!variablesPerAmbito.ContainsKey(temp.identificador) && !variablesPerAmbito[temp.identificador].Contains(ambito))
                    {
                        variables.Add(temp);
                        variablesPerAmbito.Add(temp.identificador, ambito);
                    }
                    else
                    {
                        //Variable existente
                    }
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
                        if (!variablesPerAmbito.ContainsKey(temp.identificador) && !variablesPerAmbito[temp.identificador].Contains(ambito))
                        {
                            variables.Add(temp);
                            variablesPerAmbito.Add(temp.identificador, ambito);
                        }
                        else
                        {
                            //Variable existente
                        }
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
                else if 
                       (cadenas.Peek().tipo == "ident"  || cadenas.Peek().tipo == "string" || cadenas.Peek().tipo == "bool"|| cadenas.Peek().tipo == "int" ||
                       cadenas.Peek().tipo == "double" || cadenas.Peek().contenido == "New"  || cadenas.Peek().contenido == "null" || cadenas.Peek().contenido == "!" 
                       || cadenas.Peek().contenido == "-" || cadenas.Peek().contenido == "this" || cadenas.Peek().contenido == "(")
                { 
                    expresion(ambito); //saco tipo

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
                cadenas.Dequeue();
                expresion(ambito);
                cadenas.Dequeue();
            }
            else if (cadenas.Peek().contenido == "!")
            {
                cadenas.Dequeue();
                expresion(ambito);
            }
            else if (cadenas.Peek().contenido == "-")
            {
                cadenas.Dequeue();
                expresion(ambito);
            }
            else
            {
                if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                {

                    var varTemp = obtenerVariable(cadenas.Peek().contenido, ambito);
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "==" || cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%")
                    {
                        cadenas.Dequeue();
                        if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                        {
                            var temp = obtenerVariable(cadenas.Peek().contenido, ambito);
                            if (varTemp.tipo == temp.tipo)
                            {
                                cadenas.Dequeue();
                                
                            }

                        }
                        else if (cadenas.Peek().contenido == "this" || cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "double" || cadenas.Peek().tipo == "bool" || cadenas.Peek().tipo == "string" || cadenas.Peek().contenido == "null")
                        {
                            cadenas.Dequeue();

                        }
                    }
                    if (cadenas.Peek().contenido ==  ".")
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
                        if(cadenas.Peek().contenido == "(")
                        {
                            cadenas.Dequeue();
                            actuals(ambito);
                            cadenas.Dequeue();
                        }
                        else if (cadenas.Peek().contenido == "=")
                        {
                            cadenas.Dequeue();
                            expresion(ambito);
                        }

                    }
                }
                else if(cadenas.Peek().contenido == "this" || cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "double" || cadenas.Peek().tipo == "bool" || cadenas.Peek().tipo == "string" || cadenas.Peek().contenido == "null")
                {
                    string tipo = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().contenido == "==" || cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%")
                    {
                        cadenas.Dequeue();
                        if (variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito))
                        {
                            var temp = obtenerVariable(cadenas.Peek().contenido, ambito);
                            if (tipo == temp.tipo)
                            {
                                cadenas.Dequeue();
                            }

                        }
                        else if (cadenas.Peek().contenido == "this" || cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "double" || cadenas.Peek().tipo == "bool" || cadenas.Peek().tipo == "string" || cadenas.Peek().contenido == "null")
                        {
                            cadenas.Dequeue();

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
                temp.ambito = ambito;
                temp.tipo = cadenas.Dequeue().contenido;
                temp.identificador = cadenas.Dequeue().contenido;
                temp.valor = "";

                if (!EvaluarRepetido(temp.ambito, temp.identificador))
                {
                    variables.Add(temp);
                    cadenas.Dequeue();
                }
                else
                {
                    string prueba = "Sa mierda ya la repetiste";
                    cadenas.Dequeue();
                }
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
                    temp.ambito = ambito + "Variable";
                    temp.valor = "";
                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                    }
                }
                else if (cadenas.Peek().contenido == "(")
                {
                    cadenas.Dequeue();
                    temp.tipo = aux;
                    temp.identificador = auxIdentificador;
                    temp.ambito = "Metodo" + auxIdentificador;
                    temp.valor = "";
                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                    }
                    else
                    {
                        string prueba = "Sa mierda ya la repetiste";
                    }
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
                if (!EvaluarRepetido(temp.ambito, temp.identificador))
                {
                    variables.Add(temp);
                }
                else
                {
                    string prueba = "Sa mierda ya la repetiste";
                }
                cadenas.Dequeue();
                AnalizarParametros(temp.ambito);
                AnalizarFuncion(temp.ambito);
            }
            cadenas.Dequeue();//}
        }   
        public void heredados(string ambito)
        {
            do
            {
                var temp = new Variable();
                temp.tipo = "Clase";
                temp.identificador = cadenas.Dequeue().contenido;
                temp.ambito = ambito + "Clase" + temp.identificador;
                temp.valor = "";
                
                if (!EvaluarRepetido(temp.ambito, ambito))
                {
                    variables.Add(temp);
                }
                else
                {
                    string prueba = "Sa mierda ya la repetiste";
                }
                if (cadenas.Peek().contenido == ",")
                    cadenas.Dequeue();
            } while (cadenas.Peek().contenido != "{");
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
                        temp.tipo = "Metodo " + aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = ambito;
                        temp.valor = "";
                        if (variablesPerAmbito.Count == 0)
                        {
                            variables.Add(temp);
                            variablesPerAmbito.Add(temp.identificador, temp.ambito + "Metodo " + aux + auxIdentificador);
                            AnalizarParametros(temp.ambito + "Metodo " + aux + auxIdentificador);
                            cadenas.Dequeue();
                        }
                        else if (!EvaluarRepetido(temp.ambito, temp.identificador))
                        {
                            variables.Add(temp);
                            //variablesPerAmbito.Add(temp.identificador, temp.ambito + "Metodo" + auxIdentificador);
                            AnalizarParametros(temp.ambito + "Metodo " + aux + auxIdentificador);

                            cadenas.Dequeue();
                        }
                        else
                        {
                            string prueba = "Sa mierda ya la repetiste";
                            AnalizarParametros(temp.ambito + "Metodo " + aux + auxIdentificador);
                            cadenas.Dequeue();
                        }
                    }
                }
                else if (cadenas.Peek().contenido == "void")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Funcion";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = ambito ;
                    temp.valor = "";
                    variables.Add(temp);
                    variablesPerAmbito.Add(temp.identificador, temp.ambito);
                    cadenas.Dequeue();
                    AnalizarParametros(temp.ambito + "Metodo" + temp.identificador);
                    cadenas.Dequeue();//
                }
            } while (cadenas.Peek().contenido != "}");

            cadenas.Dequeue();//}
        }
        public void actuals(string ambito)
        {
            do
            {
                expresion(ambito);
                if(cadenas.Peek().contenido == ",")
                    cadenas.Dequeue();
            } while (cadenas.Peek().contenido != ")");
        }
        public bool EvaluarRepetido (string ambito, string identificador)
        {
            var temporal = new List<Variable>();
            bool repetido = false;
            foreach(var item in variables)
            {
                if(item.ambito == ambito)
                {
                    temporal.Add(item);
                }
            }
            foreach (var item in temporal)
            {
                if (item.identificador == identificador)
                {
                    repetido = true;
                }
            }
            return repetido;
        }
    }
}