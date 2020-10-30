# Proyecto Compiladores

-Universidad Rafael Landívar, Campus Central
-Curso: Compiladores 2ndo Ciclo 2020
-Catedrática: Ing. Diana Gutiérrez

## Analizador Léxico  (FASE I)

La fase 1 de nuestro proyecto de Compiladores consiste en la iniciación de un compilador comenzando con un analizador de léxico bastante robusto, donde creamos un scanner 
que permite el reconocimiento de los tokens de un archivo de cualquier extensión determinando palabras reservadas, operadores, constantes numéricas (tanto doubles, int e
incluso hexadecimales) e identidicadores para un lenguaje de C#.

## Implementaciones Analizador Léxico 

✦ El mismo analizador omite espacios en blanco, saltos de lineas y tabulaciones, siempre contándolas para validaciones de columnas de los caracteres leídos.

✦ Reconocimiento de comentarios y constantes string las cuales son tomadas en cuenta, sin embargo no son mostradas a menos que formen parte de los errores mencionados.

✦ Cadenas con formato distintos a los de un identificador válido (concatenaciones de letras, numeros y guiones bajos siempre empezando con letras) son separados, sin tirar
error.

✦ De salidas cuenta con un salida visual en un Form donde al se analizado por completo el archivo de entrada, es posible verificar si fue exitoso todo el archivo, en caso de 
errores, se motrarán en pantalla, así también este programa al momento de examinar el código de entrada genera un archivo .out el cual contiene cada token encontrado, con su 
correspondiente número de línea y sus columnas según la línea en la que pertenezca.

Este archivo .out se guarda automáticamente donde se encuentra el archivo utilizado como entrada al inicio de la ejecución 

## Manejo de Errores Analizador Léxico

Así también nuestro analizador de léxico tiene un manejo de errores los cuales son mostrados como salida los cuales son:
✦ Caracteres no reconocidos para el lenguaje

✦ Constantes string sin terminar, es decir una inexistencia de cierre de comillas

✦ Excedente de 31 caracteres como máximo en un identificador

✦ Validación de comentarios y cadenas sin cerrar como EOF en fin de archivo

✦ Inexistencia de emparejamiento de inicio de comentarios de varias líneas

Estos mismos son identificados por su impresion con **

## Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

✦ El laboratorio A, consiste en un Analizador Sintáctico Descendente Recursivo, el cual maneja una gramática incluída en la entrega de este mismo, la cual permite analizar la 
gramática transformada (una gramática tipo 2), teniendo ninguna recursividad por la izquierda, reolviendo ambiguedades, la precedencia de simbolos y constantes, la factorización
de producciones para llegar a fomar declaraciones de variables, funciones y procesos, así como también se nos fue asignado realizar el análisis de las estructuras "if-else" y ciclos "while"  para un lenguaje de c#

✦ Así mismo se fue resulto por medio de métodos interacivos con otros, formando así la recursividad entre estos siempre de acuerdo a la gramática transformada, incluída en el
  documento de su respectiva fase.


## Implemetaciones para el Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

✦ Proceso que solo funciona cuando la entrada al programa es correcta para el analizador léxico, la cual habilita el botón de análisis para esta fase de laboratorio

✦ Maneja una recursividad basada en la gramática, tomando en cuenta cada No terminal como un método "parse" el cual redirecciona hacia otros, según la entrada que obtiene.

✦ Se manjeaun matchToken, el cual valida un string esperado si es correcto según la gramática, de lo contrario cuenta como un error de la sintaxis

✦ Manejo de backtracking mediante sentencias condicionales para la decisión de caminos a tomar por cada producción que posee varios terminales

✦ Se implementó un lookahead el cual se toma el valor en el pico de la cola para ver si es el token esperado por el match token, hacer el match o error de sintaxsis.

***IMPORTANTE:***
✦ La gramática mencionada, se encuentra e la carpeta de "archivos de prueba" denominada "Diseño de gramatica transformada" cual también contiene archivos los cuales fueron 
validados previamente en el programa, tanto con errores, como archivos correctos.

## Manejo de Errores para el Analizador Sinstáctico Descendente Recursivo (Laboratorio A)

 ✦ El programa puede reconocer errores en la sintaxis basads en la comparación de la entrada al programa con la gramática definida en este laboratorio, por cada error
encontrado se procede a:

➮ Marcarlo como un error de sintaxis y contniuar con su lectura, mostrando en pantalla el token el cual es erroneo, continaundo con el análisis de la producción del siguiente token esperado
➮ Al terminar el archivo, sin terminar de leer la gramática, se muestra de salida en pantalla un mensaje que no hay más tokens para continuar la lectura de la gramática, terminando con el programa
    ***IMPORTANTE:***
  ➮ En el metodo de parse_Stmt, hay una produccion Expr ;, con la cual la gramatica finaliza y no sigue funcionando, pero agregamos una condicion para  ver si quedan tokens 
existentes en la cola despues de esa produccion reiniciar la gramatica y evaluar todo el proceso

##  Análizador Sintáctico Ascendente SLR (FASE II)
✦   Nuestra segunda fase del proyecto de Compiladores con su robustez debida consiste en análizar sintácticamente un un programa escrito en lenguaje de C#, donde definimos una gramática que se encuentra adjunta en el documento PDF *Gramática  Modificada* en la cual procedimos a modificar de manera que los problemas como las colisoines durante el análisis disminuyeran.

✦  Esta fase permite darle sentido al programa, analizando más a fondo si la entrada está correctamente escrita según el lenguaje.

## Implementación del Análizador Sintáctico Asecendente (SLR) 
✦ Este analizador maneja la misma entrada del análizado léxico, donde por medio del alamcenamiento de los símbolos y el tipo de símbolo que provenga de la cadena de entrada se genera la pila de acciones y una pila de símbolos, los cuales irán variando según el estado que les corresponde como lo muestra la tabla de análisis SLR adjunta como un .csc llamado *Tabla de análisis, Fase 2* tabajado por medio de una colección canónica, con generación a 187 estados y un total de 13 problemas de colisiones de reduccion-desplazamiento.

✦ Esta fase se manejaron los estados por medio de métodos los cuales reciben el símbolo siguiente que proviene de la cadena de entrada junto con el número de estado al cual se dirige y al momento de encontrar el estado, dependiento lo que se encuentre en el tope de las pilas realiza la acción de reducción o de desplazamiento siendo:

-Desplamiento -> añade a la pila
-Reducción -> Quita de la pila y sustituye por la reducción al estado que le corresponde

## Manejeo de conflictos y errores, Análizador Sintáctico Ascendente SLR
✦ Para los complictos de reducción-desplazamiento se analizó por medio de la tabla de análisis, visualizando los follows del estado correspondiente, validando que exista en el estado para poder desplazar al sigueinte estado, de lo contrario a encontrarse, se procede evaluar el token en el mismo estado para la reducción

✦ Para los estados que tenían IR_A hacia su mismo estado, por medio de una bandera se valida si se es posible agregar el estado a la pila de acciones, de lo contrario solo una vez, para evitar una recursividad 
 
 ✦Para los errores encontrados, se almacenan en cola de errores, obteniendo la pocision del token como el mismo token, donde para poder continuar con el análisis, se evalua su existencia en el estado inicial y poder vaciar las pilas, de lo contrario se manda al estado que continuaría el siguiente token
 
* Ya que el analizado solamente se encarga de validar si está sintácticamente correcto, al momento de encontrar errores se van almacenando en una cola conforme los encuentre para así poder ir gurdando tanto su su fila como columnas al momento de encontrarlos y poder mostrarlos en pantalla de lo contrario sola indica que el archivo fue correcto.

## 🏁 Modo de Uso 🏁 
1. En el ejecutable como primera instancia abre una ventana la cual posee un botón para la carga del archivo y de lado derecho se observa un cuadro donde es posible ver la 
salida abstracta del análisis de léxico realizado
2. Luego de la carga del archivo, si el correcto, se habilita el botón para el análizador sintpactico descendete recursivo, de lo contrario, solamente se visualiza su cuadro de salida vacío.
3. Igualmente después del análisis sintáctico ascendente, no es importante si se encuentra correcto el archivo, es posible analizar por el tercer botón, de arriba hacia abajo, el cual muestra su salida en el segundo cuadro del lado inferior izquierdo. Teniendo así salidas ya sea de errores o simplemente de confimación de archivo correcto.

## Especificaciones:

★ El proyecto fue elaborado en Visual Studio C# Forms .FrameWork 2019 

### Colaboradores

-Edgar Ramiro Paredes Castillo  - 1078218
-Andrea Cristina Cámara Bran    - 1005718
