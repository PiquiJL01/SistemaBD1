using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Views.Reports
{
    public partial class Resumen_Asistencia : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
        }
    }
}