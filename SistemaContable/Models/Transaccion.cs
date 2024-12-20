using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Models
{
    public class Transaccion
    {
        public DateTime Fecha { get; set; }
        public string Cuenta { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; } 
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public string Nro_Doc { get; set; }
        public string Hecho_Por { get; set; }

        public Transaccion(DateTime fecha, string cuenta, decimal monto, string descripcion, string tipo, decimal debito, decimal credito, string nroDoc, string hechoPor)
        {
            Fecha = fecha;
            Cuenta = cuenta;
            Monto = monto;
            Descripcion = descripcion;
            Tipo = tipo;
            Debito = debito;
            Credito = credito;
            Nro_Doc = nroDoc;
            Hecho_Por = hechoPor;
        }
    }


}
