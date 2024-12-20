using System;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaContable.Forms
{
    partial class TransaccionContableForm : Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewTransacciones = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnCierreDiario = new Button();
            txtNroDoc = new TextBox();
            txtSecuenciaDoc = new TextBox();
            txtCuentaContable = new TextBox();
            txtValorDebito = new TextBox();
            txtValorCredito = new TextBox();
            txtComentario = new TextBox();
            labelNroDoc = new Label();
            labelSecuenciaDoc = new Label();
            labelCuentaContable = new Label();
            labelValorDebito = new Label();
            labelValorCredito = new Label();
            labelComentario = new Label();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFin = new DateTimePicker();
            labelFechaInicio = new Label();
            labelFechaFin = new Label();

            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).BeginInit();
            SuspendLayout();

            // 
            // dataGridViewTransacciones
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTransacciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTransacciones.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTransacciones.Location = new Point(20, 300);
            dataGridViewTransacciones.Name = "dataGridViewTransacciones";
            dataGridViewTransacciones.Size = new Size(740, 200);
            dataGridViewTransacciones.TabIndex = 0;
            dataGridViewTransacciones.CellClick += dataGridViewTransacciones_CellClick;

            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(76, 175, 80);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(355, 250);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 35);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Guardar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;

            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.Location = new Point(485, 250);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 35);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(244, 67, 54);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(615, 250);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // 
            // btnCierreDiario
            // 
            btnCierreDiario.BackColor = Color.FromArgb(33, 150, 243);
            btnCierreDiario.FlatStyle = FlatStyle.Flat;
            btnCierreDiario.ForeColor = Color.White;
            btnCierreDiario.Location = new Point(485, 200);
            btnCierreDiario.Name = "btnCierreDiario";
            btnCierreDiario.Size = new Size(100, 35);
            btnCierreDiario.TabIndex = 20;
            btnCierreDiario.Text = "Cierre Diario";
            btnCierreDiario.UseVisualStyleBackColor = false;
            btnCierreDiario.Click += btnCierreDiario_Click;

            // 
            // txtNroDoc
            // 
            txtNroDoc.Location = new Point(150, 20);
            txtNroDoc.Name = "txtNroDoc";
            txtNroDoc.Size = new Size(200, 23);
            txtNroDoc.TabIndex = 4;

            // 
            // txtSecuenciaDoc
            // 
            txtSecuenciaDoc.Location = new Point(150, 50);
            txtSecuenciaDoc.Name = "txtSecuenciaDoc";
            txtSecuenciaDoc.Size = new Size(200, 23);
            txtSecuenciaDoc.TabIndex = 5;

            // 
            // txtCuentaContable
            // 
            txtCuentaContable.Location = new Point(150, 80);
            txtCuentaContable.Name = "txtCuentaContable";
            txtCuentaContable.Size = new Size(200, 23);
            txtCuentaContable.TabIndex = 6;

            // 
            // txtValorDebito
            // 
            txtValorDebito.Location = new Point(150, 110);
            txtValorDebito.Name = "txtValorDebito";
            txtValorDebito.Size = new Size(200, 23);
            txtValorDebito.TabIndex = 7;

            // 
            // txtValorCredito
            // 
            txtValorCredito.Location = new Point(150, 140);
            txtValorCredito.Name = "txtValorCredito";
            txtValorCredito.Size = new Size(200, 23);
            txtValorCredito.TabIndex = 8;

            // 
            // txtComentario
            // 
            txtComentario.Location = new Point(150, 170);
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(200, 23);
            txtComentario.TabIndex = 9;

            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(150, 200);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(200, 23);
            dateTimePickerInicio.TabIndex = 16;

            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(150, 230);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(200, 23);
            dateTimePickerFin.TabIndex = 17;

            // 
            // labelNroDoc
            // 
            labelNroDoc.AutoSize = true;
            labelNroDoc.Location = new Point(20, 20);
            labelNroDoc.Name = "labelNroDoc";
            labelNroDoc.Size = new Size(136, 15);
            labelNroDoc.TabIndex = 10;
            labelNroDoc.Text = "Número de Documento:";

            // 
            // labelSecuenciaDoc
            // 
            labelSecuenciaDoc.AutoSize = true;
            labelSecuenciaDoc.Location = new Point(20, 50);
            labelSecuenciaDoc.Name = "labelSecuenciaDoc";
            labelSecuenciaDoc.Size = new Size(129, 15);
            labelSecuenciaDoc.TabIndex = 11;
            labelSecuenciaDoc.Text = "Secuencia Documento:";

            // 
            // labelCuentaContable
            // 
            labelCuentaContable.AutoSize = true;
            labelCuentaContable.Location = new Point(20, 80);
            labelCuentaContable.Name = "labelCuentaContable";
            labelCuentaContable.Size = new Size(104, 15);
            labelCuentaContable.TabIndex = 12;
            labelCuentaContable.Text = "Cuenta Contable:";

            // 
            // labelValorDebito
            // 
            labelValorDebito.AutoSize = true;
            labelValorDebito.Location = new Point(20, 110);
            labelValorDebito.Name = "labelValorDebito";
            labelValorDebito.Size = new Size(84, 15);
            labelValorDebito.TabIndex = 13;
            labelValorDebito.Text = "Valor Débito:";

            // 
            // labelValorCredito
            // 
            labelValorCredito.AutoSize = true;
            labelValorCredito.Location = new Point(20, 140);
            labelValorCredito.Name = "labelValorCredito";
            labelValorCredito.Size = new Size(94, 15);
            labelValorCredito.TabIndex = 14;
            labelValorCredito.Text = "Valor Crédito:";

            // 
            // labelComentario
            // 
            labelComentario.AutoSize = true;
            labelComentario.Location = new Point(20, 170);
            labelComentario.Name = "labelComentario";
            labelComentario.Size = new Size(80, 15);
            labelComentario.TabIndex = 15;
            labelComentario.Text = "Comentario:";

            // 
            // labelFechaInicio
            // 
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(20, 205);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(78, 15);
            labelFechaInicio.TabIndex = 18;
            labelFechaInicio.Text = "Fecha Inicio:";

            // 
            // labelFechaFin
            // 
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(20, 235);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(62, 15);
            labelFechaFin.TabIndex = 19;
            labelFechaFin.Text = "Fecha Fin:";

            // 
            // TransaccionContableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(dataGridViewTransacciones);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCierreDiario);
            Controls.Add(txtNroDoc);
            Controls.Add(txtSecuenciaDoc);
            Controls.Add(txtCuentaContable);
            Controls.Add(txtValorDebito);
            Controls.Add(txtValorCredito);
            Controls.Add(txtComentario);
            Controls.Add(labelNroDoc);
            Controls.Add(labelSecuenciaDoc);
            Controls.Add(labelCuentaContable);
            Controls.Add(labelValorDebito);
            Controls.Add(labelValorCredito);
            Controls.Add(labelComentario);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(dateTimePickerFin);
            Controls.Add(labelFechaInicio);
            Controls.Add(labelFechaFin);
            Name = "TransaccionContableForm";
            Text = "Gestión de Transacciones Contables";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Declaraciones de controles
        private DataGridView dataGridViewTransacciones;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnCierreDiario;
        private TextBox txtNroDoc;
        private TextBox txtSecuenciaDoc;
        private TextBox txtCuentaContable;
        private TextBox txtValorDebito;
        private TextBox txtValorCredito;
        private TextBox txtComentario;
        private Label labelNroDoc;
        private Label labelSecuenciaDoc;
        private Label labelCuentaContable;
        private Label labelValorDebito;
        private Label labelValorCredito;
        private Label labelComentario;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
        private Label labelFechaInicio;
        private Label labelFechaFin;
    }
}
