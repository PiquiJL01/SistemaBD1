using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Views.Role
{
    public partial class AsignarRol : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            Roles.Visible = false;

            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e) { }


        protected void btnBuscar_Click(object sender, EventArgs e) { }

    }
}