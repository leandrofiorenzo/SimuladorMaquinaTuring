using System;
using System.Collections.Generic;
using System.Linq;
namespace SimuladorMaquinaTuring.Modelo
{
    public class Cabezal
    {
        public List<char> CintaAProcesar { get; set; }
        public int PosicionDelCabezal { get; set; }
        public int PosicionDelCabezalAnterior { get; set; }

        public Cabezal(List<char> cintaAProcesar, int posicionDelCabezal)
        {
            if(cintaAProcesar.Count() == 0)
                throw new ArgumentException("Ingrese un input válido.");

            if (posicionDelCabezal > cintaAProcesar.Count() - 1 || posicionDelCabezal < 0)
                throw new ArgumentException("Posición del cabezal fuera de rango.");

            CintaAProcesar = cintaAProcesar;
            PosicionDelCabezal = posicionDelCabezal;
            PosicionDelCabezalAnterior = posicionDelCabezal;
        }

        public char Leer()
        {
            return CintaAProcesar.ElementAt(PosicionDelCabezal);
        }

        public void Escribir(char caracterAEscribir)
        {
            CintaAProcesar[PosicionDelCabezal] = caracterAEscribir;
        }

        public void MoverseALaIzquierda()
        {
            if (PosicionDelCabezal == -1) throw new ArgumentException("¡asd!");
            PosicionDelCabezalAnterior = PosicionDelCabezal;
            PosicionDelCabezal = PosicionDelCabezal - 1;
        }

        public void MoverseALaDerecha()
        {
            if (PosicionDelCabezal == CintaAProcesar.Count() - 1) throw new ArgumentException("¡asd!");
            PosicionDelCabezalAnterior = PosicionDelCabezal;
            PosicionDelCabezal = PosicionDelCabezal + 1;
        }

        public void Moverse(Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.Izquierda:
                    MoverseALaIzquierda();
                    break;
                case Direccion.NoMoverse:
                    break;
                case Direccion.Derecha:
                    MoverseALaDerecha();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direccion), direccion, null);
            }
        }
    }
}
