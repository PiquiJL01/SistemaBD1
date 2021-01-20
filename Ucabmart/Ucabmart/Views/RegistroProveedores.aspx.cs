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
        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;

        protected int CodLugar(DropDownList x, DropDownList y, DropDownList z)
        {
            List<Lugar> lugares = new List<Lugar>();
            lugares = new Lugar().Todos();
            int CodMunicpio = 0;
            int CodEstado = 0;


            foreach (Lugar lugar in lugares)
            {
                if (z.SelectedValue == lugar.Nombre && lugar.Tipo == "Estado")
                {
                    CodEstado = lugar.Codigo;
                }
            }

            foreach (Lugar lugar in lugares)
            {
                if (y.SelectedValue == lugar.Nombre && lugar.Tipo == "Municipio" && CodEstado == lugar.CodigoUbicacion)
                {
                    CodMunicpio = lugar.Codigo;
                }
            }

            foreach (Lugar lugar in lugares)
            {
                if(x.SelectedValue == lugar.Nombre && lugar.Tipo == "Parroquia" && CodMunicpio == lugar.CodigoUbicacion)
                {
                    return lugar.Codigo;
                }

            }

            return 0;
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            int CodLug1 = this.CodLugar(dplParroquia,dplMunicipio,dplEstado);
            int CodLug2 = this.CodLugar(dplParroquia2,dplMunicipio2,dplEstado2);


            CorreoElectronico correo = new CorreoElectronico(txtCorreo.Text);
            correo.Insertar();
            
            Proveedor proveedor = new Proveedor(dplRif.SelectedValue + txtRif.Text, txtRazonSocial.Text , txtDenoComercial.Text, txtPaginaWeb.Text,CodLug2,CodLug1,correo.Codigo);
            proveedor.Insertar();
            Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text, proveedor);
            telefono1.Insertar();
            Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text, proveedor);
            telefono2.Insertar();


            PersonaContacto personaContacto1 = new PersonaContacto(CedulaDrop.SelectedValue + txtCedula.Text, Nombre1.Text, Nombre2.Text, Apellido1.Text, Apellido2.Text, proveedor);
            personaContacto1.Insertar();
            Telefono telefono3 = new Telefono(int.Parse(CodigoPais3.SelectedValue), int.Parse(CodAre3.Text), int.Parse(txtTelefono3.Text), TipoTelf3.Text,personaContacto1);
            telefono3.Insertar();
            Telefono telefono4 = new Telefono(int.Parse(CodigoPais4.SelectedValue), int.Parse(CodAre4.Text), int.Parse(txtTelefono4.Text), TipoTelf4.Text,personaContacto1);
            telefono4.Insertar();


           /* PersonaContacto personaContacto2 = new PersonaContacto(CedulaDrop2.SelectedValue + txtCedula2.Text, Nombre3.Text, Nombre4.Text, Apellido3.Text, Apellido4.Text, proveedor);
            personaContacto2.Insertar();
            Telefono telefono5 = new Telefono(int.Parse(CodigoPais5.SelectedValue), int.Parse(CodAre5.Text), int.Parse(txtTelefono5.Text), TipoTelf5.Text, personaContacto2);
            telefono5.Insertar();
            Telefono telefono6 = new Telefono(int.Parse(CodigoPais6.SelectedValue), int.Parse(CodAre6.Text), int.Parse(txtTelefono6.Text), TipoTelf6.Text, personaContacto2);
            telefono6.Insertar();*/

            Session["ProveedorRif"] = proveedor.RIF;
            Response.Redirect("/Views/Check_Products.aspx", false);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<Lugar> listaLugar = new List<Lugar>();
                listaLugar = nombreLugar.Todos();
                foreach (Lugar item in listaLugar)
                {
                    if (item.Tipo == "Estado")
                    {
                        dplEstado.Items.Add(item.Nombre);
                        dplEstado2.Items.Add(item.Nombre);
                    }
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                        codigoEstado = item.Codigo;
                    //almacena el codigo del estado
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoEstado)
                    {  //compara el codigo del estado con el codigo del municipio
                        dplMunicipio.Items.Add(item.Nombre);      //agrega los municipios   
                        dplMunicipio2.Items.Add(item.Nombre);
                    }
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)   //compara el codigo del estado con el codigo del municipio
                        codigoMunicipio = item.Codigo;
                    //almacena el codigo del municipio 
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoMunicipio)
                    {  //compara el codigo del municipio con el codigo de la parroquia
                        dplParroquia.Items.Add(item.Nombre);
                        dplParroquia2.Items.Add(item.Nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }
        }

        protected void dplEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();
            foreach (Lugar item in listaLugar)
            {
                if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplMunicipio.Items.Clear();
            dplParroquia.Items.Clear();

            foreach (Lugar item in listaLugar)
            {
                if (codigoEstado == item.CodigoUbicacion)
                    dplMunicipio.Items.Add(item.Nombre);
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;

            }

            foreach (Lugar item in listaLugar)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia.Items.Add(item.Nombre);

            }
        }

        protected void dplMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar2 = new List<Lugar>();
            listaLugar2 = nombreLugar.Todos();

            foreach (Lugar item in listaLugar2)
            {
                if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplParroquia.Items.Clear();

            foreach (Lugar item in listaLugar2)
            {
                if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;
            }

            foreach (Lugar item in listaLugar2)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia.Items.Add(item.Nombre);
            }
        }

        protected void dplEstado2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();
            foreach (Lugar item in listaLugar)
            {
                if (dplEstado2.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplMunicipio2.Items.Clear();
            dplParroquia2.Items.Clear();

            foreach (Lugar item in listaLugar)
            {
                if (codigoEstado == item.CodigoUbicacion)
                    dplMunicipio2.Items.Add(item.Nombre);
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplMunicipio2.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;

            }

            foreach (Lugar item in listaLugar)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia2.Items.Add(item.Nombre);

            }
        }

        protected void dplMunicipio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar2 = new List<Lugar>();
            listaLugar2 = nombreLugar.Todos();

            foreach (Lugar item in listaLugar2)
            {
                if (dplEstado2.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplParroquia2.Items.Clear();

            foreach (Lugar item in listaLugar2)
            {
                if (dplMunicipio2.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;
            }

            foreach (Lugar item in listaLugar2)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia2.Items.Add(item.Nombre);
            }
        }

    }

}