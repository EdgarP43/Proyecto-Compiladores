# Proyecto Compiladores

Universidad Rafael Landívar, Campus Central
Curso: Compiladores 2ndo Ciclo 2020
Catedrática: Ing. Diana Gutiérrez

# Analizador Léxico

La fase 1 de nuestro proyecto de Compiladores consiste en la iniciación de un compilador comenzando con un analizador de léxico bastante robusto, donde creamos un scanner 
que permite el reconocimiento de los tokens de un archivo de cualquier extensión determinando palabras reservadas, operadores, constantes numéricas (tanto doubles, int e
incluso hexadecimales) e identidicadores para un lenguaje de c#.

# Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

El laboratorio A, consiste en un Analizador Sintáctico Descendente Recursivo, el cual maneja una gramática incluída en la entrega de este mismo, la cual permite analizar la 
gramática transformada (una gramática tipo 2), teniendo ninguna recursividad por la izquierda, reolviendo ambiguedades, la precedencia de simbolos y constantes, la factorización
de producciones para llegar a fomar declaraciones de variables, funciones y procesos, así como también se nos fue asignado realizar el análisis de las estructuras "if-else" y ciclos "while" 
para un lenguaje de c#

# Implementaciones Analizador Léxico

x El mismo analizador omite espacios en blanco, saltos de lineas y tabulaciones, siempre contándolas para validaciones de columnas de los caracteres leídos.
x Reconocimiento de comentarios y constantes string las cuales son tomadas en cuenta, sin embargo no son mostradas a menos que formen parte de los errores mencionados.
x Cadenas con formato distintos a los de un identificador válido (concatenaciones de letras, numeros y guiones bajos siempre empezando con letras) son separados, sin tirar
error.
x De salidas cuenta con un salida visual en un Form donde al se analizado por completo el archivo de entrada, es posible verificar si fue exitoso todo el archivo, en caso de 
errores, se motrarán en pantalla, así también este programa al momento de examinar el código de entrada genera un archivo .out el cual contiene cada token encontrado, con su 
correspondiente número de línea y sus columnas según la línea en la que pertenezca.
Este archivo .out se guarda automáticamente donde se encuentra el archivo utilizado como entrada al inicio de la ejecución 


# Implemetaciones para el Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

x Proceso que solo funciona cuando la entrada al programa es correcta para el analizador léxico, la cual habilita el botón de análisis para esta fase de laboratorio
x Maneja una recursividad basada en la gramática, tomando en cuenta cada No terminal como un método "parse" el cual redirecciona hacia otros, según la entrada que obtiene.
x Se manjeaun matchToken, el cual valida un string esperado si es correcto según la gramática, de lo contrario cuenta como un error de la sintaxis
x Manejo de backtracking mediante sentencias condicionales para la decisión de caminos a tomar por cada producción que posee varios terminales
x Se implementó un lookahead el cual se toma el valor en el pico de la cola para ver si es el token esperado por el match token, hacer el match o error de sintaxsis.
IMPORTANTE:
-La gramática mencionada, se encuentra e la carpeta de "archivos de prueba" denominada "Diseño de gramatica transformada" cual también contiene archivos los cuales fueron 
validados previamente en el programa, tanto con errores, como archivos correctos.


# Manejo de Errores para el Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

 x El programa puede reconocer errores en la sintaxis basads en la comparación de la entrada al programa con la gramática definida en este laboratorio, por cada error
encontrado se procede a:
-> Marcarlo como un error de sintaxis y contniuar con su lectura, mostrando en pantalla el token el cual es erroneo, continaundo con el análisis de la producción del siguiente token esperado
-> Al terminar el archivo, sin terminar de leer la gramática, se muestra de salida en pantalla un mensaje que no hay más tokens para continuar la lectura de la gramática, terminando con el programa
IMPORTANTE:
--> En el metodo de parse_Stmt, hay una produccion Expr ;, con la cual la gramatica finaliza y no sigue funcionando, pero agregamos una condicion para  ver si quedan tokens 
existentes en la cola despues de esa produccion reiniciar la gramatica y evaluar todo el proceso

# Manejo de Errores Analizador Léxico

Así también nuestro analizador de léxico tiene un manejo de errores los cuales son mostrados como salida los cuales son:
x Caracteres no reconocidos para el lenguaje
x Constantes string sin terminar, es decir una inexistencia de cierre de comillas
x Excedente de 31 caracteres como máximo en un identificador
x Validación de comentarios y cadenas sin cerrar como EOF en fin de archivo
x Inexistencia de emparejamiento de inicio de comentarios de varias líneas
Estos mismos son identificados por su impresion con ***

# Modo de Uso

-En el ejecutable como primera instancia abre una ventana la cual posee un botón para la carga del archivo y de lado derecho se observa un cuadro donde es posible ver la 
salida abstracta del análisis de léxico realizado 
-Al tener un archivo correcto, de habilita un botón del lado izquierdo el cual permite en análisis del analizador sintáctico descendente recursivo, mostrando la salida
en el cuadro derecho

# Especificaciones:

El proyecto fue elaborado en Visual Studio C# Forms .FrameWork 2019 

# Colaboradores

Edgar Ramiro Paredes Castillo  - 1078218
Andrea Cristina Cámara Bran    - 1005718
