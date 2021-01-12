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
        Lugar nombreLugar = new Lugar(0);
        List<Lugar> listaLugar = new List<Lugar>();

        protected void Page_Load(object sender, EventArgs e)
        {
            listaLugar = nombreLugar.Todos();

            foreach(Lugar item in listaLugar)
            {
                if (item.Tipo == "Estado")
                    dplEstado.Items.Add(item.Nombre);
            }
            
        }

        public string cadena;

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try {
                CorreoElectronico ctrlCorreo = new CorreoElectronico(0);

                ctrlCorreo.Direccion = txtCorreo.Text;
                ctrlCorreo.Insertar();





            }
            catch (Exception ex)
            {

                Session["mensajeError"] = "Ha ocurrido un error al registrar la persona. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }
            
        }

        protected void dplEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dplMunicipio.Items.Add("Hola");
        }

        protected void dplMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dplParroquia.Items.Add("Hola");
        }
    }
}