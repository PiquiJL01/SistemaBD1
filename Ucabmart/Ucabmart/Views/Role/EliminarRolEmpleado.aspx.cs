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