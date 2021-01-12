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
            Lugar lugar = new Lugar(10);
            Lugar lugar2 = new Lugar(20);
            
            CorreoElectronico correo = new CorreoElectronico(CorreoElectrónico.Text);
            correo.Insertar();
            
            Proveedor proveedor = new Proveedor(dplRif.SelectedValue, RazónSocial.Text,DenominacionComercial.Text,PaginaWeb.Text,40,45,correo.Codigo);
            Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text, proveedor);
            telefono1.Insertar();
            Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text, proveedor);
            telefono2.Insertar();
            proveedor.Insertar();

            PersonaContacto personaContacto1 = new PersonaContacto(CedulaDrop.SelectedValue + txtCedula, Nombre1.Text, Nombre2.Text, Apellido1.Text, Apellido2.Text, proveedor);
            Telefono telefono3 = new Telefono(int.Parse(CodigoPais3.SelectedValue), int.Parse(CodAre3.Text), int.Parse(txtTelefono3.Text), TipoTelf3.Text,personaContacto1);
            telefono3.Insertar();
            Telefono telefono4 = new Telefono(int.Parse(CodigoPais4.SelectedValue), int.Parse(CodAre4.Text), int.Parse(txtTelefono4.Text), TipoTelf4.Text,personaContacto1);
            telefono4.Insertar();
            personaContacto1.Insertar();

            PersonaContacto personaContacto2 = new PersonaContacto(CedulaDrop2.SelectedValue + txtCedula2, Nombre3.Text, Nombre4.Text, Apellido3.Text, Apellido4.Text, proveedor);
            Telefono telefono5 = new Telefono(int.Parse(CodigoPais5.SelectedValue), int.Parse(CodAre5.Text), int.Parse(txtTelefono5.Text), TipoTelf5.Text, personaContacto2);
            telefono5.Insertar();
            Telefono telefono6 = new Telefono(int.Parse(CodigoPais6.SelectedValue), int.Parse(CodAre6.Text), int.Parse(txtTelefono6.Text), TipoTelf6.Text, personaContacto2);
            telefono6.Insertar();
            personaContacto2.Insertar();
        }
    }
}