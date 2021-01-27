using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Reporting.WebForms;
using Ucabmart.Reports;

namespace Ucabmart.Views
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
                DataSet1 dsCustomers = GetData("select top 20 * from customers");
                ReportDataSource datasource = new ReportDataSource("Customers", dsCustomers.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }

        private DataSet1 GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["Host=labs-dbservices01.ucab.edu.ve;Database=grupo5db;Username=grupo5bd1;Password=123456789;Persist Security Info=True"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataSet1 dsCustomers = new DataSet1())
                    {
                        sda.Fill(dsCustomers, "DataTable1");
                        return dsCustomers;
                    }
                }
            }
        }
    }
}