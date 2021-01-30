using System;

namespace Ucabmart.Views
{
    public partial class IniciarSesionPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string loginUsuario = Email.Text;
            Session["NombreLogin"] = loginUsuario;
            Response.Redirect("/Views/User/InicioUsuario.aspx", false);
        }


    }
}