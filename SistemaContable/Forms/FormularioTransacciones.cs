using SistemaContable.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaContable.Forms
{
    public partial class FormularioTransacciones : Form
    {
        private List<Transaccion> transacciones;
        private int numeroDocumento;
        private List<string> catalogoCuentas;
        private string usuarioActual = "";

        public FormularioTransacciones()
        {
            InitializeComponent();
            transacciones = new List<Transaccion>();
            numeroDocumento = 1; // Número inicial del documento
            catalogoCuentas = new List<string> { "Caja", "Bancos", "Ingresos", "Gastos", "Ajustes", "Interno" };
        }

        private void FormularioTransacciones_Load(object sender, EventArgs e)
        {
            // Cargar las transacciones desde la base de datos
            transacciones = ObtenerTransacciones();

            dgvTransacciones.Rows.Clear();

            foreach (var transaccion in transacciones)
            {
                dgvTransacciones.Rows.Add(
                    transaccion.Nro_Doc,
                    transaccion.Descripcion,  // Corregido: "Descripción"
                    transaccion.Fecha.ToString("dd/MM/yyyy"), // Corregido: "Fecha"
                    transaccion.Tipo,
                    transaccion.Monto.ToString("F2"),
                    transaccion.Hecho_Por
                );
            }
        }

        private void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(txtDescripcionTransaccion.Text) || string.IsNullOrEmpty(txtMonto.Text) || cbTipoTransaccion.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar tipo de transacción
            string tipoTransaccion = cbTipoTransaccion.SelectedItem.ToString();
            if (!new[] { "Factura", "Ajuste", "Interno", "Crédito", "Débito" }.Contains(tipoTransaccion))
            {
                MessageBox.Show("El tipo de transacción no es válido.");
                return;
            }

            // Validar monto
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido.");
                return;
            }

            // Generar número de documento
            string nroDoc = "DOC" + numeroDocumento.ToString("D5");
            if (transacciones.Any(t => t.Nro_Doc == nroDoc))
            {
                MessageBox.Show("El número de documento ya existe.");
                return;
            }

            // Validar cuenta contable
            string cuenta = "Caja"; // Se selecciona automáticamente para este ejemplo
            if (!catalogoCuentas.Contains(cuenta))
            {
                MessageBox.Show("La cuenta contable no existe en el catálogo.");
                return;
            }

            // Crear transacción
            decimal debito = (tipoTransaccion == "Débito") ? monto : 0;
            decimal credito = (tipoTransaccion == "Crédito") ? monto : 0;

            Transaccion nuevaTransaccion = new Transaccion(
                DateTime.Now, // Fecha actual del sistema
                cuenta,
                monto,
                txtDescripcionTransaccion.Text,
                tipoTransaccion,
                debito,
                credito,
                nroDoc,
                usuarioActual // Asigna automáticamente el usuario
            );

            // Agregar transacción a la lista
            transacciones.Add(nuevaTransaccion);
            numeroDocumento++;

            // Actualizar vista
            MessageBox.Show("Transacción agregada correctamente.");
            FormularioTransacciones_Load(sender, e);

            // Guardar en archivo TXT
            GuardarTransaccionesEnArchivo();

            // Limpiar campos
            LimpiarCampos();
        }

        private void GuardarTransaccionesEnArchivo()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Transacciones.txt");
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.WriteLine("Nro_Doc\tFecha\tCuenta\tTipo\tMonto\tHecho_Por");
                foreach (var t in transacciones)
                {
                    writer.WriteLine($"{t.Nro_Doc}\t{t.Fecha:dd/MM/yyyy}\t{t.Cuenta}\t{t.Tipo}\t{t.Monto:F2}\t{t.Hecho_Por}");
                }
            }
            MessageBox.Show($"Transacciones guardadas en: {ruta}");
        }

        private void LimpiarCampos()
        {
            txtDescripcionTransaccion.Clear();
            txtMonto.Clear();
            cbTipoTransaccion.SelectedIndex = -1;
            dtpFechaTransaccion.Value = DateTime.Now;
        }

        // Función para obtener las transacciones desde la base de datos
        private List<Transaccion> ObtenerTransacciones()
        {
            List<Transaccion> transacciones = new List<Transaccion>();

            // Cadena de conexión a la base de datos
            string connectionString = "Server=localhost;Database=sistemcontable;Uid=root;Pwd=piteravi07;";

            // Consulta SQL para obtener las transacciones
            string query = "SELECT Nro_Docu, Descripcion_Docu, Fecha_Docu, Tipo_Entrada, Monto_Transaccion FROM cabecera_transaccion";

            try
            {
                // Crear conexión a la base de datos
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Crear adaptador para ejecutar la consulta
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);

                    // Crear un DataTable para almacenar los resultados
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la consulta
                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    // Iterar sobre cada fila del DataTable y crear objetos Transaccion
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string nroDoc = row["Nro_Docu"].ToString();
                        string descripcion = row["Descripcion_Docu"].ToString();
                        DateTime fecha = Convert.ToDateTime(row["Fecha_Docu"]);
                        int tipoEntrada = Convert.ToInt32(row["Tipo_Entrada"]);
                        decimal montoTransaccion = Convert.ToDecimal(row["Monto_Transaccion"]);

                        // Asignar valores de débito y crédito dependiendo del tipo de transacción
                        decimal debito = 0;
                        decimal credito = 0;

                        if (tipoEntrada == 1)
                        {
                            debito = montoTransaccion;
                        }
                        else if (tipoEntrada == 2)
                        {
                            credito = montoTransaccion;
                        }

                        // Crear la transacción a partir de los datos obtenidos
                        Transaccion transaccion = new Transaccion(
                            fecha,
                            "Caja",
                            montoTransaccion,
                            descripcion,
                            tipoEntrada == 1 ? "Débito" : "Crédito",
                            debito,
                            credito,
                            nroDoc,
                            "Usuario Actual"
                        );

                        // Agregar la transacción a la lista
                        transacciones.Add(transaccion);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores en caso de que la conexión falle o haya un problema con la consulta
                MessageBox.Show("Error al obtener las transacciones: " + ex.Message);
            }

            // Retornar la lista de transacciones obtenidas
            return transacciones;
        }
    }
}
