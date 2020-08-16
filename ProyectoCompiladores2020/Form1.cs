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
        public List<string> reservadas = new List<string>();
        analizador palala = new analizador();
        public Form1()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Reservadas.txt"))
            {
                string linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                        reservadas.Add(linea);
                }
            }
            palala.guardarReservadas(reservadas);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int contlineas = 0;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text files(*.txt)|*.txt|Todos los archivos(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(o.FileName)) 
                {
                    string linea = "";
                    while ((linea = sr.ReadLine()) != null)
                    {
                        contlineas++;
                        lineas.Add(contlineas,linea);
                    }
                }
            }
            palala.guardarArchivo(lineas);
            var mostrar = palala.Reconocedor();
            foreach (var item in mostrar)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
