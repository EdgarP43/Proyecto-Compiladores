using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoCompiladores2020
{
    class TablaSimbolos 
    {
        public Queue<Token> cadenas = new Queue<Token>();
        public List<Variable> variables = new List<Variable>();
        public Dictionary<string, string> variablesPerAmbito = new Dictionary<string, string>();
        public List<string> ambitos = new List<string>();
        public List<string> errores = new List<string>();

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
                        
                        errores.Add("constante ya existente en id " + temp.identificador);
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
                            
                            errores.Add("Variable ya existente en id " + temp.identificador);
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
                        cadenas.Dequeue();
                        AnalizarParametros(temp.ambito);
                        AnalizarFuncion(temp.ambito);

                    }
                    else
                    {
                       
                        errores.Add("método ya existente en id " + temp.identificador);
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
                       
                        errores.Add("Variable ya existente en id " + temp.identificador);
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
                       
                        errores.Add("Interfaz ya declarada "+ temp.identificador);
                        cadenas.Dequeue();
                    }
                }
            } while (cadenas.Count > 0);
            //archivo(variables);
        }

        public void archivo(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in variables)
                {
                    sw.WriteLine("{" + "\n" + "\t" +"Id: "+item.identificador + "\n" + "\t" + "Tipo: " + item.tipo + "\n" + "\t" + "Valor: " + item.valor  + "\n" + "\t" + "Ambito: " + item.ambito+ "\n" + "}");
                    sw.WriteLine("\n");
                }
            }
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
                   
                    errores.Add("Variable ya existente en id "+ temp.identificador);
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
                    temp.ambito = ambito;
                    temp.tipo = cadenas.Dequeue().contenido + cadenas.Dequeue().contenido;
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.valor = "";

                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                        cadenas.Dequeue();
                    }
                    else
                    {
                        errores.Add("Variable ya existente en id " + temp.identificador);
                    
                        cadenas.Dequeue();
                    }
                }
                else if (cadenas.Peek().contenido == "int" || cadenas.Peek().contenido == "double" || cadenas.Peek().contenido == "bool" || cadenas.Peek().contenido == "string" || cadenas.Peek().tipo == "ident")
                {
                    var temp = new Variable();
                    string aux = cadenas.Dequeue().contenido;
                    if (cadenas.Peek().tipo == "ident")
                    {
                        string auxIdentificador = cadenas.Dequeue().contenido;
                        cadenas.Dequeue();
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = ambito;
                        temp.valor = "";
                        if (!EvaluarRepetido(temp.ambito, temp.identificador))
                        {
                            variables.Add(temp);
                        }
                        else
                        {
                            errores.Add("Variable ya existente en id " + temp.identificador);
                            
                        }
                    }
                    else if (cadenas.Peek().contenido == "=")
                    {
                        cadenas.Dequeue();
                        if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident")))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                        {
                            var varTemp = obtenerVariable(cadenas.Peek().contenido, ambito);
                            if (varTemp.tipo == temp.tipo)
                            {
                                ReasignarValor(temp.valor, varTemp.identificador, varTemp.ambito);
                                cadenas.Dequeue();
                            }

                        }
                        else if (cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "string" || cadenas.Peek().tipo == "bool" || cadenas.Peek().tipo == "double")
                        {
                            if (EvaluarExistencia(ambito, aux))
                            {
                                var varTemp = obtenerVariable(aux, ambito);
                                if (varTemp.tipo == cadenas.Peek().tipo)
                                {
                                    ReasignarValor(cadenas.Dequeue().contenido, varTemp.identificador, varTemp.ambito);
                                    cadenas.Dequeue();
                                }
                            }
                            else
                            {
                                cadenas.Dequeue();
                                cadenas.Dequeue();
                                //no esta sa mierda
                                errores.Add("identificador no declarado " + aux);
                            }
                        }
                    }
                    if (cadenas.Peek().contenido == "[]")
                        cadenas.Dequeue();
                    
                    
                }
                else if (cadenas.Peek().contenido == "while")
                {
                    cadenas.Dequeue();
                    cadenas.Dequeue();
                    expresion(ambito);
                    cadenas.Dequeue();
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
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "{")
                    {
                        //{
                        AnalizarFuncion(ambito);

                    }
                }
                else if (cadenas.Peek().contenido == "else")
                {
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "if")
                    {
                        cadenas.Dequeue();
                        expresion(ambito);
                        cadenas.Dequeue();
                        if (cadenas.Peek().contenido == "{")
                        {
                            //{
                            AnalizarFuncion(ambito);

                        }
                    }
                    else if (cadenas.Peek().contenido == "{")
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

            } while (cadenas.Peek().contenido != "}");
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
                if (cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == "*" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "==")
                {
                    cadenas.Dequeue();
                    expresion(ambito);
                }
            }
            else if (cadenas.Peek().contenido == "!")
            {
                cadenas.Dequeue();
                expresion(ambito);
                if (cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == "*" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "==")
                {
                    cadenas.Dequeue();
                    expresion(ambito);
                }
            }
            else if (cadenas.Peek().contenido == "-")
            {
                cadenas.Dequeue();
                expresion(ambito);
                if (cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == "*" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "==")
                {
                    cadenas.Dequeue();
                    expresion(ambito);
                }
            }
            else
            {
                if (EvaluarExistencia( ambito,cadenas.Peek().contenido))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                {

                    var varTemp = obtenerVariable(cadenas.Peek().contenido, ambito);
                    cadenas.Dequeue();
                    if (cadenas.Peek().contenido == "==" || cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%")
                    {
                        cadenas.Dequeue();
                        if (EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident"))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
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
                        else
                        {
                           
                            errores.Add("identificador no declarado "+cadenas.Peek().contenido);
                            cadenas.Dequeue();
                        }
                    }
                    else if(cadenas.Peek().contenido == "=")
                    {
                        cadenas.Dequeue();
                        if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident"))  )/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                        {
                            var temp = obtenerVariable(cadenas.Peek().contenido, ambito);
                            if (varTemp.tipo == temp.tipo)
                            {
                                ReasignarValor(temp.valor, varTemp.identificador, varTemp.ambito);
                                cadenas.Dequeue();
                            }
                            if(cadenas.Peek().contenido == "+")
                            {
                                cadenas.Dequeue();
                                if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident")))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                                {
                                    var temp2 = obtenerVariable(cadenas.Peek().contenido, ambito);
                                    if (varTemp.tipo == temp2.tipo && varTemp.tipo == "string")
                                    {
                                        ReasignarValor(temp2.valor + varTemp.valor, varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "int")
                                    {
                                        ReasignarValor((Convert.ToInt32(temp2.valor) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "double")
                                    {
                                        ReasignarValor((Convert.ToDouble(temp2.valor) * Convert.ToDouble(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else
                                    {
                                        errores.Add("OPeracion con distintos tipos no es posible en " + varTemp.tipo);//Error
                                    }


                                }
                                else if (cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "double")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToInt32(cadenas.Dequeue().contenido) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "string")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor(cadenas.Dequeue().contenido + varTemp.valor, varTemp.identificador, varTemp.ambito);

                                    }
                                }
                            }
                            else if (cadenas.Peek().contenido == "*")
                            {
                                cadenas.Dequeue();
                                if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident")))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                                {
                                    var temp2 = obtenerVariable(cadenas.Peek().contenido, ambito);
                                    if (varTemp.tipo == temp2.tipo && varTemp.tipo == "string")
                                    {
                                        ReasignarValor(temp2.valor + varTemp.valor, varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "int" )
                                    {
                                        ReasignarValor((Convert.ToInt32(temp2.valor) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "double")
                                    {
                                        ReasignarValor((Convert.ToDouble(temp2.valor) * Convert.ToDouble(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else
                                    {
                                        errores.Add("OPeracion con distintos tipos no es posible en "+varTemp.tipo);//Error
                                    }
                                }
                                else if (cadenas.Peek().tipo == "int")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToInt32(cadenas.Dequeue().contenido) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "double")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToDouble(cadenas.Dequeue().contenido) * Convert.ToDouble(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "string" || cadenas.Peek().tipo == "bool")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        errores.Add("Operacion invalida entre operando por conversion de tipos");
                                    }
                                }
                            }
                            else
                            {
                                errores.Add("OPeracion con distintos tipos no es posible en " + varTemp.tipo);//Error
                            }

                        }
                        else if(cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "string" || cadenas.Peek().tipo == "bool" || cadenas.Peek().tipo == "double")
                        {
                            if (varTemp.tipo == cadenas.Peek().tipo)
                            {
                                ReasignarValor(cadenas.Dequeue().contenido, varTemp.identificador, varTemp.ambito);
                                
                            }
                            if (cadenas.Peek().contenido == "+")
                            {
                                cadenas.Dequeue();
                                if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident")))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                                {
                                    var temp2 = obtenerVariable(cadenas.Peek().contenido, ambito);
                                    if (varTemp.tipo == temp2.tipo)
                                    {
                                        ReasignarValor(temp2.valor + varTemp.valor, varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }

                                }
                                else if (cadenas.Peek().tipo == "int" || cadenas.Peek().tipo == "double")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToInt32(cadenas.Dequeue().contenido) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "string")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor(cadenas.Dequeue().contenido + varTemp.valor, varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "bool")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        errores.Add("Operacion invalida entre operando por conversion de tipos");
                                    }
                                }
                            }
                            else if (cadenas.Peek().contenido == "*")
                            {
                                cadenas.Dequeue();
                                if ((EvaluarExistencia(ambito, cadenas.Peek().contenido) && (cadenas.Peek().tipo == "ident")))/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/
                                {
                                    var temp2 = obtenerVariable(cadenas.Peek().contenido, ambito);
                                    if (varTemp.tipo == temp2.tipo && varTemp.tipo == "string")
                                    {
                                        ReasignarValor(temp2.valor + varTemp.valor, varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "int")
                                    {
                                        ReasignarValor((Convert.ToInt32(temp2.valor) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                    else if (varTemp.tipo == temp2.tipo && varTemp.tipo == "double")
                                    {
                                        ReasignarValor((Convert.ToDouble(temp2.valor) * Convert.ToDouble(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);
                                        cadenas.Dequeue();
                                    }
                                }
                                else if (cadenas.Peek().tipo == "int")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToInt32(cadenas.Dequeue().contenido) * Convert.ToInt32(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "double")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        ReasignarValor((Convert.ToDouble(cadenas.Dequeue().contenido) * Convert.ToDouble(varTemp.valor)).ToString(), varTemp.identificador, varTemp.ambito);

                                    }
                                }
                                else if (cadenas.Peek().tipo == "string" || cadenas.Peek().tipo == "bool")
                                {
                                    if (varTemp.tipo == cadenas.Peek().tipo)
                                    {
                                        errores.Add("Operacion invalida entre operando por conversion de tipos");
                                    }
                                }
                            }
                            else
                            {
                                errores.Add("OPeracion con distintos tipos no es posible en " + varTemp.tipo);//Error
                            }
                        }
                    }
                    else if (cadenas.Peek().contenido ==  ".")
                    {
                        cadenas.Dequeue();
                        if (EvaluarExistencia(ambito, cadenas.Peek().contenido)/*variablesPerAmbito.ContainsKey(cadenas.Peek().contenido) && variablesPerAmbito[cadenas.Peek().contenido].Contains(ambito)*/)
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
            if (cadenas.Peek().contenido == "&&" || cadenas.Peek().contenido == "+" || cadenas.Peek().contenido == "%" || cadenas.Peek().contenido == "*" || cadenas.Peek().contenido == "<=" || cadenas.Peek().contenido == "<" || cadenas.Peek().contenido == "==")
            {
                cadenas.Dequeue();
                expresion(ambito);
            }
        }
        public void clase(string ambito)
        {
            cadenas.Dequeue(); //{
            do
            {
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
                      
                         errores.Add("Variable ya existente en id: "+ temp.identificador);
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
                        cadenas.Dequeue();
                        temp.tipo = aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = ambito;
                        temp.valor = "";
                        if (!EvaluarRepetido(temp.ambito, temp.identificador))
                        {
                            variables.Add(temp);
                        }
                        else
                        {
                           
                            errores.Add("Variable ya existente en id " + temp.identificador);
                        }
                    }
                    else if (cadenas.Peek().contenido == "(")
                    {
                        cadenas.Dequeue();
                        temp.tipo = cadenas.Dequeue().contenido + aux;
                        temp.identificador = auxIdentificador;
                        temp.ambito = ambito;
                        temp.valor = "";
                        if (!EvaluarRepetido(temp.ambito, temp.identificador))
                        {
                            variables.Add(temp);
                        }
                        else
                        {
                            
                            errores.Add("Variable ya existente en id " + temp.identificador);
                        }
                        cadenas.Dequeue();
                        AnalizarParametros(temp.identificador + "Metodo" + auxIdentificador);
                        AnalizarFuncion(temp.identificador + "Metodo" + auxIdentificador);
                    }
                }
                else if (cadenas.Peek().contenido == "void")
                {
                    cadenas.Dequeue();
                    var temp = new Variable();
                    temp.tipo = "Funcion";
                    temp.identificador = cadenas.Dequeue().contenido;
                    temp.ambito = ambito;
                    temp.valor = "";
                    if (!EvaluarRepetido(temp.ambito, temp.identificador))
                    {
                        variables.Add(temp);
                    }
                    else
                    {
                       
                        errores.Add("Variable ya existente en id " + temp.identificador);
                    }
                    cadenas.Dequeue();
                    AnalizarParametros(temp.ambito + "Metodo" + temp.identificador);
                    AnalizarFuncion(temp.ambito + "Metodo" + temp.identificador);
                }
            } while (cadenas.Peek().contenido != "}");
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
                   
                    errores.Add("Variable ya existente en id " + temp.identificador);
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
                           

                            AnalizarParametros(temp.ambito + "Metodo " + aux + auxIdentificador);
                            errores.Add("método ya existente en id " + temp.identificador);
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
        public bool EvaluarExistencia(string ambito, string identificador)
        {
            var temporal = new List<Variable>();
            foreach (var item in variables)
            {
                if (item.ambito == ambito && item.identificador == identificador)
                {
                    return true;
                }
            }
            return false;
        }
        public void ReasignarValor(string valor, string identificador, string ambito)
        {
            foreach (var item in variables)
            {
                if (item.ambito == ambito && item.identificador == identificador)
                {
                    item.valor = valor;
                }
            }
        }
    }
}