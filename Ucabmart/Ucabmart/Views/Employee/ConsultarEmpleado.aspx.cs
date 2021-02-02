using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class ConsultarEmpleado : System.Web.UI.Page
    {
        public string tabla;
        public Empleado consultarEmpleado;

        protected void Page_Load(object sender, EventArgs e)
        {
            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Código</th>";
            tabla += "<th>Rif</th>";
            tabla += "<th>Cédula</th>";
            tabla += "<th>Primer Nombre</th>";
            tabla += "<th>Segundo Nombre</th>";
            tabla += "<th>Primer Apellido</th>";
            tabla += "<th>Segundo Apellido</th>";
            tabla += "<th>Código Tienda</th>";
            tabla += "<th>Código Departamento</th>";
            tabla += "<th>Código Empleado</th>";
            tabla += "<th>Código Lugar</th>";
            tabla += "<th>Código Correo</th>";
            tabla += "<th>Contraseña</th>";
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
                tabla += "<td>" + item.Nombre2 + "</td>";
                tabla += "<td>" + item.Apellido1 + "</td>";
                tabla += "<td>" + item.Apellido2 + "</td>";
                tabla += "<td>" + item.CodigoTienda+ "</td>";
                tabla += "<td>" + item.CodigoDepartamento + "</td>";
                tabla += "<td>" + item.CodigoJefe + "</td>";
                tabla += "<td>" + item.CodigoDireccion + "</td>";
                tabla += "<td>" + item.CodigoCorreoElectronico + "</td>";
                tabla += "<td>" + item.Password + "</td>";

                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaPersonaTabla.InnerHtml = tabla;
        }
    }
}