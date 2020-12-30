using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Command
{
    public partial class PruebaBD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // try { 
                ConexionBD conectandose = new ConexionBD();
                conectandose.conectar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Todo Bien');", true);
            //}
             //catch (Exception ex)
            //{
               // Session["mensajeError"] = "Ha ocurrido un error en la conexion con la BD. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);

           // }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}