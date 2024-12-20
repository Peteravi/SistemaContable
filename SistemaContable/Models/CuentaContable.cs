namespace SistemaContable.Models
{
    namespace SistemaContable.Models
    {
        namespace SistemaContable.Models
        {
            public class CuentaContable
            {
                public int No_Cta { get; set; }
                public string Descripcion_Cta { get; set; }
                public int Tipo_Cta_ID { get; set; }
                public int Nivel_Cta { get; set; }
                public int? Cta_Padre { get; set; }  // Nullable si no tiene cuenta padre
                public int Grupo_Cta { get; set; }
                public DateTime Fecha_Creacion_Cta { get; set; }
                public decimal Debito_Acumulado { get; set; }  // Propiedad para Débito
                public decimal Credito_Acumulado { get; set; } // Propiedad para Crédito
                public decimal Balance { get; set; } // Propiedad para Balance

                // Constructor para la clase CuentaContable
                public CuentaContable(int noCta, string descripcionCta, int tipoCtaID, int nivelCta, int? ctaPadre,
                                       int grupoCta, DateTime fechaCreacionCta, decimal debitoAcumulado, decimal creditoAcumulado, decimal balance)
                {
                    No_Cta = noCta;
                    Descripcion_Cta = descripcionCta;
                    Tipo_Cta_ID = tipoCtaID;
                    Nivel_Cta = nivelCta;
                    Cta_Padre = ctaPadre;
                    Grupo_Cta = grupoCta;
                    Fecha_Creacion_Cta = fechaCreacionCta;
                    Debito_Acumulado = debitoAcumulado;
                    Credito_Acumulado = creditoAcumulado;
                    Balance = balance;
                }
            }
        }

    }
}


