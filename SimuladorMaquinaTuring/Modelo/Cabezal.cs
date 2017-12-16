using System;
using System.Collections.Generic;
using System.Linq;
namespace SimuladorMaquinaTuring.Modelo2
{
    public class Cabezal
    {
        public IEnumerable<char> CintaAProcesar { get; set; }
        public int PosicionDelCabezal { get; set; }

        public Cabezal(IEnumerable<char> cintaAProcesar, int posicionDelCabezal)
        {
            if (posicionDelCabezal > cintaAProcesar.Count() - 1 || posicionDelCabezal < 0)
                throw new ArgumentException("Posición del cabezal fuera de rango.");

            CintaAProcesar = cintaAProcesar;
            PosicionDelCabezal = posicionDelCabezal;
        }


        public Cabezal Escribir(char caracterAEscribir)
        {      
            var cintaAProcesar = new List<char>(CintaAProcesar);
            cintaAProcesar[PosicionDelCabezal] = caracterAEscribir;
            return new Cabezal(cintaAProcesar, PosicionDelCabezal);
        }

        public char Leer()
        {
            return CintaAProcesar.ElementAt(PosicionDelCabezal);
        }

        public Cabezal MoveLeft()
        {
            return PosicionDelCabezal == 0
                ? new Cabezal(new[] { '_' }.Concat(CintaAProcesar), 0)
                : new Cabezal(CintaAProcesar, PosicionDelCabezal - 1);
        }

        public Cabezal MoveRight()
        {
            return PosicionDelCabezal == CintaAProcesar.Count() - 1
                ? new Cabezal(CintaAProcesar.Concat(new[] { '_' }), PosicionDelCabezal + 1)
                : new Cabezal(CintaAProcesar, PosicionDelCabezal + 1);
        }

        public Cabezal Move(Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.Izquierda:
                    return MoveLeft();
                case Direccion.NoMoverse:
                    return this;
                case Direccion.Derecha:
                    return MoveRight();
                default:
                    throw new ArgumentOutOfRangeException(nameof(direccion), direccion, null);
            }
        }
    }
}
