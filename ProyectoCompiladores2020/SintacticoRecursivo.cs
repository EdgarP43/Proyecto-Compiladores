using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoCompiladores2020
{
    class SintacticoRecursivo
    {
        public Queue<string> Tokens = new Queue<string>();

        string lookahead = string.Empty;
        bool BacktrakinfFlag = false;
        public void MatchToken(string expected)
        {
            lookahead = Tokens.Peek();
            if (lookahead == expected)
            {
                lookahead = nextToken();
            }
            else
            {
                //DEvolvemos un error de sintaxis porque no hay match
            }
        }

        public string nextToken()//vamos a cambiar de token de la cola
        {
            return Tokens.Dequeue(); ;
        }
        public void parse_Program()
        {
            //matchtoken de lo que espera
            if (BacktrakinfFlag==false)
            {
                parse_Dclr();
                parse_Program();
            }
            else 
            {
                //else
                parse_Dclr();
                BacktrakinfFlag = false;
            }

           
           
        }
        public void parse_Dclr()
        {
            if (BacktrakinfFlag==false)
            {

            }
            parse_VariableDecl();
            //els
            parse_funcDcl();

        }
        public void parse_VariableDecl()
        {
            parse_variable();
        }
        public void parse_variable()
        {
            //se va a type
            parse_Type();
            MatchToken("ident");
        }
        public void parse_Type()
        {
            parse_TypeP();
            parse_TypeR();
        }
        public void parse_TypeR()
        {
            if (lookahead == "[]")
            {
                MatchToken("[]");
            }
            else if (lookahead=="")//VALIDAR EL EPSILON ****
            {
                //matchToken("\"\"");
            }
            else
            {
                //error en sisntes
            }
        }
        public void parse_TypeP()
        {
            if (lookahead == "int")
            {
                MatchToken("int");
            }
            else if (lookahead == "double")
            {
                MatchToken("double");
            }
            else if (lookahead == "bool")
            {
                MatchToken("bool");
            }
            else if (lookahead == "string")
            {
                MatchToken("string");
            }
            else if (lookahead == "ident")
            {
                MatchToken("ident");
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
            if (lookahead == "void")
            {
                MatchToken("void");
            }
            else
            {
                parse_Type();
            }//queda duda si puede venir otra cosa
        }
        public void parse_funcDCLR()/////mmmmm
        {
            //ident (formals) metodo

        }
        public void parse_Formals()///ep?
        {
            parse_variable();
            parse_Formals_P();
            MatchToken(",");
            //o 
           //D MatchToken("\"\"");
        }
        public void parse_Formals_P()//bt
        {
            
                parse_variable();
                parse_Formals_P();
            //O
                parse_variable();
            
        }

        public void parse_stmt()
        {

        }
        public void parse_ifStmt()
        {

        }
        public void parse_ifStmt_P()
        {

        }
        public void parse_whileStmt()
        {

        }
        public void parse_Expr()
        {

        }
        //todas las derivaciones del expr
        public void parse_LValue()
        {

        }
        public void parse_LValue_P()
        {

        }
        public void parse_Constant()
        {
            //validar con nuesto lexico los numeros y t_constantes
        }

    }
}
