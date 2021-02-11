using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class ModificarRol : System.Web.UI.Page
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
                if ((int.Parse(RolAsig.SelectedValue) != 0) && (int.Parse(RolAsig.SelectedValue) != 0))
                {

                    Empleado empleado = new Empleado(int.Parse(BuscarCod.Text));
                    MuchosAMuchos em_ca = new MuchosAMuchos();
                    em_ca.Eliminar(empleado, new Rol(int.Parse(RolAsig.SelectedValue)));
                    em_ca.Insertar(empleado, new Rol(int.Parse(CamRol.SelectedValue)));

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El rol ha sido modificado exitosamente');" +
                        "window.location ='Role_Admin.aspx';", true);
                }
                else {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debe seleccionar un Rol a modificar y elegir cual va a ser el sustituto');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ha ocurrido un error. Intente de Nuevo');", true);
            }

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Empleado empleado = new Empleado(int.Parse(BuscarCod.Text));
            TxtNombre.Text = empleado.Nombre1 + " " + empleado.Nombre2 + " " + empleado.Apellido1 + " " + empleado.Apellido2;

            this.Roles_Asignados(empleado);
            this.Agregar_Roles();

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
            EmplHead.Visible = visible;
            TxtNombre.Visible = visible;
            TitleAsig.Visible = visible;
            RolAsig.Visible = visible;
            TitleCam.Visible = visible;
            CamRol.Visible = visible;
            Asignar.Visible = visible;

        }

        protected void Roles_Asignados(Empleado empleado)
        {
            RolAsig.Items.Clear();
            List<Rol> lista = new List<Rol>();
            lista = empleado.Roles();

            ListItem Title = new ListItem("Roles Asignados", "0");

            if (!RolAsig.Items.Contains(Title))
            {

                RolAsig.Items.Insert(RolAsig.Items.Count, Title);

            }

            foreach (Rol item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

                if (!RolAsig.Items.Contains(listItem))
                {
                    RolAsig.Items.Insert(RolAsig.Items.Count, listItem);
                }
            }
        }

        protected void Agregar_Roles()
        {
            CamRol.Items.Clear();
            Rol rol = new Rol();

            List<Rol> lista = new List<Rol>();
            lista = rol.Todos();

            ListItem Title = new ListItem("Roles Disponibles", "0");

            if (!CamRol.Items.Contains(Title))
            {

                CamRol.Items.Insert(CamRol.Items.Count, Title);

            }

            foreach (Rol item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

                if (!RolAsig.Items.Contains(listItem) && !CamRol.Items.Contains(listItem))
                {
                    CamRol.Items.Insert(CamRol.Items.Count, listItem);
                }
            }
        }

     


    }
}