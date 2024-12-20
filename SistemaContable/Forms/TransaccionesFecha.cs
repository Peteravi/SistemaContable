using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaContable.Forms
{
    public partial class TransaccionesFecha : Form
    {
        private string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        private DataGridView dgvTransacciones;
        private DateTimePicker dtpFecha;
        private Button btnBuscar;

        public TransaccionesFecha()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgvTransacciones = new DataGridView();
            this.dtpFecha = new DateTimePicker();
            this.btnBuscar = new Button();

            // Configuración del DataGridView
            this.dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacciones.Location = new Point(12, 12);
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.Size = new Size(760, 250);
            this.dgvTransacciones.TabIndex = 0;

            // Configuración del DateTimePicker
            this.dtpFecha.Location = new Point(12, 280);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new Size(200, 20);
            this.dtpFecha.TabIndex = 1;

            // Configuración del botón de búsqueda
            this.btnBuscar.Location = new Point(230, 280);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(100, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new EventHandler(this.BtnBuscar_Click);

            // Configuración del formulario
            this.ClientSize = new Size(800, 350);
            this.Controls.Add(this.dgvTransacciones);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnBuscar);
            this.Name = "TransaccionesFecha";
            this.Text = "Consultas de Transacciones por Fecha";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.ResumeLayout(false);
        }

        // Evento de búsqueda
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaBusqueda = dtpFecha.Value.Date;
            BuscarTransaccionesPorFecha(fechaBusqueda);
        }

        // Método para cargar las transacciones por fecha desde la base de datos
        private void BuscarTransaccionesPorFecha(DateTime fecha)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Nro_Docu, Descripcion_Docu, Fecha_Docu, Tipo_Entrada, Monto_Transaccion FROM cabecera_transaccion WHERE Fecha_Docu = @Fecha";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Fecha", fecha);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar los resultados al DataGridView
                    dgvTransacciones.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las transacciones: " + ex.Message);
            }
        }
    }
}
