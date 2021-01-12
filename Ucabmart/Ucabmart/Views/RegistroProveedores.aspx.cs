using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            CorreoElectronico correo = new CorreoElectronico(CorreoElectrónico.Text);
            Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue),int.Parse(CodAre.Text),int.Parse(txtTelefono1.Text));
            Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text));

            //PersonaContacto personaContacto1 = new PersonaContacto(CedulaDrop.SelectedValue + TextBox1,Nombre1,Nombre2,Apellido1,Apellido2,);



            //Proveedor proveedor = new Proveedor(dplRif.SelectedValue, RazónSocial.Text,DenominacionComercial.Text,PaginaWeb.Text);

            String a = RazónSocial.Text;
            String b = dplRif.SelectedValue;
        }
    }
}