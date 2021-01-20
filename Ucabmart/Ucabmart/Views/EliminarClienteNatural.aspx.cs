using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.User
{
    public partial class EliminarClienteNatural : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Natural clienteNatural = new Natural(txtBuscar.Text);

            if (clienteNatural != null) {




            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}