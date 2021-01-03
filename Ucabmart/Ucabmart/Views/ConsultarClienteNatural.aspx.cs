using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Views
{
    public partial class ConsultarClienteNatural : System.Web.UI.Page
    {
        public string tabla; // para contruir y mostrar la tabla con html 

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dplTipoCliente.SelectedValue == "Natural")
            {
                /// imprimo la cabecera de la tabla de esta manera
                /// para no perder los estilos de bootstrap
                tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                tabla += "<thead>";
                tabla += "<tr>";
                tabla += "<th>ID</th>";
                tabla += "<th>T. De Documento</th>";
                tabla += "<th>Nro. Cédula</th>";
                tabla += "<th>Nombre o Razón Social</th>";
                tabla += "<th>Sexo</th>";
                tabla += "</tr>";
                tabla += "</thead>";

                tabla += "<tbody>";

                /// cuerpo o contenido de la tabla

                tabla += "<tr>";
                tabla += "<td> Hola </td>";
                tabla += "<td> qué tal?</td>";
                tabla += "<td>todo bien?</td>";
                tabla += "<td> esta es una </td>";
                tabla += "<td>tabla natural</td>";
                tabla += "</tr>";

                tabla += "</tbody>";

                tabla += "</table>";
            }
            else
            {
                tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                tabla += "<thead>";
                tabla += "<tr>";
                tabla += "<th>ID</th>";
                tabla += "<th>T. De Documento</th>";
                tabla += "<th>Nro. Cédula</th>";
                tabla += "<th>Nombre o Razón Social</th>";
                tabla += "<th>Sexo</th>";
                tabla += "<th>Edad</th>";
                tabla += "<th>Direccion</th>";
                tabla += "</tr>";
                tabla += "</thead>";

                tabla += "<tbody>";

                /// cuerpo o contenido de la tabla

                tabla += "<tr>";
                tabla += "<td> Hola </td>";
                tabla += "<td> qué tal?</td>";
                tabla += "<td>todo bien?</td>";
                tabla += "<td> esta es una </td>";
                tabla += "<td>tabla juridica</td>";
                tabla += "<td>Aprende menor!</td>";
                tabla += "<td>JAJAJA</td>";
                tabla += "</tr>";

                tabla += "</tbody>";

                tabla += "</table>";
            }
            listaPersonaTabla.InnerHtml = tabla;

        }
    }
}