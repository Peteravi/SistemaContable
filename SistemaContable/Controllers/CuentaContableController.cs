using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SistemaContable.Models;
using SistemaContable.Models.SistemaContable.Models;
using SistemaContable.Models.SistemaContable.Models.SistemaContable.Models;

namespace SistemaContable.Controllers
{
    namespace SistemaContable.Controllers
    {
        public class CuentaContableController
        {
            private static string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07";

            public List<CuentaContable> ObtenerCuentas()
            {
                List<CuentaContable> cuentas = new List<CuentaContable>();

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM catalogo_cuenta_contable";
                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        connection.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cuentas.Add(new CuentaContable(
                                noCta: (int)reader["No_Cta"],
                                descripcionCta: reader["Descripcion_Cta"].ToString(),
                                tipoCtaID: (int)reader["Tipo_Cta_ID"],
                                nivelCta: (int)reader["Nivel_Cta"],
                                ctaPadre: reader["Cta_Padre"] != DBNull.Value ? (int?)reader["Cta_Padre"] : null,
                                grupoCta: (int)reader["Grupo_Cta"],
                                fechaCreacionCta: (DateTime)reader["Fecha_Creacion_Cta"],
                                debitoAcumulado: reader["Debito_Acum_Cta"] != DBNull.Value ? Convert.ToDecimal(reader["Debito_Acum_Cta"]) : 0,
                                creditoAcumulado: reader["Credito_Acum_Cta"] != DBNull.Value ? Convert.ToDecimal(reader["Credito_Acum_Cta"]) : 0,
                                balance: reader["Balance_Cta"] != DBNull.Value ? Convert.ToDecimal(reader["Balance_Cta"]) : 0
                            ));
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las cuentas: " + ex.Message);
                    throw;
                }

                return cuentas;
            }
        }
    }

}
