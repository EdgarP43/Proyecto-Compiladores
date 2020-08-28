# Proyecto Compiladores Fase 1
Universidad Rafael Landívar, Campus Central
Curso: Compiladores 2ndo Ciclo 2020
Catedrática: Ing. Diana Gutiérez

# Analizador Léxico
#_______________________________________________________________________________________________________________________________________________________________________
La fase 1 de nuestro proyecto de Compiladores consiste en la iniciación de un compilador comenzando con un analizador de léxico bastante robusto, donde creamos un scanner 
que permite el reconocimiento de los tokens de un archivo de cualquier extensión determinando palabras reservadas, operadores, constantes numéricas (tanto doubles, int e
incluso hexadecimales) e identidicadores para un lenguaje de c#.

# Manejo de Errores
#_______________________________________________________________________________________________________________________________________________________________________
Así también nuestro analizador de léxico tiene un manejo de errores los cuales son mostrados como salida los cuales son:
x Caracteres no reconocidos para el lenguaje
x Constantes string sin terminar, es decir una inexistencia de cierre de comillas
x Excedente de 31 caracteres como máximo en un identificador
x Validación de comentarios y cadenas sin cerrar como EOF en fin de archivo
x Inexistencia de emparejamiento de inicio de comentarios de varias líneas
Estos mismos son identificados por su impresion con *** 

# Implementaciones
#_______________________________________________________________________________________________________________________________________________________________________
x El mismo analizador omite espacios en blanco, saltos de lineas y tabulaciones, siempre contándolas para validaciones de columnas de los caracteres leídos.
x Reconocimiento de comentarios y constantes string las cuales son tomadas en cuenta, sin embargo no son mostradas a menos que formen parte de los errores mencionados.
x Cadenas con formato distintos a los de un identificador válido (concatenaciones de letras, numeros y guiones bajos siempre empezando con letras) son separados, sin tirar
error.
x De salidas cuenta con un salida visual en un Form donde al se analizado por completo el archivo de entrada, es posible verificar si fue exitoso todo el archivo, en caso de errores, se motrarán en pantalla, así también este programa al momento de examinar el código de entrada genera un archivo .out el cual contiene cada token encontrado, con su correspondiente número de línea y sus columnas según la línea en la que pertenezca.
Este archivo .out se guarda automáticamente donde se encuentra el archivo utilizado como entrada al inicio de la ejecución 

# Modo de Uso
#_______________________________________________________________________________________________________________________________________________________________________
En el ejecutable como primera instancia abre una ventana la cual posee un botón para la carga del archivo y de lado derecho se observa un cuadro donde es posible ver la 
salida abstracta del análisis de léxico realizado 

# Especificaciones:
#_______________________________________________________________________________________________________________________________________________________________________
El proyecto fue elaborado en Visual Studio C# Forms .FrameWork 2019 

# Colaboradores
#_______________________________________________________________________________________________________________________________________________________________________
Edgar Ramiro Paredes Castillo  - 1078218
Andrea Cristina Cámara Bran    - 1005718
