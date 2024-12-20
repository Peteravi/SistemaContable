using System;
using System.Windows.Forms;

namespace SistemaContable.Forms
{
    public class FormGastosGenerales : Form
    {
        private DataGridView dataGridViewGastos;
        private Button btnConsultar;

        public FormGastosGenerales()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dataGridViewGastos = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewGastos
            // 
            this.dataGridViewGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGastos.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewGastos.Name = "dataGridViewGastos";
            this.dataGridViewGastos.Size = new System.Drawing.Size(560, 300);
            this.dataGridViewGastos.TabIndex = 0;

            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(250, 330);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);

            // 
            // FormGastosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dataGridViewGastos);
            this.Name = "FormGastosGenerales";
            this.Text = "Consulta de Gastos Generales";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Agrega la lógica para consultar los gastos generales aquí
            MessageBox.Show("Consulta de gastos generales realizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
