using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaContable.Forms
{
    partial class FormularioCuentasContables
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAgregarCuenta;
        private TextBox txtNoCta;
        private TextBox txtDescripcionCta;
        private ComboBox cbTipoCta;
        private TextBox txtNivelCta;
        private TextBox txtGrupoCta;
        private TextBox txtDebitoCta;
        private TextBox txtCreditoCta;
        private TextBox txtBalanceCta;
        private DataGridView dgvCuentasContables;
        private GroupBox groupBoxDatosCuenta;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Label lblNoCta;
        private Label lblDescripcionCta;
        private Label lblTipoCta;
        private Label lblNivelCta;
        private Label lblGrupoCta;
        private Label lblDebitoCta;
        private Label lblCreditoCta;
        private Label lblBalanceCta;

        private void InitializeComponent()
        {
            groupBoxDatosCuenta = new GroupBox();
            lblNoCta = new Label();
            txtNoCta = new TextBox();
            lblDescripcionCta = new Label();
            txtDescripcionCta = new TextBox();
            lblTipoCta = new Label();
            cbTipoCta = new ComboBox();
            lblNivelCta = new Label();
            txtNivelCta = new TextBox();
            lblGrupoCta = new Label();
            txtGrupoCta = new TextBox();
            lblDebitoCta = new Label();
            txtDebitoCta = new TextBox();
            lblCreditoCta = new Label();
            txtCreditoCta = new TextBox();
            lblBalanceCta = new Label();
            txtBalanceCta = new TextBox();
            btnAgregarCuenta = new Button();
            dgvCuentasContables = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            groupBoxDatosCuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentasContables).BeginInit();
            SuspendLayout();

            // 
            // groupBoxDatosCuenta
            // 
            groupBoxDatosCuenta.BackColor = Color.WhiteSmoke;
            groupBoxDatosCuenta.Controls.Add(lblNoCta);
            groupBoxDatosCuenta.Controls.Add(txtNoCta);
            groupBoxDatosCuenta.Controls.Add(lblDescripcionCta);
            groupBoxDatosCuenta.Controls.Add(txtDescripcionCta);
            groupBoxDatosCuenta.Controls.Add(lblTipoCta);
            groupBoxDatosCuenta.Controls.Add(cbTipoCta);
            groupBoxDatosCuenta.Controls.Add(lblNivelCta);
            groupBoxDatosCuenta.Controls.Add(txtNivelCta);
            groupBoxDatosCuenta.Controls.Add(lblGrupoCta);
            groupBoxDatosCuenta.Controls.Add(txtGrupoCta);
            groupBoxDatosCuenta.Controls.Add(lblDebitoCta);
            groupBoxDatosCuenta.Controls.Add(txtDebitoCta);
            groupBoxDatosCuenta.Controls.Add(lblCreditoCta);
            groupBoxDatosCuenta.Controls.Add(txtCreditoCta);
            groupBoxDatosCuenta.Controls.Add(lblBalanceCta);
            groupBoxDatosCuenta.Controls.Add(txtBalanceCta);
            groupBoxDatosCuenta.Controls.Add(btnAgregarCuenta);
            groupBoxDatosCuenta.Font = new Font("Segoe UI", 10F);
            groupBoxDatosCuenta.ForeColor = Color.FromArgb(45, 45, 48);
            groupBoxDatosCuenta.Location = new Point(12, 12);
            groupBoxDatosCuenta.Name = "groupBoxDatosCuenta";
            groupBoxDatosCuenta.Padding = new Padding(15);
            groupBoxDatosCuenta.Size = new Size(400, 500); // Adjusted size for better layout
            groupBoxDatosCuenta.TabIndex = 0;
            groupBoxDatosCuenta.TabStop = false;
            groupBoxDatosCuenta.Text = "Datos de Cuenta";

            // 
            // lblNoCta
            // 
            lblNoCta.Location = new Point(15, 30);
            lblNoCta.Name = "lblNoCta";
            lblNoCta.Size = new Size(120, 25);
            lblNoCta.Text = "Número Cuenta";
            // 
            // txtNoCta
            // 
            txtNoCta.Location = new Point(140, 30);
            txtNoCta.Name = "txtNoCta";
            txtNoCta.Size = new Size(200, 25);
            txtNoCta.TabIndex = 1;
            // 
            // lblDescripcionCta
            // 
            lblDescripcionCta.Location = new Point(15, 70);
            lblDescripcionCta.Name = "lblDescripcionCta";
            lblDescripcionCta.Size = new Size(120, 25);
            lblDescripcionCta.Text = "Descripción";
            // 
            // txtDescripcionCta
            // 
            txtDescripcionCta.Location = new Point(140, 70);
            txtDescripcionCta.Name = "txtDescripcionCta";
            txtDescripcionCta.Size = new Size(200, 25);
            txtDescripcionCta.TabIndex = 2;
            // 
            // lblTipoCta
            // 
            lblTipoCta.Location = new Point(15, 110);
            lblTipoCta.Name = "lblTipoCta";
            lblTipoCta.Size = new Size(120, 25);
            lblTipoCta.Text = "Tipo de Cuenta";
            // 
            // cbTipoCta
            // 
            cbTipoCta.Location = new Point(140, 110);
            cbTipoCta.Name = "cbTipoCta";
            cbTipoCta.Size = new Size(200, 25);
            cbTipoCta.TabIndex = 3;
            // 
            // lblNivelCta
            // 
            lblNivelCta.Location = new Point(15, 150);
            lblNivelCta.Name = "lblNivelCta";
            lblNivelCta.Size = new Size(120, 25);
            lblNivelCta.Text = "Nivel de Cuenta";
            // 
            // txtNivelCta
            // 
            txtNivelCta.Location = new Point(140, 150);
            txtNivelCta.Name = "txtNivelCta";
            txtNivelCta.Size = new Size(200, 25);
            txtNivelCta.TabIndex = 4;
            // 
            // lblGrupoCta
            // 
            lblGrupoCta.Location = new Point(15, 190);
            lblGrupoCta.Name = "lblGrupoCta";
            lblGrupoCta.Size = new Size(120, 25);
            lblGrupoCta.Text = "Grupo de Cuenta";
            // 
            // txtGrupoCta
            // 
            txtGrupoCta.Location = new Point(140, 190);
            txtGrupoCta.Name = "txtGrupoCta";
            txtGrupoCta.Size = new Size(200, 25);
            txtGrupoCta.TabIndex = 5;
            // 
            // lblDebitoCta
            // 
            lblDebitoCta.Location = new Point(15, 230);
            lblDebitoCta.Name = "lblDebitoCta";
            lblDebitoCta.Size = new Size(120, 25);
            lblDebitoCta.Text = "Débito";
            // 
            // txtDebitoCta
            // 
            txtDebitoCta.Location = new Point(140, 230);
            txtDebitoCta.Name = "txtDebitoCta";
            txtDebitoCta.Size = new Size(200, 25);
            txtDebitoCta.TabIndex = 6;
            // 
            // lblCreditoCta
            // 
            lblCreditoCta.Location = new Point(15, 270);
            lblCreditoCta.Name = "lblCreditoCta";
            lblCreditoCta.Size = new Size(120, 25);
            lblCreditoCta.Text = "Crédito";
            // 
            // txtCreditoCta
            // 
            txtCreditoCta.Location = new Point(140, 270);
            txtCreditoCta.Name = "txtCreditoCta";
            txtCreditoCta.Size = new Size(200, 25);
            txtCreditoCta.TabIndex = 7;
            // 
            // lblBalanceCta
            // 
            lblBalanceCta.Location = new Point(15, 310);
            lblBalanceCta.Name = "lblBalanceCta";
            lblBalanceCta.Size = new Size(120, 25);
            lblBalanceCta.Text = "Balance";
            // 
            // txtBalanceCta
            // 
            txtBalanceCta.Location = new Point(140, 310);
            txtBalanceCta.Name = "txtBalanceCta";
            txtBalanceCta.Size = new Size(200, 25);
            txtBalanceCta.TabIndex = 8;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.BackColor = Color.FromArgb(56, 113, 131);
            btnAgregarCuenta.ForeColor = Color.White;
            btnAgregarCuenta.Location = new Point(140, 350);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(200, 35);
            btnAgregarCuenta.TabIndex = 9;
            btnAgregarCuenta.Text = "Guardar";
            btnAgregarCuenta.UseVisualStyleBackColor = false;
            btnAgregarCuenta.Click += new EventHandler(btnAgregarCuenta_Click);

            // 
            // dgvCuentasContables
            // 
            dgvCuentasContables.BackgroundColor = Color.White;
            dgvCuentasContables.BorderStyle = BorderStyle.None;
            dgvCuentasContables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentasContables.Columns.AddRange(new DataGridViewColumn[]
            {
                dataGridViewTextBoxColumn1,
                dataGridViewTextBoxColumn2,
                dataGridViewTextBoxColumn3,
                dataGridViewTextBoxColumn4,
                dataGridViewTextBoxColumn5,
                dataGridViewTextBoxColumn6,
                dataGridViewTextBoxColumn7,
                dataGridViewTextBoxColumn8
            });
            dgvCuentasContables.Location = new Point(420, 12);
            dgvCuentasContables.Name = "dgvCuentasContables";
            dgvCuentasContables.RowHeadersWidth = 51;
            dgvCuentasContables.RowTemplate.Height = 25;
            dgvCuentasContables.Size = new Size(600, 400); // Adjusted size for better view
            dgvCuentasContables.TabIndex = 10;

            // DataGridView columns setup
            dataGridViewTextBoxColumn1.HeaderText = "Número Cuenta";
            dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            dataGridViewTextBoxColumn4.HeaderText = "Nivel";
            dataGridViewTextBoxColumn5.HeaderText = "Grupo";
            dataGridViewTextBoxColumn6.HeaderText = "Débito";
            dataGridViewTextBoxColumn7.HeaderText = "Crédito";
            dataGridViewTextBoxColumn8.HeaderText = "Balance";

            // 
            // FormularioCuentasContables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 530); // Adjusted form size
            Controls.Add(groupBoxDatosCuenta);
            Controls.Add(dgvCuentasContables);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormularioCuentasContables";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulario Cuentas Contables";
            groupBoxDatosCuenta.ResumeLayout(false);
            groupBoxDatosCuenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentasContables).EndInit();
            ResumeLayout(false);
        }

        
        private void ClearInputs()
        {
            // Limpiar todos los campos de texto
            txtNoCta.Clear();
            txtDescripcionCta.Clear();
            txtNivelCta.Clear();
            txtGrupoCta.Clear();
            txtDebitoCta.Clear();
            txtCreditoCta.Clear();
            txtBalanceCta.Clear();

            // Restablecer el ComboBox a su valor predeterminado (sin selección)
            cbTipoCta.SelectedIndex = -1;
        }


    }
}
