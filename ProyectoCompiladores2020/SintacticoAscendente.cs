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
                //Falta r2 con $
                default:
                    return false;
            }
        }
        private bool estado3(Token lH)
        { 
            //Recucion a 3 con ident, const, int, double, bool, string, void, class, interface $
            return true;
        }
        private bool estado4(Token lH)
        {
            //Recucion a 4 con ident, const, int, double, bool, string, void, class, interface $
            return true;
        }
        private bool estado5(Token lH)
        {
            //Recucion a 5 con ident, const, int, double, bool, string, void, class, interface $
            return true;
        }
        private bool estado6(Token lH)
        {
            //Recucion a 6 con ident, const, int, double, bool, string, void, class, interface $
            return true;
        }
        private bool estado7(Token lH)
        {
            //Recucion a 7 con ident, const, int, double, bool, string, void, class, interface $
            return true;
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
            return true;
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
            //retroceso con ident R22 
            //IR A TYPE_R CON 31
            switch (lH.contenido)
            {
                case "[]":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(32);
                    lH = cadenas.Peek();
                    return estado11(lH);
                default:
                    return false;
            }
        }
        private bool estado15(Token lH)
        {
            //RETROCESO A IDENT R16
            //RETROESO CON [] R16
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
            return true;
        }
        private bool estado52(Token lH)
        {
            return true;
        }
        private bool estado53(Token lH)
        {
            return true;
        }
        private bool estado54(Token lH)
        {
            return true;
        }
        private bool estado55(Token lH)
        {
            return true;
        }
        private bool estado56(Token lH)
        {
            return true;
        }
        private bool estado57(Token lH)
        {
            return true;
        }
        private bool estado58(Token lH)
        {
            return true;
        }
        private bool estado59(Token lH)
        {
            return true;
        }
        private bool estado60(Token lH)
        {
            return true;
        }
        private bool estado61(Token lH)
        {
            return true;
        }
        private bool estado62(Token lH)
        {
            return true;
        }
        private bool estado63(Token lH)
        {
            return true;
        }
        private bool estado64(Token lH)
        {
            return true;
        }
        private bool estado65(Token lH)
        {
            return true;
        }
        private bool estado66(Token lH)
        {
            return true;
        }
        private bool estado67(Token lH)
        {
            return true;
        }
        private bool estado68(Token lH)
        {
            return true;
        }
        private bool estado69(Token lH)
        {
            return true;
        }
        private bool estado70(Token lH)
        {
            return true;
        }
        private bool estado71(Token lH)
        {
            return true;
        }
        private bool estado72(Token lH)
        {
            return true;
        }
        private bool estado73(Token lH)
        {
            return true;
        }
        private bool estado74(Token lH)
        {
            return true;
        }
        private bool estado75(Token lH)
        {
            return true;
        }
        private bool estado76(Token lH)
        {
            return true;
        }
        private bool estado77(Token lH)
        {
            return true;
        }
        private bool estado78(Token lH)
        {
            return true;
        }
        private bool estado79(Token lH)
        {
            return true;
        }
        private bool estado80(Token lH)
        {
            return true;
        }
        private bool estado81(Token lH)
        {
            return true;
        }
        private bool estado82(Token lH)
        {
            return true;
        }
        private bool estado83(Token lH)
        {
            return true;
        }
        private bool estado84(Token lH)
        {
            return true;
        }
        private bool estado85(Token lH)
        {
            return true;
        }
        private bool estado86(Token lH)
        {
            return true;
        }
        private bool estado87(Token lH)
        {
            return true;
        }
        private bool estado88(Token lH)
        {
            return true;
        }
        private bool estado89(Token lH)
        {
            return true;
        }
        private bool estado90(Token lH)
        {
            return true;
        }
        private bool estado91(Token lH)
        {
            return true;
        }
        private bool estado92(Token lH)
        {
            return true;
        }
        private bool estado93(Token lH)
        {
            return true;
        }
        private bool estado94(Token lH)
        {
            return true;
        }
        private bool estado95(Token lH)
        {
            return true;
        }
        private bool estado96(Token lH)
        {
            return true;
        }
        private bool estado97(Token lH)
        {
            return true;
        }
        private bool estado98(Token lH)
        {
            return true;
        }
        private bool estado99(Token lH)
        {
            return true;
        }
        private bool estado100(Token lH)
        {
            return true;
        }
        private bool estado101(Token lH)
        {
            return true;
        }
        private bool estado102(Token lH)
        {
            return true;
        }
        private bool estado103(Token lH)
        {
            return true;
        }
        private bool estado104(Token lH)
        {
            return true;
        }
        private bool estado105(Token lH)
        {
            return true;
        }
        private bool estado106(Token lH)
        {
            return true;
        }
        private bool estado107(Token lH)
        {
            return true;
        }
        private bool estado108(Token lH)
        {
            return true;
        }
        private bool estado109(Token lH)
        {
            return true;
        }
        private bool estado110(Token lH)
        {
            return true;
        }
        private bool estado111(Token lH)
        {
            return true;
        }
        private bool estado112(Token lH)
        {
            return true;
        }
        private bool estado113(Token lH)
        {
            return true;
        }
        private bool estado114(Token lH)
        {
            return true;
        }
        private bool estado115(Token lH)
        {
            return true;
        }
        private bool estado116(Token lH)
        {
            return true;
        }
        private bool estado117(Token lH)
        {
            return true;
        }
        private bool estado118(Token lH)
        {
            return true;
        }
        private bool estado119(Token lH)
        {
            return true;
        }
        private bool estado120(Token lH)
        {
            return true;
        }
        private bool estado121(Token lH)
        {
            return true;
        }
        private bool estado122(Token lH)
        {
            return true;
        }
        private bool estado123(Token lH)
        {
            return true;
        }
        private bool estado124(Token lH)
        {
            return true;
        }
        private bool estado125(Token lH)
        {
            return true;
        }
        private bool estado126(Token lH)
        {
            return true;
        }
        private bool estado127(Token lH)
        {
            return true;
        }
        private bool estado128(Token lH)
        {
            return true;
        }
        private bool estado129(Token lH)
        {
            return true;
        }
        private bool estado130(Token lH)
        {
            return true;
        }
        private bool estado131(Token lH)
        {
            return true;
        }
        private bool estado132(Token lH)
        {
            return true;
        }
        private bool estado133(Token lH)
        {
            return true;
        }
        private bool estado134(Token lH)
        {
            return true;
        }
        private bool estado135(Token lH)
        {
            return true;
        }
        private bool estado136(Token lH)
        {
            return true;
        }
        private bool estado137(Token lH)
        {
            return true;
        }
        private bool estado138(Token lH)
        {
            return true;
        }
        private bool estado139(Token lH)
        {
            return true;
        }
        private bool estado140(Token lH)
        {
            return true;
        }
        private bool estado141(Token lH)
        {
            return true;
        }
        private bool estado142(Token lH)
        {
            return true;
        }
        private bool estado143(Token lH)
        {
            return true;
        }
        private bool estado144(Token lH)
        {
            return true;
        }
        private bool estado145(Token lH)
        {
            return true;
        }
        private bool estado146(Token lH)
        {
            return true;
        }
        private bool estado147(Token lH)
        {
            return true;
        }
        private bool estado148(Token lH)
        {
            return true;
        }
        private bool estado149(Token lH)
        {
            return true;
        }
        private bool estado150(Token lH)
        {
            return true;
        }
        private bool estado151(Token lH)
        {
            return true;
        }
        private bool estado152(Token lH)
        {
            return true;
        }
        private bool estado153(Token lH)
        {
            return true;
        }
        private bool estado154(Token lH)
        {
            return true;
        }
        private bool estado155(Token lH)
        {
            return true;
        }
        private bool estado156(Token lH)
        {
            return true;
        }
        private bool estado157(Token lH)
        {
            return true;
        }
        private bool estado158(Token lH)
        {
            return true;
        }
        private bool estado159(Token lH)
        {
            return true;
        }
        private bool estado160(Token lH)
        {
            return true;
        }
        private bool estado161(Token lH)
        {
            return true;
        }
        private bool estado162(Token lH)
        {
            return true;
        }
        private bool estado163(Token lH)
        {
            return true;
        }
        private bool estado164(Token lH)
        {
            return true;
        }
        private bool estado165(Token lH)
        {
            return true;
        }
        private bool estado166(Token lH)
        {
            return true;
        }
        private bool estado167(Token lH)
        {
            return true;
        }
        private bool estado168(Token lH)
        {
            return true;
        }
        private bool estado169(Token lH)
        {
            return true;
        }
        private bool estado170(Token lH)
        {
            return true;
        }
        private bool estado171(Token lH)
        {
            return true;
        }
        private bool estado172(Token lH)
        {
            return true;
        }
        private bool estado173(Token lH)
        {
            return true;
        }
        private bool estado174(Token lH)
        {
            return true;
        }
        private bool estado175(Token lH)
        {
            return true;
        }
        private bool estado176(Token lH)
        {
            return true;
        }
        private bool estado177(Token lH)
        {
            return true;
        }
        private bool estado178(Token lH)
        {
            return true;
        }
        private bool estado179(Token lH)
        {
            return true;
        }
        private bool estado180(Token lH)
        {
            return true;
        }
        private bool estado181(Token lH)
        {
            return true;
        }
        private bool estado182(Token lH)
        {
            return true;
        }
        private bool estado183(Token lH)
        {
            return true;
        }
        private bool estado184(Token lH)
        {
            return true;
        }
        private bool estado185(Token lH)
        {
            return true;
        }
        private bool estado186(Token lH)
        {
            return true;
        }
        private bool estado187(Token lH)
        {
            return true;
        }
    }
}
