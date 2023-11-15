using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFormDMF
{
    internal class Coche
    {
        public static int contador { get; set; } = 0;
        public int numero { get; set; }
        public string matricula { get; set; }
        public char primeraLetraMatricula { get; set; } //Contiene la primera letra de la matricula
        public string marca { get; set; }
        public Boolean particular { get; set; } //Indica si el coche es de un particular o no
        public float precio { get; set; }
        public int aniosEdad { get; set; } //Indica cuantos años tiene el coche desde que se matriculó por primera vez
        public Image fotoCoche { get; set; } //Imagen del coche
        public string nombreFoto { get; set; }

        public Coche(string matricula, string marca, bool particular, float precio, int aniosEdad, Image fotoCoche, string nombreFoto)
        {
            contador++;
            this.numero = contador;
            this.matricula = matricula;
            this.primeraLetraMatricula = matricula[4]; 
            this.marca = marca;
            this.particular = particular;
            this.precio = precio;
            this.aniosEdad = aniosEdad;
            this.fotoCoche = fotoCoche;
            this.nombreFoto = nombreFoto;
        }
        
       

    }
}
