using SimuladorMaquinaTuring.Modelo.Enums;
using System.Collections.Generic;

namespace SimuladorMaquinaTuring.Modelo
{
    public class AntepenultimoEsUn1
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
                new Transicion("q0", '1', '1', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '_', '_', Direccion.Izquierda, "q1", 0),
                new Transicion("q1", '1', '1', Direccion.Izquierda, "q2", 0),
                new Transicion("q1", '0', '0', Direccion.Izquierda, "q2", 0),
                new Transicion("q1", '_', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q2", '1', '1', Direccion.Izquierda, "q3", 0),
                new Transicion("q2", '0', '0', Direccion.Izquierda, "q3", 0),
                new Transicion("q2", '_', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q3", '1', '1', Direccion.Izquierda, "qaccept", 0),
                new Transicion("q3", '0', '0', Direccion.Derecha, "qreject", 0),
                new Transicion("q3", '_', '_', Direccion.Derecha, "qreject", 0),
            };
        }
    }
}
