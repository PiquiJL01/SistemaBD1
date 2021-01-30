using System;
using System.Collections.Generic;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class ConsultarProveedores : System.Web.UI.Page
    {
        public string tabla;
        public Proveedor consultarProveedor;

        protected void Page_Load(object sender, EventArgs e)
        {
            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Rif</th>";
            tabla += "<th>Razón Social</th>";
            tabla += "<th>Denomincación Comercial</th>";
            tabla += "<th>Página Web</th>";
            tabla += "<th>Código Dirección Física</th>";
            tabla += "<th>Código Dirección Fiscal</th>";
            tabla += "<th>Código Correo Electrónico</th>";
            tabla += "<th>Productos</th>";
            tabla += "</tr>";
            tabla += "</thead>";

            tabla += "<tbody>";

            consultarProveedor = new Proveedor();
            List<Proveedor> listaProveedores = consultarProveedor.Todos();

            foreach (Proveedor item in listaProveedores)
            {
                tabla += "<tr>";
                tabla += "<td>" + item.RIF + "</td>";
                tabla += "<td>" + item.RazonSocial + "</td>";
                tabla += "<td>" + item.DenominacionComercial + "</td>";
                tabla += "<td>" + item.PaginaWeb + "</td>";
                tabla += "<td>" + item.DireccionFisica + "</td>";
                tabla += "<td>" + item.DireccionFiscal + "</td>";
                tabla += "<td>" + item.CodigoCorreoElectronico + "</td>";

                List<int> codigoProductos = consultarProveedor.TodosEnPP_PR(item.RIF); //obtiene los codigos de los productos relacionado con el proveedor
                Producto producto = new Producto();
                List<Producto> todosProductos = producto.Todos();  //obtengo todos los productos

                string nombreProducto="";  //declaración de la cadena que contendrá los nombres de los productos

                foreach (Producto prod in todosProductos)
                {
                    foreach (int codigo in codigoProductos)
                    {
                        if (prod.Codigo == codigo)
                            nombreProducto += prod.Nombre + "\n";
                    }
                }

                tabla += "<td>" + nombreProducto + "</td>";
                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaPersonaTabla.InnerHtml = tabla;
        }
    }
}