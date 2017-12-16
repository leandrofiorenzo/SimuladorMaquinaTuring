namespace SimuladorMaquinaTuring.Modelo2
{
    public class Transicion
    {
        public string Estado { get; set; }
        public char Leer { get; set; }
        public char Escribir { get; set; }
        public Direccion Direccion { get; set; }
        public char DireccionChar { get; set; }
        public string EstadoSiguiente { get; set; }
        public int RowIndex { get; set; }


        public Transicion(string estado, char leer, char escribir, Direccion direccion, string estadoSiguiente, int rowIndex)
        {
            Estado = estado;
            Leer = leer;
            Escribir = escribir;
            Direccion = direccion;
            DireccionChar = direccion == Direccion.Derecha ? 'R' : 'L';
            EstadoSiguiente = estadoSiguiente;
            RowIndex = rowIndex;
        }
    }
}
