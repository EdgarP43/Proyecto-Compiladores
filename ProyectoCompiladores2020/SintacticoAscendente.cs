using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace ProyectoCompiladores2020
{
    class SintacticoAscendente
    {
        public Queue<Token> cadenas = new Queue<Token>();
        private Stack<string> pilaSimbolos = new Stack<string>();
        private Stack<int> pilaAcciones = new Stack<int>();
        public List<string> errores = new List<string>();
        int contador56 = 0;
        int contador2 = 0;
        int contador47 = 0;
        int contador87 = 0;
        int contador77 = 0;
        int contador82 = 0;
        bool error87 = true;

        public void iniciar()
        {
            pilaAcciones.Clear();
            pilaSimbolos.Clear();
            errores.Clear();
            pilaAcciones.Push(0);
            var inicio = cadenas.Peek();
            if(!IrA(pilaAcciones.Peek(), inicio))
            {
                errores.Add("Archivo incorrecto");
            }
        }
        private Token rellenarCadenas(Token temp)
        {
            var colaTemp = new Queue<Token>();
            colaTemp.Enqueue(temp);
            int contador = cadenas.Count;
            for (int i = 0; i < contador; i++)
            {
                colaTemp.Enqueue(cadenas.Dequeue());
            }
            cadenas = colaTemp;
            return cadenas.Peek();
        }
        private bool error (Token lH)
        {
           
            
            if (cadenas.Count > 0)
            {
                if (lH.tipo == "ident" || lH.contenido == "const" || lH.contenido == "int" || lH.contenido == "double" || lH.contenido == "string" || lH.contenido == "void" || lH.contenido == "class" || lH.contenido == "interface" )
                {
                    pilaAcciones.Clear();
                    pilaSimbolos.Clear();
                    pilaAcciones.Push(0);
                    return IrA(pilaAcciones.Peek(), lH);
                }
                else
                {
                    errores.Add("Error en la linea " + lH.linea + ", Columnas de la " + lH.columnaInicio + "-" + lH.columnaFin + " con la cadena " + lH.contenido);
                    cadenas.Dequeue();
                    error87 = false;
                    if (cadenas.Count > 0)
                        lH = cadenas.Peek();
                    return IrA(pilaAcciones.Peek(), lH);
                }
            }
            else
                return false;
        }
        private bool IrA(int inicio, Token lH)
        {
            switch (inicio)
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
                    return estado108(lH);;

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
                case 188:
                    return estado188(lH);
                case 189:
                    return estado189(lH);
                case 190:
                    return estado190(lH);
                case 191:
                    return estado191(lH);
                case 192:
                    return estado192(lH);
                case 193:
                    return estado193(lH);
                case 194:
                    return estado194(lH);
                case 195:
                    return estado195(lH);
                case 196:
                    return estado196(lH);
                default:
                    return false;
            }
        }
        private bool estado0(Token lH)
        {
            contador2 = 0;
            contador56 = 0;
            contador47 = 0;
            contador87 = 0;
            contador77 = 0;
            contador82 = 0;
            if (pilaSimbolos.Count > 0)
            { 
            switch(pilaSimbolos.Peek())
            {
                case "Program":
                    pilaAcciones.Push(1);
                    return estado1(lH);
                case "Decl":
                    pilaAcciones.Push(2);
                    return estado2(lH);
                case "VariableDecl":
                    pilaAcciones.Push(3);
                    return estado3(lH);
                case "Variable":
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "ConstDecl":
                    pilaAcciones.Push(5);
                    return estado5(lH);
                case "Type":
                    pilaAcciones.Push(9);
                    return estado9(lH);
                case "Type_P":
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "FunctionDecl":
                    pilaAcciones.Push(4);
                    return estado4(lH);
                case "ClassDecl":
                    pilaAcciones.Push(6);
                    return estado6(lH);
                case "InterfaceDecl":
                    pilaAcciones.Push(7);
                    return estado7(lH);
            }
            }
            switch (lH.tipo)
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
                case "class":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(12);
                    lH = cadenas.Peek();
                    return estado12(lH);
                case "interface":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(13);
                    lH = cadenas.Peek();
                    return estado13(lH);
                
                default:
                    return error(lH);
            }
        }
        private bool estado1(Token lH)
        {
            //Aceptacion
            return true;
        }
        private bool estado2(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Program"://IR A 20 Program
                    pilaAcciones.Push(20);
                    return estado20(lH);
                case "Decl"://IR A 2 Decl 
                    if(contador2 == 1)
                    {
                        pilaAcciones.Push(2);
                         contador2 = 0;
                    }
                    contador2++;
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
                        case "class":
                            pilaSimbolos.Push(cadenas.Dequeue().contenido);
                            pilaAcciones.Push(12);
                            lH = cadenas.Peek();
                            return estado12(lH);
                        case "interface":
                            pilaSimbolos.Push(cadenas.Dequeue().contenido);
                            pilaAcciones.Push(13);
                            lH = cadenas.Peek();
                            return estado13(lH);
                        default:
                            pilaAcciones.Pop();
                            pilaSimbolos.Pop();
                            pilaSimbolos.Push("Program");
                            return IrA(pilaAcciones.Peek(), lH);
                    }
                case "VariableDecl"://IR A 3 VariableDecl
                    pilaAcciones.Push(3);
                    return estado3(lH);
                case "Variable"://IR A 8 Variable
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "ConstDecl"://IR A 5 ConstDecl
                    pilaAcciones.Push(5);//uy
                    return estado5(lH);
                case "Type":////IR A 9  Type
                    pilaAcciones.Push(9);
                    return estado9(lH);
                case "Type_P": /////IR A 14 Type_P
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "FunctionDecl": /////IR A 4 FunctionDecl
                    pilaAcciones.Push(4);
                    return estado4(lH);
                case "ClassDecl":///IR A 6 ClassDecl
                    pilaAcciones.Push(6);
                    return estado6(lH);
                case "InterfaceDecl":///IR A 7 InterfaceDecl
                    pilaAcciones.Push(7);
                    return estado7(lH);
            }
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
                case "class":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(12);
                    lH = cadenas.Peek();
                    return estado12(lH);
                case "interface":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(13);
                    lH = cadenas.Peek();
                    return estado13(lH);
                default:
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
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
                    if(cadenas.Count > 0)
                        lH = cadenas.Peek();
                    return estado21(lH);
                default:
                    return error(lH); ;
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
                    return estado22(lH);
                default:
                    return error(lH);
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
                    return estado23(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado11(Token lH)
        {
            if (pilaSimbolos.Count > 0)
            {
                switch (pilaSimbolos.Peek())
                {
                    case "ConstType": //IR A 24 ConstType
                        pilaAcciones.Push(24); 
                        return estado24(lH); 
                }
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(25);
                    lH = cadenas.Peek();
                    return estado25(lH);
                case "double":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(26);
                    lH = cadenas.Peek();
                    return estado26(lH);
                case "bool":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(27);
                    lH = cadenas.Peek();
                    return estado27(lH);
                case "string":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(28);
                    lH = cadenas.Peek();
                    return estado28(lH);
                default:
                    return error(lH);
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
                    return estado29(lH);
                default:
                    return error(lH);
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
                    return estado30(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado14(Token lH)
        {
            if (pilaSimbolos.Count > 0)
            {
                switch (pilaSimbolos.Peek())
                {
                    case "Type_R":
                        pilaAcciones.Push(31);
                        return estado31(lH);
                }
            }
            switch (lH.contenido)
            {
                case "[]":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(32);
                    lH = cadenas.Peek();
                    return estado32(lH);
                
            }
            switch (lH.tipo)
            {
                case "ident"://red 22
                    pilaSimbolos.Push("Type_R");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado15(Token lH)
        {
            switch (lH.contenido)
            {
                case "[]": //reduccion a 16
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident": //reduccion a 16
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado16(Token lH)
        {
            switch (lH.contenido)
            {
                case "[]"://REDUCCION CON [] R17
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident"://REDUCCION CON IDENt R17
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado17(Token lH)
        {
            switch (lH.contenido)
            {
                case "[]"://REDUCCION CON [] R18
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident"://REDUCCION IDENT R18
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado18(Token lH)
        {
            switch (lH.contenido)
            {
                case "[]": //REDUCCION CON [] R19
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident"://REDUCCION CON IDENT R19
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado19(Token lH)
        {
            switch (lH.contenido)
            {
                case "[]"://REDUCCION CON [] R20
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident"://REDUCCION CON IDENT R20
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado20(Token lH)
        {
            //Reduccion 1 con $
            pilaAcciones.Pop();
            pilaAcciones.Pop();
            pilaSimbolos.Pop();
            pilaSimbolos.Pop();
            pilaSimbolos.Push("Program");
            return IrA(pilaAcciones.Peek(), lH);
        }
        private bool estado21(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const": //r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r8
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default://r8 nada
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("VariableDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado22(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //r9
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //d33
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(33);
                    lH = cadenas.Peek();
                    return estado33(lH);
                case ")": //r9
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //r9
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado23(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //d34 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(34);
                    lH = cadenas.Peek();
                    return estado34(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado24(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //d35
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(35);
                    lH = cadenas.Peek();
                    return estado35(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado25(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":  //Reduccion a 11 con ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstType");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado26(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":  //reduccion a 12 con ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstType");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado27(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://reduccion a 13 con ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstType");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado28(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://reduccion a 14 con ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstType");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado29(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ClassDecl_P": //Ir a 36 con ClassDecl_P
                    pilaAcciones.Push(36);
                    return IrA(36, lH);
            }
            switch (lH.contenido)
            {
                case ":": //d37
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(37);
                    lH = cadenas.Peek();
                    return estado37(lH);
                case "{": //r30
                    pilaSimbolos.Push("ClassDecl_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado30(Token lH)
        {
            
            switch (lH.contenido)
            {
                case "{"://d38
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(38);
                    lH = cadenas.Peek();
                    return estado38(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado31(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":  //Reduccion 15 con ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado32(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //Reduccion 21 con ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Type_R");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado33(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Variable": //Ir a 40 con variable
                    pilaAcciones.Push(40);
                    return estado40(lH);
                case "Type": //Ir a 41 con type
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P": //Ir a 14 con type_p
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "Formals": //Ir a 39 con Formlas
                    pilaAcciones.Push(39);
                    return estado39(lH);
            }
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
                    return error(lH);
            }
        }
        private bool estado34(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Variable": //Ir a 40 con variable
                    pilaAcciones.Push(40);
                    return estado40(lH);
                case "Type": //Ir a 41 con type
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P": //Ir a 14 con type_p
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "Formals": //Ir a 42 con Formlas
                    pilaAcciones.Push(42);
                    return estado42(lH);
            }
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
                    return error(lH);
            }
        }
        private bool estado35(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //d43
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(43);
                    if(cadenas.Count > 0)
                        lH = cadenas.Peek();
                    return estado43(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado36(Token lH)
        {
            switch (lH.contenido)
            {
                case "{": //d44
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(44);
                    lH = cadenas.Peek();
                    return estado44(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado37(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //d45
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(45);
                    lH = cadenas.Peek();
                    return estado45(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado38(Token lH)
        {
           
            switch (pilaSimbolos.Peek())
            {
                case "Type": //Ir a 48 con type
                    pilaAcciones.Push(48);
                    return estado48(lH);
                case "Type_P": //Ir a 14 con type_p
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "InterfaceDecl_P": //Ir a 46 con interfacedel_p
                    pilaAcciones.Push(46);
                    return estado46(lH);
                case "Prototype": //Ir a 47 con prototype
                    pilaAcciones.Push(47);
                    return estado47(lH);
            }
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
                case "}": //r42
                    pilaSimbolos.Push("InterfaceDecl_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    pilaAcciones.Push(49);
                    lH = cadenas.Peek();
                    return estado49(lH);
                default:
                    return error(lH);

            }
        }
        private bool estado39(Token lH)
        {
            switch (lH.contenido)
            {
                case ")": //d50
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(50);
                    lH = cadenas.Peek();
                    return estado50(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado40(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Formals_P": //Ir a 51 con formals_p
                    pilaAcciones.Push(51);
                    return estado51(lH);
            }
            switch (lH.contenido)
            {
                case ")"://Reduccion a 27 con )
                    pilaSimbolos.Push("Formals_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //d52
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(52);
                    lH = cadenas.Peek();
                    return estado52(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado41(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //d53
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(53);
                    lH = cadenas.Peek();
                    return estado53(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado42(Token lH)
        {
            switch (lH.contenido)
            {
                case ")": //d54
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(54);
                    lH = cadenas.Peek();
                    return estado54(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado43(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //r10 ---
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ConstDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado44(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "VariableDecl": //Ir a 57 con variabledecl
                    pilaAcciones.Push(57);
                    return estado57(lH);
                case "Variable": //Ir a 8 con variable
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "ConstDecl": //Ir a 59 con ConstDecl
                    pilaAcciones.Push(59);
                    return estado59(lH);
                case "Type": //Ir a 9 con type
                    pilaAcciones.Push(9);
                    return estado9(lH);
                case "Type_P": //Ir a 14 con type_p
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "FunctionDecl": //Ir a 58 con functiondecl
                    pilaAcciones.Push(58);
                    return estado58(lH);
                case "ClassDecl_Q": //Ir a 55 con classdecl
                    pilaAcciones.Push(55);
                    return estado55(lH);
                case "Field": //Ir a 55 con field
                    pilaAcciones.Push(56);
                    return estado56(lH);
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
                case "}"://Reduccion a 36 }
                    pilaSimbolos.Push("ClassDecl_Q");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default: 
                    return error(lH);
            }
        }
        private bool estado45(Token lH)
        {
            switch (pilaSimbolos.Peek())//ir a
            {
                case "ClassDecl_R": //Ir a 60 con classdecl_r
                    pilaAcciones.Push(60);
                    return estado60(lH);
                case "ClassDecl_O": //Ir a 61 con classdecl_o
                    pilaAcciones.Push(61);
                    return estado61(lH);
            }
            switch (lH.contenido)
            {
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(62);
                    lH = cadenas.Peek();
                    return estado62(lH);
                case "{"://Reduccion a 32 con {
                    pilaSimbolos.Push("ClassDecl_R");
                    return IrA(pilaAcciones.Peek(), lH);

                default:
                    return error(lH);
            }
        }
        private bool estado46(Token lH)
        {
            switch (lH.contenido)
            {
                case "}"://d63
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(63);
                    if(cadenas.Count>0)
                        lH = cadenas.Peek();
                    return estado63(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado47(Token lH)
        {
            switch (pilaSimbolos.Peek())//ir a
            {
                case "Type": //Ir a 48 con type
                    pilaAcciones.Push(48);
                    return estado48(lH);
                case "Type_P": //Ir a 14 con type_p
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "InterfaceDecl_P": //Ir a 64 con interfacedecl-p
                    pilaAcciones.Push(64);
                    return estado64(lH);
                case "Prototype": //Ir a 47 con protype
                    if(contador47 == 1)
                    {
                        contador47=0;
                        pilaAcciones.Push(47);
                    }
                    contador47++;
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
                            pilaAcciones.Push(49);
                            lH = cadenas.Peek();
                            return estado49(lH);

                        case "}": //r42
                            pilaSimbolos.Push("InterfaceDecl_P");
                            return IrA(pilaAcciones.Peek(), lH);
                    }
                    switch (lH.tipo)
                    {
                        case "ident": //d19
                            pilaSimbolos.Push(cadenas.Dequeue().contenido);
                            pilaAcciones.Push(19);
                            lH = cadenas.Peek();
                            return estado19(lH);
                        default:
                            return error(lH);

                    }
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
                case "void":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(49);
                    lH = cadenas.Peek();
                    return estado49(lH);

                case "}": //r42
                    pilaSimbolos.Push("InterfaceDecl_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return error(lH);

            }
            
        }
        private bool estado48(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //d65
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(65);
                    lH = cadenas.Peek();
                    return estado65(lH);
                default:
                    return error(lH);

            }
        }
        private bool estado49(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //df66
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(66);
                    lH = cadenas.Peek();
                    return estado66(lH);
                default:
                    return error(lH);

            }

        }
        private bool estado50(Token lH)
        {
            if(pilaSimbolos.Peek() == "StmtBlock")
            {
                pilaAcciones.Push(67);
                return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "{": //d68
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado51(Token lH)
        {
            
            switch (lH.contenido)
            {
                case ")"://Reduccion a 25 con )
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop(); 
                    pilaAcciones.Pop();
                    pilaSimbolos.Push("Formals");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado52(Token lH)
        {
            switch (pilaSimbolos.Peek())//ir a
            {
                case "Variable":  //Ir a 40 con Variable
                    pilaAcciones.Push(40);
                    return estado40(lH);
                case "Type":  //Ir a 41 con Type
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P": //Ir a 14 con Type_P
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "Formals":  //Ir a 69 con Formals
                    pilaAcciones.Push(69);
                    return estado69(lH);
            }
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
                    return error(lH);
            }
        }
        private bool estado53(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //r9
                    pilaSimbolos.Pop(); //2 y 2
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //r9
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //r9
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Push("Variable");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado54(Token lH)
        {
            switch (pilaSimbolos.Peek())//ir a
            {
                case "StmtBlock":  //Ir a 70 con StmtBlock
                    pilaAcciones.Push(70);
                    return estado70(lH);
            }
            switch (lH.contenido)
            {
                case "{": //d68
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(68);
                    lH = cadenas.Peek();
                    return estado68(lH);
                default:
                    return error(lH);
            }
                    
        }
        private bool estado55(Token lH)
        {
            switch (lH.contenido)
            {
                case "}": //d71
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(71);
                    if(cadenas.Count > 0)
                    lH = cadenas.Peek();
                    return estado71(lH);
                default:
                    return error(lH);

            }
        }
        private bool estado56(Token lH)
        {
            switch (pilaSimbolos.Peek())//ir a
            {
                case "VariableDecl": //Ir a 57 VariableDecl
                    pilaAcciones.Push(57);
                    return estado57(lH);
                case "Variable":  //Ir a 8 Variable
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "ConstDecl":  //Ir a 59 ConstDecl
                    pilaAcciones.Push(59);
                    return estado59(lH);
                case "Type":  //Ir a 9 Type
                    pilaAcciones.Push(9);
                    return estado9(lH);
                case "Type_P":  //Ir a 14 Type
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "FunctionDecl": //Ir a 58 FunctionDecl
                    pilaAcciones.Push(58);
                    return estado58(lH);
                case "ClassDecl_Q": //Ir a 72 ClassDecl_Q
                    pilaAcciones.Push(72);
                    return estado72(lH);
                case "Field":   //Ir a 56 Field
                    if (contador56 == 1)
                    {
                        pilaAcciones.Push(56);
                        contador56 = 0;
                    }
                    contador56++;
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
                        case "}": //Reduccion a 36 }
                            pilaSimbolos.Push("ClassDecl_Q");
                            return IrA(pilaAcciones.Peek(), lH);
                        default:
                            return error(lH);

                    }
            }
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
                case "}": //Reduccion a 36 }
                    pilaSimbolos.Push("ClassDecl_Q");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);

            }
        }
        private bool estado57(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r37
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }

        }
        private bool estado58(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r38
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado59(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://r39
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const"://r39
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r39
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r39
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r39
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Field");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado60(Token lH)
        {
            switch (lH.contenido)
            {
                case "{"://Reduccion a 29 {
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ClassDecl_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado61(Token lH)
        {
            switch (lH.contenido)
            {
                case "{"://Reduccion a 31 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ClassDecl_R");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado62(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //d73
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(73);
                    lH = cadenas.Peek();
                    return estado73(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado63(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    
                    pilaSimbolos.Push("interfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface"://r40
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("InterfaceDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado64(Token lH)
        { 
            switch (lH.contenido)//Reduccion a 41 }
            {
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("InterfaceDecl_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);

            }
        }
        private bool estado65(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //d74
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(74);
                    lH = cadenas.Peek();
                    return estado74(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado66(Token lH)
        {
            switch (lH.contenido)
            {
                case "("://d75
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(75);
                    lH = cadenas.Peek();
                    return estado75(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado67(Token lH)
        {
            switch (lH.tipo)//Reduccion a 23 ident
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const": //Reduccion a 23 Const
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 23 interface
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion a 23 int
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 23 double
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 23 bool
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion a 23 string
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 23 void
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion a 23 }
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":  //Reduccion a 23 class
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default: //Reduccion a 23 $
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }        
        private bool estado68(Token lH)
        {
            contador87 = 0;
            var temp = new Token();
            switch (pilaSimbolos.Peek())//ir a
            {
                case "VariableDecl": //Ir a 77 VariableDecl
                    pilaAcciones.Push(77);
                    return estado77(lH);
                case "Variable":  //Ir a 8 Variable
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "Type":   //Ir a 41 Type
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P":  //Ir a 14 Type_P
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "StmtBlock_P":   //Ir a 76 StmtBlock_P
                    pilaAcciones.Push(76);
                    return estado76(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    //Colision con Reduccion 47 ident
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(19);  //d19
                        temp = lH;
                        return estado19(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");   //r47
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                //REDUCCIONES
                case "int": //Reduccion a 47 intconstant
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 47 doubleconstant
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 47 boolcontatnt
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 47 string
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //REDUCCIONES
                case ";"://Reduccion a 47 ;
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const"://Reduccion a 47 const
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 47 (
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 47 void
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 47 class
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 47 {
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 47 }
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 47 interface
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 47 if
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 47 else
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 47 while
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 47 for
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 47 retun
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 47 break
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 47 console
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 47 -
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 47 !
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 47 this
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 47 nEW
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 47 null
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    //Colision con Reduccion 47
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(15); //15
                        temp = lH;
                        return estado15(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "double":
                    //Colision con Reduccion 47
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(16); //d16
                        temp = lH;
                        return estado16(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "bool":
                    //Colision con Reduccion 47 
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(17);
                        temp = lH;
                        return estado17(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "string":
                    //Colision con Reduccion 47 
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(18);
                        temp = lH;
                        return estado18(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                default:
                //Reduccion a 47 $
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado69(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":   //reducción a 26 con )
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Formals_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado70(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":            //REDUCCION A 24 CON IDENT
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const": //Reduccion a 24 Const
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion a 24 int
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 24 double
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 24 bool
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion a 24 string
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 24 void
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion a 24 }
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class":  //Reduccion a 24 class
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":  //Reduccion a 24 interface
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("FunctionDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado71(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":            //REDUCCION A 28 CON IDENT
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {

                case "const": //Reduccion a 28 Const
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 28 int
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 28 double
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 28 bool
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 28 string
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 28 void
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 28 class
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 28 interface
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
                default: //REDUCCION A 28 CON $
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado72(Token lH)
        { 
            switch (lH.contenido)
            {
                case "}"://REDUCCION A 35 CON }
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl_Q");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado73(Token lH)
        {
            if(pilaSimbolos.Peek() == "ClassDecl_O")
            {
                pilaAcciones.Push(78);
                return estado78(lH); //d78
            }
            switch (lH.contenido)
            {
                case ","://d62
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(62); 
                    lH = cadenas.Peek();
                    return estado62(lH);
                case "{"://REDUCCION A 33 CON {
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl_O");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado74(Token lH)
        {
            switch(pilaSimbolos.Peek())
            {
                case "Variable":
                    pilaAcciones.Push(40);
                    return estado40(lH);
                case "Type":
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P":
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "Formals":
                    pilaAcciones.Push(79);
                    return estado79(lH);
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
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(19);
                    lH = cadenas.Peek();
                    return estado19(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado75(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Variable":
                    pilaAcciones.Push(40);
                    return estado40(lH);
                case "Type":
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P":
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "Formals":
                    pilaAcciones.Push(80);
                    return estado80(lH);
            }
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
                    return error(lH);
            }
        }
        private bool estado76(Token lH)
        {
            //COLISION CON (DESPLAZAMIENTO A 11 / REDUCCIÓN A 49 ) CON CONST
            var temp = new Token();
            switch(pilaSimbolos.Peek())
            {
                case "ConstDecl":
                    pilaAcciones.Push(82);
                    return estado82(lH);
                case "StmtBlock_R":
                    pilaAcciones.Push(81);
                    return estado81(lH);
            }
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 49 CON IDENT
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                //REDUCCIONES
                case "int": //Reduccion a 49 intconstant
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 49 doubleconstant
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 49 boolcontatnt
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 49 string
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //REDUCCIONES
                case "const":
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "int" || lH.contenido == "double" || lH.contenido == "bool" || lH.contenido == "string")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(11);//d11
                        temp = lH;
                        return estado11(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp); //r49
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "int"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case ";"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 49 void
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 48 class
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 49 {
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 49 }
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 49 interface
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 49 if
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 49 else
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 49 while
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 49 for
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 49 retun
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 49 break
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 49 console
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 49 -
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 4R !
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 49 this
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 49 nEW
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 49 null
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                
                default: //REDUCCION A 49 CON $
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado77(Token lH)
        {
            var temp = new Token();
            switch(pilaSimbolos.Peek())
            {
                case "Variable"://IR A 8 CON Variable
                    pilaAcciones.Push(8);
                    return estado8(lH);
                case "Type"://IR A 41 CON Type
                    pilaAcciones.Push(41);
                    return estado41(lH);
                case "Type_P"://IR A 14 CON Type_P
                    pilaAcciones.Push(14);
                    return estado14(lH);
                case "StmtBlock_P":
                    pilaAcciones.Push(83);
                    return estado83(lH);
                case "VariableDecl"://IR A 83 CON StmtBlock_P
                    if (contador77 == 1)
                    {
                        pilaAcciones.Push(77);
                        contador77 = 0;
                    }
                    contador77++;
                    switch (lH.tipo)
                    {
                        case "ident":
                            //Colision con Reduccion 47 ident
                            temp = lH;
                            cadenas.Dequeue();
                            lH = cadenas.Peek();
                            if (lH.contenido == "[]" || lH.tipo == "ident")
                            {
                                pilaSimbolos.Push(temp.contenido);
                                pilaAcciones.Push(19);
                                temp = lH;
                                return estado19(temp);
                            }
                            else
                            {
                                lH = rellenarCadenas(temp); //r47
                                pilaSimbolos.Push("StmtBlock_P");
                                return IrA(pilaAcciones.Peek(), lH);
                            }
                        //REDUCCIONES
                        case "int": //Reduccion a 47 intconstant
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "double": //Reduccion a 47 doubleconstant
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "bool": //Reduccion a 47 boolcontatnt
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "string": //Reduccion a 47 string
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                    }
                    switch (lH.contenido)
                    {
                        //REDUCCIONES
                        case ";"://Reduccion a 47 ;
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "const"://Reduccion a 47 const
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "(": //Reduccion a 47 (
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "void": //Reduccion a 47 void
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "class": //Reduccion a 47 class
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "{": //Reduccion a 47 {
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "}": //Reduccion a 47 }
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "interface": //Reduccion a 47 interface
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "if": //Reduccion a 47 if
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "else": //Reduccion a 47 else
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "while": //Reduccion a 47 while
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "for": //Reduccion a 47 for
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "return": //Reduccion a 47 retun
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "break": //Reduccion a 47 break
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "Console": //Reduccion a 47 console
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "-": //Reduccion a 47 -
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "!": //Reduccion a 47 !
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "this": //Reduccion a 47 this
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "New": //Reduccion a 47 nEW
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "null": //Reduccion a 47 null
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                        case "int":
                            //Colision con Reduccion 47
                            temp = lH;
                            cadenas.Dequeue();
                            lH = cadenas.Peek();
                            if (lH.contenido == "[]" || lH.tipo == "ident")
                            {
                                pilaSimbolos.Push(temp.contenido);
                                pilaAcciones.Push(15);
                                temp = lH;
                                return estado15(temp);
                            }
                            else
                            {
                                lH = rellenarCadenas(temp);
                                pilaSimbolos.Push("StmtBlock_P");
                                return IrA(pilaAcciones.Peek(), lH);
                            }
                        case "double":
                            //Colision con Reduccion 47
                            temp = lH;
                            cadenas.Dequeue();
                            lH = cadenas.Peek();
                            if (lH.contenido == "[]" || lH.tipo == "ident")
                            {
                                pilaSimbolos.Push(temp.contenido);
                                pilaAcciones.Push(16);
                                temp = lH;
                                return estado16(temp);
                            }
                            else
                            {
                                lH = rellenarCadenas(temp);
                                pilaSimbolos.Push("StmtBlock_P");
                                return IrA(pilaAcciones.Peek(), lH);
                            }
                        case "bool":
                            //Colision con Reduccion 47 
                            temp = lH;
                            cadenas.Dequeue();
                            lH = cadenas.Peek();
                            if (lH.contenido == "[]" || lH.tipo == "ident")
                            {
                                pilaSimbolos.Push(temp.contenido);
                                pilaAcciones.Push(17);
                                temp = lH;
                                return estado17(temp);
                            }
                            else
                            {
                                lH = rellenarCadenas(temp);
                                pilaSimbolos.Push("StmtBlock_P");
                                return IrA(pilaAcciones.Peek(), lH);
                            }
                        case "string":
                            //Colision con Reduccion 47 
                            temp = lH;
                            cadenas.Dequeue();
                            lH = cadenas.Peek();
                            if (lH.contenido == "[]" || lH.tipo == "ident")
                            {
                                pilaSimbolos.Push(temp.contenido);
                                pilaAcciones.Push(18);
                                temp = lH;
                                return estado18(temp);
                            }
                            else
                            {
                                lH = rellenarCadenas(temp);
                                pilaSimbolos.Push("StmtBlock_P");
                                return IrA(pilaAcciones.Peek(), lH);
                            }
                        default:
                            //Reduccion a 47 $
                            pilaSimbolos.Push("StmtBlock_P");
                            return IrA(pilaAcciones.Peek(), lH);
                    }

            }
            switch (lH.tipo)
            {
                case "ident":
                    //Colision con Reduccion 47 ident
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(19);
                        temp = lH;
                        return estado19(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp); //r47
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                //REDUCCIONES
                case "int": //Reduccion a 47 intconstant
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 47 doubleconstant
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 47 boolcontatnt
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 47 string
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //REDUCCIONES
                case ";"://Reduccion a 47 ;
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const"://Reduccion a 47 const
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 47 (
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 47 void
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 47 class
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 47 {
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 47 }
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 47 interface
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 47 if
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 47 else
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 47 while
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 47 for
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 47 retun
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 47 break
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 47 console
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 47 -
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 47 !
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 47 this
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 47 nEW
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 47 null
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    //Colision con Reduccion 47
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(15);
                        temp = lH;
                        return estado15(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "double":
                    //Colision con Reduccion 47
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(16);
                        temp = lH;
                        return estado16(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "bool":
                    //Colision con Reduccion 47 
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(17);
                        temp = lH;
                        return estado17(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "string":
                    //Colision con Reduccion 47 
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "[]" || lH.tipo == "ident")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(18);
                        temp = lH;
                        return estado18(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                default:
                    //Reduccion a 47 $
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado78(Token lH)
        {
            switch (lH.contenido)
            {
                case "{"://REDUCCIÓN A 34 CON {
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ClassDecl_O");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado79(Token lH)
        {
            switch (lH.contenido)
            {
                case ")": //d84
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(84);
                    lH = cadenas.Peek();
                    return estado84(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado80(Token lH)
        {
            switch (lH.contenido)
            {
                case ")": //d85
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(85);
                    lH = cadenas.Peek();
                    return estado85(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado81(Token lH)
        {
            contador87 = 0;
            error87 = true;
            switch(pilaSimbolos.Peek())
            {
                case "StmtBlock" :
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "StmtBlock_O":
                    pilaAcciones.Push(86);
                    return estado86(lH);
                case "Stmt":
                    pilaAcciones.Push(87);
                    return estado87(lH);
                case "Stmt_P":
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "IfStmt":
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt":
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt":
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt":
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
            }
            switch (lH.contenido)
            {
                case ";": //r61
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                case "}": //r51
                    pilaSimbolos.Push("StmtBlock_O");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado82(Token lH)
        {
            var temp = new Token();
            
            
            if(pilaSimbolos.Peek() == "ConstDecl")//IR A 82 CON ConstDecl
            {
                if (contador82 == 1)
                {
                    pilaAcciones.Push(82);
                    contador82 = 0;
                }
                contador82++;
                switch (lH.tipo)
                {
                    case "ident": //REUCCION A 49 CON IDENT
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    //REDUCCIONES
                    case "int": //Reduccion a 49 intconstant
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "double": //Reduccion a 49 doubleconstant
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "bool": //Reduccion a 49 boolcontatnt
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "string": //Reduccion a 49 string
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                }
                switch (lH.contenido)
                {
                    case "const":
                        temp = lH;
                        cadenas.Dequeue();
                        lH = cadenas.Peek();
                        if (lH.contenido == "int" || lH.contenido == "double" || lH.contenido == "bool" || lH.contenido == "string")
                        {
                            pilaSimbolos.Push(temp.contenido);
                            pilaAcciones.Push(11);
                            temp = lH;
                            return estado11(temp);
                        }
                        else
                        {
                            lH = rellenarCadenas(temp);
                            pilaSimbolos.Push("StmtBlock_R"); //r49 
                            return IrA(pilaAcciones.Peek(), lH);
                        }
                    //REDUCCIONES
                    case "int": //Reduccion a 49 (
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "double": //Reduccion a 49 (
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "bool": //Reduccion a 49 (
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "string": //Reduccion a 49 (
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case ";"://Reduccion a 49 ;
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "(": //Reduccion a 49 (
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "void": //Reduccion a 49 void
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "class": //Reduccion a 48 class
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "{": //Reduccion a 49 {
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "}": //Reduccion a 49 }
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "interface": //Reduccion a 49 interface
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "if": //Reduccion a 49 if
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "else": //Reduccion a 49 else
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "while": //Reduccion a 49 while
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "for": //Reduccion a 49 for
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "return": //Reduccion a 49 retun
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "break": //Reduccion a 49 break
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "Console": //Reduccion a 49 console
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "-": //Reduccion a 49 -
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "!": //Reduccion a 4R !
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "this": //Reduccion a 49 this
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "New": //Reduccion a 49 nEW
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    case "null": //Reduccion a 49 null
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                    default: //REDUCCION A 49 CON $
                        pilaSimbolos.Push("StmtBlock_R");
                        return IrA(pilaAcciones.Peek(), lH);
                }
            }
            else if(pilaSimbolos.Peek() == "StmtBlock_R")//IR A 122 CON StmtBlock_R
            {
                pilaAcciones.Push(122);
                return estado122(lH);
            }
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 49 CON IDENT
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                //REDUCCIONES
                case "int": //Reduccion a 49 intconstant
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 49 doubleconstant
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 49 boolcontatnt
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 49 string
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "const":
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "int" || lH.contenido == "double" || lH.contenido == "bool" || lH.contenido == "string")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(11);
                        temp = lH;
                        return estado11(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("StmtBlock_R"); //r49 
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                //REDUCCIONES
                case "int": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case ";"://Reduccion a 49 ;
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 49 (
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 49 void
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 48 class
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 49 {
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 49 }
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 49 interface
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 49 if
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 49 else
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 49 while
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 49 for
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 49 retun
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 49 break
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 49 console
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 49 -
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 4R !
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 49 this
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 49 nEW
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 49 null
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                default: //REDUCCION A 49 CON $
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado83(Token lH)
        {
            
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 46 CON IDENT
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                //REDUCCIONES
                case "int": //Reduccion a 46 intconstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 46 doubleconstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 46 boolcontatnt
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 46 string
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                //REDUCCIONES
                case ";"://Reduccion a 46 ;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 46 (
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion a 46 void
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion a 46 class
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 46 {
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 46 }
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface": //Reduccion a 46 interface
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 46 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 46 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 46 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 46 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 46 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 46 break
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 46 console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 46 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 46 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 46 this
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 46 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 46 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);

                default: //REDUCCION A 46 CON $
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_P");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado84(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //d123
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(123);
                    lH = cadenas.Peek();
                    return estado123(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado85(Token lH)
        {
            switch (lH.contenido)
            {
                case ";"://d124
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(124);
                    lH = cadenas.Peek();
                    return estado124(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado86(Token lH)
        {
            switch (lH.contenido)
            {
                case "}": //d125
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(125);
                    if(cadenas.Count >0)
                        lH = cadenas.Peek();
                    return estado125(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado87(Token lH)
        {
            if(pilaSimbolos.Peek() == "Stmt")
            {
                if(contador87 == 1 && error87)
                {
                    pilaAcciones.Push(87);
                    contador87 = 0;
                }
                contador87++;
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
                    case ";":
                        pilaSimbolos.Push("Stmt_S");
                        return IrA(pilaAcciones.Peek(), lH);
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
                    case "}":
                        pilaSimbolos.Push("StmtBlock_O");
                        return IrA(pilaAcciones.Peek(), lH);
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
                        return error(lH);
                }

            }
            switch (pilaSimbolos.Peek())
            {
                case "StmtBlock":
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "StmtBlock_O":
                    pilaAcciones.Push(126);
                    return estado126(lH);
                case "Stmt_P":
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "IfStmt":
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt":
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt":
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt":
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);;
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push("Stmt_S");
                    return IrA(pilaAcciones.Peek(), lH);
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
                case "}":
                    pilaSimbolos.Push("StmtBlock_O");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado88(Token lH)
        {
            contador77 = 0;
            if(pilaSimbolos.Peek() == "Stmt")
            {
                contador87 = 1;
            }
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 52 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 52 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 52 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 52 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 52 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 52 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 52 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 52 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 52 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 52 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 52 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 52 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 52 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 52 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 52 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 52 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 52 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 52 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 52 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 52 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 52 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado89(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 53 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 53 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 53 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 53 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 53 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 53 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 53 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 53 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 53 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 53 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 53 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 53 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 53 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 53 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 53 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 53 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 53 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 53 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 53 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 53 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 53 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado90(Token lH)
        {
            switch (lH.contenido) //D127
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(127);
                    lH = cadenas.Peek();
                    return estado127(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado91(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 55 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 55 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 55 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 55 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 55 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 55 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 55 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 55 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 55 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 55 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 55 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 55 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 55 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 55 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 55 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 55 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 55 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 55 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 55 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 55 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 55 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado92(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 56 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 56 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 56 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 56 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 56 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 56 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 56 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 56 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 56 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 56 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 56 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 56 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 56 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 56 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 56 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 56 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 56 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 56 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 56 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 56 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 56 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado93(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 57 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 57 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 57 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 57 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 42 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 57 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 57 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 57 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 57 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 57 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 57 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 57 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 57 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 57 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 57 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 57 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 57 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 57 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 57 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 57 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 57 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado94(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 58 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //Reduccion a 58 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 58 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 58 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 58 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://Reduccion a 58 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 58 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 58 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 58 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 58 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 58 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 58 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 58 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 58 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 57 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 58 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 58 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 58 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 57 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 58 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 58 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado95(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident": //REUCCION A 57 CON IDENT
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                //REDUCCIONES
                case "int": //Reduccion a 57 intconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double": //Reduccion a 57 doubleconstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool": //Reduccion a 57 boolcontatnt
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string": //Reduccion a 42 string
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //REDUCCIONES
                case ";"://Reduccion a 57 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion a 57 (
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion a 57 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion a 57 }
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion a 57 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion a 57 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion a 57 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion a 57 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion a 57 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion a 57 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion a 57 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion a 57 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion a 57 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion a 57 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion a 57 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion a 57 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado96(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //d128
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(128);
                    lH = cadenas.Peek();
                    return estado128(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado97(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //d129
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(129);
                    lH = cadenas.Peek();
                    return estado129(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado98(Token lH)
        {
            switch(lH.contenido)
            {
                case ";": //r60
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado99(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //D130
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(130);
                    lH = cadenas.Peek();
                    return estado130(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado100(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //D131
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(131);
                    lH = cadenas.Peek();
                    return estado131(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado101(Token lH)
        {
            switch(pilaSimbolos.Peek())
            {
                case "Expr":
                    pilaAcciones.Push(132);
                    return estado132(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);;
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                default: return error(lH);
            }
        }
        private bool estado102(Token lH)
        {
            switch (lH.contenido)
            {
                case ".": //D133
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(133);
                    lH = cadenas.Peek();
                    return estado133(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado103(Token lH) 
        {
            var temp = new Token();
            switch (lH.tipo)
            {
                case "ident": //r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";": //r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")"://COLISION D135 Y R96
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "(" || lH.contenido == "-" || lH.contenido == "!" || lH.contenido == "this" || lH.contenido == "New" || lH.contenido == "null"|| lH.tipo == "ident" || lH.tipo == "int" || lH.tipo == "bool"|| lH.tipo == "string")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(135);
                        temp = lH;
                        return estado135(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaAcciones.Pop();
                        pilaSimbolos.Pop();
                        pilaSimbolos.Push("ExprCompP");
                        return IrA(pilaAcciones.Peek(), lH);
                    }

                case ","://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r94
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "."://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=": //desplamiento a 134
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(134);
                    lH = cadenas.Peek();
                    return estado134(lH);
                case "=="://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<"://r96
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+"://
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*"://r
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%"://r
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-"://r94
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado104(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ","://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r 74
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":// D136
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(136);
                    lH = cadenas.Peek();
                    return estado136(lH);
                case "-"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r 73
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado105(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop(); 
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //ES REDUCCION A 76
                case ";"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr"); 
                    return IrA(pilaAcciones.Peek(), lH);
                case ")"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ","://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=="://r 75
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://d137
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(137);
                    lH = cadenas.Peek();
                    return estado137(lH);
                case "-"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r 76
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado106(Token lH)
        {//TODAS SON REDUCION A 78
            switch (lH.tipo)
            {
                
                case "ident": //r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int": //r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ","://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=="://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<"://d138
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(138);
                    lH = cadenas.Peek();
                    return estado138(lH);
                case "<="://d 139
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(139);
                    lH = cadenas.Peek();
                    return estado139(lH);
                case "-"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r 77
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado107(Token lH)
        {//REDUCCION A 81
            switch (lH.tipo)
            {
                case "ident"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";": //r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "("://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ","://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=="://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<="://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+": //d140
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(140);
                    lH = cadenas.Peek();
                    return estado140(lH);
                case "-"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r 80
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado108(Token lH)
        {//REDUCCION A 81
            switch (lH.tipo)
            {
                case "ident": //r 81
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://r 81
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://r 81
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://r 81
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://r 81
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {  
                case "*": //d 141
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(141);
                    lH = cadenas.Peek();
                    return estado141(lH);
                case "%": //d 142
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(142);
                    lH = cadenas.Peek();
                    return estado142(lH);
                case ";": //Reduccion 82 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 82(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 82)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 82,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://Reduccion 82 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 82}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion 82if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion 82else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion 82 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion 82 FOR
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://Reduccion 82return 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion 82break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://REDUCCION 82 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=="://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<="://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://r 82
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado109(Token lH)
        {//TODAS SON REDUCCION A 86
            switch (lH.tipo)
            {
                case "ident": //Reduccion 85ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 85intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 85doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 85boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 85 stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";": //Reduccion 85 ;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 85(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 85)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 85,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://Reduccion 85 {
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 85}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion 85if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion 85else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion 85 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion 85 FOR
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return"://Reduccion 85return 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion 85break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console"://REDUCCION 85 console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=="://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<="://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://REDUCCION 85
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado110(Token lH)
        {
            switch(pilaSimbolos.Peek())
            {
                case "ExprComp": //ir a 142
                    pilaAcciones.Push(143);
                    return estado143(lH);
                case "ExprCompP": // ir a 113
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident": 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado111(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprComp":
                    pilaAcciones.Push(145);
                    return estado145(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident": 
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado112(Token lH)
        {//REDUCCION 89 EQUALSP 1-1
            switch (lH.tipo)
            {
                case "ident"://Reduccion 88ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 88intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 88doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 88boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 88stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 88;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 88(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 88)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 88,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 88{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 88}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 88 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 88 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 88while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 88 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 88 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 88 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 88 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //DESPLAZAMIENTO CON . A 146
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(146);
                    lH = cadenas.Peek();
                    return estado146(lH);
                case "==":  //Reduccion 88 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 88 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 88 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 88 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 88 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 88 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 88 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 88 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 88 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":  //Reduccion 88 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 88 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 88 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado113(Token lH)
        { //TODAS SON REDUCCION A 93 1-1
            switch (lH.tipo)
            {
                case "ident"://Reduccion 91ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 91intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 91doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 91boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 91stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
            }

            switch (lH.contenido)
            {
                case ";":  //Reduccion 91;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 91(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 91)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 91,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 91{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 91}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 91 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 91 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 91 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 91 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 91 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 91 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 91 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 91 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 91 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 91 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 91 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 91 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 91 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 91 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 91 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 91 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 91 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":  //Reduccion 91 this
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 91 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 91 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado114(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":
                    pilaAcciones.Push(147);
                    return estado147(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);;
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado115(Token lH)
        {//REDUCCION A 95 COMP_P 1-1
            switch (lH.tipo)
            {
                case "ident"://Reduccion 93ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 93intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 93doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 93boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 93stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }

            switch (lH.contenido)
            {
                case ";":  //Reduccion 93;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 93(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 93)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 93,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 93{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 93}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 93 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 93 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 93 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 93 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 93 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 93 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 93 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 93 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 93 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 93 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 93 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 93 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 93 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 93 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 93 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 93 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 93 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 93 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 93 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 93 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado116(Token lH)
        {
            switch (lH.contenido)
            {
                case "(": //d 148
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(148);
                    lH = cadenas.Peek();
                    return estado148(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado117(Token lH)
        {//REDUCCION A 98
            switch (lH.tipo)
            {
                case "ident"://Reduccion 96ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 96intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 96doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 96boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 96stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 96;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 96(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 96)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 96,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 96{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 96}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 96 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 96 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 96 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 96 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 96 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 96 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 96 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 96 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 96 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 96 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 96 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 96 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 96 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 96 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 96 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 96 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 96 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 96 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 96 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 96 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado118(Token lH)
        {//TODAS SON REDUCCION 99
            switch (lH.tipo)
            {
                case "ident"://Reduccion 97ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 97intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 97doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 97boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 97stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 97;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 97(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 97)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 97,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 97{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 97}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 97 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 97 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 97 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 97 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 97 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 97 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 97 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 97 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 97 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 97 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 97 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 97 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 97 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 97 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 97 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 97 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 97 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 97 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 97 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 97 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado119(Token lH)
        {//REDUCCION A 100 1-1
            switch (lH.tipo)
            {
                case "ident"://Reduccion 98ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 98intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 98doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 98boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 98stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 98;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 98(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 98)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 98,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 98{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 98}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 98 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 98 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 98 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 98 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 98 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 98 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 98 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 98 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 98 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 98 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 98 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 98 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 98 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 98 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 98 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 98 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 98 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 98 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 98 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 98 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado120(Token lH)
        {//REDUCCION A 101 COMP_P 1-1
            switch (lH.tipo)
            {
                case "ident"://Reduccion 99ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 99intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 99doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 99boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 99stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                //REDUCCIONES
                case ";":  //Reduccion 99;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 99(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 99)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 99,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 99{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 99}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 99 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 99 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 99 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 99 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 99 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 99 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 99 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 99 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 99 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 99 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 99 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 99 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 99 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 99 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 99 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 99 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 99 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 99 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 99 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 99 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado121(Token lH)
        {//REDUCCION A 102
            switch (lH.tipo)
            {
                case "ident"://Reduccion 100ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 100(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 100)
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 100,
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".": //Reduccion 100 . 
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 100 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 100 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 100 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 100 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 100 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 100 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 100 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default: 
                    return error(lH);
            }
        }
        private bool estado122(Token lH)
        {//todas son reduccion a 48
            switch (lH.tipo)
            {
                case "ident"://Reduccion 48 ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 48 intConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 48 doubleConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 48 boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 48 stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "const":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":  //Reduccion 48;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 48(
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion 48)
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion 48,
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 48{
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 48}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":  //Reduccion 48}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 48 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock_R");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado123(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":  //Reduccion 43 ;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado124(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":  //Reduccion 43 ;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "void":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Prototype");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado125(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://Reduccion 45 ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 45
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 45
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "const":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "int":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "double":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "string":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 100(
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "void": //Reduccion 100)
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "class": //Reduccion 100,
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "interface":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");

                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("StmtBlock");
                    return IrA(pilaAcciones.Peek(), lH);
            }
        }
        private bool estado126(Token lH)
        {
            if(lH.contenido == "}") //Reduccion 50 }
            {
                pilaAcciones.Pop();
                pilaAcciones.Pop();
                pilaSimbolos.Pop();
                pilaSimbolos.Pop();
                pilaSimbolos.Push("StmtBlock_O");
                return IrA(pilaAcciones.Peek(), lH);
            }
            else
            {
                return error(lH);
            }
        }
        private bool estado127(Token lH)
        {
            contador77 = 0;
            switch (lH.tipo)
            {
                case "ident"://Reduccion 100ident 54!!
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Stmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado128(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":
                    pilaAcciones.Push(149);
                    return estado149(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado129(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":
                    pilaAcciones.Push(150);
                    return estado150(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado130(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":
                    pilaAcciones.Push(151);
                    return estado151(lH);
                case "ExprOr":
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado131(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://Reduccion 100ident   //68!!!!!
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 100(
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 break
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("BreakStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado132(Token lH)
        {
            switch (lH.contenido)
            {
                case ";": //d 152
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(152);
                    lH = cadenas.Peek();
                    return estado152(lH);
                default:
                    return error(lH);
            }
                    
        }
        private bool estado133(Token lH)
        {
            switch (lH.contenido)
            {
                case "WriteLine":  //d 153
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(153);
                    lH = cadenas.Peek();
                    return estado153(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado134(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprOr"://Ir a 154 ExprOr
                    pilaAcciones.Push(154);
                    return estado154(lH);
                case "ExprOrP": //Ir a 105 ExprOrP
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //Ir a 106 ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP"://Ir a 107 ExpreAndP
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals": //Ir a 108 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado135(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr": //Ir a 156 ExprOr
                    pilaAcciones.Push(156);
                    return estado156(lH);
                case "ExprOr": //Ir a 156 ExprOr
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //Ir a 156 ExprOr
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //Ir a 106 ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP"://Ir a 107 ExpreAndP
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals": //Ir a 108 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
                case "Actuals": //Ir a 155 Actuals
                    pilaAcciones.Push(155);
                    return estado155(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado136(Token lH)
        {
            switch (pilaSimbolos.Peek())
            { 
                case "ExprOrP": //Ir a 157 ExprAnd
                    pilaAcciones.Push(157);
                    return estado157(lH);
                case "ExprAnd": //Ir a 106 ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP": //Ir a 107 ExpreAndP
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //Ir a 108 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado137(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprAnd": //Ir a 158 ExpreAnd
                    pilaAcciones.Push(158);
                    return estado158(lH);
                case "ExprAndP": //Ir a 107 ExpreAndP
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //Ir a 108 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado138(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprAndP": //Ir a 159 ExpreAndP
                    pilaAcciones.Push(159);
                    return estado159(lH);
                case "ExprEquals":  //Ir a 108 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado139(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprAndP":  //Ir a 160 ExprANDOP
                    pilaAcciones.Push(160);
                    return estado160(lH);
                case "ExprEquals"://Ir a 109 ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP"://Ir a 109 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado140(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprEquals": 
                    pilaAcciones.Push(161);
                    return estado161(lH);
                case "ExprEqualsP"://Ir a 159 ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
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
                    return error(lH);
            }
        }
        private bool estado141(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprEqualsP"://Ir a 162 ExprEqualsP
                    pilaAcciones.Push(162);
                    return estado162(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado142(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprEqualsP"://Ir a 162 ExprEqualsP
                    pilaAcciones.Push(163);
                    return estado163(lH);
                case "ExprComp": //Ir a 112  ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //Ir a 113 ExprComp
                    pilaAcciones.Push(113);
                    return estado113(lH);
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado143(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://Reduccion 100ident   86!!!!!
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 100;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 100 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 100 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 100 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 100 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 100 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 100 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 100 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(146);
                    lH = cadenas.Peek();
                    return estado146(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado144(Token lH)
        {//todA son reducciones a 96
            switch (lH.tipo)
            {
                case "ident"://Reduccion 100ident    
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 94;
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 100 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 100 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 100 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 100 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 100 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 100 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 100 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado145(Token lH)
        {//TODAS SON REDUCCIONA 88
            switch (lH.tipo)
            {//REDUCION A 88, SACANDO DOS Y METIENDO EQUALSp
                case "ident"://Reduccion 100ident
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 100intConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 100doubleConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 100boolConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 100stringConstant
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {//87
                case ";":  
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 100{
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 100}
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 100 if
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 100 else
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 100 while
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 100 for
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 100 return
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 100 brak
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 100 Console
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":  //Reduccion 100 ==
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 100 &&
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 100 <
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 100 <=
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 100 +
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 100 *
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 100 %
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 100 -
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 100 !
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 100 ExprCompP
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 100 New
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 100 null
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEqualsP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "."://DESPL
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(146);
                    lH = cadenas.Peek();
                    return estado146(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado146(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident": //D 164
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(164);
                    lH = cadenas.Peek();
                    return estado164(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado147(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(165);
                    lH = cadenas.Peek();
                    return estado165(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado148(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(166);
                    lH = cadenas.Peek();
                    return estado166(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado149(Token lH)
        {
            switch (lH.contenido)
            {
                case ")": //dd167
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(167);
                    lH = cadenas.Peek();
                    return estado167(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado150(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(168);
                    lH = cadenas.Peek();
                    return estado168(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado151(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(169);
                    lH = cadenas.Peek();
                    return estado169(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado152(Token lH)
        {
            switch (lH.tipo)
            {//REDUCCION A 67, SACO 3 Y METO RTN STMT
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ReturnStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado153(Token lH)
        {
            switch (lH.contenido)
            {
                case "(":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(170);
                    lH = cadenas.Peek();
                    return estado170(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado154(Token lH)
        {//REDUCCION A A72!!, saco 3 y expr
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH); 
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(136);
                    lH = cadenas.Peek();
                    return estado136(lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado155(Token lH)
        {
            if(lH.contenido == ")")
            {
                pilaSimbolos.Push(cadenas.Dequeue().contenido);
                pilaAcciones.Push(171);
                lH = cadenas.Peek();
                return estado171(lH);
            }
            else
            {
                return error(lH);
            }
        }
        private bool estado156(Token lH)
        {
            switch(lH.contenido)
            {
                case ")": //R104
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("Actuals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(172);
                    lH = cadenas.Peek();
                    return estado172(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado157(Token lH)
        {
            switch (lH.tipo)
            {//REDUCCION A 75, SACO 3 DEJOR EL EXPROR
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(137);
                    lH = cadenas.Peek();
                    return estado137(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado158(Token lH)
        {//reduccion a 77, 
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprOrP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(138);
                    lH = cadenas.Peek();
                    return estado138(lH);
                case "<=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(139);
                    lH = cadenas.Peek();
                    return estado139(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado159(Token lH)
        {//REDUCCION 79, 3 y meto and
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(140);
                    lH = cadenas.Peek();
                    return estado140(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado160(Token lH)
        {//reduccion a 79
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAnd");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(140);
                    lH = cadenas.Peek();
                    return estado140(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado161(Token lH)
        {//REDUCCION A 82, saco 3 andP
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprAndP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(141);
                    lH = cadenas.Peek();
                    return estado141(lH);
                case "%":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(142);
                    lH = cadenas.Peek();
                    return estado142(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado162(Token lH)
        {//reduccion a 84, sacando 3 y metiendo ExprEquals
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado163(Token lH)
        {//reduccion a 85, sacando 3 y equials
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprEquals");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado164(Token lH)
        {//REDUCCION A 92, sacando 3 METIENDO CPOMP
            var temp = new Token();
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    //COLISION (DESPLAZAMIENTO A 176 / REDUCCION A 64 ) CON ELSE
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == "(" || lH.contenido == "-" || lH.contenido == "!" || lH.contenido == "this" || lH.contenido == "New" || lH.contenido == "null"
                        || lH.tipo == "ident" || lH.tipo == "int" || lH.tipo == "double" || lH.tipo == "bool" || lH.tipo == "string")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(174);
                        temp = lH;
                        return estado176(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaAcciones.Pop();
                        pilaAcciones.Pop();
                        pilaAcciones.Pop();
                        pilaSimbolos.Pop();
                        pilaSimbolos.Pop();
                        pilaSimbolos.Pop();
                        pilaSimbolos.Push("ExprComp");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "=":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(173);
                    lH = cadenas.Peek();
                    return estado173(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado165(Token lH)
        {//REDUCCION A 94, SACANDO 3 Y METER COMPPP
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH); ;
                case "%":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado166(Token lH)
        {

            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(175);
                    lH = cadenas.Peek();
                    return estado175(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado167(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "StmtBlock"://IR A 95 CON Stmtblock
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "Stmt_P":  //IR A 90 CON Stmt_P
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "Stmt":  //IR A 170 CON Stmt
                    pilaAcciones.Push(176);
                    return IrA(176, lH);
                case "IfStmt": //IR A 88 CON IfStmt
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt": //IR A 89 CON WhileStmt
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt": //IR A 91 CON forStmt 
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":  //IR A 93 CON returnStmt 
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt"://IR A 92 CON BreakStmt 
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":  //IR A 94 CON PrintStmt 
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":   //IR A 98 CON Expr 
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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

            }
            switch (lH.contenido)
            {
                case ";": //reduccion 61 con ;
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado168(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "StmtBlock"://IR A 95 CON Stmtblock
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "Stmt_P":  //IR A 90 CON Stmt_P
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "Stmt":  //IR A 177 CON Stmt
                    pilaAcciones.Push(177);
                    return IrA(177, lH);
                case "IfStmt": //IR A 88 CON IfStmt
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt": //IR A 89 CON WhileStmt
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt": //IR A 91 CON forStmt 
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":  //IR A 93 CON returnStmt 
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt"://IR A 92 CON BreakStmt 
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":  //IR A 94 CON PrintStmt 
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":   //IR A 98 CON Expr 
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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

            }
            switch (lH.contenido)
            {
                case ";": //reduccion 61 con ;
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado169(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":    //IR A EXPR CON 172
                    pilaAcciones.Push(178);
                    return IrA(178, lH);
                case "ExprOr":   //IR A EXPROR CON 104
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":   //IR A 105 CON EXPRORP
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":   //IR A 106 CON EXPRAND
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP": //IR  A EXPRANDP CON 107
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":   //IR A EXPREQUALS CON 108
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A EXPREQUALSP CON 109
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":    //IR A EXPRCOMP CON 112
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":   //IR A EXPRCOMP_P CON 113
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado170(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":    //IR A EXPR CON 179
                    pilaAcciones.Push(179);
                    return IrA(179, lH);
                case "ExprOr":   //IR A EXPROR CON 104
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":   //IR A 105 CON EXPRORP
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":   //IR A 106 CON EXPRAND
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP": //IR  A EXPRANDP CON 107
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":   //IR A EXPREQUALS CON 108
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A EXPREQUALSP CON 109
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":    //IR A EXPRCOMP CON 112
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":   //IR A EXPRCOMP_P CON 113
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado171(Token lH) 
        {
            switch (lH.tipo)
            {
                case "ident":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);

                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);

                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Expr");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado172(Token lH)
        {
            switch(pilaSimbolos.Peek())
            {
                case "Expr":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(156);
                    return estado156(lH);
                case "ExprOr":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(113);
                    return estado113(lH);
                case "Actuals":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(180);
                    return IrA(180, lH);
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
            }
            switch(lH.contenido)
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
                    return error(lH);
            }
        }
        private bool estado173(Token lH)//
        {
            switch (pilaSimbolos.Peek())
            {
                case "ExprCompP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(181);
                    return IrA(181, lH);
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
            }
            switch (lH.tipo)
            {
                case "ident":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(144);
                    lH = cadenas.Peek();
                    return estado144(lH);
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
                    return error(lH);
            }
        }
        private bool estado174(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(156);
                    return estado156(lH);
                case "ExprOr":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(113);
                    return estado113(lH);
                case "Actuals":   //IR A EXPRCOMP_P CON 174
                    pilaAcciones.Push(182);
                    return IrA(182, lH);
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
                    return error(lH);
            }
        }
        private bool estado175(Token lH)
        {//REDUCCION A 97, SACANDO 4 METIENDO COMPP
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprCompP");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado176(Token lH)
        {//
            var temp = new Token();
            switch (pilaSimbolos.Peek())
            {
                case "IfStmt_P": //IR A 175 CON IfStmt
                    pilaAcciones.Push(183);
                    return IrA(183, lH);
            }
            switch (lH.tipo)
            {
                case "ident":  //Reduccion 64 ident
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":   //Reduccion 64 intConstant
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 64 doubleConstant
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 64 boolConstant
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 64 stringConstant
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 64 ;
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 64 (
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{"://Reduccion 64 {
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}"://Reduccion 64 }
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion 64 if
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    //COLISION (DESPLAZAMIENTO A 176 / REDUCCION A 64 ) CON ELSE
                    temp = lH;
                    cadenas.Dequeue();
                    lH = cadenas.Peek();
                    if (lH.contenido == ";" || lH.contenido == "(" || lH.contenido == "{" || lH.contenido == "if" || lH.contenido == "while" || lH.contenido == "for" 
                        || lH.contenido == "return" || lH.contenido == "break" || lH.contenido == "Console" || lH.contenido == "-" || lH.contenido == "!" 
                        || lH.contenido == "this" || lH.contenido == "New" || lH.contenido == "null"  || lH.tipo == "ident" || lH.tipo == "int" 
                        || lH.tipo == "double" || lH.tipo == "bool" || lH.tipo == "string")
                    {
                        pilaSimbolos.Push(temp.contenido);
                        pilaAcciones.Push(184);
                        temp = lH;
                        return estado184(temp);
                    }
                    else
                    {
                        lH = rellenarCadenas(temp);
                        pilaSimbolos.Push("IfStmt_P");
                        return IrA(pilaAcciones.Peek(), lH);
                    }
                case "for"://Reduccion 64 for
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while"://Reduccion 64 while
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion 64 return 
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break"://Reduccion 64 break
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion 64 Console
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion 64 -
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion 64 !
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 64 this
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New"://Reduccion 64 New
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null"://Reduccion 64 null
                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
           
        }
        private bool estado177(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident"://Reduccion 65ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 65intConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 65doubleConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 65boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop(); 
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 65stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 65;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 65(
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);

                case "{":  //Reduccion 65{
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 65}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 65 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 65 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 65 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 65 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 65 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 65 brak
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 65 Console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 65 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 65 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 65 WhileStmt
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 65 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 65 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("WhileStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado178(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(185);
                    lH = cadenas.Peek();
                    return estado185(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado179(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "PrintStmt_P":    //IR A 178 CON PRINT STMT
                    pilaAcciones.Push(186);
                    return IrA(186, lH);
            }
            switch (lH.contenido)
            {
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(187);
                    lH = cadenas.Peek();
                    return estado187(lH);
                case ")":  //Reduccion 71 )
                    pilaSimbolos.Push("PrintStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }

        private bool estado180 (Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("Actuals");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }

        private bool estado181(Token lH)
        {//toda redccion a 90
            switch (lH.tipo)
            {
                case "ident"://Reduccion 89ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 89intConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 89doubleConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 89boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 89stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 89;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 89(
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ")": //Reduccion 89)
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case ",": //Reduccion 89,
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":  //Reduccion 89{
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":  //Reduccion 89}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":  //Reduccion 89 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":  //Reduccion 89 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":  //Reduccion 89 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":  //Reduccion 89 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":  //Reduccion 89 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":  //Reduccion 89 brak
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":  //Reduccion 89 Console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);

                case ".": //Reduccion 89 . 
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);

                case "==":  //Reduccion 89 ==
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":  //Reduccion 89 &&
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":  //Reduccion 89 <
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":  //Reduccion 89 <=
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":  //Reduccion 89 +
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":  //Reduccion 89 *
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":  //Reduccion 89 %
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":  //Reduccion 89 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":  //Reduccion 89 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this"://Reduccion 89 WhileStmt
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":  //Reduccion 89 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":  //Reduccion 89 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado182(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(188);
                    lH = cadenas.Peek();
                    return estado188(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado183(Token lH)
        {
            if (pilaSimbolos.Peek() == "Stmt")
                contador87 = 1;
            switch (lH.tipo)
            {
                case "ident"://Reduccion 62ident
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                case "int"://Reduccion 62intConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "double"://Reduccion 62doubleConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool"://Reduccion 62boolConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "string"://Reduccion 62stringConstant
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":  //Reduccion 62;
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "(": //Reduccion 62(
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "{": //Reduccion 62{
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "}": //Reduccion 62}
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                case "if": //Reduccion 62 if
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "else": //Reduccion 62 else
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "while": //Reduccion 62 while
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                case "for": //Reduccion 62 for
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "return": //Reduccion 62 return
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "break": //Reduccion 62 break
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console": //Reduccion 62 console
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "-": //Reduccion 62 -
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "!": //Reduccion 62 !
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "this": //Reduccion 62 this
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                case "New": //Reduccion 62 New
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                   
                    return IrA(pilaAcciones.Peek(), lH);
                case "null": //Reduccion 62 null
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    if (pilaSimbolos.Peek() == "Stmt")
                        contador87 = 1;
                    pilaSimbolos.Push("IfStmt");
                    
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }

        }
        private bool estado184(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "StmtBlock"://IR A 95 CON Stmtblock
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "Stmt_P":  //IR A 90 CON Stmt_P
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "Stmt":  //IR A 189 CON Stmt
                    pilaAcciones.Push(189);
                    return IrA(189, lH);
                case "IfStmt": //IR A 88 CON IfStmt
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt": //IR A 89 CON WhileStmt
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt": //IR A 91 CON forStmt 
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":  //IR A 93 CON returnStmt 
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt"://IR A 92 CON BreakStmt 
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":  //IR A 94 CON PrintStmt 
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":   //IR A 98 CON Expr 
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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

            }
            switch (lH.contenido)
            {
                case ";"://Reducción 61 ;
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado185(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":   //IR A 190 CON Expr 
                    pilaAcciones.Push(190);
                    return IrA(190, lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }
        private bool estado186(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(191);
                    lH = cadenas.Peek();
                    return estado191(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado187(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "Expr":   //IR A 183 CON Expr 
                    pilaAcciones.Push(192);
                    return IrA(192, lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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
                    return error(lH);
            }
        }

        private bool estado188(Token lH)
        {//REDUCCION A 91
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case ")":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case ",":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case ".":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "==":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "&&":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "<":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "<=":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "+":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "*":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "%":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Push("ExprComp"); //mmm
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado189(Token lH)
        {
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);

                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("IfStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado190(Token lH)
        {
            switch (lH.contenido)
            {
                case ")":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(193);
                    lH = cadenas.Peek();
                    return estado193(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado191(Token lH)
        {
            switch (lH.contenido)
            {
                case ";":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(194);
                    lH = cadenas.Peek();
                    return estado194(lH);
                default:
                    return error(lH);
            }
        }
        private bool estado192(Token lH)
        {
            
            switch (pilaSimbolos.Peek())
            {
                case "PrintStmt_P": //Ir a 195 PrintStmt_P
                    pilaAcciones.Push(195);
                    return IrA(195, lH);
            }
            switch (lH.contenido)
            {
                case ",":
                    pilaSimbolos.Push(cadenas.Dequeue().contenido);
                    pilaAcciones.Push(187);
                    lH = cadenas.Peek();
                    return estado187(lH);

                case ")"://r71
                    pilaSimbolos.Push("PrintStmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado193(Token lH)
        {
            switch (pilaSimbolos.Peek())
            {
                case "StmtBlock"://IR A 95 CON Stmtblock
                    pilaAcciones.Push(95);
                    return estado95(lH);
                case "Stmt_P":  //IR A 90 CON Stmt_P
                    pilaAcciones.Push(90);
                    return estado90(lH);
                case "Stmt":  //IR A 187 CON Stmt
                    pilaAcciones.Push(196);
                    return IrA(196, lH);
                case "IfStmt": //IR A 88 CON IfStmt
                    pilaAcciones.Push(88);
                    return estado88(lH);
                case "WhileStmt": //IR A 89 CON WhileStmt
                    pilaAcciones.Push(89);
                    return estado89(lH);
                case "ForStmt": //IR A 91 CON forStmt 
                    pilaAcciones.Push(91);
                    return estado91(lH);
                case "ReturnStmt":  //IR A 93 CON returnStmt 
                    pilaAcciones.Push(93);
                    return estado93(lH);
                case "BreakStmt"://IR A 92 CON BreakStmt 
                    pilaAcciones.Push(92);
                    return estado92(lH);
                case "PrintStmt":  //IR A 94 CON PrintStmt 
                    pilaAcciones.Push(94);
                    return estado94(lH);
                case "Expr":   //IR A 98 CON Expr 
                    pilaAcciones.Push(98);
                    return estado98(lH);
                case "ExprOr":  //IR A 104 CON ExprOr 
                    pilaAcciones.Push(104);
                    return estado104(lH);
                case "ExprOrP": //IR A 105 CON ExprOrP 
                    pilaAcciones.Push(105);
                    return estado105(lH);
                case "ExprAnd": //IR A 106 CON ExprAnd
                    pilaAcciones.Push(106);
                    return estado106(lH);
                case "ExprAndP":  //IR A 107 CON ExprAndP 
                    pilaAcciones.Push(107);
                    return estado107(lH);
                case "ExprEquals":  //IR A 108 CON ExprEquals
                    pilaAcciones.Push(108);
                    return estado108(lH);
                case "ExprEqualsP": //IR A 109 CON ExprEqualsP
                    pilaAcciones.Push(109);
                    return estado109(lH);
                case "ExprComp": //IR A 112 CON ExprComp
                    pilaAcciones.Push(112);
                    return estado112(lH);
                case "ExprCompP": //IR A 113 CON ExprCompP
                    pilaAcciones.Push(113);
                    return estado113(lH);
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

            }
            switch (lH.contenido)
            {
                case ";": //Reduccion 61 ;
                    pilaSimbolos.Push("Stmt_P");
                    return IrA(pilaAcciones.Peek(), lH);
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
                    return error(lH);
            }
        }
        private bool estado194(Token lH)
        {//REDUCCION A 69,  8 datos
            switch (lH.tipo)
            {
                case "ident":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":

                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("PrintStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
        private bool estado195(Token lH)
        {
            if (lH.contenido == ")") ///r70
            {
                pilaAcciones.Pop();
                pilaAcciones.Pop();
                pilaAcciones.Pop();

                pilaSimbolos.Pop();
                pilaSimbolos.Pop();
                pilaSimbolos.Pop();
                pilaSimbolos.Push("PrintStmt_P");
                return IrA(pilaAcciones.Peek(), lH);
            }
            else
            {
                return error(lH);
            }
        }
        private bool estado196(Token lH)
        {//r66
            switch (lH.tipo)
            {
                case "ident":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "int":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "double":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "bool":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "string":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);

            }
            switch (lH.contenido)
            {
                case ";":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "(":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "{":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "}":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "if":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "else":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "while":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "for":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "return":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "break":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "Console":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "-":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "!":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "this":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "New":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                case "null":
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();
                    pilaAcciones.Pop();

                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();
                    pilaSimbolos.Pop();

                    pilaSimbolos.Push("ForStmt");
                    return IrA(pilaAcciones.Peek(), lH);
                default:
                    return error(lH);
            }
        }
       
 
    }
}
