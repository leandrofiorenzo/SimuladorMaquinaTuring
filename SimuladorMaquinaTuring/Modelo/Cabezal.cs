using SimuladorMaquinaTuring.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorMaquinaTuring.Modelo
{
    public class Cabezal
    {
        public List<char> CintaAProcesar { get; set; }
        public int PosicionDelCabezal { get; set; }
        public int PosicionDelCabezalAnterior { get; set; }

        public Cabezal(List<char> cintaAProcesar)
        {
            if(cintaAProcesar.Count() == 0)
                throw new ArgumentException("Ingrese un input válido.");

            CintaAProcesar = cintaAProcesar;
            PosicionDelCabezal = 0;
            PosicionDelCabezalAnterior = 0;
        }

        public char Leer()
        {
            if (PosicionDelCabezal == -1 || PosicionDelCabezal == CintaAProcesar.Count())
                return '_';
            return CintaAProcesar.ElementAt(PosicionDelCabezal);
        }

        public void Escribir(char caracterAEscribir)
        {
            if (PosicionDelCabezal <= -1 || PosicionDelCabezal >= CintaAProcesar.Count())
                return;
            CintaAProcesar[PosicionDelCabezal] = caracterAEscribir;
        }

        public void MoverseALaIzquierda()
        {
            if (PosicionDelCabezal == -1)
                return;
            PosicionDelCabezalAnterior = PosicionDelCabezal;
            PosicionDelCabezal = PosicionDelCabezal - 1;
        }

        public bool PuedoMovermeALaIzquierda()
        {
            return PosicionDelCabezal > -1;
        }

        public void MoverseALaDerecha()
        {
            if (PosicionDelCabezal == CintaAProcesar.Count())
                return;
            PosicionDelCabezalAnterior = PosicionDelCabezal;
            PosicionDelCabezal = PosicionDelCabezal + 1;
        }

        public bool PuedoMovermeALaDerecha()
        {
            return PosicionDelCabezal < CintaAProcesar.Count();
        }

        public void Moverse(Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.Izquierda:
                    MoverseALaIzquierda();
                    break;
                case Direccion.Derecha:
                    MoverseALaDerecha();
                    break;
                default:
                    break;
            }
        }



        public string ObtenerCintaProcesada()
        {
            var stringBuilder = new StringBuilder();
            foreach (var c in CintaAProcesar)
            {
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}
