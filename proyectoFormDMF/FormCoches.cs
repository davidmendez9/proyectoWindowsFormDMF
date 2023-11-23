using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace proyectoFormDMF
{
    public partial class FormCoches : Form
    {
        private static List<Coche> lista = new List<Coche>(); //Lista principal

        static int contador = 0; //Variable para almacenar el numero de coches.
        static int actual = 0; //Variable que contiene la posicion del elemento actual.
        Boolean modifyMode = false; //Variable para comprobar si estamos en modificar o en añadir.
        public FormCoches()
        {
            InitializeComponent();

            /*
             * Tengo estos add comentados porque los he usado para crear el fichero. 
             * Como el fichero ya está creado, no son necesarios ya que iniciamos el programa
             * mediante los datos del fichero.
             */

            //aniadirElemento("1234DMF", "Nissan", true, (float)2500.99, 20, "nissan.jpg");
            //aniadirElemento("4567PPS", "Volvo", false, (float)4750.50, 15, "volvo.jpg");
            //aniadirElemento("5643DVZ", "Volskwagen", true, (float)4000.52, 17, "Volsk.jpg");
            //aniadirElemento("2472AND", "Ferrari", false, (float)200000, 4, "Ferrari.jpg");
            //escribirArchivo();

            leerArchivo();
            mostrarElementos(actual);
            btnAnterior.Enabled = false;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;

            //Evento para cuando se cierre el formulario
            this.FormClosing += FormCoches_FormClosing;
        }
        //Cuando cerremos el formulario se ejecuta este método en el que guardamos en el fichero los datos de la lista.
        private void FormCoches_FormClosing(object sender, FormClosingEventArgs e)
        {
            escribirArchivo();
        }

        //Método en el que mostramos el elemento en la posicion deseada. 
        public void mostrarElementos(int actual)
        {
            //Comprobamos si el numero introducido no supera el tamaño de la lista o
            //si en la lista hay elementos.
            if (lista.Count > 0 && actual >= 0 && actual < lista.Count)
            {
                //Intoducimos los valores en sus respectivos campos.
                txtMatricula.Text = "" + lista[actual].matricula;
                txtMarca.Text = "" + lista[actual].marca;
                txtAniosEdad.Text = "" + lista[actual].aniosEdad;
                txtPrecio.Text = "" + lista[actual].precio;
                txtPrimeraLetra.Text = "" + lista[actual].primeraLetraMatricula;
                txtParticular.Text = "" + lista[actual].particular;
                pbFotoCoche.Image = lista[actual].fotoCoche;
                txtNombreFoto.Text = "" + lista[actual].nombreFoto;
            }
            else
            {
                //Mostramos mensaje de error
                MessageBox.Show("Error");
            }
        }

        //Método para leer los datos del fichero
        public void leerArchivo()
        {
            string nombreArchivo = "databank.data"; //Nombre del fichero con los datos

            try
            {
                if (File.Exists(nombreArchivo))
                {
                    // Limpia la lista antes de leer nuevos datos
                    lista.Clear();

                    using (StreamReader reader = new StreamReader(nombreArchivo))//Abrimos archivo
                    {
                        while (!reader.EndOfStream)//Recorremos hasta el final del fichero
                        {
                            string line = reader.ReadLine(); //Guardamos una linea
                            string[] datos = line.Split('-'); //Dividimos la linea a partir de '-' y guardamos cada parte en una posicion del vector
                            
                            // Comprobamos que tenemos los datos requeridos para crear un nuevo registro de coche
                            if (datos.Length == 6)
                            {
                                //Guardamos los datos en cada variable
                                string matricula = datos[0];
                                string marca = datos[1];
                                bool particular = bool.Parse(datos[2]);
                                float precio = float.Parse(datos[3]);
                                int anios = int.Parse(datos[4]);
                                string nombreFoto = datos[5];

                                //Añadimos los datos recogidos a la lista
                                aniadirElemento(matricula, marca, particular, precio, anios, nombreFoto);
                            }
                        }
                    }

                    // Establecer actual en 0 después de cargar los datos
                    actual = 0;

                    // Mostrar el primer elemento después de cargar los datos
                    mostrarElementos(actual);
                }
            }
            catch (Exception ex) //Si hay algun problema de lectura con el archivo, indicamos por pantalla el fallo.
            {
                MessageBox.Show("Error al leer el archivo");
            }
        }
        public void escribirArchivo()
        {
            // Nombre del archivo
            string nombreArchivo = "databank.data";

            try
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    foreach (Coche coche in lista) //Recorremos por elementos la lista.
                    {
                        //Lo escribimos todo siguiendo el formato siguiente:
                        // Formato de cada línea: matricula-marca-particular-precio-anios-nombreFoto
                        string linea = $"{coche.matricula}-{coche.marca}-{coche.particular}-{coche.precio}-{coche.aniosEdad}-{coche.nombreFoto}";
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)//Mostramos un error, en el caso de que lo haya, al intentar escribir en el fichero.
            {
                MessageBox.Show("Error al escribir en el archivo");
            }
        }

        //Método para añadir nuevos Coches a la lista, sin tener que pasar la imagen
        public void aniadirElemento(string matricula, string marca, Boolean particular, float precio, int anios, String nombreFoto)
        {
            Image fotoCoche = Image.FromFile(nombreFoto);
            lista.Add(new Coche(matricula, marca, particular, precio, anios, fotoCoche, nombreFoto));
            contador++;
        }
        private Boolean isLast() //Método para comprobar si nos encontramos en el último elemento de la lista.
        {
            if (actual == lista.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean isFirst() //Método para comprobar si nos encontramos en el primer elemento de la lista.
        {
            if (actual == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void avanzar() //Método para avanzar al siguiente elemento
        {
            if (actual < lista.Count - 1) //Importante comprobar que actual no sea mayor que el tamaño de la lista
            {
                actual++; //Sumando 1 a actual, avanzamos al siguiente indice
                
                //Comprobaciones de botones
                btnAnterior.Enabled = true;
                if (isLast())
                {
                    btnSiguiente.Enabled = false;
                }
                mostrarElementos(actual);
            }
        }
        private void retroceder() //Método para retroceder al anterior elemento
        {
            if (actual > 0) //Comprobamos que actual sea un número válido para el índice de la lista
            {
                actual--; //Restando 1 a actual, volvemos al anterior indice

                //Comprobaciones de botones
                btnSiguiente.Enabled = true;
                if (isFirst())
                {
                    btnAnterior.Enabled = false;
                }
                mostrarElementos(actual);
            }
        }
        public void modificar() //Método para modificar el estado de los botones cuando vayamos a modificar un elemento
        {
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = false;
            btnAniadir.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            lblNombreFoto.Visible = true;
            txtNombreFoto.Visible = true;
            txtPrimeraLetra.Enabled = false;
        }
        public void vaciarDatos() //Vaciamos todos los campos con este método
        {
            txtMatricula.Clear();
            txtMarca.Clear();
            txtParticular.Clear();
            txtPrecio.Clear();
            txtPrimeraLetra.Clear();
            txtAniosEdad.Clear();
            txtNombreFoto.Clear();
            pbFotoCoche.Image = null;

        }

        public void borrarElemento() //Método para borrar un elemento
        {
            if (contador > 1) //Comprobamos que haya algún elemento en la lista
            {
                lista.RemoveAt(actual);
                actual = 0; //Siempre volvemos a mostrar el elemento inicial para evitar fallos
                contador--;
                mostrarElementos(actual);
                btnAnterior.Enabled = false;
            }
            else if (contador == 1) //Si queda uno, lo bottamos y dejamos los campos deshabilitados y vacíos. Sólo se podría añadir
            {
                lista.RemoveAt(actual);
                actual = 0;
                contador = 0;

                vaciarDatos();
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
                btnAniadir.Enabled = true;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;

                txtAniosEdad.Enabled = false;
                txtMarca.Enabled = false;
                txtPrecio.Enabled = false;
                txtPrimeraLetra.Enabled = false;
                txtMatricula.Enabled = false;
                txtParticular.Enabled = false;
                txtAniosEdad.Enabled = false;
            }

        }
        //Eventos de los botones empleando los métodos anteriores

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            avanzar();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

            retroceder();
        }

        private void btnAniadir_Click(object sender, EventArgs e)
        {
            vaciarDatos();
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = false;
            btnAniadir.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            lblNombreFoto.Visible = true;
            txtNombreFoto.Visible = true;
            txtPrimeraLetra.Enabled = false;

            txtAniosEdad.Enabled = true;
            txtMarca.Enabled = true;
            txtPrecio.Enabled = true;
            txtMatricula.Enabled = true;
            txtParticular.Enabled = true;
            txtAniosEdad.Enabled = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!modifyMode) //Comprobamos que no estemos modificando
            {
                if (txtNombreFoto.Text == "")
                {
                    aniadirElemento(txtMatricula.Text, txtMarca.Text, Boolean.Parse(txtParticular.Text), float.Parse(txtPrecio.Text), int.Parse(txtAniosEdad.Text), "pordefecto.png");
                }
                else
                {
                    aniadirElemento(txtMatricula.Text, txtMarca.Text, Boolean.Parse(txtParticular.Text), float.Parse(txtPrecio.Text), int.Parse(txtAniosEdad.Text), txtNombreFoto.Text);
                }

            }
            else //Si estamos modificando, sobreescribimos los valores del elemento por los nuevos
            {
                lista[actual].matricula = txtMatricula.Text;
                lista[actual].particular = Boolean.Parse(txtParticular.Text);
                lista[actual].marca = txtMarca.Text;
                lista[actual].precio = float.Parse(txtPrecio.Text);
                lista[actual].aniosEdad = int.Parse(txtAniosEdad.Text);
                if (txtNombreFoto.Text == "")
                {
                    lista[actual].fotoCoche = Image.FromFile("pordefecto.png");
                }
                else
                {
                    lista[actual].fotoCoche = Image.FromFile(txtNombreFoto.Text);
                }
            }

            mostrarElementos(actual);
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;

            //Comprobaciones de los botones

            if (isFirst())
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }
            if (isLast())
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
            }
            btnAniadir.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;
            txtPrimeraLetra.Enabled = true;
            modifyMode = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarElementos(actual);
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            if (isFirst())
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }

            if (isLast())
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
            }

            btnAniadir.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;
            txtPrimeraLetra.Enabled = true;
            modifyMode = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modifyMode = true; //Activamos el boolean para indicar que vamos a modificar
            modificar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (isFirst())
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }
            if (isLast())
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
            }

            borrarElemento();
        }
    }
}