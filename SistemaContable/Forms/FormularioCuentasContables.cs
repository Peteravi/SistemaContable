using MySql.Data.MySqlClient;
using SistemaContable.Models.SistemaContable.Models.SistemaContable.Models;

namespace SistemaContable.Forms
{
    public partial class FormularioCuentasContables : Form
    {
        private List<CuentaContable> cuentasContables;
        private static string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07";

        public FormularioCuentasContables()
        {
            InitializeComponent();
            cuentasContables = new List<CuentaContable>();
            CargarCuentas();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void CargarCuentas()
        {
            dgvCuentasContables.Rows.Clear();
            cuentasContables = ObtenerCuentasDB();

            foreach (var cuenta in cuentasContables)
            {
                string tipoCuenta = cuenta.Tipo_Cta_ID == 1 ? "General" : "Detalle";

                dgvCuentasContables.Rows.Add(
                    cuenta.No_Cta,
                    cuenta.Descripcion_Cta,
                    tipoCuenta,
                    cuenta.Nivel_Cta,
                    cuenta.Grupo_Cta,
                    cuenta.Debito_Acumulado,
                    cuenta.Credito_Acumulado,
                    cuenta.Balance
                );
            }
        }

        private List<CuentaContable> ObtenerCuentasDB()
        {
            List<CuentaContable> cuentas = new List<CuentaContable>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT No_Cta, Descripcion_Cta, Tipo_Cta_ID, Debito_Acum_Cta, Credito_Acum_Cta, Grupo_Cta, Balance_Cta, Fecha_Creacion_Cta " +
                                   "FROM catalogo_cuenta_contable;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CuentaContable cuenta = new CuentaContable(
                                    noCta: reader.IsDBNull(reader.GetOrdinal("No_Cta")) ? 0 : reader.GetInt32("No_Cta"),
                                    descripcionCta: reader.IsDBNull(reader.GetOrdinal("Descripcion_Cta")) ? string.Empty : reader.GetString("Descripcion_Cta"),
                                    tipoCtaID: reader.IsDBNull(reader.GetOrdinal("Tipo_Cta_ID")) ? 0 : reader.GetInt32("Tipo_Cta_ID"),
                                    nivelCta: 1,  // Suponiendo que el nivel es fijo para la consulta
                                    ctaPadre: null,
                                    grupoCta: reader.IsDBNull(reader.GetOrdinal("Grupo_Cta")) ? 0 : reader.GetInt32("Grupo_Cta"),
                                    fechaCreacionCta: reader.GetDateTime("Fecha_Creacion_Cta"),
                                    debitoAcumulado: reader.IsDBNull(reader.GetOrdinal("Debito_Acum_Cta")) ? 0m : reader.GetDecimal("Debito_Acum_Cta"),
                                    creditoAcumulado: reader.IsDBNull(reader.GetOrdinal("Credito_Acum_Cta")) ? 0m : reader.GetDecimal("Credito_Acum_Cta"),
                                    balance: reader.IsDBNull(reader.GetOrdinal("Balance_Cta")) ? 0m : reader.GetDecimal("Balance_Cta")
                                );

                                cuentas.Add(cuenta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las cuentas: {ex.Message}");
            }

            return cuentas;
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            // Validar los campos de entrada antes de agregar la cuenta
            if (string.IsNullOrWhiteSpace(txtNoCta.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcionCta.Text) ||
                cbTipoCta.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNivelCta.Text) ||
                string.IsNullOrWhiteSpace(txtGrupoCta.Text) ||
                string.IsNullOrWhiteSpace(txtDebitoCta.Text) ||
                string.IsNullOrWhiteSpace(txtCreditoCta.Text) ||
                string.IsNullOrWhiteSpace(txtBalanceCta.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear una conexión a la base de datos
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para insertar los datos de la cuenta
                    string query = "INSERT INTO catalogo_cuenta_contable (No_Cta, Descripcion_Cta, Tipo_Cta_ID, Nivel_Cta, Grupo_Cta, Debito_Acum_Cta, Credito_Acum_Cta, Balance_Cta, Fecha_Creacion_Cta) " +
                                   "VALUES (@NoCta, @DescripcionCta, @TipoCta, @NivelCta, @GrupoCta, @Debito, @Credito, @Balance, NOW())";

                    // Crear el comando SQL
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Agregar los parámetros al comando SQL
                        cmd.Parameters.AddWithValue("@NoCta", txtNoCta.Text);
                        cmd.Parameters.AddWithValue("@DescripcionCta", txtDescripcionCta.Text);
                        cmd.Parameters.AddWithValue("@TipoCta", cbTipoCta.SelectedIndex == 0 ? 1 : 2); // Asumimos que '1' es "General" y '2' es "Detalle"
                        cmd.Parameters.AddWithValue("@NivelCta", txtNivelCta.Text);
                        cmd.Parameters.AddWithValue("@GrupoCta", txtGrupoCta.Text);
                        cmd.Parameters.AddWithValue("@Debito", Convert.ToDecimal(txtDebitoCta.Text));
                        cmd.Parameters.AddWithValue("@Credito", Convert.ToDecimal(txtCreditoCta.Text));
                        cmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(txtBalanceCta.Text));

                        // Ejecutar el comando de inserción
                        cmd.ExecuteNonQuery();
                    }

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Cuenta guardada exitosamente.");

                    // Limpiar los campos de entrada después de agregar la cuenta
                    ClearInputs();

                    // Recargar las cuentas para reflejar la nueva cuenta
                    CargarCuentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la cuenta: {ex.Message}");
                }
            }
        }

    }
}
