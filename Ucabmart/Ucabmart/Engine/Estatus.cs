namespace Ucabmart.Engine
{
    public class Estatus
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public Estatus(int codigo, string tipo, string descripcion)
        {
            Codigo = codigo;
            Tipo = tipo;
            Descripcion = descripcion;
        }
    }
}