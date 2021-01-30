using System;
using System.Web.UI;
using Ucabmart.Engine;

namespace Ucabmart.Command
{
    public partial class PruebaBD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Lugar test = new Lugar("nombre", TipoLugar.Pais, "test2");
                test.Insertar();
                Natural natural = new Natural("V25561714");
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error en la conexion con la BD. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}