using Microsoft.Build.Framework.XamlTypes;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using RDLCProj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RDLCProj
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BloggerConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                string Query = "select * from ViewLogo";
                SqlCommand cm = new SqlCommand(Query, con);
                SqlDataAdapter adp = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "img";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            ShowReport();

        }
        private void ShowReport()
        {
            //reset
            ReportViewer1.Reset();
            //datasource
            DataTable dt = GetData(TextBox1.Text);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            //Path
            ReportViewer1.LocalReport.ReportPath = "Reporting/Report1.rdlc";
            //Parameters
            ReportViewer1.LocalReport.EnableExternalImages = true;
            string imagePath = new Uri(Server.MapPath("~/images/images.jpg")).AbsoluteUri;
            ReportParameter[] param = new ReportParameter[] {
                new ReportParameter("IMG",DropDownList1.SelectedValue)
            };
            ReportViewer1.LocalReport.SetParameters(param);
            //refresh
            ReportViewer1.LocalReport.Refresh();

        }
        private DataTable GetData(string Name)
        {
            DataTable dt = new DataTable();
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BloggerConnectionString"].ConnectionString;
            using (SqlConnection sc = new SqlConnection(ConnectionString))
            {
                SqlCommand cm = new SqlCommand("ProcSelectArticles", sc);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                SqlDataAdapter adp = new SqlDataAdapter(cm);
                adp.Fill(dt);

            }
            return dt;
        }
    }
}