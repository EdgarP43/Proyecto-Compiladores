using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ProyectoCompiladores2020
{
    public class SintacticoRecursivo
    {
        public Queue<Token> tokens = new Queue<Token>();
        string[] tipos = new string[5] { "int", "double", "bool", "string", "ident" };

        string lookahead = string.Empty;
        bool BacktrakinfFlag = false;
        public void MatchToken(string expected)
        {
            lookahead = tokens.Peek().contenido;
            if (lookahead == expected)
            {
                lookahead = nextToken();
                //if (tokens.Count == 0) 
                    //return 0;
            }
            else
            {
                //DEvolvemos un error de sintaxis porque no hay match
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
        }

        //Cambiar a void
        public bool parse_Dclr()
        {
            if (tipos.Contains(tokens.Peek().contenido))
            {
                parse_VariableDecl();

                return true;
            }
            else if (tokens.Peek().contenido == "void" || tipos.Contains(tokens.Peek().tipo))
            {
                parse_funcDcl();
                return false;
            }
            else
            {
                //error en sintaxis
                return false;
            }
           

        }
        //Cambiar a Void
        public bool parse_Dcl_P()
        {
            parse_Dclr();
            //o viene epsilon
            return true;
        }
        public void parse_VariableDecl()
        {
            parse_variable();
           MatchToken(";");
        }
        public void parse_variable()
        {
            //se va a type
            parse_Type();
            //MatchToken("ident");
            if (tokens.Peek().tipo == "ident")
            {
                tokens.Dequeue();
            }
            else
            {
                tokens.Dequeue();
                //Kagada
            }
        }
        public void parse_Type()
        {
            parse_TypeP();
            parse_TypeR();
        }
        public void parse_TypeR()
        {
            if (tokens.Peek().contenido == "[]")
            {
                MatchToken("[]");
            }
        }
        public void parse_TypeP()
        {
            if (tokens.Peek().contenido == "int")
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
                //error de sintaxis
            }
        }
        public void parse_funcDcl()
        {
            parse_funcDcl_P();
            parse_funcDCLR();
        }
        public void parse_funcDcl_P()
        {
            if (tokens.Peek().contenido == "void")
            {
                MatchToken("void");
            }
            else if (tipos.Contains(tokens.Peek().contenido))
            {
                parse_Type();
            }//queda duda si puede venir otra cosa
            else
            {
                //Error de sintaxis
            }
        }
        public void parse_funcDCLR()
        {
            //ident (formals) metodo
            if(tokens.Peek().tipo == "ident")
            {
                tokens.Dequeue();
            }
            MatchToken("(");
            parse_Formals();
            MatchToken(")");
            parse_funcDCLAs();
        }
        public void parse_funcDCLAs()
        {
            if(tokens.Peek().contenido == "if" || tokens.Peek().contenido == "while")
            {
                parse_stmt();
                parse_funcDCLAs();
            }
        }
        public void parse_Formals()///ep?
        {
            if (tipos.Contains(tokens.Peek().tipo))
            {
                parse_variable();
                parse_variableP();
                MatchToken(",");
            }
            //o 
           //D MatchToken("\"\"");
        }
        public void parse_variableP()
        {
            if (tipos.Contains(tokens.Peek().contenido))
            {
                parse_variable();
                parse_variableP();
            }
        }
        public void parse_stmt()
        {
            if (tokens.Peek().contenido == "if")
            {
                parse_ifStmt();
            }
            else if ( tokens.Peek().contenido == "while")
            {
                parse_whileStmt();
            }
            else
            {
                //Cagada
            }
        }
        public void parse_ifStmt()
        {
            MatchToken("if");
            MatchToken("(");
            //parse_Expr();
            MatchToken(")");
            parse_stmt();
            parse_ifStmt_P();

        }
        public void parse_ifStmt_P()
        {
            if(tokens.Peek().contenido== "else")
            {
                MatchToken("else");
                parse_stmt();
            }
        }
        public void parse_whileStmt()
        {
            if(tokens.Peek().contenido == "while")
            {
                MatchToken("while");
                MatchToken("(");
                //parse_Expr();
                MatchToken(")");
                parse_stmt();
            }
        }

        public void parse_Expr()
        {
            parse_Expr1();
            parse_Expr_P();
        }
        public void parse_Expr_P()
        {
            if (tokens.Peek().contenido == "||")
            {
                MatchToken("||");
                parse_Expr1();
                parse_Expr_P1();
                //o epison
            }
        }
        public void parse_Expr1()
        {
            parse_Expr_P1();
            parse_Expr_P1();
        }
        public void parse_Expr_P1()
        {
            if (tokens.Peek().contenido == "&&")
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
            if (tokens.Peek().contenido == "==")
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
            if (tokens.Peek().contenido == "<")
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
            if (tokens.Peek().contenido == "+")
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
            if (tokens.Peek().contenido == "*")
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
            parse_Expr7();
            parse_Expr_P6();
        }
        public void parse_Expr_P6()
        {
            if (tokens.Peek().contenido == "!")
            {
                MatchToken("!");
                parse_Expr7();
                parse_Expr_P6();
            }
        }
        public void parse_Expr7()
        {
            parse_Expr8();
            parse_Expr_P7();
        }
        public void parse_Expr_P7()
        {
            if (tokens.Peek().contenido == "-")
            {
                MatchToken("-");
                parse_Expr8();
                parse_Expr_P7();
            }
        }
        public void parse_Expr8()
        {
            if (tipos.Contains(tokens.Peek().tipo) && tokens.Peek().tipo != "ident")
            {
                parse_Constant();
            }
            else if (tokens.Peek().tipo == "ident")
            {
                parse_LValue();
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
                //MatchToken(tokens.peek())
                MatchToken(")");
            }
            else
            {
                //cagada
            }
        }
        public void parse_LValue()
        {

            if (tokens.Peek().tipo == "ident")
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
            if (tokens.Peek().contenido == ".")
            {
                tokens.Dequeue();
                if (tokens.Peek().tipo == "ident")
                {
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
                //cagada
            }
        }
        public void parse_Constant()
        {
            //validar con nuesto lexico los numeros y t_constantes
            if (tokens.Peek().tipo == "int")
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
                //Cagada
            }
        }
    }
}
