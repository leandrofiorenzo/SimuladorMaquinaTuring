using SimuladorMaquinaTuring.Modelo.Enums;
using System.Collections.Generic;

namespace SimuladorMaquinaTuring.Modelo
{
    public class On1n
    {
        public static string ObtenerEntrada()
        {
            return "0000011111";
        }

        public static string ObtenerEstadoInicial()
        {
            return "q0";
        }

        public static IEnumerable<Transicion> ObtenerTablaDeTransiciones()
        {
            return new[]
            {
                new Transicion("q0", '0', '_', Direccion.Derecha, "q1", 0),
                new Transicion("q0", '1', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q0", '_', '_', Direccion.Derecha, "qaccept", 0),
                new Transicion("q1", '0', '0', Direccion.Derecha, "q1", 0),
                new Transicion("q1", '1', '1', Direccion.Derecha, "q2", 0),
                new Transicion("q1", '_', '_', Direccion.Izquierda, "qreject", 0),
                new Transicion("q2", '0', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q2", '1', '1', Direccion.Derecha, "q2", 0),
                new Transicion("q2", '_', '_', Direccion.Izquierda, "q3", 0),
                new Transicion("q3", '1', '_', Direccion.Izquierda, "q4", 0),
                new Transicion("q3", '0', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q3", '_', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q4", '1', '1', Direccion.Izquierda, "q4", 0),
                new Transicion("q4", '0', '0', Direccion.Izquierda, "q4", 0),
                new Transicion("q4", '_', '_', Direccion.Derecha, "q0", 0),
            };
        }
    }
}
