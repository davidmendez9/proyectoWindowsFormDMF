namespace proyectoFormDMF
{
    public partial class FormCoches : Form
    {
        List<Coche> lista = new List<Coche>();
        static int contador = -1;
        static int actual = 0;
        Boolean modifyMode = false;
        public FormCoches()
        {
            InitializeComponent();
            aniadirElemento("1234DMF", "Nissan", true, (float)2500.99, 20, Image.FromFile("nissan.jpg"));
            aniadirElemento("4567PPS", "Volvo", false, (float)4750.50, 15, Image.FromFile("volvo.jpg"));
            aniadirElemento("5643DVZ", "Volskwagen", true, (float)4000.52, 17, Image.FromFile("Volsk.jpg"));
            aniadirElemento("2472AND", "Ferrari", false, (float)200000, 4, Image.FromFile("Ferrari.jpg"));
            mostrarElementos(actual);
            btnAnterior.Enabled = false;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;

        }


        public void mostrarElementos(int contador)
        {
            txtNumero.Text = "" + lista[contador].numero;
            txtMatricula.Text = "" + lista[contador].matricula;
            txtMarca.Text = "" + lista[contador].marca;
            txtAniosEdad.Text = "" + lista[contador].aniosEdad;
            txtPrecio.Text = "" + lista[contador].precio;
            txtPrimeraLetra.Text = "" + lista[contador].primeraLetraMatricula;
            txtParticular.Text = "" + lista[contador].particular;
            pbFotoCoche.Image = lista[contador].fotoCoche;
        }

        public void aniadirElemento(string matricula, string marca, Boolean particular, float precio, int anios, Image fotoCoche)
        {
            lista.Add(new Coche(matricula, marca, particular, precio, anios, fotoCoche));
            contador++;
        }
        public void aniadirElementoSinFoto(string matricula, string marca, Boolean particular, float precio, int anios, String nombreFoto)
        {
            Image fotoCoche = Image.FromFile(nombreFoto);
            lista.Add(new Coche(matricula, marca, particular, precio, anios, fotoCoche));
            contador++;
        }
        private void avanzar()
        {
            actual++;
            btnAnterior.Enabled = true;
            if (actual == lista.Count - 1)
            {
                btnSiguiente.Enabled = false;
            }
            mostrarElementos(actual);
        }
        private void retroceder()
        {
            actual--;
            btnSiguiente.Enabled = true;
            if (actual == 0)
            {
                btnAnterior.Enabled = false;
            }
            mostrarElementos(actual);
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
            txtNumero.Enabled = false;
            txtPrimeraLetra.Enabled = false;
        }
        public void vaciarDatos()
        {
            txtMatricula.Clear();
            txtMarca.Clear();
            txtNumero.Clear();
            txtNumero.Clear();
            txtParticular.Clear();
            txtPrecio.Clear();
            txtPrimeraLetra.Clear();
            txtAniosEdad.Clear();
            txtNombreFoto.Clear();
            pbFotoCoche.Image = null;
            
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
            txtNumero.Enabled = false;
            txtPrimeraLetra.Enabled = false;
            txtNombreFoto.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!modifyMode)
            {
                aniadirElementoSinFoto(txtMatricula.Text, txtMarca.Text, Boolean.Parse(txtParticular.Text), float.Parse(txtPrecio.Text), int.Parse(txtAniosEdad.Text), txtNombreFoto.Text);
            }
            else
            {
                lista[actual].matricula = txtMatricula.Text;
                lista[actual].particular = Boolean.Parse(txtParticular.Text);
                lista[actual].marca = txtMarca.Text;
                lista[actual].precio = float.Parse(txtPrecio.Text);
                lista[actual].aniosEdad = int.Parse(txtAniosEdad.Text);
                lista[actual].fotoCoche = Image.FromFile(txtNombreFoto.Text);
            }

            mostrarElementos(actual);
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;
            btnAniadir.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;
            txtNumero.Enabled = true;
            txtPrimeraLetra.Enabled = true;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarElementos(actual);
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;
            btnAniadir.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            lblNombreFoto.Visible = false;
            txtNombreFoto.Visible = false;
            txtNumero.Enabled = true;
            txtPrimeraLetra.Enabled = true;
            txtNombreFoto.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modifyMode = true;
            modificar();
        }
    }
}