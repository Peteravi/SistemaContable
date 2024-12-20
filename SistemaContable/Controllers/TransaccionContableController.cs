using MySql.Data.MySqlClient;
using SistemaContable.Models;
using System;
using System.Collections.Generic;

namespace SistemaContable.Controllers
{
    public class TransaccionContableController
    {
        private readonly string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        // CREATE: Agregar una nueva transacción contable
        public void CrearTransaccion(TransaccionContable transaccion)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO transaccion_contable (Nro_Doc, Secuencia_Doc, Cuenta_Contable, Valor_Debito, Valor_Credito, Comentario) " +
                                   "VALUES (@NroDoc, @SecuenciaDoc, @CuentaContable, @ValorDebito, @ValorCredito, @Comentario)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NroDoc", transaccion.NroDoc);
                    cmd.Parameters.AddWithValue("@SecuenciaDoc", transaccion.SecuenciaDoc);
                    cmd.Parameters.AddWithValue("@CuentaContable", transaccion.CuentaContable);
                    cmd.Parameters.AddWithValue("@ValorDebito", transaccion.ValorDebito);
                    cmd.Parameters.AddWithValue("@ValorCredito", transaccion.ValorCredito);
                    cmd.Parameters.AddWithValue("@Comentario", transaccion.Comentario ?? "");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la transacción: " + ex.Message);
            }
        }

        // READ: Obtener todas las transacciones
        public List<TransaccionContable> ObtenerTransacciones()
        {
            List<TransaccionContable> listaTransacciones = new List<TransaccionContable>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM transaccion_contable";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransaccionContable transaccion = new TransaccionContable(
                                reader["Nro_Doc"].ToString(),
                                Convert.ToInt32(reader["Secuencia_Doc"]),
                                Convert.ToInt32(reader["Cuenta_Contable"]),
                                Convert.ToDouble(reader["Valor_Debito"]),
                                Convert.ToDouble(reader["Valor_Credito"]),
                                reader["Comentario"].ToString()
                            );

                            listaTransacciones.Add(transaccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las transacciones: " + ex.Message);
            }

            return listaTransacciones;
        }

        // UPDATE: Actualizar una transacción existente
        public void ActualizarTransaccion(TransaccionContable transaccion)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE transaccion_contable SET Cuenta_Contable = @CuentaContable, " +
                                   "Valor_Debito = @ValorDebito, Valor_Credito = @ValorCredito, Comentario = @Comentario " +
                                   "WHERE Nro_Doc = @NroDoc AND Secuencia_Doc = @SecuenciaDoc";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NroDoc", transaccion.NroDoc);
                    cmd.Parameters.AddWithValue("@SecuenciaDoc", transaccion.SecuenciaDoc);
                    cmd.Parameters.AddWithValue("@CuentaContable", transaccion.CuentaContable);
                    cmd.Parameters.AddWithValue("@ValorDebito", transaccion.ValorDebito);
                    cmd.Parameters.AddWithValue("@ValorCredito", transaccion.ValorCredito);
                    cmd.Parameters.AddWithValue("@Comentario", transaccion.Comentario ?? "");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la transacción: " + ex.Message);
            }
        }

        // DELETE: Eliminar una transacción por NroDoc y SecuenciaDoc
        public void EliminarTransaccion(string nroDoc, int secuenciaDoc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM transaccion_contable WHERE Nro_Doc = @NroDoc AND Secuencia_Doc = @SecuenciaDoc";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NroDoc", nroDoc);
                    cmd.Parameters.AddWithValue("@SecuenciaDoc", secuenciaDoc);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la transacción: " + ex.Message);
            }
        }

        // Método RealizarCierreDiario: Cerrar las transacciones entre dos fechas
        public bool RealizarCierreDiario(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE transaccion_contable SET Estado = 'Cerrada', Fecha_Cierre = NOW() " +
                                   "WHERE Fecha BETWEEN @FechaInicio AND @FechaFin";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0; // Retorna true si se actualizaron filas
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar el cierre diario: " + ex.Message);
                return false;
            }
        }
    }
}
