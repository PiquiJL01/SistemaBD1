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
            //QRCodeEncoder encoder = new QRCodeEncoder();
            //cadena += "Nombre Completo del Cliente: " + Nombre1.Text +" " + Nombre2.Text + " " + Apellido1.Text + " " + Apellido2.Text + "\n";
            //cadena += "Numero de Rif: " +dplRif.Text + " - " + txtRif.Text + "\n";
            //cadena += "Numero de Cedula: " + dplCedula.Text + " - " + txtCedula.Text + "\n";
            //cadena += "Codigo Tienda: " + "\n";


            //Bitmap img = encoder.Encode(cadena);
            //System.Drawing.Image QR = (System.Drawing.Image)img;

            //using (MemoryStream ms = new MemoryStream()){
            //    QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    byte[] imageBytes = ms.ToArray();
            //    imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
            //    imgCtrl.Height = 200;
            //    imgCtrl.Width = 200;

            //}

            //string _open = "window.open('VerCarnetNatural.aspx', '_newtab');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            
        }
    }
}