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
       

    }
}
