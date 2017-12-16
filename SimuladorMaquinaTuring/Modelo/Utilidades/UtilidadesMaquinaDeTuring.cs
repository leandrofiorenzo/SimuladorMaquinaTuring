using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimuladorMaquinaTuring.Modelo2
{
    public static class TransicionesEjemplo
    {
        public static IEnumerable<Transicion> Contiene101()
        {
            return new[]
            {
                new Transicion("q0", '0', '0', Direccion.Derecha, "q0", 0),
                new Transicion("q0", '_', '_', Direccion.Derecha, "qreject", 0),
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

    public class Utilidades
    {
        public static IEnumerable<Transicion> GenerarTablaDeTransiciones(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.Rows.Count == 0) throw new ArgumentException("Por favor, ingrese valores en la tabla de transición");

                var tablaDeTransicion = new List<Transicion>();

                foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                {
                    tablaDeTransicion.Add(GenerarTransicion(dataGridViewRow));
                }

                return tablaDeTransicion;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static Transicion GenerarTransicion(DataGridViewRow dataGridViewRow)
        {
            try
            {
                //Estado.
                if (dataGridViewRow.Cells[0].Value == null)
                    throw new ArgumentException("Transición inválida. El campo 'Estado' no puede estar vacío. Fila " + (dataGridViewRow.Index + 1));

                //Leer.
                if (dataGridViewRow.Cells[1].Value == null)
                    throw new ArgumentException("Transición inválida. El campo 'Leer' no puede estar vacío. Fila " + (dataGridViewRow.Index + 1));

                if (dataGridViewRow.Cells[1].Value.ToString().Length != 1)
                    throw new ArgumentException("Transición inválida. El campo 'Leer' solo acepta 1 caracter. Fila " + (dataGridViewRow.Index + 1));

                //Escribir
                if (dataGridViewRow.Cells[2].Value == null)
                    throw new ArgumentException("Transición inválida. El campo 'Escribir' no puede estar vacío. Fila " + (dataGridViewRow.Index + 1));

                if (dataGridViewRow.Cells[2].Value.ToString().Length != 1)
                    throw new ArgumentException("Transición inválida. El campo 'Escribir' solo acepta 1 caracter. Fila " + (dataGridViewRow.Index + 1));

                //Dirección
                if (dataGridViewRow.Cells[3].Value == null)
                    throw new ArgumentException("Transición inválida. El campo 'Direccion' no puede estar vacío. Fila " + (dataGridViewRow.Index + 1));

                if (!dataGridViewRow.Cells[3].Value.ToString().Equals("L") && !dataGridViewRow.Cells[3].Value.ToString().Equals("R"))
                    throw new ArgumentException("Transición inválida. El campo 'Direccion' solo acepta 'L' o 'R'. Fila " + (dataGridViewRow.Index + 1));

                //Estado Siguiente
                if (dataGridViewRow.Cells[4].Value == null)
                    throw new ArgumentException("Transición inválida. El campo 'Estado Siguiente' no puede estar vacío. Fila " + (dataGridViewRow.Index + 1));

                return new Transicion(
                    dataGridViewRow.Cells[0].Value.ToString(),
                    char.Parse(dataGridViewRow.Cells[1].Value.ToString()),
                    char.Parse(dataGridViewRow.Cells[2].Value.ToString()),
                    dataGridViewRow.Cells[3].Value.ToString().Equals("R") ? Direccion.Derecha : Direccion.Izquierda,
                    dataGridViewRow.Cells[4].Value.ToString(),
                    dataGridViewRow.Index);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
