using SimuladorMaquinaTuring.Modelo.Enums;
using System.Collections.Generic;

namespace SimuladorMaquinaTuring.Modelo
{
    public class SumarDosNumerosEnUnario
    {
        public static string ObtenerEntrada()
        {
            return "111_11";
        }

        public static string ObtenerEstadoInicial()
        {
            return "q0";
        }

        public static IEnumerable<Transicion> ObtenerTablaDeTransiciones()
        {
            return new[]
            {
                new Transicion("q0", '1', '1', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '_', '1', Direccion.Derecha, "q1", 0),
                new Transicion("q1", '1', '1', Direccion.Derecha, "q1", 0),
                new Transicion("q1", '_', '_', Direccion.Izquierda, "q2", 0),
                new Transicion("q2", '1', '_', Direccion.Izquierda, "qaccept", 0),
            };
        }
    }
}
