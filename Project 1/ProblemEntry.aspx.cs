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
    public partial class ProblemEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clsDatabase.ProblemNo = "";
                lblError.Text = "";
                lblTicNum.Text = "";
                LoadProducts();
                LoadTechs();
                LoadProblems();
            }
        }

        //Populates the Technician dropdown
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

        //Set the problem # to 1 and gets the ticket number
        private void LoadProblems()
        {
            lblTicNum.Text = clsDatabase.TicketNo;
            lblProblemNumb.Text = "1";
            clsDatabase.ProblemNo = "1";
        }

        //Populats the Products field
        private void LoadProducts()

        {
            DataSet dsData;
            drpTech.Items.Clear();
            dsData = clsDatabase.GetProductList();
            drpProduct.AppendDataBoundItems = true;
            drpProduct.DataSource = dsData.Tables[0];
            drpProduct.DataTextField = "ProductDesc";
            drpProduct.DataValueField = "ProductID";
            drpProduct.DataBind();
            dsData.Dispose();
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
            if (drpProduct.SelectedIndex < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length < 0)
                {
                    str = str + "; ";
                }
                str = str + "Please select a product; ";
            }
            if (tbProblem.Text.Trim().Length < 1)
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

            protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Default.aspx");
        }

        //Clears the page and adds 1 to the problem number and saves ticket and prob number to a string
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (Validate())
            {
                if (clsDatabase.InsertProblem(Convert.ToInt32(lblTicNum.Text), Convert.ToInt32(lblProblemNumb.Text), Convert.ToString(tbProblem.Text), Convert.ToInt32(RuntimeHelpers.GetObjectValue(drpTech.SelectedValue)), Convert.ToString(drpProduct.SelectedValue)) != 0)
                {
                    lblError.Text = "Error inserting problem.";
                }
                else
                {
                    int num = Convert.ToInt32(clsDatabase.ProblemNo);
                    num = checked (num + 1);
                    clsDatabase.ProblemNo = num.ToString();
                    lblProblemNumb.Text = num.ToString();
                    drpProduct.SelectedIndex = 0;
                    Clear();
                    btnInfo.Enabled = true;
                    lblError.Text = "Problem inserted. Ready for next problem";
                }
            }
        }
    
        //Clears the text fields
        public void Clear()
        {
            drpTech.SelectedIndex = 0;
            tbProblem.Text = "";
            drpProduct.SelectedIndex = 0;
            lblError.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}