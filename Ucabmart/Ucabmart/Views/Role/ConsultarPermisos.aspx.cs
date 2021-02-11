using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class ConsultarPermisos : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }
        public string tabla;
        public Rol consultarRol;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Código Rol</th>";
            tabla += "<th>Rol</th>";
            tabla += "<th>Permisos</th>";
            tabla += "</tr>";
            tabla += "</thead>";

            tabla += "<tbody>";

            consultarRol = new Rol();
            List<Rol> listaRol = consultarRol.Todos();

            foreach (Rol rol in listaRol)
            {
                tabla += "<tr>";
                tabla += "<td>" + rol.Codigo + "</td>";
                tabla += "<td>" + rol.Nombre + "</td>";
                
                List<Permiso> listaPermiso = rol.Permisos();
                string nombrePermiso = "";

                foreach(Permiso item in listaPermiso)
                {
                    nombrePermiso += item.Codigo + "-" + item.Nombre + ", ";
                }

                tabla += "<td>" + nombrePermiso + "</td>";
                
                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaPermisosTabla.InnerHtml = tabla;
        }
    }
}