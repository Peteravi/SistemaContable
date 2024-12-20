using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaContable.Forms
{
    partial class FormularioTransacciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Inicialización de controles
            dgvTransacciones = new DataGridView();
            NoTransaccion = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            TipoTransaccion = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();

            txtDescripcionTransaccion = new TextBox();
            dtpFechaTransaccion = new DateTimePicker();
            cbTipoTransaccion = new ComboBox();
            txtMonto = new TextBox();
            btnAgregarTransaccion = new Button();

            groupBoxDatosTransaccion = new GroupBox();
            lblDescripcion = new Label();
            lblFecha = new Label();
            lblTipoTransaccion = new Label();
            lblMonto = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).BeginInit();
            groupBoxDatosTransaccion.SuspendLayout();
            SuspendLayout();

            // --------------------------
            // Configuración de DataGridView
            // --------------------------
            dgvTransacciones.AllowUserToAddRows = false;
            dgvTransacciones.AllowUserToDeleteRows = false;
            dgvTransacciones.BackgroundColor = Color.WhiteSmoke;
            dgvTransacciones.BorderStyle = BorderStyle.Fixed3D;
            dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransacciones.Columns.AddRange(new DataGridViewColumn[]
            {
                NoTransaccion, Descripcion, Fecha, TipoTransaccion, Monto
            });
            dgvTransacciones.GridColor = Color.LightGray;
            dgvTransacciones.Location = new Point(12, 250);
            dgvTransacciones.Name = "dgvTransacciones";
            dgvTransacciones.ReadOnly = true;
            dgvTransacciones.RowHeadersVisible = false;
            dgvTransacciones.Size = new Size(776, 180);
            dgvTransacciones.TabIndex = 0;

            // Configuración de columnas
            NoTransaccion.HeaderText = "No. Transacción";
            NoTransaccion.Name = "NoTransaccion";
            NoTransaccion.ReadOnly = true;

            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripción";
            Descripcion.ReadOnly = true;

            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;

            TipoTransaccion.HeaderText = "Tipo de Transacción";
            TipoTransaccion.Name = "TipoTransaccion";
            TipoTransaccion.ReadOnly = true;

            Monto.HeaderText = "Monto";
            Monto.Name = "Monto";
            Monto.ReadOnly = true;

            // --------------------------
            // Configuración de GroupBox
            // --------------------------
            groupBoxDatosTransaccion.Controls.Add(lblDescripcion);
            groupBoxDatosTransaccion.Controls.Add(txtDescripcionTransaccion);
            groupBoxDatosTransaccion.Controls.Add(lblFecha);
            groupBoxDatosTransaccion.Controls.Add(dtpFechaTransaccion);
            groupBoxDatosTransaccion.Controls.Add(lblTipoTransaccion);
            groupBoxDatosTransaccion.Controls.Add(cbTipoTransaccion);
            groupBoxDatosTransaccion.Controls.Add(lblMonto);
            groupBoxDatosTransaccion.Controls.Add(txtMonto);

            groupBoxDatosTransaccion.ForeColor = Color.DarkSlateGray;
            groupBoxDatosTransaccion.Location = new Point(12, 12);
            groupBoxDatosTransaccion.Name = "groupBoxDatosTransaccion";
            groupBoxDatosTransaccion.Size = new Size(393, 155);
            groupBoxDatosTransaccion.TabIndex = 6;
            groupBoxDatosTransaccion.TabStop = false;
            groupBoxDatosTransaccion.Text = "Datos de la Transacción";

            // --------------------------
            // Labels y TextBox
            // --------------------------
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(6, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(80, 15);
            lblDescripcion.Text = "Descripción:";

            txtDescripcionTransaccion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcionTransaccion.Location = new Point(120, 35);
            txtDescripcionTransaccion.Name = "txtDescripcionTransaccion";
            txtDescripcionTransaccion.Size = new Size(260, 23);

            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(6, 64);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(45, 15);
            lblFecha.Text = "Fecha:";

            dtpFechaTransaccion.Location = new Point(120, 61);
            dtpFechaTransaccion.Name = "dtpFechaTransaccion";
            dtpFechaTransaccion.Size = new Size(260, 23);

            lblTipoTransaccion.AutoSize = true;
            lblTipoTransaccion.Location = new Point(6, 90);
            lblTipoTransaccion.Name = "lblTipoTransaccion";
            lblTipoTransaccion.Size = new Size(112, 15);
            lblTipoTransaccion.Text = "Tipo de Transacción:";

            cbTipoTransaccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoTransaccion.FormattingEnabled = true;
            cbTipoTransaccion.Items.AddRange(new object[] { "Débito", "Crédito" });
            cbTipoTransaccion.Location = new Point(120, 87);
            cbTipoTransaccion.Name = "cbTipoTransaccion";
            cbTipoTransaccion.Size = new Size(150, 23);

            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(6, 119);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(46, 15);
            lblMonto.Text = "Monto:";

            txtMonto.BorderStyle = BorderStyle.FixedSingle;
            txtMonto.Location = new Point(120, 116);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(150, 23);

            // --------------------------
            // Botón Agregar Transacción
            // --------------------------
            btnAgregarTransaccion.BackColor = Color.LightSkyBlue;
            btnAgregarTransaccion.Cursor = Cursors.Hand;
            btnAgregarTransaccion.FlatAppearance.BorderSize = 0;
            btnAgregarTransaccion.FlatStyle = FlatStyle.Flat;
            btnAgregarTransaccion.ForeColor = Color.White;
            btnAgregarTransaccion.Location = new Point(12, 173);
            btnAgregarTransaccion.Name = "btnAgregarTransaccion";
            btnAgregarTransaccion.Size = new Size(200, 35);
            btnAgregarTransaccion.TabIndex = 5;
            btnAgregarTransaccion.Text = "GUARDAR";
            btnAgregarTransaccion.UseVisualStyleBackColor = false;
            btnAgregarTransaccion.Click += btnAgregarTransaccion_Click;

            // --------------------------
            // Configuración principal del formulario
            // --------------------------
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxDatosTransaccion);
            Controls.Add(btnAgregarTransaccion);
            Controls.Add(dgvTransacciones);

            Name = "FormularioTransacciones";
            Text = "Gestión de Transacciones";
            Load += FormularioTransacciones_Load;

            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).EndInit();
            groupBoxDatosTransaccion.ResumeLayout(false);
            groupBoxDatosTransaccion.PerformLayout();
            ResumeLayout(false);
        }

        // Declaración de controles
        private System.Windows.Forms.DataGridView dgvTransacciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;

        private System.Windows.Forms.TextBox txtDescripcionTransaccion;
        private System.Windows.Forms.DateTimePicker dtpFechaTransaccion;
        private System.Windows.Forms.ComboBox cbTipoTransaccion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAgregarTransaccion;
        private System.Windows.Forms.GroupBox groupBoxDatosTransaccion;

        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTipoTransaccion;
        private System.Windows.Forms.Label lblMonto;
    }
}
