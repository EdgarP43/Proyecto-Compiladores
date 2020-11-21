using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoCompiladores2020
{
    public partial class Form1 : Form
    {
        public Dictionary<int, string> lineas = new Dictionary<int, string>();
        analizador iraAnalizador = new analizador();
        analizador iraAnalizador2 = new analizador();
        SintacticoRecursivo sintacticoDes = new SintacticoRecursivo();
        TablaSimbolos tabla = new TablaSimbolos();
        string nombreArchivo2;
        // SintacticoAscendente sintacticoAs = new SintacticoAscendente();
        public Form1()
        {
            InitializeComponent();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            iraAnalizador.tokens.Clear();
            int contlineas = 0;
            iraAnalizador.correcto = true;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Todos los archivos(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                if (listBox1.Items != null)
                {
                    listBox1.Items.Clear();
                    lineas.Clear();
                }
                using (StreamReader sr = new StreamReader(o.FileName)) 
                {
                    string linea = "";
                    while ((linea = sr.ReadLine()) != null)
                    {
                        contlineas++;
                        lineas.Add(contlineas, linea);
                    }

                   
                }
                iraAnalizador.guardarArchivo(lineas);
                iraAnalizador2.guardarArchivo(lineas);
                var mostrar = iraAnalizador.Reconocedor();
                var listaTemp = iraAnalizador2.Reconocedor();
                sintacticoDes.tokens = iraAnalizador.tokens;
                tabla.cadenas = iraAnalizador2.tokens;
                if (iraAnalizador.correcto == false)
                {
                    foreach (var item in iraAnalizador.errores)
                    {
                        listBox1.Items.Add(item);
                        listBox1.Items.Add("\n");

                    }
                }
                else
                {
                    listBox1.Items.Add("Archivo correcto");
                    button2.Enabled = true ;
                    button3.Enabled = true ;

                }       
                string nombreArchivo = Path.ChangeExtension(o.FileName,".out");
                nombreArchivo2 = Path.ChangeExtension(o.FileName, ".tabla");
                using (StreamWriter sw = new StreamWriter(nombreArchivo))
                {
                    foreach (var item in mostrar)
                    {
                        sw.WriteLine(item);
                        sw.WriteLine("\n");
                    }
                }
                iraAnalizador.errores.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            sintacticoDes.tokens = iraAnalizador.tokens;
            sintacticoDes.parse_Program();
            if (sintacticoDes.errores.Count != 0)
            {
                foreach (var item in sintacticoDes.errores)
                {
                    listBox2.Items.Add(item);
                    listBox2.Items.Add("\n");
                }
            }
            else
            {
                listBox2.Items.Add("Archivo correcto");
            }
            sintacticoDes.errores.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox3.Items != null)
            {
                listBox3.Items.Clear();
            }
            
            SintacticoAscendente sintacticoAs = new SintacticoAscendente();
            sintacticoAs.cadenas = iraAnalizador.tokens;
            sintacticoAs.iniciar();
            if (sintacticoAs.errores.Count != 0)
            {
                foreach (var item in sintacticoAs.errores)
                {
                    listBox3.Items.Add(item);
                    listBox3.Items.Add("\n");
                }
            }
            else
            {
                listBox3.Items.Add("El archivo es correcto");
                button4.Enabled = true;
            }
            sintacticoAs.errores.Clear();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox4.Items != null)
            {
                listBox4.Items.Clear();
            }

            TablaSimbolos tabla = new TablaSimbolos();
            tabla.cadenas = iraAnalizador2.tokens;
            tabla.Inicar();
            tabla.archivo(nombreArchivo2);

            if (tabla.errores.Count != 0)
            {
                foreach (var item in tabla.errores)
                {
                    listBox4.Items.Add(item);
                    listBox4.Items.Add("\n");
                }
            }
            else
            {
                listBox4.Items.Add("El archivo es correcto");
            }
            tabla.errores.Clear();
            button4.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
