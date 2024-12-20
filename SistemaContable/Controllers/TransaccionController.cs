using SistemaContable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Controllers
{
    public class TransaccionController
    {
        private List<Transaccion> _transacciones;  // Simulamos una base de datos en memoria

        public TransaccionController()
        {
            _transacciones = new List<Transaccion>();
        }

        // Crear una nueva transacción
        public void CrearTransaccion(Transaccion transaccion)
        {
            _transacciones.Add(transaccion);
            Console.WriteLine("Transacción creada exitosamente.");
        }

        // Obtener todas las transacciones
        public List<Transaccion> ObtenerTransacciones()
        {
            return _transacciones;
        }

        // Buscar transacción por número de documento
        public Transaccion ObtenerTransaccionPorNumero(string nroDoc)
        {
            return _transacciones.FirstOrDefault(t => t.Nro_Doc == nroDoc);
        }
    }
}
