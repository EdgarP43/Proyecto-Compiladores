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
        private Queue<Token> cadenas = new Queue<Token>();
        private Stack<string> pilaSimbolos = new Stack<string>();
        private Stack<int> pilaAcciones = new Stack<int>();
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
                        if(fila[llavesCont].Equals("n"))
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
        }
        public SintacticoAscendente(){
            Tabla();
            Token temporal = new Token();
            temporal.contenido = "$";
            temporal.tipo = "reservada";
            cadenas.Enqueue(temporal);
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
            "==",
            "&&",
            "<",
            "<=",
            "+",
            "*",
            "%",
            "-",
            "!",
            "this",
            "New",
            "intConstant",
            "doubleConstant",
            "boolConstant",
            "stringConstant",
            "null",
            "$",
            "S'",
            "Program",
            "Decl",
            "VariableDecl",
            "Variable",
            "ConstDecl",
            "ConstType",
            "Type",
            "Type_P",
            "Type_R",
            "FunctionDecl",
            "Formals",
            "Formals_P",
            "ClassDecl",
            "ClassDecl_P",
            "ClassDecl_R",
            "ClassDecl_O",
            "ClassDecl_Q",
            "Field",
            "InterfaceDecl",
            "InterfaceDecl_P",
            "Prototype",
            "StmtBlock",
            "StmtBlock_P",
            "StmtBlock_R",
            "StmtBlock_O",
            "Stmt",
            "Stmt_P",
            "IfStmt",
            "IfStmt_P",
            "WhileStmt",
            "ForStmt",
            "ReturnStmt",
            "BreakStmt",
            "PrintStmt",
            "PrintStmt_P",
            "Expr",
            "ExprOr",
            "ExprOrP",
            "ExprAnd",
            "ExprAndP",
            "ExprEquals",
            "ExprEqualsP",
            "ExprComp",
            "ExprCompP",
        };

        private bool IrA(int inicio, Token lH)
        {
            switch(inicio)
            {
                case 0:
                     return estado0(lH);
                case 1:
                    return estado1(lH);
                case 2:
                    return estado2(lH);
                case 3:
                    return estado3(lH);
                case 4:
                    return estado4(lH);
                case 5:
                    return estado5(lH);
                case 6:
                    return estado6(lH);
                case 7:
                    return estado7(lH);
                case 8:
                    return estado8(lH);
                case 9:
                    return estado9(lH);
                case 10:
                    return estado10(lH);
                case 11:
                    return estado11(lH);
                case 12:
                    return estado12(lH);
                case 13:
                    return estado13(lH);
                case 14:
                    return estado14(lH);
                case 15:
                    return estado15(lH);
                case 16:
                    return estado16(lH);
                case 17:
                    return estado17(lH);
                case 18:
                    return estado18(lH);
                    
                case 19:
                    return estado19(lH);
                    
                case 20:
                    return estado20(lH);
                    
                case 21:
                    return estado21(lH);
                    
                case 22:
                    return estado22(lH);
                    
                case 23:
                    return estado23(lH);
                    
                case 24:
                    return estado24(lH);
                    
                case 25:
                    return estado25(lH);
                    
                case 26:
                    return estado26(lH);
                    
                case 27:
                    return estado27(lH);
                    
                case 28:
                    return estado28(lH);
                    
                case 29:
                    return estado29(lH);
                    
                case 30:
                    return estado30(lH);
                    
                case 31:
                    return estado31(lH);
                    
                case 32:
                    return estado32(lH);
                    
                case 33:
                    return estado33(lH);
                    
                case 34:
                    return estado34(lH);
                    
                case 35:
                    return estado35(lH);
                    
                case 36:
                    return estado36(lH);
                    
                case 37:
                    return estado37(lH);
                    
                case 38:
                    return estado38(lH);
                    
                case 39:
                    return estado39(lH);
                    
                case 40:
                    return estado40(lH);
                    
                case 41:
                    return estado41(lH);
                    
                case 42:
                    return estado42(lH);
                    
                case 43:
                    return estado43(lH);
                    
                case 44:
                    return estado44(lH);
                    
                case 45:
                    return estado45(lH);
                    
                case 46:
                    return estado46(lH);
                    
                case 47:
                    return estado47(lH);
                    
                case 48:
                    return estado48(lH);
                    
                case 49:
                    return estado49(lH);
                    
                case 50:
                    return estado50(lH);
                    
                case 51:
                    return estado51(lH);
                    
                case 52:
                    return estado52(lH);
                    
                case 53:
                    return estado53(lH);
                    
                case 54:
                    return estado54(lH);
                    
                case 55:
                    return estado55(lH);
                    
                case 56:
                    return estado56(lH);
                    
                case 57:
                    return estado57(lH);
                    
                case 58:
                    return estado58(lH);
                    
                case 59:
                    return estado59(lH);
                    
                case 60:
                    return estado60(lH);
                    
                case 61:
                    return estado61(lH);
                    
                case 62:
                    return estado62(lH);
                    
                case 63:
                    return estado63(lH);
                    
                case 64:
                    return estado64(lH);
                    
                case 65:
                    return estado65(lH);
                    
                case 66:
                    return estado66(lH);
                    
                case 67:
                    return estado67(lH);
                    
                case 68:
                    return estado68(lH);
                    
                case 69:
                    return estado69(lH);
                    
                case 70:
                    return estado70(lH);
                    
                case 71:
                    return estado71(lH);
                    
                case 72:
                    return estado72(lH);
                    
                case 73:
                    return estado73(lH);
                    
                case 74:
                    return estado74(lH);
                    
                case 75:
                    return estado75(lH);
                    
                case 76:
                    return estado76(lH);
                    
                case 77:
                    return estado77(lH);
                    
                case 78:
                    return estado78(lH);
                    
                case 79:
                    return estado79(lH);
                    
                case 80:
                    return estado80(lH);
                    
                case 81:
                    return estado81(lH);
                    
                case 82:
                    return estado82(lH);
                    
                case 83:
                    return estado83(lH);
                    
                case 84:
                    return estado84(lH);
                    
                case 85:
                    return estado85(lH);
                    
                case 86:
                    return estado86(lH);
                    
                case 87:
                    return estado87(lH);
                    
                case 88:
                    return estado88(lH);
                    
                case 89:
                    return estado89(lH);
                    
                case 90:
                    return estado90(lH);
                    
                case 91:
                    return estado91(lH);
                    
                case 92:
                    return estado92(lH);
                    
                case 93:
                    return estado93(lH);
                    
                case 94:
                    return estado94(lH);
                    
                case 95:
                    return estado95(lH);
                    
                case 96:
                    return estado96(lH);
                    
                case 97:
                    return estado97(lH);
                    
                case 98:
                    return estado98(lH);
                    
                case 99:
                    return estado99(lH);
                    
                case 100:
                    return estado100(lH);
                    
                case 101:
                    return estado101(lH);
                    
                case 102:
                    return estado102(lH);
                    
                case 103:
                    return estado103(lH);
                    
                case 104:
                    return estado104(lH);
                    
                case 105:
                    return estado105(lH);
                    
                case 106:
                    return estado106(lH);
                    
                case 107:
                    return estado107(lH);
                    
                case 108:
                    return estado108(lH);
                    
                case 109:
                    return estado109(lH);
                    
                case 110:
                    return estado110(lH);
                    
                case 111:
                    return estado111(lH);
                    
                case 112:
                    return estado112(lH);
                    
                case 113:
                    return estado113(lH);
                    
                case 114:
                    return estado114(lH);
                    
                case 115:
                    return estado115(lH);
                    
                case 116:
                    return estado116(lH);
                    
                case 117:
                    return estado117(lH);
                    
                case 118:
                    return estado118(lH);
                    
                case 119:
                    return estado119(lH);
                    
                case 120:
                    return estado120(lH);
                    
                case 121:
                    return estado121(lH);
                    
                case 122:
                    return estado122(lH);
                    
                case 123:
                    return estado123(lH);
                    
                case 124:
                    return estado124(lH);
                    
                case 125:
                    return estado125(lH);
                    
                case 126:
                    return estado126(lH);
                    
                case 127:
                    return estado127(lH);
                    
                case 128:
                    return estado128(lH);
                    
                case 129:
                    return estado129(lH);
                    
                case 130:
                    return estado130(lH);
                    
                case 131:
                    return estado131(lH);
                    
                case 132:
                    return estado132(lH);
                    
                case 133:
                    return estado133(lH);
                    
                case 134:
                    return estado134(lH);
                    
                case 135:
                    return estado135(lH);
                    
                case 136:
                    return estado136(lH);
                    
                case 137:
                    return estado137(lH);
                    
                case 138:
                    return estado138(lH);
                    
                case 139:
                    return estado139(lH);
                    
                case 140:
                    return estado140(lH);
                    
                case 141:
                    return estado141(lH);
                    
                case 142:
                    return estado142(lH);
                    
                case 143:
                    return estado143(lH);
                    
                case 144:
                    return estado144(lH);
                    
                case 145:
                    return estado145(lH);
                    
                case 146:
                    return estado146(lH);
                case 147:
                    return estado147(lH);
                case 148:
                    return estado148(lH);
                case 149:
                    return estado149(lH);
                case 150:
                    return estado150(lH);
                case 151:
                    return estado151(lH);
                case 152:
                    return estado152(lH);
                case 153:
                    return estado153(lH);
                case 154:
                    return estado154(lH);
                case 155:
                    return estado155(lH);
                case 156:
                    return estado156(lH);
                case 157:
                    return estado157(lH);
                case 158:
                    return estado158(lH);
                case 159:
                    return estado159(lH);
                case 160:
                    return estado160(lH);
                case 161:
                    return estado161(lH);
                case 162:
                    return estado162(lH);
                case 163:
                    return estado163(lH);
                case 164:
                    return estado164(lH);
                case 165:
                    return estado165(lH);
                case 166:
                    return estado166(lH);
                case 167:
                    return estado167(lH);
                case 168:
                    return estado168(lH);
                case 169:
                    return estado169(lH);
                case 170:
                    return estado170(lH);
                case 171:
                    return estado171(lH);
                case 172:
                    return estado172(lH);
                case 173:
                    return estado173(lH);
                case 174:
                    return estado174(lH);
                case 175:
                    return estado175(lH);
                case 176:
                    return estado176(lH);
                case 177:
                    return estado177(lH);
                case 178:
                    return estado178(lH);
                case 179:
                    return estado179(lH);
                case 180:
                    return estado180(lH);
                case 181:
                    return estado181(lH);
                case 182:
                    return estado182(lH);
                case 183:
                    return estado183(lH);
                case 184:
                    return estado184(lH);
                case 185:
                    return estado185(lH);
                case 186:
                    return estado186(lH);
                case 187:
                    return estado187(lH);
                default:
                    return false;
            }
        }

        private bool estado0(Token lH)
        {
            switch(lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch(lH.contenido)
            {
                case "const":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "class":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "interface":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado11(lH);
                //Faltas los irA
                default:
                    return false;
            }
        }
        private bool estado1(Token lH)
        {
            //Aceptacion
            return true;
        }
        private bool estado2(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "class":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "interface":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                //Faltas los irA
                default:
                    pilaSimbolos.Push("Program");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado3(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado4(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado5(Token lH)
        {
            //Recucion a 5 con ident, const, int, double, bool, string, void, class, interface $
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado6(Token lH)
        {
            //Recucion a 6 con ident, const, int, double, bool, string, void, class, interface $
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado7(Token lH)
        {
            //Recucion a 7 con ident, const, int, double, bool, string, void, class, interface $
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaSimbolos.Push("Decl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado8(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(21);
                    lH = cadenas.Peek();
                    return estado21(lH);
                default:
                    return false;
            }
        }
        private bool estado9(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(22);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
            }

        }
        private bool estado10(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(23);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
            }
        }
        private bool estado11(Token lH)
        {
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(25);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(26);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(27);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(28);
                    lH = cadenas.Peek();
                    return estado11(lH);

                //Faltas los irA CONSTYPE
                default:
                    return false;
            }
        }
        private bool estado12(Token lH)
        {

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(29);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
            }
        }
        private bool estado13(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(30);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
            }
        }
        private bool estado14(Token lH)
        {
            
            //IR A TYPE_R CON 31

            switch (lH.contenido)
            {
                case "[]":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(32);
                    lH = cadenas.Peek();
                    return estado11(lH);
                
            }
            switch (lH.tipo)//retroceso con ident R22 
            {
                case "ident":
                    pilaSimbolos.Push("Type_R");
                    return estado2(lH);
                default:
                    return false;
            }
        }
        private bool estado15(Token lH)
        {
            //RETROCESO A IDENT R16
            //RETROESO CON [] R16
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push("Type_R");
                    return estado2(lH);
                default:
                    return false;
            }


            return true;
        }
        private bool estado16(Token lH)
        {
            //REDUCCION CON IDEN R17
            //REDUCCION CON [] R17
            return true;
        }
        private bool estado17(Token lH)
        {
            //REDUCCION IDENT R18
            //REDUCCION CON [] R18
            return true;
        }
        private bool estado18(Token lH)
        {
            //REDUCCION CON IDENT R19
            //REDUCCION CON [] R19
            return true;
        }
        private bool estado19(Token lH)
        {
            //REDUCCION CON IDENT R20
            //REDUCCION CON [] R20
            return true;
        }
        private bool estado20(Token lH)
        {
            //Reduccion 1 con $
            return true;
        }
        private bool estado21(Token lH)
        {
            //REDUCCION CON ; R8
            //REDUCCION CON IDENT R8
            //REDUCCION CON CONST R8
            //REDUCCION CON INT R8
            //REDUCCION CON DOUBLE R8
            //REDUCCION CON BOOL R8
            //REDUCCION CON STRING R8
            //REDUCCION CON ( R8
            //REDUCCION CON void R8
            //REDUCCION CON class R8
            //REDUCCION CON { R8
            //REDUCCION CON } R8
            //REDUCCION CON interface R8
            //REDUCCION CON { R8
            //REDUCCION CON if R8
            //REDUCCION CON else R8
            //REDUCCION CON while R8
            //REDUCCION CON for R8
            //REDUCCION CON return R8
            //REDUCCION CON break R8
            //REDUCCION CON Console R8
            //REDUCCION CON - R8
            //REDUCCION CON ! R8
            //REDUCCION CON this R8
            //REDUCCION CON New R8
            //REDUCCION CON intConstant R8
            //REDUCCION CON doubleConstant R8
            //REDUCCION CON boolConstant R8
            //REDUCCION CON stringConstant R8
            //REDUCCION CON null R8
            //REDUCCION CON $ R8

            return true;
        }
        private bool estado22(Token lH)
        {
            //REDUCCION CON ident R9
            //REDUCCION CON ) R9
            //REDUCCION CON , R9
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(33);
                    lH = cadenas.Peek();
                    return estado33(lH);
                default:
                    return false;
            }
        }
        private bool estado23(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(34);
                    lH = cadenas.Peek();
                    return estado34(lH);
                default:
                    return false;
            }
        }
        private bool estado24(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(35);
                    lH = cadenas.Peek();
                    return estado35(lH);
                default:
                    return false;
            }
        }
        private bool estado25(Token lH)
        {
            //Reduccion a 11 con ident
            return true;
        }
        private bool estado26(Token lH)
        {
            //reduccion a 12 con ident
            return true;
        }
        private bool estado27(Token lH)
        {
            //reduccion a 13 con ident
            return true;
        }
        private bool estado28(Token lH)
        {
            //reduccion a 14 con ident
            return true;
        }
        private bool estado29(Token lH)
        {
            //Ir a 36 con ClassDecll_P
            //Reduccion a 30 con {
            switch (lH.contenido)
            {
                case ":":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(37);
                    lH = cadenas.Peek();
                    return estado37(lH);
                default:
                    return false;
            }
        }
        private bool estado30(Token lH)
        {
            
            switch (lH.contenido)
            {
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(38);
                    lH = cadenas.Peek();
                    return estado38(lH);
                default:
                    return false;
            }
        }
        private bool estado31(Token lH)
        {
            //Reduccion 15 con ident
            return true;
        }
        private bool estado32(Token lH)
        {
            //Reduccion 21 con ident
            return true;
        }
        private bool estado33(Token lH)
        {
            //Ir a 40 Variable
            //IR a 41 Type
            //IR a 14 Type_P
            //IR a 39 Formals /42
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                default:
                    return false;
            }
        }
        private bool estado34(Token lH)
        {
            //Ir a 40 Variable
            //IR a 41 Type
            //IR a 14 Type_P
            //IR a 42 Formals 
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                default:
                    return false;
            }
        }
        private bool estado35(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(43);
                    lH = cadenas.Peek();
                    return estado43(lH);
                default:
                    return false;
            }
        }
        private bool estado36(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(44);
                    lH = cadenas.Peek();
                    return estado44(lH);
                default:
                    return false;
            }
        }
        private bool estado37(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(45);
                    lH = cadenas.Peek();
                    return estado45(lH);
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(44);
                    lH = cadenas.Peek();
                    return estado44(lH);
                default:
                    return false;
            }
        }
        private bool estado38(Token lH)
        {
            //Reduccion a 42 con }
            //Ir a 48 con Type
            //Ir a 14 con Type
            //Ir a 46 con InterfaceDecl_P
            //Ir a 47 con Prototype
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(49);
                    lH = cadenas.Peek();
                    return estado49(lH);
                default:
                    return false;

            }
        }
        private bool estado39(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(50);
                    lH = cadenas.Peek();
                    return estado50(lH);
                default:
                    return false;
            }
        }
        private bool estado40(Token lH)
        {
            //Reduccion a 27 con )
            //Ir a 51 Formals
            switch (lH.contenido)
            {
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(52);
                    lH = cadenas.Peek();
                    return estado52(lH);
                default:
                    return false;
            }
        }
        private bool estado41(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(53);
                    lH = cadenas.Peek();
                    return estado53(lH);
                default:
                    return false;
            }
        }
        private bool estado42(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(54);
                    lH = cadenas.Peek();
                    return estado54(lH);
                default:
                    return false;
            }
        }
        private bool estado43(Token lH)
        {
            //Reduccion a 10 ;
            //Reduccion a 10 ident
            //Reduccion a 10 const
            //Reduccion a 10 int 
            //Reduccion a 10 double
            //Reduccion a 10 bool
            //Reduccion a 10 string
            //Reduccion a 10 )
            //Reduccion a 10 void
            //Reduccion a 10 Class
            //Reduccion a 10 {
            //Reduccion a 10 }
            //Reduccion a 10 interface
            //Reduccion a 10 if
            //Reduccion a 10 else
            //Reduccion a 10 while
            //Reduccion a 10 for
            //Reduccion a 10 return 
            //Reduccion a 10 break
            //Reduccion a 10 Console
            //Reduccion a 10 -
            //Reduccion a 10 !
            //Reduccion a 10 this
            //Reduccion a 10 New 
            //Reduccion a 10 intConstant
            //Reduccion a 10 doubleConstant
            //Reduccion a 10 boolConstant
            //Reduccion a 10 stringConstant
            //Reduccion a 10 stringConstant
            //Reduccion a 10 null
            //Reduccion a 10 $
            return true;
        }
        private bool estado44(Token lH)
        {
            //Reduccion a 36
            //Ir a 57 con VariableDecl
            //Ir a 8 con Variable
            //Ir a 59 con ConstDecl
            //Ir a 9 con Type
            //Ir a 14 con Type_P
            //Ir a 58 con FunctionDecl
            //IR a 55 con ClassDecl_Q
            //Ir a 56 con Field
            switch (lH.contenido)
            {
                case "const":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(10);
                    lH = cadenas.Peek();
                    return estado10(lH);

            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
            }
        }
        private bool estado45(Token lH)
        {
            //Reduccion a 32 con {
            //IR a 60 con ClassDecl_R
            //Ir a 61 con ClassDecl_O

            switch (lH.contenido)
            {
                case "const":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(62);
                    lH = cadenas.Peek();
                    return estado62(lH);
                default:
                    return false;
            }
        }
        private bool estado46(Token lH)
        {
            switch (lH.contenido)
            {
                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(63);
                    lH = cadenas.Peek();
                    return estado63(lH);
                default:
                    return false;
            }
        }
        private bool estado47(Token lH)
        {
            //IR A TYPE CON 48
            //IR A TYPE_P CON 14
            //IR A INTERFACEDECL_P CON 64
            //IR A PROTOTYPE CON 47

            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(10);
                    lH = cadenas.Peek();
                    return estado10(lH);

                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(42);
                    lH = cadenas.Peek();
                    return estado42(lH);
            }

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return false;
                    
            }
            
        }
        private bool estado48(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(65);
                    lH = cadenas.Peek();
                    return estado65(lH);
                default:
                    return false;

            }
        }
        private bool estado49(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(66);
                    lH = cadenas.Peek();
                    return estado66(lH);
                default:
                    return false;

            }

        }
        private bool estado50(Token lH)
        {
            switch (lH.contenido)
            {
                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                default:
                    return false;
            }
        }
        private bool estado51(Token lH)
        {
            //Reduccion a 25 con )

            return true;
        }
        private bool estado52(Token lH)
        {
            //Ir a 40 con Variable
            //Ir a 41 con Type
            //Ir a 14 con Type_P
            //Ir a 69 con Formals
            switch(lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                default:
                    return false;
            }
        }
        private bool estado53(Token lH)
        {
            //Reduccion 9 con ;
            //Reduccion 9 con )
            //Reduccion 9 con ,
            return true;
        }
        private bool estado54(Token lH)
        {
            //Ir a 70 con StmtBlock
            switch (lH.contenido)
            {
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                default:
                    return false;

            }
                    
        }
        private bool estado55(Token lH)
        {
            switch (lH.contenido)
            {
                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(71);
                    lH = cadenas.Peek();
                    return estado71(lH);
                default:
                    return false;

            }
        }
        private bool estado56(Token lH)
        {
            //Reduccion a 36 }
            //Ir a 57 VariableDecl
            //Ir a 8 Variable
            //Ir a 59 ConstDecl
            //Ir a 9 Type
            //Ir a 14 Type_p
            //Ir a 58 FunctionDecl
            //Ir a 75 ClassDecl_Q
            //Ir a 56 Field
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(11);
                    lH = cadenas.Peek();
                    return estado11(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(10);
                    lH = cadenas.Peek();
                    return estado10(lH);
                default:
                    return false;

            }
        }
        private bool estado57(Token lH)
        {
            //Reduccion a 37 ident
            //Reduccion a 37 Const
            //Reduccion a 37 int
            //Reduccion a 37 double
            //Reduccion a 37 bool
            //Reduccion a 37 string
            //Reduccion a 37 void
            //Reduccion a 37 }
            return true;

        }
        private bool estado58(Token lH)
        {
            //Reduccion a 38 ident
            //Reduccion a 38 Const
            //Reduccion a 38 int
            //Reduccion a 38 double
            //Reduccion a 38 bool
            //Reduccion a 38 string
            //Reduccion a 38 void
            //Reduccion a 38 }
            return true;
        }
        private bool estado59(Token lH)
        {
            //Reduccion a 39 ident
            //Reduccion a 39 Const
            //Reduccion a 39 int
            //Reduccion a 39 double
            //Reduccion a 39 bool
            //Reduccion a 39 string
            //Reduccion a 39 void
            //Reduccion a 39 }
            return true;
        }
        private bool estado60(Token lH)
        {
            //Reduccion a 29
            return true;
        }
        private bool estado61(Token lH)
        {
            //Reduccion a 31
            return true;
        }
        private bool estado62(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(73);
                    lH = cadenas.Peek();
                    return estado73(lH);
                default:
                    return false;
            }
        }
        private bool estado63(Token lH)
        {
            //Reduccion a 40 ident
            //Reduccion a 40 Const
            //Reduccion a 40 int
            //Reduccion a 40 double
            //Reduccion a 40 bool
            //Reduccion a 40 string
            //Reduccion a 40 void
            //Reduccion a 40 }
            return true;
        }
        private bool estado64(Token lH)
        {
            //Reduccion a 41 }
            return true;
        }
        private bool estado65(Token lH)
        {
            switch (lH.contenido)
            {
                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(74);
                    lH = cadenas.Peek();
                    return estado74(lH);
                default:
                    return false;
            }
        }
        private bool estado66(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(73);
                    lH = cadenas.Peek();
                    return estado73(lH);
                default:
                    return false;
            }
        }
        private bool estado67(Token lH)
        {
            //Reduccion a 23 ident
            //Reduccion a 23 Const
            //Reduccion a 23 int
            //Reduccion a 23 double
            //Reduccion a 23 bool
            //Reduccion a 23 string
            //Reduccion a 23 void
            //Reduccion a 23 class
            //Reduccion a 23 }
            //Reduccion a 23 interface
            //Reduccion a 23 $
            return true;
        }
        private bool estado68(Token lH)
        {
            //Reduccion a 47 ;
            //Reduccion a 47 const
            //Reduccion a 47 (
            //Reduccion a 47 void
            //Reduccion a 47 class
            //reduccion a 47 {
            //Reduccion a 47 }
            //Reduccion a 47 interface
            //Reduccion a 47 if
            //Reduccion a 47 else
            //Reduccion a 47 while 
            //Reduccion a 47 for
            //Reduccion a 48 return
            //Reduccion a 47 break
            //Reduccion a 47 Console 
            //Reduccion a 47 -
            //Reduccion a 47 !
            //Reduccion a 47 this
            //Reduccion a 47 New 
            //Reduccion a 47 intConstant
            //Reduccion a 48 doubleConstant
            //Reduccion a 47 boolConstant
            //Reduccion a 47 stringConstant
            //Reduccion a 47 con null
            //Reduccion a 47 con $
            //Ir a 77 VariableDecl
            //Ir a 8 Variable 
            //Ir a 41 Type
            //Ir a 14 Type_P
            //Ir a 76 StmtBlock_P
            switch (lH.tipo)
            {
                case "ident":
                    //Colision con Reuddcion 47 ident
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    //Colision con Reuddcion 47 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    //Colision con Reuddcion 47 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    //Colision con Reuddcion 47 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    //Colision con Reuddcion 47 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                default:
                    return false;
            }
        }
        private bool estado69(Token lH)
        {
            //reducción a 26 con )
            return true;
        }
        private bool estado70(Token lH)
        {
            //REDUCCION A 24 CON IDENT
            //REDUCCION A 24 CON CONST
            //REDUCCION A 24 CON INT
            //REDUCCION A 24 CON DOUBLE
            //REDUCCION A 24 CON BOOL 
            //REDUCCION A 24 CON STRING 
            //REDUCCION A 24 CON VOID 
            //REDUCCION A 24 CON CLASS
            //REDUCCION A 24 CON } 
            //REDUCCION A 24 CON interface
            //REDUCCION A 24 CON $

            return true;
        }
        private bool estado71(Token lH)
        {
            //REDUCCION A 28 CON IDENT
            //REDUCCION A 28 CON CONST
            //REDUCCION A 28 CON INT 
            //REDUCCION A 28 CON DOUBLE
            //REDUCCION A 28 CON BOOL
            //REDUCCION A 28 CON STRING 
            //REDUCCION A 28 CON VOID
            //REDUCCION A 28 CON CLASS 
            //REDUCCION A 28 CON interface
            //REDUCCION A 28 CON $
            return true;
        }
        private bool estado72(Token lH)
        {
            //REDUCCION A 35 CON }
            return true;
        }
        private bool estado73(Token lH)
        {
            switch (lH.contenido)
            {
                //REDUCCION A 33 CON {
                //IR A ClassDecl_O con 78

                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(62);
                    lH = cadenas.Peek();
                    return estado62(lH);
                default:
                    return false;
            }

        }
        private bool estado74(Token lH)
        {
            //IR A Variable con 40
            //IR A Type con 41
            //IR A Type_P con 14
            //IR A Formlas con 79
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
            }
                    switch (lH.tipo)
                    {
                        case "ident":
                            pilaSimbolos.Push(cadenas.Dequeue().contenido);
                            pilaAcciones.Push(19);
                            lH = cadenas.Peek();
                            return estado19(lH);
                        default:
                            return false;
                    }
            


            }
        private bool estado75(Token lH)
        {
            //IR A 40 con Variable
            //IR A 41 CON Type
            //IR A 14 con Type_P 
            //IR A 80 CON Formals

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(15);
                    lH = cadenas.Peek();
                    return estado15(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(16);
                    lH = cadenas.Peek();
                    return estado16(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(17);
                    lH = cadenas.Peek();
                    return estado17(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(18);
                    lH = cadenas.Peek();
                    return estado18(lH);
                default:
                    return false;
            }

        }
        private bool estado76(Token lH)
        {
            //REDUCCIÓN A 49 CON;
            //COLISION CON (DESPLAZAMIENTO A 11 / REDUCCIÓN A 49 ) CON CONST
            //REDUCCION A 49 CON INT
            //REDUCCION A 49 CON DOUBLE
            //REDUCCION A 49 CON BOOL 
            //REDUCCION A 49 CON STRING 
            //REDUCCION A 49 CON (
            //REDUCCION A 49 CON VOID
            //REDUCCION A 49 CON CLASS
            //REDUCCION A 49 CON { 
            //REDUCCION A 49 CON }
            //REDUCCION A 49 CON interface 
            //REDUCCION A 49 CON IF
            //REDUCCION A 49 CON ELSE
            //REDUCCION A 49 CON WHILE
            //REDUCCION A 49 CON FOR 
            //REDUCCION A 49 CON RETURN 
            //REDUCCION A 49 CON BREAK
            //REDUCCION A 49 CON Console
            //REDUCCION A 49 CON -
            //REDUCCION A 49 CON !
            //REDUCCION A 49 CON this
            //REDUCCION A 49 CON New
            //REDUCCION A 49 CON intConst
            //REDUCCION A 49 CON doubleConst
            //REDUCCION A 49 CON boolConst
            //REDUCCION A 49 CON stringConst
            //REDUCCION A 49 CON null
            //REDUCCION A 49 CON $ 

            //IR A 82 CON ConstDecl
            //IR A 81 CON StmtBlock_R
            return true;
        }
        private bool estado77(Token lH)
        {
            //REDUCCION A ; CON 47
            //COLISION (DESPLZAMIENTO A 19 / REDUCCIÓN A 47) CON IDENT 
            //REDUCCIÓN A 47 CON const

            //COLISIÓN (DESPLAZAMEINTO A 15 / REDUCCIÓN 47) CON int
            //COLISIÓN (DESPLAZAMEINTO A 16 / REDUCCIÓN 47) CON double
            //COLISIÓN (DESPLAZAMEINTO A 17 / REDUCCIÓN 47) CON bool
            //COLISIÓN (DESPLAZAMEINTO A 18 / REDUCCIÓN 47) CON string

            //REDUCCIÓN A 47 CON (
            //REDUCCIÓN A 47 CON void
            //REDUCCIÓN A 47 CON class 
            //REDUCCIÓN A 47 CON {
            //REDUCCIÓN A 47 CON } 
            //REDUCCIÓN A 47 CON interface 
            //REDUCCIÓN A 47 CON if
            //REDUCCIÓN A 47 CON else
            //REDUCCIÓN A 47 CON while
            //REDUCCIÓN A 47 CON for
            //REDUCCIÓN A 47 CON return
            //REDUCCIÓN A 47 CON break
            //REDUCCIÓN A 47 CON Console
            //REDUCCIÓN A 47 CON -
            //REDUCCIÓN A 47 CON !
            //REDUCCIÓN A 47 CON this
            //REDUCCIÓN A 47 CON New
            //REDUCCIÓN A 47 CON intConstantt
            //REDUCCIÓN A 47 CON doubleConstant
            //REDUCCIÓN A 47 CON boolConstatn
            //REDUCCIÓN A 47 CON stringConstatn 
            //REDUCCIÓN A 47 CON null
            //REDUCCIÓN A 47 CON $

            //IR A 77 CON VariableDecl
            //IR A 8 CON Variable
            //IR A 41 CON Type
            //IR A 14 CON Type_P
            //IR A 83 CON StmtBlock_P

            return true;
        }
        private bool estado78(Token lH)
        {
            //REDUCCIÓN A 34 CON {

            return true;
        }
        private bool estado79(Token lH)
        {
            switch (lH.tipo)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(84);
                    lH = cadenas.Peek();
                    return estado84(lH);
                default:
                    return false;
            }
           
        }
        private bool estado80(Token lH)
        {

            switch (lH.tipo)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(85);
                    lH = cadenas.Peek();
                    return estado85(lH);
                default:
                    return false;
            }
        }
        private bool estado81(Token lH)
        {
            //REUDCCION A 51 CON }

            //IR A StmtBlock CON 95
            //IR A 86 CON StmtBlock_O 
            //IR A 87 CON Stmt
            //IR A 90 CON Stmt_P
            //IR A 88 CON IfStmt
            //IR A 89 CON WhileStmt
            //IR A 91 CON ForStmt 
            //IR A 93 CON ReturnStmt
            //IR A 92 CON BreakStmt
            //IR A 94 CON PrintStmt

            //IR A 98 CON Expr
            //IR A 104 CON ExprOr
            //IR A 105 CON ExprOr_P
            //IR A 106 CON ExprAnd
            //IR A 107 CON ExprAndP
            //IR A 108 CON ExprEquals
            //IR A 109 CON ExprEqualsP
            //IR A 112 CON ExprComp
            //IR A 113 CON ExprCompP



            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }

            }
        private bool estado82(Token lH)
        {
            //REDUCCION A 49 CON ;
            //REDUCCION A 49 CON ident

            //COLISION (DESPLAZAMAIENTO A 11 / REDUCCIÓN A 49) CON const

            //REDUCCION A 49 CON int
            //REDUCCION A 49 CON double
            //REDUCCION A 49 CON bool
            //REDUCCION A 49 CON string
            //REDUCCION A 49 CON (
            //REDUCCION A 49 CON void
            //REDUCCION A 49 CON class
            //REDUCCION A 49 CON {
            //REDUCCION A 49 CON }
            //REDUCCION A 49 CON interface
            //REDUCCION A 49 CON if
            //REDUCCION A 49 CON else
            //REDUCCION A 49 CON while
            //REDUCCION A 49 CON for
            //REDUCCION A 49 CON return 
            //REDUCCION A 49 CON break
            //REDUCCION A 49 CON Console
            //REDUCCION A 49 CON -
            //REDUCCION A 49 CON !
            //REDUCCION A 49 CON this
            //REDUCCION A 49 CON New
            //REDUCCION A 49 CON intConstant
            //REDUCCION A 49 CON doubleConstant
            //REDUCCION A 49 CON boolConstant
            //REDUCCION A 49 CON stringConstant
            //REDUCCION A 49 CON null
            //REDUCCION A 49 CON $

            //IR A 82 CON ConstDecl
            //IR A 122 CON StmtBlock_R

            return true;
        }
        private bool estado83(Token lH)
        {
            //REDUCCIÓN A 46 CON ;
            //REDUCCIÓN A 46 CON ident
            //REDUCCIÓN A 46 CON const
            //REDUCCIÓN A 46 CON int
            //REDUCCIÓN A 46 CON double
            //REDUCCIÓN A 46 CON bool
            //REDUCCIÓN A 46 CON string
            //REDUCCIÓN A 46 CON (
            //REDUCCIÓN A 46 CON void 
            //REDUCCIÓN A 46 CON class
            //REDUCCIÓN A 46 CON {
            //REDUCCIÓN A 46 CON }
            //REDUCCIÓN A 46 CON interface
            //REDUCCIÓN A 46 CON if
            //REDUCCIÓN A 46 CON else
            //REDUCCIÓN A 46 CON while
            //REDUCCIÓN A 46 CON for
            //REDUCCIÓN A 46 CON return
            //REDUCCIÓN A 46 CON break
            //REDUCCIÓN A 46 CON Console
            //REDUCCIÓN A 46 CON -
            //REDUCCIÓN A 46 CON !
            //REDUCCIÓN A 46 CON this
            //REDUCCIÓN A 46 CON New
            //REDUCCIÓN A 46 CON intConstant
            //REDUCCIÓN A 46 CON doubleConstant
            //REDUCCIÓN A 46 CON boolConstant
            //REDUCCIÓN A 46 CON stringConstant
            //REDUCCIÓN A 46 CON null
            //REDUCCIÓN A 46 CON $



            return true;
        }
        private bool estado84(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(123);
                    lH = cadenas.Peek();
                    return estado123(lH);
                default:
                    return false;
            }
        }
        private bool estado85(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(124);
                    lH = cadenas.Peek();
                    return estado124(lH);
                default:
                    return false;
            }
        }
        private bool estado86(Token lH)
        {

            switch (lH.contenido)
            {
                case "}":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(125);
                    lH = cadenas.Peek();
                    return estado125(lH);
                default:
                    return false;
            }
        }
        private bool estado87(Token lH)
        {
            //Reduccion a 61 ;
            //Reduccion a 51 }
            //Ir a 95 StmtBlock
            //Ir a 126 StmtBlock_O
            //Ir a 87 Stmt
            //Ir a 90 Stmt_P
            //Ir a 88 IfStmt
            //Ir a 89 WhileStmt
            //Ir a 91 ForStmt
            //Ir a 93 ReturnStmt
            //Ir a 92 BreakStmt
            //Ir a 94 PrintStmt
            //Ir a 98 Expr
            //Ir a 104 ExprOR
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExprAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112 ExprComp
            //Ir a 113 ExprCompP
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                default:
                    return false;
            }
        }
        private bool estado88(Token lH)
        {
            //Reduccion 52 ;
            //Reduccion 52 ident
            //Reduccion 52 (
            //Reduccion 52 {
            //Reduccion 52 }
            //Reduccion 52 if
            //Reduccion 52 else
            //Reduccion 52 while
            //Reduccion 52 for
            //Reduccion 52 return 
            //Reduccion 52 break
            //Reduccion 52 Console
            //Reduccion 52 -
            //Reduccion 52 !
            //Reduccion 52 this
            //Reduccion 52 New
            //Reduccion 52 intConstant
            //Reduccion 52 doubleConstant
            //Reduccion 52 boolConstant
            //Reduccion 52 stringConstant
            //Reduccion 52 null
            return true;
        }
        private bool estado89(Token lH)
        {
            //Reduccion 53 ;
            //Reduccion 53 ident
            //Reduccion 53 (
            //Reduccion 53 {
            //Reduccion 53 }
            //Reduccion 53 if
            //Reduccion 53 else
            //Reduccion 53 while
            //Reduccion 53 for
            //Reduccion 53 return 
            //Reduccion 53 break
            //Reduccion 53 Console
            //Reduccion 53 -
            //Reduccion 53 !
            //Reduccion 53 this
            //Reduccion 53 New
            //Reduccion 53 intConstant
            //Reduccion 53 doubleConstant
            //Reduccion 53 boolConstant
            //Reduccion 53 stringConstant
            //Reduccion 53 null
            return true;
        }
        private bool estado90(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                default:
                    return false;
            }
        }
        private bool estado91(Token lH)
        {
            //Reduccion 55 ;
            //Reduccion 55 ident
            //Reduccion 55 (
            //Reduccion 55 {
            //Reduccion 55 }
            //Reduccion 55 if
            //Reduccion 55 else
            //Reduccion 55 while
            //Reduccion 55 for
            //Reduccion 55 return 
            //Reduccion 55 break
            //Reduccion 55 Console
            //Reduccion 55 -
            //Reduccion 55 !
            //Reduccion 55 this
            //Reduccion 55 New
            //Reduccion 55 intConstant
            //Reduccion 55 doubleConstant
            //Reduccion 55 boolConstant
            //Reduccion 55 stringConstant
            //Reduccion 55 null
            return true;
        }
        private bool estado92(Token lH)
        {
            //Reduccion 56 ;
            //Reduccion 56 ident
            //Reduccion 56 (
            //Reduccion 56 {
            //Reduccion 56 }
            //Reduccion 56 if
            //Reduccion 56 else
            //Reduccion 56 while
            //Reduccion 56 for
            //Reduccion 56 return 
            //Reduccion 56 break
            //Reduccion 56 Console
            //Reduccion 56 -
            //Reduccion 56 !
            //Reduccion 56 this
            //Reduccion 56 New
            //Reduccion 56 intConstant
            //Reduccion 56 doubleConstant
            //Reduccion 56 boolConstant
            //Reduccion 56 stringConstant
            //Reduccion 56 null
            return true;
        }
        private bool estado93(Token lH)
        {
            //Reduccion 57 ;
            //Reduccion 57 ident
            //Reduccion 57 (
            //Reduccion 57 {
            //Reduccion 57 }
            //Reduccion 57 if
            //Reduccion 57 else
            //Reduccion 57 while
            //Reduccion 57 for
            //Reduccion 57 return 
            //Reduccion 57 break
            //Reduccion 57 Console
            //Reduccion 57 -
            //Reduccion 57 !
            //Reduccion 57 this
            //Reduccion 57 New
            //Reduccion 57 intConstant
            //Reduccion 57 doubleConstant
            //Reduccion 57 boolConstant
            //Reduccion 57 stringConstant
            //Reduccion 57 null
            return true;
        }
        private bool estado94(Token lH)
        {
            //Reduccion 58 ;
            //Reduccion 58 ident
            //Reduccion 58 (
            //Reduccion 58 {
            //Reduccion 58 }
            //Reduccion 58 if
            //Reduccion 58 else
            //Reduccion 58 while
            //Reduccion 58 for
            //Reduccion 58 return 
            //Reduccion 58 break
            //Reduccion 58 Console
            //Reduccion 58 -
            //Reduccion 58 !
            //Reduccion 58 this
            //Reduccion 58 New
            //Reduccion 58 intConstant
            //Reduccion 58 doubleConstant
            //Reduccion 58 boolConstant
            //Reduccion 58 stringConstant
            //Reduccion 58 null
            return true;
        }
        private bool estado95(Token lH)
        {
            //Reduccion 59 ;
            //Reduccion 59 ident
            //Reduccion 59 (
            //Reduccion 59 {
            //Reduccion 59 }
            //Reduccion 59 if
            //Reduccion 59 else
            //Reduccion 59 while
            //Reduccion 59 for
            //Reduccion 59 return 
            //Reduccion 59 break
            //Reduccion 59 Console
            //Reduccion 59 -
            //Reduccion 59 !
            //Reduccion 59 this
            //Reduccion 59 New
            //Reduccion 59 intConstant
            //Reduccion 59 doubleConstant
            //Reduccion 59 boolConstant
            //Reduccion 59 stringConstant
            //Reduccion 59 null
            return true;
        }
        private bool estado96(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(128);
                    lH = cadenas.Peek();
                    return estado128(lH);
                default:
                    return false;
            }
        }
        private bool estado97(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(129);
                    lH = cadenas.Peek();
                    return estado129(lH);
                default:
                    return false;
            }
        }
        private bool estado98(Token lH)
        {
            //Reduccion a 60 ;
            return true;
        }
        private bool estado99(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(130);
                    lH = cadenas.Peek();
                    return estado130(lH);
                default:
                    return false;
            }
        }
        private bool estado100(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(131);
                    lH = cadenas.Peek();
                    return estado131(lH);
                default:
                    return false;
            }
        }
        private bool estado101(Token lH)
        {

            //IR A 132 CON Expr
            //IR A 104 CON ExprOr
            //IR A 105 CON ExprOrP
            //IR A 106 CON ExprAnd
            //IR A 107 CON ExprAndP
            //IR A 108 CON ExprEquals
            //IR A 109 CON ExprEqualsP
            //IR A 112 CON ExprComp
            //IR A 113 CON ExprCompP

            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
            }

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
                default:
                    return false;
            }
            }
        private bool estado102(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(133);
                    lH = cadenas.Peek();
                    return estado133(lH);
                default:
                    return false;
            }
        }
        private bool estado103(Token lH)
        {
            //Reduccion 94 ;
            //Reduccion 94 ident
            //Reduccion 94 (
            //Reduccion 94 )
            //Reduccion 94 ,
            //Reduccion 94 {
            //Reduccion 94 }
            //Reduccion 94 if
            //Reduccion 94 else
            //Reduccion 94 while
            //Reduccion 94 for
            //Reduccion 94 return 
            //Reduccion 94 break
            //Reduccion 94 Console
            //Reduccion 94 .
            //Reduccion 94 ==
            //Reduccion 94 &&
            //Reduccion 94 <
            //Reduccion 94 <=
            //Reduccion 94 +
            //Reduccion 94 *
            //Reduccion 94 %
            //Reduccion 94 -
            //Reduccion 94 !
            //Reduccion 94 this
            //Reduccion 94 New
            //Reduccion 94 intConstant
            //Reduccion 94 doubleConstant
            //Reduccion 94 boolConstant
            //Reduccion 94 stringConstant
            //Reduccion 94 null
            switch (lH.contenido)
            {
                case "=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(134);
                    lH = cadenas.Peek();
                    return estado134(lH);
                default:
                    return false;
            }
        }
        private bool estado104(Token lH)
        {
            //Reduccion 73 ;
            //Reduccion 73 ident
            //Reduccion 73 (
            //Reduccion 73 )
            //Reduccion 73 ,
            //Reduccion 73 {
            //Reduccion 73 }
            //Reduccion 73 if
            //Reduccion 73 else
            //Reduccion 73 while
            //Reduccion 73 for
            //Reduccion 73 return 
            //Reduccion 73 break
            //Reduccion 73 Console
            //Reduccion 73 .
            //Reduccion 73 ==
            //Reduccion 73 -
            //Reduccion 73 !
            //Reduccion 73 this
            //Reduccion 73 New
            //Reduccion 73 intConstant
            //Reduccion 73 doubleConstant
            //Reduccion 73 boolConstant
            //Reduccion 73 stringConstant
            //Reduccion 73 null
            switch (lH.contenido)
            {
                case "==":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(135);
                    lH = cadenas.Peek();
                    return estado135(lH);
                default:
                    return false;
            }
        }
        private bool estado105(Token lH)
        {
            //Reduccion 75 ;
            //Reduccion 75 ident
            //Reduccion 75 (
            //Reduccion 75 )
            //Reduccion 75 ,
            //Reduccion 75 {
            //Reduccion 75 }
            //Reduccion 75 if
            //Reduccion 75 else
            //Reduccion 75 while
            //Reduccion 75 for
            //Reduccion 75 return 
            //Reduccion 75 break
            //Reduccion 75 Console
            //Reduccion 75 .
            //Reduccion 75 ==
            //Reduccion 75 &&
            //Reduccion 75 -
            //Reduccion 75 !
            //Reduccion 75 this
            //Reduccion 75 New
            //Reduccion 75 intConstant
            //Reduccion 75 doubleConstant
            //Reduccion 75 boolConstant
            //Reduccion 75 stringConstant
            //Reduccion 75 null
            switch (lH.contenido)
            {
                case "&&":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(136);
                    lH = cadenas.Peek();
                    return estado136(lH);
                default:
                    return false;
            }
        }
        private bool estado106(Token lH)
        {
            //Reduccion 77 ;
            //Reduccion 77 ident
            //Reduccion 77 (
            //Reduccion 77 )
            //Reduccion 77 ,
            //Reduccion 77 {
            //Reduccion 77 }
            //Reduccion 77 if
            //Reduccion 77 else
            //Reduccion 77 while
            //Reduccion 77 for
            //Reduccion 77 return 
            //Reduccion 77 break
            //Reduccion 77 Console
            //Reduccion 77 .
            //Reduccion 77 ==
            //Reduccion 77 &&
            //Reduccion 77 -
            //Reduccion 77 !
            //Reduccion 77 this
            //Reduccion 77 New
            //Reduccion 77 intConstant
            //Reduccion 77 doubleConstant
            //Reduccion 77 boolConstant
            //Reduccion 77 stringConstant
            //Reduccion 77 null
            switch (lH.contenido)
            {
                case "<":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(137);
                    lH = cadenas.Peek();
                    return estado137(lH);
                case "<=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(138);
                    lH = cadenas.Peek();
                    return estado138(lH);
                default:
                    return false;
            }
        }
        private bool estado107(Token lH)
        {
            //Reduccion 78;
            //Reduccion 78ident
            //Reduccion 78(
            //Reduccion 78)
            //Reduccion 78,
            //Reduccion 78{
            //Reduccion 78}
            //Reduccion 78if
            //Reduccion 78else
            //Reduccion 78while
            //Reduccion 78for
            //Reduccion 78return 
            //Reduccion 78break
            //Reduccion 78Console
            //Reduccion 78.
            //Reduccion 78==
            //Reduccion 78&&
            //Reduccion 78<
            //Reduccion 78<=
            //Reduccion 78-
            //Reduccion 78!
            //Reduccion 78this
            //Reduccion 78New
            //Reduccion 78intConstant
            //Reduccion 78doubleConstant
            //Reduccion 78boolConstant
            //Reduccion 78stringConstant
            //Reduccion 78null
            switch (lH.contenido)
            {
                case "+":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(137);
                    lH = cadenas.Peek();
                    return estado137(lH);
                default:
                    return false;
            }
        }
        private bool estado108(Token lH)
        {
            //Reduccion 80;
            //Reduccion 80ident
            //Reduccion 80(
            //Reduccion 80)
            //Reduccion 80,
            //Reduccion 80{
            //Reduccion 80}
            //Reduccion 80if
            //Reduccion 80else
            //Reduccion 80while
            //Reduccion 80for
            //Reduccion 80return 
            //Reduccion 80break
            //Reduccion 80Console
            //Reduccion 80.
            //Reduccion 80==
            //Reduccion 80&&
            //Reduccion 80<
            //Reduccion 80<=
            //Reduccion 80+
            //Reduccion 80-
            //Reduccion 80!
            //Reduccion 80this
            //Reduccion 80New
            //Reduccion 80intConstant
            //Reduccion 80doubleConstant
            //Reduccion 80boolConstant
            //Reduccion 80stringConstant
            //Reduccion 80null
            switch (lH.contenido)
            {
                case "*":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(140);
                    lH = cadenas.Peek();
                    return estado140(lH);
                case "%":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(141);
                    lH = cadenas.Peek();
                    return estado141(lH);
                default:
                    return false;
            }
        }
        private bool estado109(Token lH)
        {
            //Reduccion 85;
            //Reduccion 85ident
            //Reduccion 85(
            //Reduccion 85)
            //Reduccion 85,
            //Reduccion 85{
            //Reduccion 85}
            //Reduccion 85if
            //Reduccion 85else
            //Reduccion 85while
            //Reduccion 85for
            //Reduccion 85return 
            //Reduccion 85break
            //Reduccion 85Console
            //Reduccion 85.
            //Reduccion 85==
            //Reduccion 85&&
            //Reduccion 85<
            //Reduccion 85<=
            //Reduccion 85+
            //Reduccion 85-
            //Reduccion 85!
            //Reduccion 85this
            //Reduccion 85New
            //Reduccion 85intConstant
            //Reduccion 85doubleConstant
            //Reduccion 85boolConstant
            //Reduccion 85stringConstant
            //Reduccion 85null
            return true;
        }
        private bool estado110(Token lH)
        {
            //Ir a 142 ExprComp
            //Ir a 113 ExprCompP
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado111(Token lH)
        {

            //Ir a 144 ExprComp
            //Ir a 113 ExprCompP
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado112(Token lH)
        {
            //Reduccion 88;
            //Reduccion 88ident
            //Reduccion 88(
            //Reduccion 88)
            //Reduccion 88,
            //Reduccion 88{
            //Reduccion 88}
            //Reduccion 88if
            //Reduccion 88else
            //Reduccion 88while
            //Reduccion 88for
            //Reduccion 88return 
            //Reduccion 88break
            //Reduccion 88Console
            //Reduccion 88==
            //Reduccion 88&&
            //Reduccion 88<
            //Reduccion 88<=
            //Reduccion 88+
            //Reduccion 88*
            //Reduccion 88%
            //Reduccion 88-
            //Reduccion 88!
            //Reduccion 88this
            //Reduccion 88New
            //Reduccion 88intConstant
            //Reduccion 88doubleConstant
            //Reduccion 88boolConstant
            //Reduccion 88stringConstant
            //Reduccion 88null
            switch (lH.contenido)
            {
                case ".":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(145);
                    lH = cadenas.Peek();
                    return estado145(lH);
                default:
                    return false;
            }
        }
        private bool estado113(Token lH)
        {
            //Reduccion 91;
            //Reduccion 91ident
            //Reduccion 91(
            //Reduccion 91)
            //Reduccion 91,
            //Reduccion 91{
            //Reduccion 91}
            //Reduccion 91if
            //Reduccion 91else
            //Reduccion 91while
            //Reduccion 91for
            //Reduccion 91return 
            //Reduccion 91break
            //Reduccion 91Console
            //Reduccion 91.
            //Reduccion 91==
            //Reduccion 91&&
            //Reduccion 91<
            //Reduccion 91<=
            //Reduccion 91+
            //Reduccion 91*
            //Reduccion 91%
            //Reduccion 91-
            //Reduccion 91!
            //Reduccion 91this
            //Reduccion 91New
            //Reduccion 91intConstant
            //Reduccion 91doubleConstant
            //Reduccion 91boolConstant
            //Reduccion 91stringConstant
            //Reduccion 91null
            return true;
        }
        private bool estado114(Token lH)
        {
            //Ir a 146 Expr
            //Ir a 104 ExprOr
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado115(Token lH)
        {
            //Reduccion 93;
            //Reduccion 93ident
            //Reduccion 93(
            //Reduccion 93)
            //Reduccion 93,
            //Reduccion 93{
            //Reduccion 93}
            //Reduccion 93if
            //Reduccion 93else
            //Reduccion 93while
            //Reduccion 93for
            //Reduccion 93return 
            //Reduccion 93break
            //Reduccion 93Console
            //Reduccion 93.
            //Reduccion 93==
            //Reduccion 93&&
            //Reduccion 93<
            //Reduccion 93<=
            //Reduccion 93+
            //Reduccion 93*
            //Reduccion 93%
            //Reduccion 93-
            //Reduccion 93!
            //Reduccion 93this
            //Reduccion 93New
            //Reduccion 93intConstant
            //Reduccion 93doubleConstant
            //Reduccion 93boolConstant
            //Reduccion 93stringConstant
            //Reduccion 93null
            return false;
        }
        private bool estado116(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(147);
                    lH = cadenas.Peek();
                    return estado147(lH);
                default:
                    return false;
            }
        }
        private bool estado117(Token lH)
        {
            //Reduccion 96;
            //Reduccion 96ident
            //Reduccion 96(
            //Reduccion 96)
            //Reduccion 96,
            //Reduccion 96{
            //Reduccion 96}
            //Reduccion 96if
            //Reduccion 96else
            //Reduccion 96while
            //Reduccion 96for
            //Reduccion 96return 
            //Reduccion 96break
            //Reduccion 96Console
            //Reduccion 96.
            //Reduccion 96==
            //Reduccion 96&&
            //Reduccion 96<
            //Reduccion 96<=
            //Reduccion 96+
            //Reduccion 96*
            //Reduccion 96%
            //Reduccion 96-
            //Reduccion 96!
            //Reduccion 96this
            //Reduccion 96New
            //Reduccion 96intConstant
            //Reduccion 96doubleConstant
            //Reduccion 96boolConstant
            //Reduccion 96stringConstant
            //Reduccion 96null
            return true;
        }
        private bool estado118(Token lH)
        {
            //Reduccion 97;
            //Reduccion 97ident
            //Reduccion 97(
            //Reduccion 97)
            //Reduccion 97,
            //Reduccion 97{
            //Reduccion 97}
            //Reduccion 97if
            //Reduccion 97else
            //Reduccion 97while
            //Reduccion 97for
            //Reduccion 97return 
            //Reduccion 97break
            //Reduccion 97Console
            //Reduccion 97.
            //Reduccion 97==
            //Reduccion 97&&
            //Reduccion 97<
            //Reduccion 97<=
            //Reduccion 97+
            //Reduccion 97*
            //Reduccion 97%
            //Reduccion 97-
            //Reduccion 97!
            //Reduccion 97this
            //Reduccion 97New
            //Reduccion 97intConstant
            //Reduccion 97doubleConstant
            //Reduccion 97boolConstant
            //Reduccion 97stringConstant
            //Reduccion 97null
            return true;
        }
        private bool estado119(Token lH)
        {
            //Reduccion 98;
            //Reduccion 98ident
            //Reduccion 98(
            //Reduccion 98)
            //Reduccion 98,
            //Reduccion 98{
            //Reduccion 98}
            //Reduccion 98if
            //Reduccion 98else
            //Reduccion 98while
            //Reduccion 98for
            //Reduccion 98return 
            //Reduccion 98break
            //Reduccion 98Console
            //Reduccion 98.
            //Reduccion 98==
            //Reduccion 98&&
            //Reduccion 98<
            //Reduccion 98<=
            //Reduccion 98+
            //Reduccion 98*
            //Reduccion 98%
            //Reduccion 98-
            //Reduccion 98!
            //Reduccion 98this
            //Reduccion 98New
            //Reduccion 98intConstant
            //Reduccion 98doubleConstant
            //Reduccion 98boolConstant
            //Reduccion 98stringConstant
            //Reduccion 98null
            return true;
        }
        private bool estado120(Token lH)
        {
            //Reduccion 99;
            //Reduccion 99ident
            //Reduccion 99(
            //Reduccion 99)
            //Reduccion 99,
            //Reduccion 99{
            //Reduccion 99}
            //Reduccion 99if
            //Reduccion 99else
            //Reduccion 99while
            //Reduccion 99for
            //Reduccion 99return 
            //Reduccion 99break
            //Reduccion 99Console
            //Reduccion 99.
            //Reduccion 99==
            //Reduccion 99&&
            //Reduccion 99<
            //Reduccion 99<=
            //Reduccion 99+
            //Reduccion 99*
            //Reduccion 99%
            //Reduccion 99-
            //Reduccion 99!
            //Reduccion 99this
            //Reduccion 99New
            //Reduccion 99intConstant
            //Reduccion 99doubleConstant
            //Reduccion 99boolConstant
            //Reduccion 99stringConstant
            //Reduccion 99null
            return true;
        }
        private bool estado121(Token lH)
        {
            //Reduccion 100;
            //Reduccion 100ident
            //Reduccion 100(
            //Reduccion 100)
            //Reduccion 100,
            //Reduccion 100{
            //Reduccion 100}
            //Reduccion 100if
            //Reduccion 100else
            //Reduccion 100while
            //Reduccion 100for
            //Reduccion 100return 
            //Reduccion 100break
            //Reduccion 100Console
            //Reduccion 100.
            //Reduccion 100==
            //Reduccion 100&&
            //Reduccion 100<
            //Reduccion 100<=
            //Reduccion 100+
            //Reduccion 100*
            //Reduccion 100%
            //Reduccion 100-
            //Reduccion 100!
            //Reduccion 100this
            //Reduccion 100New
            //Reduccion 100intConstant
            //Reduccion 100doubleConstant
            //Reduccion 100boolConstant
            //Reduccion 100stringConstant
            //Reduccion 100null
            return true;
        }
        private bool estado122(Token lH)
        {
            //Reduccion 48 ;
            //Reduccion 48 ident
            //Reduccion 48 conts
            //Reduccion 48 int
            //Reduccion 48 double
            //Reduccion 48 bool
            //Reduccion 48 string
            //Reduccion 48 (
            //Reduccion 48 void
            //Reduccion 48 class
            //Reduccion 48 {
            //Reduccion 48 } 
            //Reduccion 48 interface
            //Reduccion 48 if
            //Reduccion 48 else
            //Reduccion 48 while
            //Reduccion 48 for
            //Reduccion 48 return
            //Reduccion 48 break
            //Reduccion 48 Console
            //Reduccion 48 -
            //Reduccion 48 !
            //Reduccion 48 this
            //Reduccion 48 New
            //Reduccion 48 intConstant
            //Reduccion 48 doubleConstant
            //Reduccion 48 boolConstant
            //Reduccion 48 stringConstant
            //Reduccion 48 null
            //Reduccion 48 $
            return true;
        }
        private bool estado123(Token lH)
        {
            //Reduccion 43 ident
            //Reduccion 43 int
            //Reduccion 43 double
            //Reduccion 43 bool
            //Reduccion 43 string
            //Reduccion 43 void
            //Reduccion 43 }
            return true;
        }
        private bool estado124(Token lH)
        {
            //Reduccion 444 ident
            //Reduccion 44 int
            //Reduccion 44 double
            //Reduccion 44 bool
            //Reduccion 44 string
            //Reduccion 44 void
            //Reduccion 44 }
            return true;
        }
        private bool estado125(Token lH)
        {
            //Reduccion 45 ;
            //Reduccion 45 ident
            //Reduccion 45 conts
            //Reduccion 45 int
            //Reduccion 45 double
            //Reduccion 45 bool
            //Reduccion 45 string
            //Reduccion 45 (
            //Reduccion 45 void
            //Reduccion 45 class
            //Reduccion 45 {
            //Reduccion 45 } 
            //Reduccion 45 interface
            //Reduccion 45 if
            //Reduccion 45 else
            //Reduccion 45 while
            //Reduccion 45 for
            //Reduccion 45 return
            //Reduccion 45 break
            //Reduccion 45 Console
            //Reduccion 45 -
            //Reduccion 45 !
            //Reduccion 45 this
            //Reduccion 45 New
            //Reduccion 45 intConstant
            //Reduccion 45 doubleConstant
            //Reduccion 45 boolConstant
            //Reduccion 45 stringConstant
            //Reduccion 45 null
            //Reduccion 45 $
            return true;
        }
        private bool estado126(Token lH)
        {
            //Reduccion 50 }
            return true;
        }
        private bool estado127(Token lH)
        {
            //Reduccion 54 ;
            //Reduccion 54 ident
            //Reduccion 54 conts
            //Reduccion 54 int
            //Reduccion 54 double
            //Reduccion 54 bool
            //Reduccion 54 string
            //Reduccion 54 (
            //Reduccion 54 void
            //Reduccion 54 class
            //Reduccion 54 {
            //Reduccion 54 } 
            //Reduccion 54 interface
            //Reduccion 54 if
            //Reduccion 54 else
            //Reduccion 54 while
            //Reduccion 54 for
            //Reduccion 54 return
            //Reduccion 54 break
            //Reduccion 54 Console
            //Reduccion 54 -
            //Reduccion 54 !
            //Reduccion 54 this
            //Reduccion 54 New
            //Reduccion 54 intConstant
            //Reduccion 54 doubleConstant
            //Reduccion 54 boolConstant
            //Reduccion 54 stringConstant
            //Reduccion 54 null
            //Reduccion 54 $
            return true;
        }
        private bool estado128(Token lH)
        {
            //Ir a 148 Expr
            //Ir a 104 ExprOr
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado129(Token lH)
        {
            //Ir a 149 Expr
            //Ir a 104 ExprOr
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado130(Token lH)
        {
            //Ir a 150 Expr
            //Ir a 104 ExprOr
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado131(Token lH)
        {
            //Reduccion 68 ;
            //Reduccion 68 ident
            //Reduccion 68 (
            //Reduccion 68 {
            //Reduccion 68 }
            //Reduccion 68 if
            //Reduccion 68 else
            //Reduccion 68 while
            //Reduccion 68 for
            //Reduccion 68 return 
            //Reduccion 68 break
            //Reduccion 68 Console
            //Reduccion 68 -
            //Reduccion 68 !
            //Reduccion 68 this
            //Reduccion 68 New
            //Reduccion 68 intConstant
            //Reduccion 68 doubleConstant
            //Reduccion 68 boolConstant
            //Reduccion 68 stringConstant
            //Reduccion 68 null
            return true;
        }
        private bool estado132(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(151);
                    lH = cadenas.Peek();
                    return estado151(lH);
                default:
                    return false;
            }
                    
        }
        private bool estado133(Token lH)
        {
            switch (lH.contenido)
            {
                case "WriteLine":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(152);
                    lH = cadenas.Peek();
                    return estado152(lH);
                default:
                    return false;
            }
        }
        private bool estado134(Token lH)
        {
            //Ir a 153 ExprOr
            //Ir a 105 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado135(Token lH)
        {
            //Ir a 154 ExprOrP
            //Ir a 106 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado136(Token lH)
        {
            //Ir a 155 ExprAnd
            //Ir a 107 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado137(Token lH)
        {
            //Ir a 156 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado138(Token lH)
        {
            //Ir a 157 ExpreAndP
            //Ir a 108 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado139(Token lH)
        {
            //Ir a 158 ExprEquals
            //Ir a 109 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado140(Token lH)
        {
            //Ir a 159 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado141(Token lH)
        {
            //Ir a 160 ExprEqualsP
            //Ir a 112  ExprComp
            //Ir a 113 ExprComp
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(143);
                    lH = cadenas.Peek();
                    return estado143(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado142(Token lH)
        {
            //Reduccion 86;
            //Reduccion 86ident
            //Reduccion 86(
            //Reduccion 86)
            //Reduccion 86,
            //Reduccion 86{
            //Reduccion 86}
            //Reduccion 86if
            //Reduccion 86else
            //Reduccion 86while
            //Reduccion 86for
            //Reduccion 86return 
            //Reduccion 86break
            //Reduccion 86Console
            //Reduccion 86==
            //Reduccion 86&&
            //Reduccion 86<
            //Reduccion 86<=
            //Reduccion 86+
            //Reduccion 86*
            //Reduccion 86%
            //Reduccion 86-
            //Reduccion 86!
            //Reduccion 86this
            //Reduccion 86New
            //Reduccion 86intConstant
            //Reduccion 86doubleConstant
            //Reduccion 86boolConstant
            //Reduccion 86stringConstant
            //Reduccion 86null
            switch (lH.contenido)
            {
                case ".":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(145);
                    lH = cadenas.Peek();
                    return estado145(lH);
                default:
                    return false;
            }
        }
        private bool estado143(Token lH)
        {
            //Reduccion 94;
            //Reduccion 94ident
            //Reduccion 94(
            //Reduccion 94)
            //Reduccion 94,
            //Reduccion 94{
            //Reduccion 94}
            //Reduccion 94if
            //Reduccion 94else
            //Reduccion 94while
            //Reduccion 94for
            //Reduccion 94return 
            //Reduccion 94break
            //Reduccion 94Console
            //Reduccion 94 .
            //Reduccion 94==
            //Reduccion 94&&
            //Reduccion 94<
            //Reduccion 94<=
            //Reduccion 94+
            //Reduccion 94*
            //Reduccion 94%
            //Reduccion 94-
            //Reduccion 94!
            //Reduccion 94this
            //Reduccion 94New
            //Reduccion 94intConstant
            //Reduccion 94doubleConstant
            //Reduccion 94boolConstant
            //Reduccion 94stringConstant
            //Reduccion 94null
            return false;
        }
        private bool estado144(Token lH)
        {
            //Reduccion 87 ;
            //Reduccion 87 ident
            //Reduccion 87 (
            //Reduccion 87 )
            //Reduccion 87 ,
            //Reduccion 87 {
            //Reduccion 87 }
            //Reduccion 87 if
            //Reduccion 87 else
            //Reduccion 87 while
            //Reduccion 87 for
            //Reduccion 87 return 
            //Reduccion 87 break
            //Reduccion 87 Console
            //Reduccion 87 ==
            //Reduccion 87 &&
            //Reduccion 87 <
            //Reduccion 87 <=
            //Reduccion 87 +
            //Reduccion 87 *
            //Reduccion 87 %
            //Reduccion 87 -
            //Reduccion 87 !
            //Reduccion 87 this
            //Reduccion 87 New
            //Reduccion 87 intConstant
            //Reduccion 87 doubleConstant
            //Reduccion 87 boolConstant
            //Reduccion 87 stringConstant
            //Reduccion 87 null
            switch (lH.contenido)
            {
                case ".":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(145);
                    lH = cadenas.Peek();
                    return estado145(lH);
                default:
                    return false;
            }
        }
        private bool estado145(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(161);
                    lH = cadenas.Peek();
                    return estado161(lH);
                default:
                    return false;
            }
        }
        private bool estado146(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(162);
                    lH = cadenas.Peek();
                    return estado162(lH);
                default:
                    return false;
            }
        }
        private bool estado147(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(163);
                    lH = cadenas.Peek();
                    return estado163(lH);
                default:
                    return false;
            }
        }
        private bool estado148(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(164);
                    lH = cadenas.Peek();
                    return estado164(lH);
                default:
                    return false;
            }
        }
        private bool estado149(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(165);
                    lH = cadenas.Peek();
                    return estado165(lH);
                default:
                    return false;
            }
        }
        private bool estado150(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(166);
                    lH = cadenas.Peek();
                    return estado166(lH);
                default:
                    return false;
            }
        }
        private bool estado151(Token lH)
        {
            //REDUCCION A 67 CON ;
            //REDUCCION A 67 CON IDENT 
            //REDUCCION A 67 CON (
            //REDUCCION A 67 CON {
            //REDUCCION A 67 CON }
            //REDUCCION A 67 CON if
            //REDUCCION A 67 CON else
            //REDUCCION A 67 CON while
            //REDUCCION A 67 CON for
            //REDUCCION A 67 CON return
            //REDUCCION A 67 CON break
            //REDUCCION A 67 CON Console
            //REDUCCION A 67 CON -
            //REDUCCION A 67 CON !
            //REDUCCION A 67 CON this
            //REDUCCION A 67 CON new
            //REDUCCION A 67 CON intConstant
            //REDUCCION A 67 CON doubleConstant
            //REDUCCION A 67 CON boolconstant
            //REDUCCION A 67 CON stringconstant
            //REDUCCION A 67 CON null
            return true;
        }
        private bool estado152(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(167);
                    lH = cadenas.Peek();
                    return estado167(lH);
                default:
                    return false;
            }
        }
        private bool estado153(Token lH)
        {
            //REDUCCION A 72 CON ;
            //REDUCCION A 72 CON IDENT
            //REDUCCION A 72 CON (
            //REDUCCION A 72 CON )
            //REDUCCION A 72 CON ,
            //REDUCCION A 72 CON {
            //REDUCCION A 72 CON }
            //REDUCCION A 72 CON if
            //REDUCCION A 72 CON else
            //REDUCCION A 72 CON for
            //REDUCCION A 72 CON return
            //REDUCCION A 72 CON break
            //REDUCCION A 72 CON console

            //REDUCCION A 72 CON -
            //REDUCCION A 72 CON !
            //REDUCCION A 72 CON new
            //REDUCCION A 72 CON intconstant
            //REDUCCION A 72 CON doubleconstant
            //REDUCCION A 72 CON booLConstant
            //REDUCCION A 72 CON stringConstant
            //REDUCCION A 72 CON null

            switch (lH.contenido)
            {
                case "==":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(135);
                    lH = cadenas.Peek();
                    return estado135(lH);
                default:
                    return false;
            }

        }
        private bool estado154(Token lH)
        {
            //Reduccion 74 ;
            //Reduccion 74 ident
            //Reduccion 74 (
            //Reduccion 74 )
            //Reduccion 74 ,
            //Reduccion 74 {
            //Reduccion 74 }
            //Reduccion 74 if
            //Reduccion 74 else
            //Reduccion 74 while
            //Reduccion 74 for
            //Reduccion 74 return 
            //Reduccion 74 break
            //Reduccion 74 Console
            //REDUCCION 74 ==

            //Reduccion 74 -
            //Reduccion 74 !
            //Reduccion 74 this
            //Reduccion 74 New
            //Reduccion 74 intConstant
            //Reduccion 74 doubleConstant
            //Reduccion 74 boolConstant
            //Reduccion 74 stringConstant
            //Reduccion 74 null
            switch (lH.contenido)
            {
                case "&&":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(136);
                    lH = cadenas.Peek();
                    return estado136(lH);
                default:
                    return false;
            }
        }
        private bool estado155(Token lH)
        {
            //Reduccion 76 ;
            //Reduccion 76 ident

            //Reduccion 76 ;
            //Reduccion 76 ident
            //Reduccion 76 (
            //Reduccion 76 )
            //Reduccion 76 ,
            //Reduccion 76 {
            //Reduccion 76 }
            //Reduccion 76 if
            //Reduccion 76 else
            //Reduccion 76 while
            //Reduccion 76 for
            //Reduccion 76 return 
            //Reduccion 76 break
            //Reduccion 76 Console

            //Reduccion 76 ==
            //Reduccion 76 &&

            //Reduccion 76 -
            //Reduccion 76 !
            //Reduccion 76 this
            //Reduccion 76 New
            //Reduccion 76 intConstant
            //Reduccion 76 doubleConstant
            //Reduccion 76 boolConstant
            //Reduccion 76 stringConstant
            //Reduccion 76 null

            switch (lH.contenido)
            {
                case "<":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(137);
                    lH = cadenas.Peek();
                    return estado137(lH);
                case "<=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(138);
                    lH = cadenas.Peek();
                    return estado138(lH);
                default:
                    return false;
            }
        }
        private bool estado156(Token lH)
        {
            //Reduccion 78 ;
            //Reduccion 78 ident
            //Reduccion 78 (
            //Reduccion 78 )
            //Reduccion 78 ,
            //Reduccion 78 {
            //Reduccion 78 }
            //Reduccion 78 if
            //Reduccion 78 else
            //Reduccion 78 while
            //Reduccion 78 for
            //Reduccion 78 return 
            //Reduccion 78 break
            //Reduccion 78 Console
            //Reduccion 78 ==
            //Reduccion 78 &&
            //Reduccion 78 <
            //Reduccion 78 <=

            //Reduccion 78 -
            //Reduccion 78 !
            //Reduccion 78 this
            //Reduccion 78 New
            //Reduccion 78 intConstant
            //Reduccion 78 doubleConstant
            //Reduccion 78 boolConstant
            //Reduccion 78 stringConstant
            //Reduccion 78 null

            switch (lH.contenido)
            {
                case "+":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(139);
                    lH = cadenas.Peek();
                    return estado139(lH);
                default:
                    return false;
            }
        }
        private bool estado157(Token lH)
        {
            //Reduccion 79 ;
            //Reduccion 79 ident
            //Reduccion 79 (
            //Reduccion 79 )
            //Reduccion 79 ,
            //Reduccion 79 {
            //Reduccion 79 }
            //Reduccion 79 if
            //Reduccion 79 else
            //Reduccion 79 while
            //Reduccion 79 for
            //Reduccion 79 return 
            //Reduccion 79 break
            //Reduccion 79 Console
            //Reduccion 79 ==
            //Reduccion 79 &&
            //Reduccion 79 <
            //Reduccion 79 <=

            //Reduccion 79 -
            //Reduccion 79 !
            //Reduccion 79 this
            //Reduccion 79 New
            //Reduccion 79 intConstant
            //Reduccion 79 doubleConstant
            //Reduccion 79 boolConstant
            //Reduccion 79 stringConstant
            //Reduccion 79 null

            switch (lH.contenido)
            {
                case "+":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(139);
                    lH = cadenas.Peek();
                    return estado139(lH);
                default:
                    return false;
            }
        }
        private bool estado158(Token lH)
        {
            //Reduccion 81 ;
            //Reduccion 81 ident
            //Reduccion 81 (
            //Reduccion 81 )
            //Reduccion 81 ,
            //Reduccion 81 {
            //Reduccion 81 }
            //Reduccion 81 if
            //Reduccion 81 else
            //Reduccion 81 while
            //Reduccion 81 for
            //Reduccion 81 return 
            //Reduccion 81 break
            //Reduccion 81 Console
            //Reduccion 81 ==
            //Reduccion 81 &&
            //Reduccion 81 <
            //Reduccion 81 <=
            //Reduccion 81 +

            //Reduccion 81 !
            //Reduccion 81 this
            //Reduccion 81 New
            //Reduccion 81 intConstant
            //Reduccion 81 doubleConstant
            //Reduccion 81 boolConstant
            //Reduccion 81 stringConstant
            //Reduccion 81 null

            switch (lH.contenido)
            {
                case "*":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(140);
                    lH = cadenas.Peek();
                    return estado140(lH);
                case "%":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(141);
                    lH = cadenas.Peek();
                    return estado141(lH);
                default:
                    return false;
            }

        }
        private bool estado159(Token lH)
        {

            //Reduccion 83 ;
            //Reduccion 83 ident
            //Reduccion 83 (
            //Reduccion 83 )
            //Reduccion 83 ,
            //Reduccion 83 {
            //Reduccion 83 }
            //Reduccion 83 if
            //Reduccion 83 else
            //Reduccion 83 while
            //Reduccion 83 for
            //Reduccion 83 return 
            //Reduccion 83 break
            //Reduccion 83 Console
            //Reduccion 83 ==
            //Reduccion 83 &&
            //Reduccion 83 <
            //Reduccion 83 <=
            //Reduccion 83 +
            //Reduccion 83 *
            //Reduccion 83 %
            //Reduccion 83 -
            //Reduccion 83 !
            //Reduccion 83 this
            //Reduccion 83 New
            //Reduccion 83 intConstant
            //Reduccion 83 doubleConstant
            //Reduccion 83 boolConstant
            //Reduccion 83 stringConstant
            //Reduccion 83 null
            return true;
        }
        private bool estado160(Token lH)
        {
            //Reduccion 84 ;
            //Reduccion 84 ident
            //Reduccion 84 (
            //Reduccion 84 )
            //Reduccion 84 ,
            //Reduccion 84 {
            //Reduccion 84 }
            //Reduccion 84 if
            //Reduccion 84 else
            //Reduccion 84 while
            //Reduccion 84 for
            //Reduccion 84 return 
            //Reduccion 84 break
            //Reduccion 84 Console
            //Reduccion 84 ==
            //Reduccion 84 &&
            //Reduccion 84 <
            //Reduccion 84 <=
            //Reduccion 84 +
            //Reduccion 84 *
            //Reduccion 84 %
            //Reduccion 84 -
            //Reduccion 84 !
            //Reduccion 84 this
            //Reduccion 84 New
            //Reduccion 84 intConstant
            //Reduccion 84 doubleConstant
            //Reduccion 84 boolConstant
            //Reduccion 84 stringConstant
            //Reduccion 84 null
            return true;
        }
        private bool estado161(Token lH)
        {
            //Reduccion 90 ;
            //Reduccion 90 ident
            //Reduccion 90 (
            //Reduccion 90 )
            //Reduccion 90 ,
            //Reduccion 90 {
            //Reduccion 90 }
            //Reduccion 90 if
            //Reduccion 90 else
            //Reduccion 90 while
            //Reduccion 90 for
            //Reduccion 90 return 
            //Reduccion 90 break
            //Reduccion 90 Console
            //reducción .

            //Reduccion 90 ==
            //Reduccion 90 &&
            //Reduccion 90 <
            //Reduccion 90 <=
            //Reduccion 90 +
            //Reduccion 90 *
            //Reduccion 90 %
            //Reduccion 90 -
            //Reduccion 90 !
            //Reduccion 90 this
            //Reduccion 90 New
            //Reduccion 90 intConstant
            //Reduccion 90 doubleConstant
            //Reduccion 90 boolConstant
            //Reduccion 90 stringConstant
            //Reduccion 90 null

            switch (lH.contenido)
            {
                case "=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(168);
                    lH = cadenas.Peek();
                    return estado168(lH);
                default:
                    return false;
            }
        }
        private bool estado162(Token lH)
        {
            //Reduccion 92 ;
            //Reduccion 92 ident
            //Reduccion 92 (
            //Reduccion 92 )
            //Reduccion 92 ,
            //Reduccion 92 {
            //Reduccion 92 }
            //Reduccion 92 if
            //Reduccion 92 else
            //Reduccion 92 while
            //Reduccion 92 for
            //Reduccion 92 return 
            //Reduccion 92 break
            //Reduccion 92 Console
            //reduccion 92 .

            //Reduccion 92 ==
            //Reduccion 92 &&
            //Reduccion 92 <
            //Reduccion 92 <=
            //Reduccion 92 +
            //Reduccion 92 *
            //Reduccion 92 %
            //Reduccion 92 -
            //Reduccion 92 !
            //Reduccion 92 this
            //Reduccion 92 New
            //Reduccion 92 intConstant
            //Reduccion 92 doubleConstant
            //Reduccion 92 boolConstant
            //Reduccion 92 stringConstant
            //Reduccion 92 null
            return true;
        }
        private bool estado163(Token lH)
        {

            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(169);
                    lH = cadenas.Peek();
                    return estado169(lH);
                default:
                    return false;
            }
        }
        private bool estado164(Token lH)
        {

            //reduccion 61 con ;

            //IR A 95 CON Stmtblock
            //IR A 170 CON Stmt
            //IR A 90 CON Stmt_P
            //IR A 88 CON IfStmt
            //IR A 89 CON WhileStmt
            //IR A 91 CON forStmt 
            //IR A 93 CON returnStmt 
            //IR A 92 CON BreakStmt 
            //IR A 94 CON PrintStmt 
            //IR A 98 CON Expr 
            //IR A 104 CON ExprOr 
            //IR A 105 CON ExprOrP 
            //IR A 106 CON ExprAnd 
            //IR A 107 CON ExprAndP 
            //IR A 108 CON ExprEquals
            //IR A 109 CON ExprEqualsP
            //IR A 112 CON ExprComp
            //IR A 113 CON ExprCompP


            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado165(Token lH)
        {
            //reduccion 61 con ;

            //IR A 95 CON Stmtblock
            //IR A 171 CON Stmt
            //IR A 90 CON Stmt_P
            //IR A 88 CON IfStmt
            //IR A 89 CON WhileStmt
            //IR A 91 CON forStmt 
            //IR A 93 CON returnStmt 
            //IR A 92 CON BreakStmt 
            //IR A 94 CON PrintStmt 
            //IR A 98 CON Expr 
            //IR A 104 CON ExprOr 
            //IR A 105 CON ExprOrP 
            //IR A 106 CON ExprAnd 
            //IR A 107 CON ExprAndP 
            //IR A 108 CON ExprEquals
            //IR A 109 CON ExprEqualsP
            //IR A 112 CON ExprComp
            //IR A 113 CON ExprCompP


            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado166(Token lH)
        {
            //IR A EXPR CON 172
            //IR A EXPROR CON 104
            //IR A 105 CON EXPRORP
            //IR A EXPRAND CON 106
            //IR  A EXPRANDP CON 107
            //IR A EXPREQUALS CON 108
            //IR A EXPREQUALSP CON 109
            //IR A EXPRCOMP CON 112
            //IR A EXPRCOMP_P CON 113


            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);

                default:
                    return false;
            }
        }
        private bool estado167(Token lH)
        {
            //IR A EXPR CON 173
            //IR A EXPROR CON 104
            //IR A 105 CON EXPRORP
            //IR A EXPRAND CON 106
            //IR  A EXPRANDP CON 107
            //IR A EXPREQUALS CON 108
            //IR A EXPREQUALSP CON 109
            //IR A EXPRCOMP CON 112
            //IR A EXPRCOMP_P CON 113


            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);

                default:
                    return false;
            }
        }
        private bool estado168(Token lH)
        {
            //IR A 174 CON EXPRCOMP_P

            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
            }

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);
                default:
                    return false;
            }
        }
        private bool estado169(Token lH)
        {
            //Reduccion 95 ;
            //Reduccion 95 ident
            //Reduccion 95 (
            //Reduccion 95 )
            //Reduccion 95 ,
            //Reduccion 95 {
            //Reduccion 95 }
            //Reduccion 95 if
            //Reduccion 95 else
            //Reduccion 95 while
            //Reduccion 95 for
            //Reduccion 95 return 
            //Reduccion 95 break
            //Reduccion 95 Console
            //REduccion 95 .

            //Reduccion 95 ==
            //Reduccion 95 &&
            //Reduccion 95 <
            //Reduccion 95 <=
            //Reduccion 95 +
            //Reduccion 95 *
            //Reduccion 95 %
            //Reduccion 95 -
            //Reduccion 95 !
            //Reduccion 95 this
            //Reduccion 95 New
            //Reduccion 95 intConstant
            //Reduccion 95 doubleConstant
            //Reduccion 95 boolConstant
            //Reduccion 95 stringConstant
            //Reduccion 95 null
            return true;
        }
        private bool estado170(Token lH)
        {
            //Reduccion 64 ;
            //Reduccion 64 ident
            //Reduccion 64 (
            //Reduccion 64 ,
            //Reduccion 64 {
            //Reduccion 64 }
            //Reduccion 64 if

            //COLISION (DESPLAZAMIENTO A 176 / REDUCCION A 64 ) CON ELSE

            //Reduccion 64 while
            //Reduccion 64 for
            //Reduccion 64 return 
            //Reduccion 64 break
            //Reduccion 64 Console

            //Reduccion 64 -
            //Reduccion 64 !
            //Reduccion 64 this
            //Reduccion 64 New
            //Reduccion 64 intConstant
            //Reduccion 64 doubleConstant
            //Reduccion 64 boolConstant
            //Reduccion 64 stringConstant
            //Reduccion 64 null
            return true;
        }
        private bool estado171(Token lH)
        {
            //Reduccion 65 ;
            //Reduccion 65 ident
            //Reduccion 65 (

            //Reduccion 65 else
            //Reduccion 65 while
            //Reduccion 65 for
            //Reduccion 65 return 
            //Reduccion 65 break
            //Reduccion 65 Console

            //Reduccion 65 -
            //Reduccion 65 !
            //Reduccion 65 this
            //Reduccion 65 New
            //Reduccion 65 intConstant
            //Reduccion 65 doubleConstant
            //Reduccion 65 boolConstant
            //Reduccion 65 stringConstant
            //Reduccion 65 null

            return true;
        }
        private bool estado172(Token lH)
        {

            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(177);
                    lH = cadenas.Peek();
                    return estado177(lH);
                default:
                    return false;
            }
        }
        private bool estado173(Token lH)
        {
            //Reducción 71 con )

            //IR A 178 CON PRINT STMT


            switch (lH.contenido)
            {
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(179);
                    lH = cadenas.Peek();
                    return estado179(lH);
                default:
                    return false;
            }
        }
        private bool estado174(Token lH)
        {
            //Reduccion 89 ;
            //Reduccion 89 ident
            //Reduccion 89 (
            //Reduccion 89 )
            //Reduccion 89 ,
            //Reduccion 89 {
            //Reduccion 89 }
            //Reduccion 89 if
            //Reduccion 89 else
            //Reduccion 89 while
            //Reduccion 89 for
            //Reduccion 89 return 
            //Reduccion 89 break
            //Reduccion 89 Console
            //REDUCCION 89 .

            //Reduccion 89 ==
            //Reduccion 89 &&
            //Reduccion 89 <
            //Reduccion 89 <=
            //Reduccion 89 +
            //Reduccion 89 *
            //Reduccion 89 %
            //Reduccion 89 -
            //Reduccion 89 !
            //Reduccion 89 this
            //Reduccion 89 New
            //Reduccion 89 intConstant
            //Reduccion 89 doubleConstant
            //Reduccion 89 boolConstant
            //Reduccion 89 stringConstant
            //Reduccion 89 null

            return true;
        }
        private bool estado175(Token lH)
        {

            //Reduccion 62 ;
            //Reduccion 62 ident
            //Reduccion 62 (

            //Reduccion 62 {
            //Reduccion 62 }
            //Reduccion 62 if
            //Reduccion 62 else
            //Reduccion 62 while
            //Reduccion 62 for
            //Reduccion 62 return 
            //Reduccion 62 break
            //Reduccion 62 Console

            //Reduccion 62 -
            //Reduccion 62 !
            //Reduccion 62 this
            //Reduccion 62 New
            //Reduccion 62 intConstant
            //Reduccion 62 doubleConstant
            //Reduccion 62 boolConstant
            //Reduccion 62 stringConstant
            //Reduccion 62 null

            return true;
        }
        private bool estado176(Token lH)
        {

            //Reducción 61 ;

            //IR A 95 StmtBlock
            //iR A 180 Stmt
            //iR A 90 Stmt_P
            //iR A 88 IFStmt
            //iR A 89 WhileStmt
            //iR A 91 forStmt
            //iR A 93 ReturnStmt
            //iR A 94 PrintStmt

            //iR A 98 Expr
            //iR A 104 ExprOr
            //iR A 105 ExprP
            //iR A 106 ExprPAnd
            //iR A 107 ExprPAndP
            //iR A 108 ExprEquals
            //iR A 109 ExprEqualsP

            //iR A 112 ExprCOmp
            //iR A 113 ExprCOmpP

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado177(Token lH)
        {
            //iR A 181 Expr
            //iR A 104 ExprOr
            //iR A 105 ExprP
            //iR A 106 ExprPAnd
            //iR A 107 ExprPAndP
            //iR A 108 ExprEquals
            //iR A 109 ExprEqualsP

            //iR A 112 ExprCOmp
            //iR A 113 ExprCOmpP

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
               
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado178(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(182);
                    lH = cadenas.Peek();
                    return estado182(lH);
                default:
                    return false;
            }
        }
        private bool estado179(Token lH)
        {
            //iR A 183 Expr
            //iR A 104 ExprOr
            //iR A 105 ExprP
            //iR A 106 ExprPAnd
            //iR A 107 ExprPAndP
            //iR A 108 ExprEquals
            //iR A 109 ExprEqualsP

            //iR A 112 ExprCOmp
            //iR A 113 ExprCOmpP

            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);

                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado180(Token lH)
        {
            //Reduccion 63 ;
            //Reduccion 63 ident
            //Reduccion 63 (
            //Reduccion 63 {
            //Reduccion 63 }
            //Reduccion 63 if
            //Reduccion 63 else
            //Reduccion 63 while
            //Reduccion 63 for
            //Reduccion 63 return 
            //Reduccion 63 break
            //Reduccion 63 Console
            //Reduccion 63 -
            //Reduccion 63 !
            //Reduccion 63 this
            //Reduccion 63 New
            //Reduccion 63 intConstant
            //Reduccion 63 doubleConstant
            //Reduccion 63 boolConstant
            //Reduccion 63 stringConstant
            //Reduccion 63 null
            return true;
        }
        private bool estado181(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(184);
                    lH = cadenas.Peek();
                    return estado184(lH);
                default:
                    return false;
            }
        }
        private bool estado182(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(185);
                    lH = cadenas.Peek();
                    return estado185(lH);
                default:
                    return false;
            }
        }
        private bool estado183(Token lH)
        {
            //Reduccion 71 )
            //Ir a 186 PrintStmt_P
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(179);
                    lH = cadenas.Peek();
                    return estado179(lH);
                default:
                    return false;
            }
        }
        private bool estado184(Token lH)
        {
            //Reduccion 61 ;
            //Ir a 95 StmtBlock
            //Ir a 187 Stmt
            //Ir a 90 Stmt_P
            //iR A 88 IFStmt
            //iR A 89 WhileStmt
            //iR A 91 forStmt
            //iR A 93 ReturnStmt
            //Ir a 92 BreakStmt
            //iR A 94 PrintStmt

            //iR A 98 Expr
            //iR A 104 ExprOr
            //iR A 105 ExprP
            //iR A 106 ExprPAnd
            //iR A 107 ExprPAndP
            //iR A 108 ExprEquals
            //iR A 109 ExprEqualsP

            //iR A 112 ExprCOmp
            //iR A 113 ExprCOmpP
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(103);
                    lH = cadenas.Peek();
                    return estado103(lH);
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(117);
                    lH = cadenas.Peek();
                    return estado117(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(118);
                    lH = cadenas.Peek();
                    return estado118(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(119);
                    lH = cadenas.Peek();
                    return estado119(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(120);
                    lH = cadenas.Peek();
                    return estado120(lH);

            }
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(114);
                    lH = cadenas.Peek();
                    return estado114(lH);
                case "{":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                case "if":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(96);
                    lH = cadenas.Peek();
                    return estado96(lH);
                case "while":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(97);
                    lH = cadenas.Peek();
                    return estado97(lH);
                case "for":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(99);
                    lH = cadenas.Peek();
                    return estado99(lH);
                case "return":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(101);
                    lH = cadenas.Peek();
                    return estado101(lH);
                case "break":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(100);
                    lH = cadenas.Peek();
                    return estado100(lH);
                case "Console":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(102);
                    lH = cadenas.Peek();
                    return estado102(lH);
                case "-":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(110);
                    lH = cadenas.Peek();
                    return estado110(lH);
                case "!":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(111);
                    lH = cadenas.Peek();
                    return estado111(lH);
                case "this":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(115);
                    lH = cadenas.Peek();
                    return estado115(lH);
                case "New":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(116);
                    lH = cadenas.Peek();
                    return estado116(lH);
                case "null":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(121);
                    lH = cadenas.Peek();
                    return estado121(lH);
                default:
                    return false;
            }
        }
        private bool estado185(Token lH)
        {
            //Reduccion 69 ;
            //Reduccion 69 ident
            //Reduccion 69 (
            //Reduccion 69 {
            //Reduccion 69 }
            //Reduccion 69 if
            //Reduccion 69 else
            //Reduccion 69 while
            //Reduccion 69 for
            //Reduccion 69 return 
            //Reduccion 69 break
            //Reduccion 69 Console
            //Reduccion 69 -
            //Reduccion 69 !
            //Reduccion 69 this
            //Reduccion 69 New
            //Reduccion 69 intConstant
            //Reduccion 69 doubleConstant
            //Reduccion 69 boolConstant
            //Reduccion 69 stringConstant
            //Reduccion 69 null
            return true;
        }
        private bool estado186(Token lH)
        {
            //Reduccion 70 )
            return true;
        }
        private bool estado187(Token lH)
        {
            //Reduccion 66 ;
            //Reduccion 66 ident
            //Reduccion 66 (
            //Reduccion 66 {
            //Reduccion 66 }
            //Reduccion 66 if
            //Reduccion 66 else
            //Reduccion 66 while
            //Reduccion 66 for
            //Reduccion 66 return 
            //Reduccion 66 break
            //Reduccion 66 Console
            //Reduccion 66 -
            //Reduccion 66 !
            //Reduccion 66 this
            //Reduccion 66 New
            //Reduccion 66 intConstant
            //Reduccion 66 doubleConstant
            //Reduccion 66 boolConstant
            //Reduccion 66 stringConstant
            //Reduccion 66 null
            return true;
        }
    }
}
