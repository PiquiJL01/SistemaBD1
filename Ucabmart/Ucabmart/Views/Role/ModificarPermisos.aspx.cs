using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class ModificarPermisos : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            this.VisibleFields(false);
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int.Parse(PerAsig.SelectedValue) != 0) && (int.Parse(CamPer.SelectedValue) != 0))
                {

                    Rol rol = new Rol(int.Parse(BuscarCod.Text));
                    MuchosAMuchos ro_pe = new MuchosAMuchos();
                    ro_pe.Eliminar(new Permiso(int.Parse(PerAsig.SelectedValue)),rol);
                    ro_pe.Insertar(rol, new Permiso(int.Parse(CamPer.SelectedValue)));

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El permiso del rol ha sido modificado exitosamente');" +
                        "window.location ='Role_Admin.aspx';", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debe seleccionar un permiso a modificar y elegir cual va a ser el sustituto');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ha ocurrido un error. Intente de Nuevo');", true);
            }

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol(int.Parse(BuscarCod.Text));
            TxtNombre.Text = rol.Nombre;

            this.Permisos_Asignados(rol);
            this.Agregar_Permisos();
            this.VisibleFields(true);
            this.EnableFields(false);

        }


        protected void EnableFields(bool enable)
        {

            TxtNombre.Enabled = enable;
            TxtNombre.CssClass = "form-control";

        }

        protected void VisibleFields(bool visible)
        {
            Nombre.Visible = visible;
            RolHead.Visible = visible;
            TxtNombre.Visible = visible;
            TitleAsig.Visible = visible;
            PerAsig.Visible = visible;
            TitleCam.Visible = visible;
            CamPer.Visible = visible;
            Asignar.Visible = visible;

        }

        protected void Permisos_Asignados(Rol rol)
        {
            PerAsig.Items.Clear();
            List<Permiso> lista = new List<Permiso>();
            lista = rol.Permisos();


            ListItem Title = new ListItem("Permisos Asignados", "0");

            if (!PerAsig.Items.Contains(Title))
            {

                PerAsig.Items.Insert(PerAsig.Items.Count, Title);

            }


            foreach (Permiso item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

                if (!PerAsig.Items.Contains(listItem))
                {
                    PerAsig.Items.Insert(PerAsig.Items.Count, listItem);
                }
            }
        }

        protected void Agregar_Permisos()
        {
            CamPer.Items.Clear();
            Permiso permiso = new Permiso();

            List<Permiso> lista = new List<Permiso>();
            lista = permiso.Todos();

            ListItem Title = new ListItem("Permisos Disponibles", "0");

            if (!CamPer.Items.Contains(Title))
            {

                CamPer.Items.Insert(CamPer.Items.Count, Title);

            }


            foreach (Permiso item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

                if (!CamPer.Items.Contains(listItem) && !PerAsig.Items.Contains(listItem))
                {
                    CamPer.Items.Insert(CamPer.Items.Count, listItem);
                }
            }


        }
    }
}