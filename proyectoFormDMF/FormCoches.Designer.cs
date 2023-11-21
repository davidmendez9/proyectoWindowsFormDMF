namespace proyectoFormDMF
{
    partial class FormCoches
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMatricula = new Label();
            lblPrimeraLetra = new Label();
            lblMarca = new Label();
            lblParticular = new Label();
            lblPrecio = new Label();
            lblAniosEdad = new Label();
            lblImagen = new Label();
            pbFotoCoche = new PictureBox();
            txtMatricula = new TextBox();
            txtPrimeraLetra = new TextBox();
            txtMarca = new TextBox();
            txtParticular = new TextBox();
            txtPrecio = new TextBox();
            txtAniosEdad = new TextBox();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnModificar = new Button();
            btnAniadir = new Button();
            btnBorrar = new Button();
            lblNombreFoto = new Label();
            txtNombreFoto = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbFotoCoche).BeginInit();
            SuspendLayout();
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(58, 156);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(74, 20);
            lblMatricula.TabIndex = 0;
            lblMatricula.Text = "Matrícula:";
            // 
            // lblPrimeraLetra
            // 
            lblPrimeraLetra.AutoSize = true;
            lblPrimeraLetra.Location = new Point(58, 200);
            lblPrimeraLetra.Name = "lblPrimeraLetra";
            lblPrimeraLetra.Size = new Size(100, 20);
            lblPrimeraLetra.TabIndex = 1;
            lblPrimeraLetra.Text = "Primera Letra:";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(58, 241);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(53, 20);
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca:";
            // 
            // lblParticular
            // 
            lblParticular.AutoSize = true;
            lblParticular.Location = new Point(58, 277);
            lblParticular.Name = "lblParticular";
            lblParticular.Size = new Size(73, 20);
            lblParticular.TabIndex = 3;
            lblParticular.Text = "Particular:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(58, 313);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio:";
            // 
            // lblAniosEdad
            // 
            lblAniosEdad.AutoSize = true;
            lblAniosEdad.Location = new Point(58, 352);
            lblAniosEdad.Name = "lblAniosEdad";
            lblAniosEdad.Size = new Size(45, 20);
            lblAniosEdad.TabIndex = 5;
            lblAniosEdad.Text = "Años:";
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Location = new Point(623, 67);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(62, 20);
            lblImagen.TabIndex = 6;
            lblImagen.Text = "Imagen:";
            // 
            // pbFotoCoche
            // 
            pbFotoCoche.Location = new Point(465, 101);
            pbFotoCoche.Name = "pbFotoCoche";
            pbFotoCoche.Size = new Size(379, 333);
            pbFotoCoche.SizeMode = PictureBoxSizeMode.Zoom;
            pbFotoCoche.TabIndex = 7;
            pbFotoCoche.TabStop = false;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(189, 153);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(229, 27);
            txtMatricula.TabIndex = 8;
            // 
            // txtPrimeraLetra
            // 
            txtPrimeraLetra.Location = new Point(189, 197);
            txtPrimeraLetra.Name = "txtPrimeraLetra";
            txtPrimeraLetra.Size = new Size(37, 27);
            txtPrimeraLetra.TabIndex = 9;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(189, 238);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(229, 27);
            txtMarca.TabIndex = 10;
            // 
            // txtParticular
            // 
            txtParticular.Location = new Point(189, 274);
            txtParticular.Name = "txtParticular";
            txtParticular.Size = new Size(229, 27);
            txtParticular.TabIndex = 11;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(189, 310);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(229, 27);
            txtPrecio.TabIndex = 12;
            // 
            // txtAniosEdad
            // 
            txtAniosEdad.Location = new Point(189, 349);
            txtAniosEdad.Name = "txtAniosEdad";
            txtAniosEdad.Size = new Size(229, 27);
            txtAniosEdad.TabIndex = 13;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(502, 463);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(144, 154);
            btnAnterior.TabIndex = 14;
            btnAnterior.Text = "<--";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(660, 463);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(144, 154);
            btnSiguiente.TabIndex = 15;
            btnSiguiente.Text = "-->";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(176, 463);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(167, 31);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAniadir
            // 
            btnAniadir.Location = new Point(176, 525);
            btnAniadir.Name = "btnAniadir";
            btnAniadir.Size = new Size(167, 31);
            btnAniadir.TabIndex = 17;
            btnAniadir.Text = "Añadir";
            btnAniadir.UseVisualStyleBackColor = true;
            btnAniadir.Click += btnAniadir_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(176, 586);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(167, 31);
            btnBorrar.TabIndex = 18;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // lblNombreFoto
            // 
            lblNombreFoto.AutoSize = true;
            lblNombreFoto.Location = new Point(61, 393);
            lblNombreFoto.Name = "lblNombreFoto";
            lblNombreFoto.Size = new Size(101, 20);
            lblNombreFoto.TabIndex = 21;
            lblNombreFoto.Text = "Nombre Foto:";
            // 
            // txtNombreFoto
            // 
            txtNombreFoto.Location = new Point(189, 390);
            txtNombreFoto.Name = "txtNombreFoto";
            txtNombreFoto.Size = new Size(229, 27);
            txtNombreFoto.TabIndex = 22;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(349, 525);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(98, 30);
            btnAceptar.TabIndex = 23;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(76, 525);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 31);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormCoches
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 673);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtNombreFoto);
            Controls.Add(lblNombreFoto);
            Controls.Add(btnBorrar);
            Controls.Add(btnAniadir);
            Controls.Add(btnModificar);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(txtAniosEdad);
            Controls.Add(txtPrecio);
            Controls.Add(txtParticular);
            Controls.Add(txtMarca);
            Controls.Add(txtPrimeraLetra);
            Controls.Add(txtMatricula);
            Controls.Add(pbFotoCoche);
            Controls.Add(lblImagen);
            Controls.Add(lblAniosEdad);
            Controls.Add(lblPrecio);
            Controls.Add(lblParticular);
            Controls.Add(lblMarca);
            Controls.Add(lblPrimeraLetra);
            Controls.Add(lblMatricula);
            Name = "FormCoches";
            Text = "Formulario Coches";
            ((System.ComponentModel.ISupportInitialize)pbFotoCoche).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMatricula;
        private Label lblPrimeraLetra;
        private Label lblMarca;
        private Label lblParticular;
        private Label lblPrecio;
        private Label lblAniosEdad;
        private Label lblImagen;
        private PictureBox pbFotoCoche;
        private TextBox txtMatricula;
        private TextBox txtPrimeraLetra;
        private TextBox txtMarca;
        private TextBox txtParticular;
        private TextBox txtPrecio;
        private TextBox txtAniosEdad;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnModificar;
        private Button btnAniadir;
        private Button btnBorrar;
        private Label lblNombreFoto;
        private TextBox txtNombreFoto;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}