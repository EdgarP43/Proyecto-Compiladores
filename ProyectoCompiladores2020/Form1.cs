﻿using System;
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
        public Form1()
        {
            InitializeComponent();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int contlineas = 0;
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
                var mostrar = iraAnalizador.Reconocedor();
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
                }       
                string nombreArchivo = Path.ChangeExtension(o.FileName,".out");
                using (StreamWriter sw = new StreamWriter(nombreArchivo))
                {
                    foreach (var item in mostrar)
                    {
                        sw.WriteLine(item);
                        sw.WriteLine("\n");
                    }
                }
            }
            






        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
