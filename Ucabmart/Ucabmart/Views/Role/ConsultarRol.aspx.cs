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

            Productos.Visible = false;
            Tiendas.Visible = false;
            Nomina.Visible = false;
            Proveedores.Visible = false;
            Clientes.Visible = false;
            RolesA.Visible = false;

            string rol1 = Session["Rol"].ToString();
            int codigoRol1 = Int32.Parse(rol1);
            Rol nombreRol = new Rol(codigoRol1);
            List<Permiso> listaPermiso = nombreRol.Permisos();

            foreach (Permiso permiso in listaPermiso)
            {
                switch (permiso.Codigo)
                {
                    case 1:
                        Productos.Visible = true;
                        break;
                    case 2:
                        Tiendas.Visible = true;
                        break;
                    case 3:
                        Nomina.Visible = true;
                        break;
                    case 4:
                        Proveedores.Visible = true;
                        break;
                    case 5:
                        Clientes.Visible = true;
                        break;
                    case 6:
                        RolesA.Visible = true;
                        break;

                }
            }

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

            foreach (Empleado empleado in listaEmpleado)
            {
                tabla += "<tr>";
                tabla += "<td>" + empleado.Codigo + "</td>";
                tabla += "<td>" + empleado.RIF + "</td>";
                tabla += "<td>" + empleado.Cedula + "</td>";
                tabla += "<td>" + empleado.Nombre1 + "</td>";
                tabla += "<td>" + empleado.Apellido1 + "</td>";

                MuchosAMuchos m_m = new MuchosAMuchos();
                int codigoRol = m_m.BuscarRol(empleado.Codigo);
                Rol rol = new Rol(codigoRol);

                tabla += "<td>" + rol.Nombre + "</td>";
                
                string nombrePermiso = rol.BuscarPermiso(rol.Codigo);

                tabla += "<td>" + nombrePermiso + "</td>";

                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaRolesTabla.InnerHtml = tabla;
        }
    }
}