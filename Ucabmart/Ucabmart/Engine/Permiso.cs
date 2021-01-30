namespace Ucabmart.Engine
{
    public class Permiso
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EstaPermitido { get; set; }
        public string Descripcion { get; set; }

        public Permiso(int codigo, string nombre, bool estaPermitido, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EstaPermitido = estaPermitido;
            Descripcion = descripcion;
        }
    }
}