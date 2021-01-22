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

                CodigoPais1.Enabled = false;
                CodigoPais1.CssClass = "input-group-prepend be-addon";
                TipoTelf.Enabled = false;
                TipoTelf.CssClass = "input-group-prepend be-addon";
                CodAre.Enabled = false;
                CodAre.CssClass = "form-control";
                txtTelefono1.Enabled = false;
                txtTelefono1.CssClass = "form-control";


                CodigoPais2.Enabled = false;
                CodigoPais2.CssClass = "input-group-prepend be-addon";
                TipoTelf2.Enabled = false;
                TipoTelf2.CssClass = "input-group-prepend be-addon";
                CodAre2.Enabled = false;
                CodAre2.CssClass = "form-control";
                txtTelefono2.Enabled = false;
                txtTelefono2.CssClass = "form-control";

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

                btnModificar.Enabled = false;
                btnModificar.CssClass = "btn btn-primary btn-user btn-block";

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

                //CORREO
                CorreoElectronico correo = new CorreoElectronico(cliente.CodigoCorreoElectronico);
                txtCorreo.Text = correo.Direccion;
                txtCorreo.Enabled = true;

                //TELEFONOS

                Telefono telefono1 = new Telefono();
                List<Telefono> telefonos = telefono1.Leer(cliente);


                foreach (ListItem item in CodigoPais1.Items)
                {
                    if (item.Value == telefonos[0].Numero[NumeroTelefono.Pais].ToString()) {

                        CodigoPais1.SelectedValue = item.Value;
                    
                    }
                }
                CodigoPais1.Enabled = true;

                TipoTelf.SelectedValue = telefonos[0].Tipo;
                TipoTelf.Enabled = true;
                CodAre.Text = telefonos[0].Numero[NumeroTelefono.Area].ToString();
                CodAre.Enabled = true;
                txtTelefono1.Text = telefonos[0].Numero[NumeroTelefono.Numero].ToString();
                txtTelefono1.Enabled = true;

                if (telefonos.Count > 1) {

                    foreach (ListItem item in CodigoPais2.Items)
                    {
                        if (item.Value == telefonos[1].Numero[NumeroTelefono.Pais].ToString())
                        {

                            CodigoPais2.SelectedValue = item.Value;

                        }
                    }
                    CodigoPais2.Enabled = true;

                    TipoTelf2.SelectedValue = telefonos[1].Tipo;
                    TipoTelf2.Enabled = true;
                    CodAre2.Text = telefonos[1].Numero[NumeroTelefono.Area].ToString();
                    CodAre2.Enabled = true;
                    txtTelefono2.Text = telefonos[1].Numero[NumeroTelefono.Numero].ToString();
                    txtTelefono2.Enabled = true;
                }


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

                btnModificar.Enabled = true;

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

                CodigoPais1.Enabled = false;
                CodigoPais1.CssClass = "input-group-prepend be-addon";
                TipoTelf.Enabled = false;
                TipoTelf.CssClass = "input-group-prepend be-addon";
                CodAre.Enabled = false;
                CodAre.CssClass = "form-control";
                txtTelefono1.Enabled = false;
                txtTelefono1.CssClass = "form-control";


                CodigoPais2.Enabled = false;
                CodigoPais2.CssClass = "input-group-prepend be-addon";
                TipoTelf2.Enabled = false;
                TipoTelf2.CssClass = "input-group-prepend be-addon";
                CodAre2.Enabled = false;
                CodAre2.CssClass = "form-control";
                txtTelefono2.Enabled = false;
                txtTelefono2.CssClass = "form-control";


                dplEstado.Enabled = false;
                dplEstado.CssClass = "input-group-prepend be-addon";
                dplMunicipio.Enabled = false;
                dplMunicipio.CssClass = "input-group-prepend be-addon";
                dplParroquia.Enabled = false;
                dplParroquia.CssClass = "input-group-prepend be-addon";

                btnModificar.Enabled = false;
                btnModificar.CssClass = "btn btn-primary btn-user btn-block";
            }

        }


        protected void btnGuardarCambios(object sender, EventArgs e)
        {
            int CodLug1 = this.CodLugar(dplParroquia, dplMunicipio, dplEstado);
            Lugar lugar = new Lugar(CodLug1);

            CorreoElectronico ctrlCorreo = new CorreoElectronico(txtCorreo.Text);
            ctrlCorreo.Actualizar();

            Cliente datosCliente = new Cliente(dplRif.SelectedValue + txtRif.Text, txtContraseña.Text, ctrlCorreo, null);
            datosCliente.Actualizar();

            Natural natural = new Natural(dplRif.SelectedValue + txtRif.Text, txtContraseña.Text,ctrlCorreo, dplCedula.SelectedValue + txtCedula.Text,Nombre1.Text,Nombre2.Text,Apellido1.Text,Apellido2.Text,lugar);
            natural.Actualizar();

            Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text, datosCliente);
            telefono1.Actualizar();
            Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text, datosCliente);
            telefono1.Actualizar();




        }



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
                if (x.SelectedValue == lugar.Nombre && lugar.Tipo == "Parroquia" && CodMunicpio == lugar.CodigoUbicacion)
                {
                    return lugar.Codigo;
                }

            }

            return 0;
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
            CodigoPais1.Enabled = true;
            CodAre.Enabled = true;
            TipoTelf.Enabled = true;
            txtTelefono1.Enabled = true;
            CodigoPais2.Enabled = true;
            CodAre2.Enabled = true;
            TipoTelf2.Enabled = true;
            txtTelefono2.Enabled = true;
            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;
            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;
            btnModificar.Enabled = true;

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