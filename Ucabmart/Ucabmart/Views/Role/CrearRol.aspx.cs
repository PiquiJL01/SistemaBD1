using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class CrearRol : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = new Rol(TxtNombre.Text, TextDescripcion.Text);
                rol.Insertar();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('el rol ha sido creado exitosamente');" +
                "window.location ='Role_Admin.aspx';", true);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al crear el rol. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }



        }

    }
}