﻿namespace Ucabmart.Engine
{
    public class ImagenProducto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public int CodigoProducto { get; set; }

        public ImagenProducto(string codigo, string nombre, string ubicacion, string descripcion, Producto productoAsociado)
        {
            Codigo = codigo;
            Nombre = nombre;
            Ubicacion = ubicacion;
            Descripcion = descripcion;
            CodigoProducto = productoAsociado.Codigo;
        }
    }
}