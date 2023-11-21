using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace proyectoFormDMF
{
    public partial class FormCoches : Form
    {
        private static List<Coche> lista = new List<Coche>(); //Lista principal

        static int contador = 0;
        static int actual = 0;
        Boolean modifyMode = false;
        public FormCoches()
        {
            InitializeComponent();
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

            this.FormClosing += FormCoches_FormClosing;
        }

        private void FormCoches_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Llama a escribirArchivo al cerrar el formulario
            escribirArchivo();
        }
        public void mostrarElementos(int actual)
        {
            if (lista.Count > 0 && actual >= 0 && actual < lista.Count)
            {
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
                Console.WriteLine("No hay elementos");
            }
        }

        public void leerArchivo()
        {
            string nombreArchivo = "databank.data";

            try
            {
                if (File.Exists(nombreArchivo))
                {
                    // Limpia la lista antes de leer nuevos datos
                    lista.Clear();

                    using (StreamReader reader = new StreamReader(nombreArchivo))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] datos = line.Split('-');

                            MessageBox.Show("Linea leida: " + datos[1] +contador);
                            
                            // Asegúrate de que hay suficientes elementos en el array antes de intentar acceder a ellos
                            if (datos.Length == 6)
                            {
                                string matricula = datos[0];
                                string marca = datos[1];
                                bool particular = bool.Parse(datos[2]);
                                float precio = float.Parse(datos[3]);
                                int anios = int.Parse(datos[4]);
                                string nombreFoto = datos[5];

                                
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
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes mostrar un mensaje de error, registrar el error, etc.)
                MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    foreach (Coche coche in lista)
                    {
                        // Formato de cada línea: matricula,marca,particular,precio,anios,nombreFoto
                        string linea = $"{coche.matricula}-{coche.marca}-{coche.particular}-{coche.precio}-{coche.aniosEdad}-{coche.nombreFoto}";
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes mostrar un mensaje de error, registrar el error, etc.)
                MessageBox.Show("Error al escribir en el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void aniadirElemento(string matricula, string marca, Boolean particular, float precio, int anios, String nombreFoto)
        {
            Image fotoCoche = Image.FromFile(nombreFoto);
            lista.Add(new Coche(matricula, marca, particular, precio, anios, fotoCoche, nombreFoto));
            contador++;
        }
        private Boolean isLast()
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

        private Boolean isFirst()
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
        private void avanzar()
        {
            if (actual < lista.Count - 1)
            {
                actual++;
                btnAnterior.Enabled = true;
                if (isLast())
                {
                    btnSiguiente.Enabled = false;
                }
                mostrarElementos(actual);
            }
        }
        private void retroceder()
        {
            if (actual > 0)
            {
                actual--;
                btnSiguiente.Enabled = true;
                if (isFirst())
                {
                    btnAnterior.Enabled = false;
                }
                mostrarElementos(actual);
            }
        }
        public void modificar()
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
        public void vaciarDatos()
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

        public void borrarElemento()
        {
            if (contador > 1)
            {
                lista.RemoveAt(actual);
                actual = 0;
                contador--;
                mostrarElementos(actual);
                btnAnterior.Enabled = false;
            }
            else if (contador == 1)
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
            if (!modifyMode)
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
            else
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
            modifyMode = true;
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