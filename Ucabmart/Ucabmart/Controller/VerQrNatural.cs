using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Ucabmart.Controller
{
    public class VerQrNatural
    {
       

        public System.Web.UI.HtmlControls.HtmlImage GenerarQr(System.Web.UI.HtmlControls.HtmlImage imgCtrl, string cadena) {

            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(cadena);
            System.Drawing.Image QR = (System.Drawing.Image)img;

            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgCtrl.Height = 200;
                imgCtrl.Width = 200;

            }
            return imgCtrl;
        }

        public System.Web.UI.HtmlControls.HtmlImage MostrarQR (System.Web.UI.HtmlControls.HtmlImage codigo, string imagen ) {

            System.Text.ASCIIEncoding enco = new System.Text.ASCIIEncoding();
            byte[] prueba2 = enco.GetBytes(imagen);
            //byte[] imageBytes = System.Text.UTF32Encoding.Default.GetBytes(imagen);
            // byte[] imageBytes = Encoding.BigEndianUnicode.GetBytes(imagen);




            codigo.Src = "data:image/gif;base64," + Convert.ToBase64String(prueba2);
                codigo.Height = 200;
                codigo.Width = 200;
                
            

            return codigo;
        }

    }
}