using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaContable.Forms
{
    public partial class TransaccionesRangoFecha : Form
    {
        private string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        private DataGridView dgvTransacciones;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnBuscar;

        public TransaccionesRangoFecha()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgvTransacciones = new DataGridView();
            this.dtpFechaInicio = new DateTimePicker();
            this.dtpFechaFin = new DateTimePicker();
            this.btnBuscar = new Button();

            // Configuración del DataGridView
            this.dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacciones.Location = new Point(12, 12);
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.Size = new Size(760, 250);
            this.dgvTransacciones.TabIndex = 0;

            // Configuración del DateTimePicker de fecha de inicio
            this.dtpFechaInicio.Location = new Point(12, 280);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new Size(200, 20);
            this.dtpFechaInicio.TabIndex = 1;

            // Configuración del DateTimePicker de fecha de fin
            this.dtpFechaFin.Location = new Point(230, 280);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new Size(200, 20);
            this.dtpFechaFin.TabIndex = 2;

            // Configuración del botón de búsqueda
            this.btnBuscar.Location = new Point(460, 280);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(100, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new EventHandler(this.BtnBuscar_Click);

            // Configuración del formulario
            this.ClientSize = new Size(800, 350);
            this.Controls.Add(this.dgvTransacciones);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnBuscar);
            this.Name = "TransaccionesFecha";
            this.Text = "Consultas de Transacciones por Rango de Fechas";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.ResumeLayout(false);
        }

        // Evento de búsqueda
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            BuscarTransaccionesPorRangoDeFechas(fechaInicio, fechaFin);
        }

        // Método para cargar las transacciones por rango de fechas desde la base de datos
        private void BuscarTransaccionesPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para obtener transacciones entre dos fechas
                    string query = "SELECT Nro_Docu, Descripcion_Docu, Fecha_Docu, Tipo_Entrada, Monto_Transaccion " +
                                   "FROM cabecera_transaccion WHERE Fecha_Docu BETWEEN @FechaInicio AND @FechaFin";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Verificar si el DataTable contiene datos
                    if (dataTable.Rows.Count > 0)
                    {
                        // Asignar los resultados al DataGridView
                        dgvTransacciones.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron transacciones en el rango de fechas seleccionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las transacciones: " + ex.Message);
            }
        }
    }
}
