using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Product
{
    public partial class ConsultarProducto : System.Web.UI.Page
    {
        public string tabla;
        public Producto consultarProducto;
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Código</th>";
            tabla += "<th>Nombre</th>";
            tabla += "<th>Alimenticio</th>";
            tabla += "<th>Precio</th>";
            tabla += "<th>Calidad</th>";
            tabla += "<th>Descripción</th>";
            tabla += "<th>Código de la Marca</th>";
            tabla += "<th>Nombre de la Marca</th>";
            tabla += "<th>Código de la Clasificación</th>";
            tabla += "<th>Nombre de la Clasificación</th>";
            tabla += "</tr>";
            tabla += "</thead>";

            tabla += "<tbody>";

            consultarProducto = new Producto();
            List<Producto> listaProducto = consultarProducto.Todos();

            foreach (Producto item in listaProducto)
            {
                tabla += "<tr>";
                tabla += "<td>" + item.Codigo + "</td>";
                tabla += "<td>" + item.Nombre + "</td>";
                tabla += "<td>" + item.EsAlimenticio + "</td>";
                tabla += "<td>" + item.Precio + "</td>";
                tabla += "<td>" + item.Calidad + "</td>";
                tabla += "<td>" + item.Descripcion + "</td>";
                tabla += "<td>" + item.CodigoMarca + "</td>";
                
                Marca obtenerMarca = new Marca();
                List<Marca> listaMarcas = obtenerMarca.Todos();
                string nombreMarca= "";

                foreach (Marca nombre in listaMarcas)
                {
                    if (item.CodigoMarca == nombre.Codigo)
                        nombreMarca = nombre.Nombre;
                }

                tabla += "<td>" + nombreMarca + "</td>";
                tabla += "<td>" + item.CodigoClasificacion + "</td>";

                Clasificacion obtenerClasificacion = new Clasificacion();
                List<Clasificacion> listaClasificacion = obtenerClasificacion.Todos();
                string nombreClasificacion = "";

                foreach (Clasificacion nombre in listaClasificacion)
                {
                    if (item.CodigoClasificacion == nombre.Codigo)
                        nombreClasificacion= nombre.Nombre;
                }

                tabla += "<td>" + nombreClasificacion + "</td>";
                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaPersonaTabla.InnerHtml = tabla;
        }
    }
}