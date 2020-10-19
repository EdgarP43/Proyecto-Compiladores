using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoCompiladores2020
{
    class SintacticoAscendente
    {
        public Dictionary<string, string> filaMov = new Dictionary<string, string>();
        public Dictionary<int, Dictionary<string, string>> estados = new Dictionary<int, Dictionary<string, string>>();
        private Queue<string> cadenas = new Queue<string>();
        private Stack<string> pilaSimbolos = new Stack<string>();
        private Stack<int> acciones = new Stack<int>();
        private void Tabla()
        {
            int contadorLineas = 0;
            int llavesCont = 0;
            using (StreamReader sr = new StreamReader("SLR.txt"))
            {
                string linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    Dictionary<string, string> filaMov = new Dictionary<string, string>();
                    var fila = linea.Split(';');
                    foreach (var item in fila)
                    {
                        if(fila[llavesCont].Equals("null"))
                        { }
                        else
                            filaMov.Add(llaves[llavesCont], fila[llavesCont]);
                       
                        llavesCont++;
                    }
                    estados.Add(contadorLineas, filaMov);
                    llavesCont = 0;
                    contadorLineas++;
                }


            }
            prueba();
        }
        public SintacticoAscendente(){
            Tabla();
        }
        private string[] llaves = new string[]
        {
            ";",
            "ident",
            "const",
            "int",
            "double",
            "bool",
            "string",
            "[]",
            "(",
            ")",
            "void",
            ",",
            "class",
            " ",
            "{",
            "}",
            ":",
            "interface",
            "if",
            "else",
            "while",
            "for",
            "return",
            "break",
            "Console",
            ".",
            "WriteLine",
            "=",
            "this",
            "+",
            "*",
            "%",
            "-",
            "<",
            "<=",
            "==",
            "&&",
            "!",
            "New",
            "intConstant",
            "doubleConstant",
            "boolConstant",
            "stringConstant",
            "null",
            "$",
            "S",
            "Program",
            "Program'",
            "Decl",
            "VariableDecl",
            "Variable",
            "ConstDecl",
            "ConstType",
            "Type",
            "FunctionDecl",
            "Formals",
            "ClassDecl",
            "ClassDecl1",
            "ClassDecl2",
            "ClassDecl3",
            "Field",
            "InterfaceDecl",
            "InterfaceDecl'",
            "Prototype",
            "StmtBlock",
            "StmtBlock1",
            "StmtBlock2",
            "StmtBlock3",
            "Stmt",
            "Stmt'",
            "IfStmt",
            "IfStmt'",
            "WhileStmt",
            "ForStmt",
            "ReturnStmt",
            "BreakStmt",
            "PrintStmt",
            "PrintStmt'",
            "Expr",
            "LValue",
            "Constant"
        };

        private bool estado0()
        {
            return true;
        }
        public bool AnalizandoEntrada(int pila, string entrada)
        {
            if (estados.ContainsKey(pila))//titulo 
            {
                var temp = estados[pila];
                if (temp.ContainsKey(entrada))
                {
                    var accion = temp[entrada];

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
