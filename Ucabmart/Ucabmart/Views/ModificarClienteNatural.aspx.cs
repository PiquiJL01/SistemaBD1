using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class ModificarClienteNatural : System.Web.UI.Page
    {
        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;
        int vez = 1;
  

        public void cargarPagina(Boolean flag)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();

            if (flag)
            {
                foreach (Lugar item in listaLugar)
                {
                    if (item.Tipo == "Estado")
                        dplEstado.Items.Add(item.Nombre);
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                        codigoEstado = item.Codigo;
                    //almacena el codigo del estado
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoEstado)   //compara el codigo del estado con el codigo del municipio
                        dplMunicipio.Items.Add(item.Nombre);      //agrega los municipios                       
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)   //compara el codigo del estado con el codigo del municipio
                        codigoMunicipio = item.Codigo;
                    //almacena el codigo del municipio 
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoMunicipio)  //compara el codigo del municipio con el codigo de la parroquia
                        dplParroquia.Items.Add(item.Nombre);
                }
            }
            else
            {

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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                cargarPagina(true);

                Nombre1.Enabled = false;
                Nombre1.CssClass = "form-control";
                Nombre2.Enabled = false;
                Nombre2.CssClass = "form-control";

                Apellido1.Enabled = false;
                Apellido1.CssClass = "form-control";
                Apellido2.Enabled = false;
                Apellido2.CssClass = "form-control";

                dplRif.Enabled = false;
                dplRif.CssClass = "input-group-prepend be-addon";
                txtRif.Enabled = false;
                txtRif.CssClass = "form-control";

                dplCedula.Enabled = false;
                dplCedula.CssClass = "input-group-prepend be-addon";
                txtCedula.Enabled = false;
                txtCedula.CssClass = "form-control";

                txtCorreo.Enabled = false;
                txtCorreo.CssClass = "form-control";

                dplEstado.Enabled = false;
                dplEstado.CssClass = "input-group-prepend be-addon";
                dplMunicipio.Enabled = false;
                dplMunicipio.CssClass = "input-group-prepend be-addon";
                dplParroquia.Enabled = false;
                dplParroquia.CssClass = "input-group-prepend be-addon";

                txtContraseña.Enabled = false;
                txtContraseña.CssClass = "form-control";
                txtRepetirContraseña.Enabled = false;
                txtRepetirContraseña.CssClass = "form-control";

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Natural cliente = new Natural(BuscarRif.Text);


            if (cliente.Cedula != null)
            {
                //NOMBRE Y APELLIDO
                Nombre1.Text = cliente.Nombre1;
                Nombre1.Enabled = true;
                Nombre2.Text = cliente.Nombre2;
                Nombre2.Enabled = true;

                Apellido1.Text = cliente.Apellido1;
                Apellido1.Enabled = true;
                Apellido2.Text = cliente.Apellido2;
                Apellido2.Enabled = true;

                //RIF
                char[] a = new char[1];
                cliente.RIF.CopyTo(0, a, 0, 1);
                char[] NumRif = new char[15];
                cliente.RIF.CopyTo(1, NumRif, 0, cliente.RIF.Length-1);

                dplRif.SelectedValue = new String(a).Replace("\0", "");
                dplRif.Enabled = true;
                txtRif.Text = new String(NumRif).Replace("\0", "");
                txtRif.Enabled = true;

                //Cedula
                char[] c = new char[1];
                cliente.Cedula.CopyTo(0, c, 0, 1);
                char[] NumCed = new char[15];
                cliente.Cedula.CopyTo(1, NumCed, 0, cliente.Cedula.Length - 1);

                dplCedula.SelectedValue = new String(c).Replace("\0", "");
                dplCedula.Enabled = true;
                txtCedula.Text = new String(NumCed).Replace("\0", "");
                txtCedula.Enabled = true;

                //CORREO Y TELEFONOS
                CorreoElectronico correo = new CorreoElectronico(cliente.CodigoCorreoElectronico);
                txtCorreo.Text = correo.Direccion;
                txtCorreo.Enabled = true;


                //LUGAR Y CONTRASEÑA
                Lugar parroquia = new Lugar(cliente.Direccion);
                Lugar Municipio = new Lugar(parroquia.CodigoUbicacion);
                Lugar Estado = new Lugar(Municipio.CodigoUbicacion);
                dplEstado.SelectedValue = Estado.Nombre;
                dplEstado.Enabled = true;
                this.dplEstado_SelectedIndexChanged(sender,e);
                dplMunicipio.SelectedValue = Municipio.Nombre;
                dplMunicipio.Enabled = true;
                this.dplMunicipio_SelectedIndexChanged(sender,e);
                dplParroquia.SelectedValue = parroquia.Nombre;
                dplParroquia.Enabled = true;

                txtContraseña.Text = cliente.Password;
                txtContraseña.Enabled = true;
                txtRepetirContraseña.Text = cliente.Password;
                txtRepetirContraseña.Enabled = true;

            }
            else
            {
                Nombre1.Enabled = false;
                Nombre1.CssClass = "form-control";
                Nombre2.Enabled = false;
                Nombre2.CssClass = "form-control";

                Apellido1.Enabled = false;
                Apellido1.CssClass = "form-control";
                Apellido2.Enabled = false;
                Apellido2.CssClass = "form-control";

                dplRif.Enabled = false;
                dplRif.CssClass = "input-group-prepend be-addon";
                txtRif.Enabled = false;
                txtRif.CssClass = "form-control";

                dplCedula.Enabled = false;
                dplCedula.CssClass = "input-group-prepend be-addon";
                txtCedula.Enabled = false;
                txtCedula.CssClass = "form-control";

                txtCorreo.Enabled = false;
                txtCorreo.CssClass = "form-control";

                dplEstado.Enabled = false;
                dplEstado.CssClass = "input-group-prepend be-addon";
                dplMunicipio.Enabled = false;
                dplMunicipio.CssClass = "input-group-prepend be-addon";
                dplParroquia.Enabled = false;
                dplParroquia.CssClass = "input-group-prepend be-addon";

            }

        }

        protected void dplEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre1.Enabled = true;
            Nombre2.Enabled = true;
            Apellido1.Enabled = true;
            Apellido2.Enabled = true;
            dplRif.Enabled = true;
            txtRif.Enabled = true;
            dplCedula.Enabled = true;
            txtCedula.Enabled = true;
            txtCorreo.Enabled = true;
            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;
            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;

            cargarPagina(false);

        }

        protected void dplMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vez = 2;
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

    }
}