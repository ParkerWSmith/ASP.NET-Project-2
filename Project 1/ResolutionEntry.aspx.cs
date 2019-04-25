using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace Project_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadTechs();
                LoadTicket();
            }
        }

        //Populates the Tech Dropdown
            private void LoadTechs()
        {
            DataSet dsData;
            drpTech.Items.Clear();
            dsData = clsDatabase.GetTechnicianList();
            drpTech.AppendDataBoundItems = true;
            drpTech.Items.Add(new ListItem("--Technicians--"));
            drpTech.DataSource = dsData.Tables[0];
            drpTech.DataTextField = "TechName";
            drpTech.DataValueField = "TechnicianID";
            drpTech.DataBind();
            dsData.Dispose();
        }

        //Get the Ticket number and the Problem number
        private void LoadTicket()
        {
            lblTicNum.Text = clsDatabase.TicketNo.ToString();
            lblProblem.Text = clsDatabase.ProblemNo.ToString();
            lblResNo.Text = "1";
            clsDatabase.ResolutionNo = "1";
        }

        //Clears text feilds
        public void Clear()
        {
            drpTech.SelectedIndex = 0;
            tbResolution.Text = "";
            txtCostMile.Text = "";
            txtSupplies.Text = "";
            txtMileage.Text = "";
            txtFixed.Text = "";
            txtMisc.Text = "";
            txtOnsite.Text = "";
            lblError.Text = "";
            txtHours.Text = "";
        }

        //Validates the page
        public bool Validate()
        {
            Boolean blnErrorOccurred = false;
            decimal num = 0M;
            long num2 = -1L;
            string str = "";
            if (drpTech.SelectedIndex < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length < 0)
                {
                    str = str + "; ";
                }
                str = str + "Please select a technician; ";
            }
            if (txtHours.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length < 0)
                {
                    str = str + "; ";
                }
                str = str + "Please add hours; ";
            }
            if (tbResolution.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length < 0)
                {
                    str = str + "; ";
                }
                str = str + "Please add a problem description; ";
            }
            lblError.Text = str;
            return !blnErrorOccurred;
        }

        //Return to the main menu
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Problem.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Removes the problem from the grid
        protected void removeProblem()
        {
            //clsDatabase.DeleteProblem(strTicket);
        }

        //Adds this information to the database and removes the ticket number
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (Validate())
            {
                if (clsDatabase.InsertResolution(Convert.ToInt32(lblTicNum.Text), Convert.ToInt32(lblProblem.Text), Convert.ToInt32(lblResNo.Text), Convert.ToString(tbResolution.Text), Convert.ToString(txtFixed.Text), Convert.ToString(txtOnsite.Text), Convert.ToInt32(RuntimeHelpers.GetObjectValue(drpTech.SelectedValue)), Convert.ToDecimal(txtHours.Text), Convert.ToString(txtMileage.Text), Convert.ToString(txtCostMile.Text), Convert.ToString(txtSupplies.Text), Convert.ToString(txtMisc.Text)) != 0)
                {
                    lblError.Text = "Error inserting resolution.";
                    return;
                }
                int num = Convert.ToInt32(clsDatabase.ResolutionNo);
                num = checked(num + 1);
                clsDatabase.ResolutionNo = num.ToString();
                lblResNo.Text = num.ToString();
                Clear();
                lblError.Text = "Resolution inserted. Ready for next resolution";
            }
        }
    }
}