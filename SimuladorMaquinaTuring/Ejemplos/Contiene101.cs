using SimuladorMaquinaTuring.Modelo.Enums;
using System.Collections.Generic;

namespace SimuladorMaquinaTuring.Modelo
{
    public class Contiene101
    {
        public static string ObtenerEntrada()
        {
            return "1001100011001010";
        }

        public static IEnumerable<Transicion> ObtenerTablaDeTransiciones()
        {
            return new[]
            {
                new Transicion("q0", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '_', '_', Direccion.Izquierda, "qreject", 0),
                new Transicion("q0", '1', '1', Direccion.Derecha, "q1", 0),
                new Transicion("q1", '0', '0', Direccion.Derecha, "q2", 0),
                new Transicion("q1", '_', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q1", '1', '1', Direccion.Derecha, "q1", 0),
                new Transicion("q2", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q2", '_', '_', Direccion.Derecha, "qreject", 0),
                new Transicion("q2", '1', '1', Direccion.Derecha, "qaccept", 0),
            };
        }
    }
}
