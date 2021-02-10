using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class ConsultarRol : System.Web.UI.Page
    {
        public string tabla;
        public Empleado consultarEmpleado;
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Código</th>";
            tabla += "<th>Rif</th>";
            tabla += "<th>Cédula</th>";
            tabla += "<th>Primer Nombre</th>";
            tabla += "<th>Primer Apellido</th>";
            tabla += "<th>ROL</th>";
            tabla += "<th>Permisos</th>";
            tabla += "</tr>";
            tabla += "</thead>";

            tabla += "<tbody>";

            consultarEmpleado = new Empleado();
            List<Empleado> listaEmpleado = consultarEmpleado.Todos();

            foreach (Empleado item in listaEmpleado)
            {
                tabla += "<tr>";
                tabla += "<td>" + item.Codigo + "</td>";
                tabla += "<td>" + item.RIF + "</td>";
                tabla += "<td>" + item.Cedula + "</td>";
                tabla += "<td>" + item.Nombre1 + "</td>";
                tabla += "<td>" + item.Apellido1 + "</td>";

                

                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaRolesTabla.InnerHtml = tabla;
        }
    }
}