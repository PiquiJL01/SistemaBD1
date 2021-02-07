using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class ModificarClienteJuridico : System.Web.UI.Page
    {
        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            try
            {
                //PERSONA DE CONTACTO
                dplCedula.Enabled = false;
                dplCedula.CssClass = "input-group-prepend be-addon";
                txtCedula.Enabled = false;
                txtCedula.CssClass = "form-control";

                Nombre1.Enabled = false;
                Nombre1.CssClass = "form-control";
                Nombre2.Enabled = false;
                Nombre2.CssClass = "form-control";

                Apellido1.Enabled = false;
                Apellido1.CssClass = "form-control";
                Apellido2.Enabled = false;
                Apellido2.CssClass = "form-control";

                CodigoPais3.Enabled = false;
                CodigoPais3.CssClass = "input-group-prepend be-addon";
                TipoTelf3.Enabled = false;
                TipoTelf3.CssClass = "input-group-prepend be-addon";
                CodAre3.Enabled = false;
                CodAre3.CssClass = "form-control";
                txtTelefono3.Enabled = false;
                txtTelefono3.CssClass = "form-control";

                CodigoPais4.Enabled = false;
                CodigoPais4.CssClass = "input-group-prepend be-addon";
                TipoTelf4.Enabled = false;
                TipoTelf4.CssClass = "input-group-prepend be-addon";
                CodAre4.Enabled = false;
                CodAre4.CssClass = "form-control";
                txtTelefono4.Enabled = false;
                txtTelefono4.CssClass = "form-control";

                //DATOS DEL CLIENTE JURIDICO
                dplRif.Enabled = false;
                dplRif.CssClass = "input-group-prepend be-addon";
                txtRif.Enabled = false;
                txtRif.CssClass = "form-control";

                txtDenoComercial.Enabled = false;
                txtDenoComercial.CssClass = "form-control";

                txtRazonSocial.Enabled = false;
                txtRazonSocial.CssClass = "form-control";

                txtPaginaWeb.Enabled = false;
                txtPaginaWeb.CssClass = "form-control";

                txtCapitalDisponible.Enabled = false;
                txtCapitalDisponible.CssClass = "form-control";

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

                dplEstado2.Enabled = false;
                dplEstado2.CssClass = "input-group-prepend be-addon";
                dplMunicipio2.Enabled = false;
                dplMunicipio2.CssClass = "input-group-prepend be-addon";
                dplParroquia2.Enabled = false;
                dplParroquia2.CssClass = "input-group-prepend be-addon";

                txtContraseña.Enabled = false;
                txtContraseña.CssClass = "form-control";
                txtRepetirContraseña.Enabled = false;
                txtRepetirContraseña.CssClass = "form-control";

                btnModificar.Enabled = false;
                btnModificar.CssClass = "btn btn-primary btn-user btn-block";


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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Juridico cliente = new Juridico(BuscarRif.Text);

            if (cliente.RazonSocial != null)
            {

                //RIF
                char[] a = new char[1];
                cliente.RIF.CopyTo(0, a, 0, 1);
                char[] NumRif = new char[15];
                cliente.RIF.CopyTo(1, NumRif, 0, cliente.RIF.Length - 1);

                dplRif.SelectedValue = new String(a).Replace("\0", "");
                dplRif.Enabled = true;
                txtRif.Text = new String(NumRif).Replace("\0", "");
                txtRif.Enabled = true;


                txtDenoComercial.Text = cliente.DenominacionComercial;
                txtDenoComercial.Enabled = true;
                txtRazonSocial.Text = cliente.RazonSocial;
                txtRazonSocial.Enabled = true;
                txtPaginaWeb.Text = cliente.PaginaWeb;
                txtPaginaWeb.Enabled = true;
                txtCapitalDisponible.Text = cliente.Capital.ToString();
                txtCapitalDisponible.Enabled = true;


                //CORREO
                CorreoElectronico correo = new CorreoElectronico(cliente.CodigoCorreoElectronico);
                txtCorreo.Text = correo.Direccion;
                txtCorreo.Enabled = true;

                //TELEFONOS

                Telefono telefono1 = new Telefono();
                List<Telefono> telefonos = telefono1.Leer(cliente);


                foreach (ListItem item in CodigoPais1.Items)
                {
                    if (item.Value == telefonos[0].Numero[NumeroTelefono.Pais].ToString())
                    {

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

                if (telefonos.Count > 1)
                {

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


                //DIRECCION FISCAL
                Lugar parroquia = new Lugar(cliente.DireccionFiscal);
                Lugar Municipio = new Lugar(parroquia.CodigoUbicacion);
                Lugar Estado = new Lugar(Municipio.CodigoUbicacion);
                dplEstado.SelectedValue = Estado.Nombre;
                dplEstado.Enabled = true;
                this.dplEstado_SelectedIndexChanged(sender, e);
                dplMunicipio.SelectedValue = Municipio.Nombre;
                dplMunicipio.Enabled = true;
                this.dplMunicipio_SelectedIndexChanged(sender, e);
                dplParroquia.SelectedValue = parroquia.Nombre;
                dplParroquia.Enabled = true;

                //DIRECCION FISICA PRINCIPAL
                Lugar parroquia2 = new Lugar(cliente.DireccionFisica);
                Lugar Municipio2 = new Lugar(parroquia2.CodigoUbicacion);
                Lugar Estado2 = new Lugar(Municipio2.CodigoUbicacion);
                dplEstado2.SelectedValue = Estado2.Nombre;
                dplEstado2.Enabled = true;
                this.dplEstado2_SelectedIndexChanged(sender, e);
                dplMunicipio2.SelectedValue = Municipio2.Nombre;
                dplMunicipio2.Enabled = true;
                this.dplMunicipio2_SelectedIndexChanged(sender, e);
                dplParroquia2.SelectedValue = parroquia2.Nombre;
                dplParroquia2.Enabled = true;

                //CONTRASEÑA
                txtContraseña.Text = cliente.Password;
                txtContraseña.Enabled = true;
                txtRepetirContraseña.Text = cliente.Password;
                txtRepetirContraseña.Enabled = true;

                //PERSONA DE CONTACTO

                PersonaContacto contacto = cliente.PersonaContacto();

                //CEDULA
                char[] c = new char[1];
                contacto.Cedula.CopyTo(0, c, 0, 1);
                char[] NumCed = new char[15];
                contacto.Cedula.CopyTo(1, NumCed, 0, contacto.Cedula.Length - 1);

                dplCedula.SelectedValue = new String(c).Replace("\0", "");
                dplCedula.Enabled = true;
                txtCedula.Text = new String(NumCed).Replace("\0", "");
                txtCedula.Enabled = true;

                //NOMBRE Y APELLIDO DE LA PERSONA DE CONTACTO
                Nombre1.Text = contacto.Nombre1;
                Nombre1.Enabled = true;
                Nombre2.Text = contacto.Nombre2;
                Nombre2.Enabled = true;

                Apellido1.Text = contacto.Apellido1;
                Apellido1.Enabled = true;
                Apellido2.Text = contacto.Apellido2;
                Apellido2.Enabled = true;


                //TELEFONOS DE LA PERSONA DE CONTACTO

                Telefono telefono3 = new Telefono();
                List<Telefono> telefonosPC = telefono3.Leer(contacto);


                foreach (ListItem item in CodigoPais3.Items)
                {
                    if (item.Value == telefonosPC[0].Numero[NumeroTelefono.Pais].ToString())
                    {

                        CodigoPais3.SelectedValue = item.Value;

                    }
                }
                CodigoPais3.Enabled = true;

                TipoTelf3.SelectedValue = telefonosPC[0].Tipo;
                TipoTelf3.Enabled = true;
                CodAre3.Text = telefonosPC[0].Numero[NumeroTelefono.Area].ToString();
                CodAre3.Enabled = true;
                txtTelefono3.Text = telefonosPC[0].Numero[NumeroTelefono.Numero].ToString();
                txtTelefono3.Enabled = true;

                if (telefonosPC.Count > 1)
                {

                    foreach (ListItem item in CodigoPais4.Items)
                    {
                        if (item.Value == telefonosPC[1].Numero[NumeroTelefono.Pais].ToString())
                        {

                            CodigoPais4.SelectedValue = item.Value;

                        }
                    }
                    CodigoPais4.Enabled = true;

                    TipoTelf4.SelectedValue = telefonosPC[1].Tipo;
                    TipoTelf4.Enabled = true;
                    CodAre4.Text = telefonosPC[1].Numero[NumeroTelefono.Area].ToString();
                    CodAre4.Enabled = true;
                    txtTelefono4.Text = telefonosPC[1].Numero[NumeroTelefono.Numero].ToString();
                    txtTelefono4.Enabled = true;
                }

                btnModificar.Enabled = true;

            }
            else
            {
                //PERSONA DE CONTACTO
                dplCedula.Enabled = false;
                dplCedula.CssClass = "input-group-prepend be-addon";
                txtCedula.Enabled = false;
                txtCedula.CssClass = "form-control";

                Nombre1.Enabled = false;
                Nombre1.CssClass = "form-control";
                Nombre2.Enabled = false;
                Nombre2.CssClass = "form-control";

                Apellido1.Enabled = false;
                Apellido1.CssClass = "form-control";
                Apellido2.Enabled = false;
                Apellido2.CssClass = "form-control";

                CodigoPais3.Enabled = false;
                CodigoPais3.CssClass = "input-group-prepend be-addon";
                TipoTelf3.Enabled = false;
                TipoTelf3.CssClass = "input-group-prepend be-addon";
                CodAre3.Enabled = false;
                CodAre3.CssClass = "form-control";
                txtTelefono3.Enabled = false;
                txtTelefono3.CssClass = "form-control";

                CodigoPais4.Enabled = false;
                CodigoPais4.CssClass = "input-group-prepend be-addon";
                TipoTelf4.Enabled = false;
                TipoTelf4.CssClass = "input-group-prepend be-addon";
                CodAre4.Enabled = false;
                CodAre4.CssClass = "form-control";
                txtTelefono4.Enabled = false;
                txtTelefono4.CssClass = "form-control";

                //DATOS DEL CLIENTE JURIDICO
                dplRif.Enabled = false;
                dplRif.CssClass = "input-group-prepend be-addon";
                txtRif.Enabled = false;
                txtRif.CssClass = "form-control";

                txtDenoComercial.Enabled = false;
                txtDenoComercial.CssClass = "form-control";

                txtRazonSocial.Enabled = false;
                txtRazonSocial.CssClass = "form-control";

                txtPaginaWeb.Enabled = false;
                txtPaginaWeb.CssClass = "form-control";

                txtCapitalDisponible.Enabled = false;
                txtCapitalDisponible.CssClass = "form-control";

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

                dplEstado2.Enabled = false;
                dplEstado2.CssClass = "input-group-prepend be-addon";
                dplMunicipio2.Enabled = false;
                dplMunicipio2.CssClass = "input-group-prepend be-addon";
                dplParroquia2.Enabled = false;
                dplParroquia2.CssClass = "input-group-prepend be-addon";

                txtContraseña.Enabled = false;
                txtContraseña.CssClass = "form-control";
                txtRepetirContraseña.Enabled = false;
                txtRepetirContraseña.CssClass = "form-control";

                btnModificar.Enabled = false;
                btnModificar.CssClass = "btn btn-primary btn-user btn-block";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El cliente no existe');", true);
            }

        }

        protected void btnGuardarCambios(object sender, EventArgs e)
        {
            try
            {
                //CLIENTE JURIDICO         

                int CodLug1 = this.CodLugar(dplParroquia, dplMunicipio, dplEstado);
                int CodLug2 = this.CodLugar(dplParroquia2, dplMunicipio2, dplEstado2);


                Juridico ClienteJuridico = new Juridico(dplRif.SelectedValue + txtRif.Text);
                ClienteJuridico.DenominacionComercial = txtDenoComercial.Text;
                ClienteJuridico.RazonSocial = txtRazonSocial.Text;
                ClienteJuridico.PaginaWeb = txtPaginaWeb.Text;
                ClienteJuridico.Capital = float.Parse(txtCapitalDisponible.Text);
                ClienteJuridico.Password = txtContraseña.Text;
                ClienteJuridico.DireccionFiscal = CodLug1;
                ClienteJuridico.DireccionFisica = CodLug2;


                CorreoElectronico ctrlCorreo = new CorreoElectronico(ClienteJuridico.CodigoCorreoElectronico);
                ctrlCorreo.Direccion = txtCorreo.Text;
                ctrlCorreo.Actualizar();

                ClienteJuridico.Actualizar();

                Telefono telefono = new Telefono();
                List<Telefono> telefonos = telefono.Leer(ClienteJuridico);


                Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text, ClienteJuridico);
                Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text, ClienteJuridico);

                if (!VerificarCambiosTelefono(telefonos[0], telefono1))
                {
                    telefonos[0].Eliminar();
                    telefono1.Insertar();
                }

                if (!VerificarCambiosTelefono(telefonos[1], telefono2))
                {
                    telefonos[1].Eliminar();
                    telefono2.Insertar();
                }

                //PERSONA DE CONTACTO

                PersonaContacto contacto = ClienteJuridico.PersonaContacto();
                contacto.Nombre1 = Nombre1.Text;
                contacto.Nombre2 = Nombre2.Text;
                contacto.Apellido1 = Apellido1.Text;
                contacto.Apellido2 = Apellido2.Text;
                contacto.Cedula = dplCedula.SelectedValue + txtCedula.Text;

                contacto.Actualizar();


                telefonos = telefono.Leer(contacto);


                Telefono telefono3 = new Telefono(int.Parse(CodigoPais3.SelectedValue), int.Parse(CodAre3.Text), int.Parse(txtTelefono3.Text), TipoTelf3.Text, contacto);
                Telefono telefono4 = new Telefono(int.Parse(CodigoPais4.SelectedValue), int.Parse(CodAre4.Text), int.Parse(txtTelefono4.Text), TipoTelf4.Text, contacto);

                if (!VerificarCambiosTelefono(telefonos[0], telefono3))
                {
                    telefonos[0].Eliminar();
                    telefono3.Insertar();
                }

                if (!VerificarCambiosTelefono(telefonos[1], telefono4))
                {
                    telefonos[1].Eliminar();
                    telefono4.Insertar();
                }

                //Response.Redirect("/Views/Clientes_Admin.aspx", false);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El cliente se ha sido modificado exitosamente');" +
                                    "window.location ='Clientes_Admin';", true);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al modificar el cliente juridico. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }
        }

        protected bool VerificarCambiosTelefono(Telefono tlf1, Telefono tlf2)
        {
            if (tlf1.Numero[NumeroTelefono.Area] == tlf2.Numero[NumeroTelefono.Area] && tlf1.Numero[NumeroTelefono.Pais] == tlf2.Numero[NumeroTelefono.Pais] && tlf1.Numero[NumeroTelefono.Numero] == tlf2.Numero[NumeroTelefono.Numero] && tlf1.Tipo == tlf2.Tipo)
            {
                return true;
            }
            return false;


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
            dplCedula.Enabled = true;
            txtCedula.Enabled = true;

            Nombre1.Enabled = true;
            Nombre2.Enabled = true;

            Apellido1.Enabled = true;
            Apellido2.Enabled = true;

            CodigoPais3.Enabled = true;
            TipoTelf3.Enabled = true;
            CodAre3.Enabled = true;
            txtTelefono3.Enabled = true;

            CodigoPais4.Enabled = true;
            TipoTelf4.Enabled = true;
            CodAre4.Enabled = true;
            txtTelefono4.Enabled = true;

            //DATOS DEL CLIENTE JURIDICO
            dplRif.Enabled = true;
            txtRif.Enabled = true;

            txtDenoComercial.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtPaginaWeb.Enabled = true;
            txtCapitalDisponible.Enabled = true;
            txtCorreo.Enabled = true;

            CodigoPais1.Enabled = true;
            TipoTelf.Enabled = true;
            CodAre.Enabled = true;
            txtTelefono1.Enabled = true;

            CodigoPais2.Enabled = true;
            TipoTelf2.Enabled = true;
            CodAre2.Enabled = true;
            txtTelefono2.Enabled = true;

            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;

            dplEstado2.Enabled = true;
            dplMunicipio2.Enabled = true;
            dplParroquia2.Enabled = true;

            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;

            btnModificar.Enabled = true;


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
            dplCedula.Enabled = true;
            txtCedula.Enabled = true;

            Nombre1.Enabled = true;
            Nombre2.Enabled = true;

            Apellido1.Enabled = true;
            Apellido2.Enabled = true;

            CodigoPais3.Enabled = true;
            TipoTelf3.Enabled = true;
            CodAre3.Enabled = true;
            txtTelefono3.Enabled = true;

            CodigoPais4.Enabled = true;
            TipoTelf4.Enabled = true;
            CodAre4.Enabled = true;
            txtTelefono4.Enabled = true;

            //DATOS DEL CLIENTE JURIDICO
            dplRif.Enabled = true;
            txtRif.Enabled = true;

            txtDenoComercial.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtPaginaWeb.Enabled = true;
            txtCapitalDisponible.Enabled = true;
            txtCorreo.Enabled = true;

            CodigoPais1.Enabled = true;
            TipoTelf.Enabled = true;
            CodAre.Enabled = true;
            txtTelefono1.Enabled = true;

            CodigoPais2.Enabled = true;
            TipoTelf2.Enabled = true;
            CodAre2.Enabled = true;
            txtTelefono2.Enabled = true;

            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;

            dplEstado2.Enabled = true;
            dplMunicipio2.Enabled = true;
            dplParroquia2.Enabled = true;

            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;

            btnModificar.Enabled = true;


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
            dplCedula.Enabled = true;
            txtCedula.Enabled = true;

            Nombre1.Enabled = true;
            Nombre2.Enabled = true;

            Apellido1.Enabled = true;
            Apellido2.Enabled = true;

            CodigoPais3.Enabled = true;
            TipoTelf3.Enabled = true;
            CodAre3.Enabled = true;
            txtTelefono3.Enabled = true;

            CodigoPais4.Enabled = true;
            TipoTelf4.Enabled = true;
            CodAre4.Enabled = true;
            txtTelefono4.Enabled = true;

            //DATOS DEL CLIENTE JURIDICO
            dplRif.Enabled = true;
            txtRif.Enabled = true;

            txtDenoComercial.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtPaginaWeb.Enabled = true;
            txtCapitalDisponible.Enabled = true;
            txtCorreo.Enabled = true;

            CodigoPais1.Enabled = true;
            TipoTelf.Enabled = true;
            CodAre.Enabled = true;
            txtTelefono1.Enabled = true;

            CodigoPais2.Enabled = true;
            TipoTelf2.Enabled = true;
            CodAre2.Enabled = true;
            txtTelefono2.Enabled = true;

            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;

            dplEstado2.Enabled = true;
            dplMunicipio2.Enabled = true;
            dplParroquia2.Enabled = true;

            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;

            btnModificar.Enabled = true;

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
            dplCedula.Enabled = true;
            txtCedula.Enabled = true;

            Nombre1.Enabled = true;
            Nombre2.Enabled = true;

            Apellido1.Enabled = true;
            Apellido2.Enabled = true;

            CodigoPais3.Enabled = true;
            TipoTelf3.Enabled = true;
            CodAre3.Enabled = true;
            txtTelefono3.Enabled = true;

            CodigoPais4.Enabled = true;
            TipoTelf4.Enabled = true;
            CodAre4.Enabled = true;
            txtTelefono4.Enabled = true;

            //DATOS DEL CLIENTE JURIDICO
            dplRif.Enabled = true;
            txtRif.Enabled = true;

            txtDenoComercial.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtPaginaWeb.Enabled = true;
            txtCapitalDisponible.Enabled = true;
            txtCorreo.Enabled = true;

            CodigoPais1.Enabled = true;
            TipoTelf.Enabled = true;
            CodAre.Enabled = true;
            txtTelefono1.Enabled = true;

            CodigoPais2.Enabled = true;
            TipoTelf2.Enabled = true;
            CodAre2.Enabled = true;
            txtTelefono2.Enabled = true;

            dplEstado.Enabled = true;
            dplMunicipio.Enabled = true;
            dplParroquia.Enabled = true;

            dplEstado2.Enabled = true;
            dplMunicipio2.Enabled = true;
            dplParroquia2.Enabled = true;

            txtContraseña.Enabled = true;
            txtRepetirContraseña.Enabled = true;

            btnModificar.Enabled = true;

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