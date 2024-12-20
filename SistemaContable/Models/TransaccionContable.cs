using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Models
{
    public class TransaccionContable
    {
        // Claves primarias
        public string NroDoc { get; set; }              
        public int SecuenciaDoc { get; set; }          
        // Otros atributos
        public int CuentaContable { get; set; }        
        public double ValorDebito { get; set; }        
        public double ValorCredito { get; set; }      
        public string Comentario { get; set; }         

        // Constructor
        public TransaccionContable(string nroDoc, int secuenciaDoc, int cuentaContable, double valorDebito, double valorCredito, string comentario)
        {
            NroDoc = nroDoc;
            SecuenciaDoc = secuenciaDoc;
            CuentaContable = cuentaContable;
            ValorDebito = valorDebito;
            ValorCredito = valorCredito;
            Comentario = comentario;
        }
    }
}
