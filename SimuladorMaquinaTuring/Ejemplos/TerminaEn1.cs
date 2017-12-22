using SimuladorMaquinaTuring.Modelo.Enums;
using System.Collections.Generic;

namespace SimuladorMaquinaTuring.Modelo
{
    public class TerminaEn1
    {
        public static string ObtenerEntrada()
        {
            return "10011000110010101";
        }

        public static string ObtenerEstadoInicial()
        {
            return "q0";
        }

        public static IEnumerable<Transicion> ObtenerTablaDeTransiciones()
        {
            return new[]
            {
                new Transicion("q0", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '_', '_', Direccion.Izquierda, "qreject", 0),
                new Transicion("q0", '1', '1', Direccion.Derecha, "q1", 0),
                new Transicion("q1", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q1", '_', '_', Direccion.Izquierda, "qaccept", 0),
                new Transicion("q1", '1', '1', Direccion.Derecha, "q1", 0),
            };
        }
    }
}
