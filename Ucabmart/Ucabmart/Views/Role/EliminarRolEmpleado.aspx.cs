using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class EliminarRol : System.Web.UI.Page
    {
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

            string rol = Session["Rol"].ToString();
            int codigoRol = Int32.Parse(rol);
            Rol nombreRol = new Rol(codigoRol);
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
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado(txtEliminar.Text);

                if (empleado != null)
                {

                    MuchosAMuchos m_m = new MuchosAMuchos();
                    int codigoRol = m_m.BuscarRol(empleado.Codigo);
                    Rol rol = new Rol(codigoRol);

                    if (rol != null)
                    {
                        m_m.Eliminar(empleado, rol);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El rol del empleado ha sido eliminada');" +
                                    "window.location ='Role_Admin.aspx';", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado no tiene un rol asignado');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado no existe');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hubo un error al eliminar');", true);
            }
        }
    }
}