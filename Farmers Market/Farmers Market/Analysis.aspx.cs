﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Farmers_Market
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                getMostPrice();
                getMostType();
                getSoldItems();
                getPriceChartData();
                getItemTypeChartData();
                getLocationChartData();
                getFlagChartData();
            }

        }

        private void getMostPrice()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            String qry = "SELECT MAX(Convert(int, Price)) as mostPrice FROM Report WHERE isnumeric(Price) = 1";

            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Report");

            string price = ds.Tables[0].Rows[0]["mostPrice"].ToString();
            mostItemPrice.Text = price;

        }

        private void getMostType()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            String qry = "SELECT HarvestType, COUNT(HarvestType) AS mostType FROM Report GROUP BY HarvestType ORDER BY mostType DESC";

            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Report");

            string type = ds.Tables[0].Rows[0]["HarvestType"].ToString();
            mostItemType.Text = type;

        }

        private void getSoldItems()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            String qry = "SELECT COUNT(Status) AS soldItems FROM Report WHERE Status='Sold'";

            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Report");

            string sold = ds.Tables[0].Rows[0]["soldItems"].ToString();
            soldItems.Text = sold;

        }

        private void getPriceChartData()
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new
                        SqlCommand("SELECT Title, Price FROM Report", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    Series chartPriceSeries = chartPrice.Series["chartPriceSeries"];

                    while (sdr.Read())
                    {
                        chartPriceSeries.Points.AddXY(sdr["Title"].ToString(),
                            sdr["Price"]);
                    }
                }

            }
            catch (SqlException) 
            {

            }

        }

        private void getItemTypeChartData()
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new
                        SqlCommand("SELECT HarvestType, COUNT(*) AS noOfTypes FROM Report GROUP BY HarvestType", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    Series chartItemTypeSeries = chartItemType.Series["chartItemTypeSeries"];

                    while (sdr.Read())
                    {

                        chartItemTypeSeries.Points.AddXY(sdr["HarvestType"],
                            sdr["noOfTypes"]);

                    }
                }

            }
            catch (SqlException) 
            { 

            }

        }

        private void getLocationChartData()
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new
                        SqlCommand("SELECT City, COUNT(*) AS noOfReports FROM Report JOIN Farmer ON Report.Email=Farmer.Email GROUP BY City", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    Series chartFarmerLocationSeries = chartFarmerLocation.Series["chartFarmerLocationSeries"];

                    while (sdr.Read())
                    {
                        chartFarmerLocationSeries.Points.AddXY(sdr["City"].ToString(),
                            sdr["noOfReports"]);
                    }
                }

            }
            catch (SqlException)
            {

            }

        }

        private void getFlagChartData()
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new
                        SqlCommand("SELECT CASE Flag WHEN 'http://maps.google.com/mapfiles/ms/icons/green-dot.png' THEN 'Flagged as edible' WHEN 'http://maps.google.com/mapfiles/ms/icons/caution.png' THEN 'Flagged as in-edible' ELSE 'Not yet flagged' END AS flagName, COUNT(*) AS noOfTypes FROM Report GROUP BY Flag", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    Series chartFlagSeries = chartFlag.Series["chartFlagSeries"];

                    while (sdr.Read())
                    {

                        chartFlagSeries.Points.AddXY(sdr["flagName"],
                            sdr["noOfTypes"]);

                    }
                }

            }
            catch (SqlException)
            {

            }

        }
    }
}