using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimuladorMaquinaTuring.Modelo2
{
    public class MaquinaDeTuring
    {
        public int IntervaloDeTiempo { get; set; }
        public string EstadoActual { get; set; }
        public Cabezal Cabezal { get; }
        public IEnumerable<Transicion> TablaTransiciones { get; set; }

        public MaquinaDeTuring(string estadoActual, Cabezal cabezal, IEnumerable<Transicion> tablaTransiciones, int intervaloDeTiempo)
        {
            if (!estadoActual.Contains("accept") && !estadoActual.Contains("reject") && !tablaTransiciones.Any(t => t.Estado == estadoActual)) 
                    throw new ArgumentException("Ocurrio un problema: el estado inicial no coincide con ningún estado de la tabla de transiciones");           

            EstadoActual = estadoActual;
            Cabezal = cabezal;
            TablaTransiciones = tablaTransiciones;
            IntervaloDeTiempo = intervaloDeTiempo;
        }

        public MaquinaDeTuring Step()
        {
            //if (EstadoInicial < 0) return this;

            MaquinaDeTuring maquinaDeTuring = TablaTransiciones
                    .Where(t => t.Estado == EstadoActual && t.Leer == Cabezal.Leer())
                    .Select(
                       t => new MaquinaDeTuring(t.EstadoSiguiente, Cabezal.Escribir(t.Escribir).Move(t.Direccion), TablaTransiciones, IntervaloDeTiempo))
                    .First();

            return maquinaDeTuring;
        }

        //public MaquinaDeTuring Run()
        //{
        //    var m = this;

        //    while (!m.EstadoInicial.Contains("accept") && !m.EstadoInicial.Contains("reject"))
        //    {
        //        m = m.Step();
        //        Thread.Sleep(IntervaloDeTiempo * 1000);
        //    }

        //    return m;
        //}
    }
}

