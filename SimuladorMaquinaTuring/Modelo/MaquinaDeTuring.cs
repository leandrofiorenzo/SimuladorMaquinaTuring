using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuladorMaquinaTuring.Modelo
{
    public class MaquinaDeTuring
    {
        public int IntervaloDeTiempo { get; set; }
        public string EstadoActual { get; set; }
        public Cabezal Cabezal { get; }
        public IEnumerable<Transicion> TablaTransiciones { get; set; }
        public int IndiceEnLaTabla { get; set; }
        public int IndiceEnLaTablaAnterior { get; set; }
        public Estado Estado { get; set; }

        public MaquinaDeTuring(string estadoActual, Cabezal cabezal, IEnumerable<Transicion> tablaTransiciones, int intervaloDeTiempo, int indiceEnLaTabla)
        {
            if (!estadoActual.Contains("accept") && !estadoActual.Contains("reject") && !tablaTransiciones.Any(t => t.Estado == estadoActual))
                throw new ArgumentException("Ocurrio un problema: el estado inicial no coincide con ningún estado de la tabla de transiciones");

            EstadoActual = estadoActual;
            Cabezal = cabezal;
            TablaTransiciones = tablaTransiciones;
            IntervaloDeTiempo = intervaloDeTiempo;
            IndiceEnLaTabla = indiceEnLaTabla;
            IndiceEnLaTablaAnterior = indiceEnLaTabla;
            Estado = Estado.Pausada;
        }

        public MaquinaDeTuring Step()
        {
            Transicion transicion = TablaTransiciones.Where(t => t.Estado == EstadoActual && t.Leer == Cabezal.Leer()).First();

            IndiceEnLaTablaAnterior = IndiceEnLaTabla;
            IndiceEnLaTabla = transicion.RowIndex;

            Cabezal.Escribir(transicion.Escribir);
            Cabezal.Moverse(transicion.Direccion);
            
            EstadoActual = transicion.EstadoSiguiente;
            IndiceEnLaTabla = transicion.RowIndex;

            return this;
        }

        public void CambiarEstadoAPausa()
        {
            Estado = Estado.Pausada;
        }

        public bool EstaPausada()
        {
            return Estado == Estado.Pausada;
        }
        public void CambiarEstadoACorrer()
        {
            Estado = Estado.Corriendo;
        }
        public bool EstaCorriendo()
        {
            return Estado == Estado.Corriendo;
        }

  
        public bool HaFinalizado()
        {
            return EstadoActual.Contains("accept") || EstadoActual.Contains("reject");
        }
    }
}

