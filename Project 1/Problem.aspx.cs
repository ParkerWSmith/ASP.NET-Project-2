using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Project_1
{
    public partial class Problem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                                                                                                                                          
            LoadProblems();
        }

        //Back to main menu
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Default.aspx"); 
        }

        //Populats the gird and saves ticket and prob # to a string
        //Clicking Select moves to Res Entry
        protected void gvProblems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Boolean blnErrorOccurred = false;
            String strGrid = "";

            lblError.Text = "";

            if (e.CommandName.Trim().ToUpper() == "SELECT")
            {
                try
                {
                    clsDatabase.TicketNo = gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
                    clsDatabase.ProblemNo = gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    lblError.Text = "Unable to find problems";
                }

                if (!blnErrorOccurred)
                {
                    Response.Redirect("./ResolutionEntry.aspx");
                }
            }
        }

        //Loads info for the grid
        private void LoadProblems()
        {
            DataSet dsData;

            lblError.Text = "";

            dsData = clsDatabase.GetProblems();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Problems";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Problems";
                dsData.Dispose();
            }
            else
            {
                gvProblems.DataSource = dsData.Tables[0];
                gvProblems.DataBind();
                dsData.Dispose();
            }
        }
    }
}