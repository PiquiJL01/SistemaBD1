using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Controller;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class RegistrarClienteNatural : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string cadena;

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try {
                Cliente clienteCtrl = new Cliente();


                clienteCtrl.RIF = dplRif.Text + txtRif.Text;
                clienteCtrl.Insertar();





            }
            catch (Exception ex)
            {

                Session["mensajeError"] = "Ha ocurrido un error al registrar la persona. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }
            
        }
    }
}