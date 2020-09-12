using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ProyectoCompiladores2020
{
    public class SintacticoRecursivo
    {
        public Queue<Token> tokens = new Queue<Token>();
        string[] tipos = new string[5] { "int", "double", "bool", "string", "ident" };
        public List<string> errores = new List<string>();

        string lookahead = string.Empty;
        public void MatchToken(string expected)
        {
            if(tokens.Count > 0)
                lookahead = tokens.Peek().contenido;

            if(tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (lookahead == expected)
            {
                lookahead = nextToken();
                //if (tokens.Count == 0) 
                    //return 0;
            }
            else
            {
                errores.Add("Error de sintaxis token:" + lookahead + " incorrecto");
                lookahead = nextToken();
            }
        }
        public string nextToken()
        {
            return tokens.Dequeue().contenido;
        }
        public void parse_Program()
        {
            //matchtoken de lo que espera
            
            parse_Dclr();
            parse_Dcl_P();
            if(tokens.Count != 0)
            {
                parse_Program();
            }
        }
        public void parse_Dclr()
        {
            if(tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tipos.Contains(tokens.Peek().contenido))
            {
                parse_VariableDecl();

                
            }
            else if (tokens.Peek().contenido == "void" || tipos.Contains(tokens.Peek().contenido))
            {
                parse_funcDcl();
                
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();

            }
        }
        public void parse_Dcl_P()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tipos.Contains(tokens.Peek().contenido) || tokens.Peek().tipo == "ident" || tokens.Peek().contenido == "void")
            {
                parse_Dclr();
                parse_Dcl_P();
            }
        }
        public void parse_VariableDecl()
        {
            parse_variable();
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == ";")
            { 
                MatchToken(";"); 
            }
            else if (tokens.Peek().contenido == "(" || tokens.Peek().contenido == "()")
            {
                parse_VariableOrFunction();
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: "+ tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }

        }
        public void parse_VariableOrFunction()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "()")
            {
                MatchToken("()");
                parse_funcDCLAs();
            }
            else
            {
                MatchToken("(");
                parse_Formals();
                MatchToken(")");
                parse_funcDCLAs();
            }

        }
        public void parse_variable()
        {
            //se va a type
            parse_Type();
            //MatchToken("ident");
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().tipo == "ident")
            {
                tokens.Dequeue();
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_Type()
        {
            parse_TypeP();
            parse_TypeR();
        }
        public void parse_TypeR()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "[]")
            {
                MatchToken("[]");
            }
        }
        public void parse_TypeP()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "int")
            {
                MatchToken("int");
            }
            else if (tokens.Peek().contenido == "double")
            {
                MatchToken("double");
            }
            else if (tokens.Peek().contenido == "bool")
            {
                MatchToken("bool");
            }
            else if (tokens.Peek().contenido == "string")
            {
                MatchToken("string");
            }
            else if (tokens.Peek().tipo == "ident" )
            {
                //MatchToken("ident");
                tokens.Dequeue(); //lo scamaos porque si es un id y pasamos al sig
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_funcDcl()
        {
            parse_funcDcl_P();
            parse_funcDCLR();
        }
        public void parse_funcDcl_P()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "void")
            {
                MatchToken("void");
            }
            else if (tipos.Contains(tokens.Peek().contenido))
            {
                parse_Type();
            }//queda duda si puede venir otra cosa
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_funcDCLR()
        {
            //ident (formals) metodo
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().tipo == "ident")
            {
                tokens.Dequeue();
                if (tokens.Count == 0)
                {
                    errores.Add("Error de sintaxis no hay mas tokens disponibles");
                }
                else if (tokens.Peek().contenido == "()")
                {
                    MatchToken("()");
                    parse_funcDCLAs();
                }
                else
                {
                    MatchToken("(");
                    parse_Formals();
                    MatchToken(")");
                    parse_funcDCLAs();
                }
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_funcDCLAs()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "if" || tokens.Peek().contenido == "while" || tokens.Peek().tipo == "ident")
            {
                parse_stmt();
                parse_funcDCLAs();
            }
        }
        public void parse_Formals()///ep?
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tipos.Contains(tokens.Peek().contenido) || tokens.Peek().tipo == "ident")
            {
                parse_variableP();
            }
            //o 
            //D MatchToken("\"\"");
        }
        public void parse_variableP()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tipos.Contains(tokens.Peek().contenido) || tokens.Peek().tipo == "ident")
            {

                parse_variable();
                parse_variablePP();
            }
        }
        public void parse_variablePP()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == ",")
            {
                MatchToken(",");
                parse_variable();
                parse_variableP();
            }
        }
        public void parse_stmt()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "if")
            {
                parse_ifStmt();
            }
            else if ( tokens.Peek().contenido == "while")
            {
                parse_whileStmt();
            }
            else if(tipos.Contains(tokens.Peek().tipo) ||  tokens.Peek().contenido == "null" || tokens.Peek().contenido == "this" || tokens.Peek().contenido == "(" || tokens.Peek().contenido == "New")
            {
                parse_Expr();
                MatchToken(";");
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_ifStmt()
        {
            MatchToken("if");
            MatchToken("(");
            parse_Expr();
            MatchToken(")");
            parse_stmt();
            parse_ifStmt_P();

        }
        public void parse_ifStmt_P()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido== "else")
            {
                MatchToken("else");
                parse_stmt();
            }
        }
        public void parse_whileStmt()
        {
            MatchToken("while");
            MatchToken("(");
            parse_Expr();
            MatchToken(")");
            parse_stmt();
        }
        public void parse_Expr()
        {
            parse_Expr1();
            parse_Expr_P();
        }
        public void parse_Expr_P()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "||")
            {
                MatchToken("||");
                parse_Expr1();
                parse_Expr_P1();
                //o epison
            }
        }
        public void parse_Expr1()
        {
            parse_Expr2();
            parse_Expr_P1();
        }
        public void parse_Expr_P1()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "&&")
            {
                MatchToken("&&");
                parse_Expr2();
                parse_Expr_P1();
                //o epison
            }
        }
        public void parse_Expr2()
        {
            parse_Expr3();
            parse_Expr_P2();
        }
        public void parse_Expr_P2()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "==")
            {
                MatchToken("==");
                parse_Expr3();
                parse_Expr_P2();
                //o epison
            }
            else if (tokens.Peek().contenido == "!=")
            {
                MatchToken("!=");
                parse_Expr3();
                parse_Expr_P2();
                //o epison
            }
        }
        public void parse_Expr3()
        {
            parse_Expr4();
            parse_Expr_P3();
        }
        public void parse_Expr_P3()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "<")
            {
                MatchToken("<");
                parse_Expr4();
                parse_Expr_P3();
                //o epison
            }
            else if (tokens.Peek().contenido == ">")
            {
                MatchToken(">");
                parse_Expr4();
                parse_Expr_P3();
                //o epison
            }
            else if (tokens.Peek().contenido == ">=")
            {
                MatchToken(">=");
                parse_Expr4();
                parse_Expr_P3();
                //o epison
            }
            else if (tokens.Peek().contenido == "<=")
            {
                MatchToken("<=");
                parse_Expr4();
                parse_Expr_P3();
                //o epison
            }
        }
        public void parse_Expr4()
        {
            parse_Expr5();
            parse_Expr_P4();
        }
        public void parse_Expr_P4()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "+")
            {
                MatchToken("+");
                parse_Expr5();
                parse_Expr_P4();
                //o epison
            }
            else if (tokens.Peek().contenido == "-")
            {
                MatchToken("-");
                parse_Expr5();
                parse_Expr_P4();
                //o epison
            }
        }
        public void parse_Expr5()
        {
            parse_Expr6();
            parse_Expr_P5();
        }
        public void parse_Expr_P5()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == "*")
            {
                MatchToken("*");
                parse_Expr6();
                parse_Expr_P5();
            }
            else if (tokens.Peek().contenido == "/")
            {
                MatchToken("/");
                parse_Expr6();
                parse_Expr_P5();
            }
            else if (tokens.Peek().contenido == "%")
            {
                MatchToken("%");
                parse_Expr6();
                parse_Expr_P5();
            }
        }
        public void parse_Expr6()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tipos.Contains(tokens.Peek().tipo) && tokens.Peek().tipo != "ident")
            {
                parse_Constant();
            }
            else if (tokens.Peek().tipo == "ident")
            {
                parse_LValue();
                if( tokens.Peek().contenido == "=")
                {
                    MatchToken("=");
                    parse_Expr();
                }
            }
            else if (tokens.Peek().contenido == "(")
            {
                MatchToken("(");
                parse_Expr();
                MatchToken(")");
            }
            else if (tokens.Peek().contenido == "this")
            {
                MatchToken("this");
            }
            else if (tokens.Peek().contenido == "New")
            {
                MatchToken("New");
                MatchToken("(");
                //Sacar identificador
                if (tokens.Peek().tipo == "ident")
                {
                    tokens.Dequeue();
                }
                else
                {
                    errores.Add("Error de sintaxis token no encontrado"); //error de sintaxis
                    tokens.Dequeue();
                }
                MatchToken(")");
            }

            else if (tokens.Peek().contenido == "-")
            {
                MatchToken("-");
                parse_Expr();
            }

            else if (tokens.Peek().contenido == "!")
            {
                MatchToken("!");
                parse_Expr();
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_LValue()
        {

            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().tipo == "ident")
            {
                tokens.Dequeue();
            }
            else
            {
                parse_Expr();
                parse_LValue_P();
            }


        }
        public void parse_LValue_P()
        {
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().contenido == ".")
            {
                tokens.Dequeue();
                if (tokens.Peek().tipo == "ident")
                {
                    tokens.Dequeue();
                }
                else
                {
                    errores.Add("Error de sintaxis token no encontrado"); //error de sintaxis
                    tokens.Dequeue();
                }
            }
            else if (tokens.Peek().contenido == "[")
            {
                MatchToken("[");
                parse_Expr();
                MatchToken("]");
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
        public void parse_Constant()
        {
            //validar con nuesto lexico los numeros y t_constantes
            if (tokens.Count == 0)
            {
                errores.Add("Error de sintaxis no hay mas tokens disponibles");
            }
            else if (tokens.Peek().tipo == "int")
            {
                tokens.Dequeue();
            }
            else if (tokens.Peek().tipo == "double")
            {
                tokens.Dequeue();
            }
            else if (tokens.Peek().tipo == "double")
            {
                tokens.Dequeue();
            }
            else if (tokens.Peek().tipo == "bool")
            {
                tokens.Dequeue();
            }
            else if (tokens.Peek().tipo == "sting")
            {
                tokens.Dequeue();
            }
            else if (tokens.Peek().contenido == "null")
            {
                tokens.Dequeue();
            }
            else
            {
                errores.Add("Error de sintaxis token no encontrado: " + tokens.Peek().contenido); //error de sintaxis
                tokens.Dequeue();
            }
        }
    }
}
