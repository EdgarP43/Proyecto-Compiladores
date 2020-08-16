using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores2020
{
    class analizador
    {
        private List<string> reservadas = new List<string>();
        private Dictionary<int, string> archivo = new Dictionary<int, string>();
        public void guardarReservadas(List<string> palabras)
        {
            reservadas = palabras;
        }
        public void guardarArchivo(Dictionary<int, string> lineas)
        {
            archivo = lineas ;
        }

        public List<string> Reconocedor()
        {
            int llave = 1;
            string concatpalabra = String.Empty;
            var prueba = new List<string>();
            do
            {
                for(int i = 0; i<reservadas.Count; i++)
                { 
                    if (archivo[llave].Contains(reservadas[i])/*lineas.ContainsValue(archivo.)*/)
                    {
                        prueba.Add("reservada : "+reservadas[i] + " en linea " + llave.ToString());
                        
                    }
                    if (archivo[i]!="\t" && archivo[i] != "\n" && archivo[i] != " ")
                    {
                        concatpalabra += archivo[i];
                    }
                }
                llave++;
            } while (archivo.ContainsKey(llave));
            return prueba;
        }
    }
}
