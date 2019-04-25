using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsDatabase.TicketNo = "";
                lblDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                LoadClient();
            }
        }

        //Back to main menu
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Default.aspx");
        }


        //Populate the Client Dropdown
        private void LoadClient()

        {
            DataSet dsData;
            drpClient.Items.Clear();
            lblError.Text = "";
            dsData = clsDatabase.GetClientList();
            drpClient.AppendDataBoundItems = true;
            drpClient.Items.Add(new ListItem("--Client--"));
            drpClient.DataSource = dsData.Tables[0];
            drpClient.DataTextField = "ClientName";
            drpClient.DataValueField = "ClientID";
            drpClient.DataBind();
            dsData.Dispose();
        }

        //Clear the Text Fields
        public void Clear()
        {
            drpClient.SelectedIndex = 0;
            ContactTxt.Text = "";
            PhoneTxt.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Inserts the data to the database and saves a new ticket number
        protected void NextBtn_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int num = clsDatabase.InsertServiceEvent(Convert.ToInt32(drpClient.SelectedValue), Convert.ToDateTime(lblDate.Text), PhoneTxt.Text.Trim(), ContactTxt.Text.Trim());
                if (num > 0)
                {
                    clsDatabase.TicketNo = num.ToString();
                    Clear();   
                    Response.Redirect("ProblemEntry.aspx");
                }
                else
                {
                    lblError.Text = "Unable to add service event";
                }
            }
        }

        //Validates the fields
        public bool Validate()
        {
            Boolean blnErrorOccurred = false;
            decimal num = 0M;
            long num2 = -1L;
            string str = "";
            if(drpClient.SelectedIndex < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length < 0)
                {
                    str = str + "; ";
                }
                str = str + "Please select a client";
            }
            if (ContactTxt.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Contact is required";
            }
            if (PhoneTxt.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Telephone is required";
            }
            else if (PhoneTxt.Text.Trim().Length < 10)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Telephone must be 10 digits";
            }
            else
            {
                //Convert phone number to int64
                try
                {
                    num2 = Convert.ToInt64(PhoneTxt.Text);
                }
                catch (Exception ex)
                {
                    num2 = -1L;
                }
                if (num2 < 0L)
                {
                    blnErrorOccurred = true;
                    if (str.Trim().Length > 0)
                    {
                        str = str + "; ";
                    }
                    str = str + "Telephone must be numeric";
                }
            }
            lblError.Text = str;
            return !blnErrorOccurred;
        }
    }
}