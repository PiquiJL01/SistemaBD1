using System;
using System.Web.UI;

namespace Ucabmart.Views
{
    public partial class IniciarSesionPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string loginUsuario = Email.Text;
                Session["NombreLogin"] = loginUsuario;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", 
                //                "window.location ='/Views/User/InicioUsuario.aspx';", true);
                Response.Redirect("/Views/User/InicioUsuario.aspx", false);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al acceder en el Login. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS ');", true);

            }
        }


    }
}
