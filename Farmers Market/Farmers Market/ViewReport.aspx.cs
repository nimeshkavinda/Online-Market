﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmers_Market
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["farmer"] != null)
            {
                Label loggedUser = (Label)Master.FindControl("loggedUser");
                loggedUser.Text = Session["farmer"].ToString();
                PlaceHolder userControls = (PlaceHolder)Master.FindControl("userControls");
                userControls.Visible = false;
                PlaceHolder userAvatar = (PlaceHolder)Master.FindControl("userAvatar");
                userAvatar.Visible = true;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
                String qry = "SELECT * FROM Farmer WHERE Email='" + Session["farmer"].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Farmer");

                string fname = ds.Tables[0].Rows[0][2].ToString();
                string lname = ds.Tables[0].Rows[0][3].ToString();
                string email = ds.Tables[0].Rows[0][0].ToString();

                loggedInFarmer.Text = (fname + " " + lname);

                SqlDataSourceReport.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlDataSourceReport.SelectCommand = "SELECT * FROM Report WHERE Email='" + Session["farmer"].ToString() + "'";
                SqlDataSourceReport.UpdateCommand = "UPDATE [Report] SET [Title] = @Title, [HarvestType] = @HarvestType, [Description] = @Description, [Price] = @Price WHERE [ReportId] = @ReportId";
                SqlDataSourceReport.DeleteCommand = "DELETE FROM [Report] WHERE [ReportId] = @ReportId";

            }
            else
            {

                Response.Redirect("~/FarmerLogin");

            }

        }
    }
}