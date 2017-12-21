using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        public MaquinaDeTuring(string estadoActual, Cabezal cabezal, DataGridView dataGridView, int intervaloDeTiempo)
        {
            try
            {
                TablaTransiciones = Utilidades.GenerarTablaDeTransiciones(dataGridView);

                Transicion transicionInicial = TablaTransiciones.FirstOrDefault(t => t.Estado == estadoActual && t.Leer == cabezal.Leer());

                if(transicionInicial == null)
                    throw new ArgumentException(string.Format("Por favor, verifique el estado inicial y/o la tabla de transiciones. No se encontró transición para el estado {0} leyendo el caracter {1}.", estadoActual, cabezal.Leer()));

                if(!TablaTransiciones.Any(x => x.Estado.Contains("accept")) && !TablaTransiciones.Any(x => x.EstadoSiguiente.Contains("accept")))
                    throw new ArgumentException(string.Format("Por favor, verifique la tabla de transiciones. No se encontro ningún estado 'accept'.", estadoActual, cabezal.Leer()));

                EstadoActual = estadoActual;
                Cabezal = cabezal;

                IntervaloDeTiempo = intervaloDeTiempo;
                Estado = Estado.Pausada;

                IndiceEnLaTabla = transicionInicial.RowIndex;
                IndiceEnLaTablaAnterior = IndiceEnLaTabla;

            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transicion ObtenerSiguienteTransicion(string estadoActual, char charALeer)
        {
            try
            {
                Transicion transicionDeLaTabla = TablaTransiciones.FirstOrDefault(t => t.Estado == estadoActual && t.Leer == charALeer);

                bool puedoMoverme = true;

                switch(transicionDeLaTabla.Direccion)
                {
                    case Direccion.Derecha:
                        puedoMoverme = Cabezal.PuedoMovermeALaDerecha();
                        break;
                    case Direccion.Izquierda:
                        puedoMoverme = Cabezal.PuedoMovermeALaIzquierda();
                        break;
                }
                  
                if (transicionDeLaTabla == null || !puedoMoverme)
                    throw new ArgumentException(string.Format("No se encontró una transición válida para el estado {0} leyendo el caracter {1}.", estadoActual, charALeer));
                return transicionDeLaTabla;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MaquinaDeTuring Step()
        {
            try
            {
                Transicion transicion = ObtenerSiguienteTransicion(EstadoActual, Cabezal.Leer());

                IndiceEnLaTablaAnterior = IndiceEnLaTabla;
                IndiceEnLaTabla = transicion.RowIndex;

                Cabezal.Escribir(transicion.Escribir);
                Cabezal.Moverse(transicion.Direccion);

                EstadoActual = transicion.EstadoSiguiente;
                IndiceEnLaTabla = transicion.RowIndex;

                return this;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoAPausa()
        {
            Estado = Estado.Pausada;
        }

        public bool EstaPausada()
        {
            return Estado == Estado.Pausada;
        }
        public void CambiarEstadoAEjecutandose()
        {
            Estado = Estado.Ejecutandose;
        }
        public bool EstaEjecutandose()
        {
            return Estado == Estado.Ejecutandose;
        }

        public bool HaFinalizado()
        {
            return EstadoActual.Contains("accept") || EstadoActual.Contains("reject");
        }
    }
}

