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
    public partial class Technicians : System.Web.UI.Page
    {

        //Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadTechs();
            }
        }

        //Load Techs
        private void LoadTechs()

        {
            DataSet dsData;
            drpTech.Items.Clear();
            lblError.Text = "";
            dsData = clsDatabase.GetTechnicianList();
            drpTech.Items.Add(new ListItem("--Selected Technicians--"));
            drpTech.AppendDataBoundItems = true;
            drpTech.DataSource = dsData.Tables[0];
            drpTech.DataTextField = "TechName";
            drpTech.DataValueField = "TechnicianID";
            drpTech.DataBind();
            dsData.Dispose();
        }

        //Clear all fields
        public void Clear()
        {
            txtFName.Text = "";
            txtMInit.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtDept.Text = "";
            txtPhone.Text = "";
            txtHRate.Text = "";
        }

        //Turn on buttons and turn off dropdown
        public void ButtonsOn()
        {
            btnAccept.Enabled = true;
            btnCancel.Enabled = true;
            btnRemove.Enabled = true;
            btnClear.Enabled = true;
            btnNew.Enabled = false;
            drpTech.Enabled = false;
        }

        //Turn off Buttons and turn on dropdown
        public void ButtonsOff()
        {
            btnAccept.Enabled = false;
            btnCancel.Enabled = false;
            btnRemove.Enabled = false;
            btnClear.Enabled = false;
            btnNew.Enabled = true;
            drpTech.Enabled = true;
        }

        //Return Button
        //Return to default page
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Default.aspx");
        }

        //Add Tech Button
        //Clear fields to add a new Tech
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            lblError.Text = "";
            ButtonsOn();

        }

        //Remove Button
        //Remove a tech from the DB and clear the fields
        protected void btnRemove_Click(object sender, EventArgs e)
        {

            if (drpTech.SelectedIndex == 0)
            {
                lblError.Text = "Choose a Tech to remove";
            }
            else
            {
                clsDatabase.DeleteTechnician(drpTech.SelectedValue);
                LoadTechs();
                ButtonsOff();
            }
        }

        //Cancel Button
        //Cancel editing or adding
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            lblError.Text = "";
        }

        //Clear Button
        //Clear all fields on click
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            lblError.Text = "";
        }

        //Pull info from DB to pupulate textboxes
        private void DisplayTechnician(String strTechID)
        {
            DataSet dsData;

            dsData = clsDatabase.GetTechnicianByID(strTechID);
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Technicians";
            }
            else if (dsData.Tables.Count < 0)
            {
                lblError.Text = "Error retrieving Technicians";
                dsData.Dispose();
            }
            else
            {
                if (dsData.Tables[0].Rows[0]["FName"] == DBNull.Value)
                {
                    txtFName.Text = "";
                }
                else
                {
                    txtFName.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["LName"] == DBNull.Value)
                {
                    txtLName.Text = "";
                }
                else
                {
                    txtLName.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMInit.Text = "";
                }
                else
                {
                    txtMInit.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value)
                {
                    txtEmail.Text = "";
                }
                else
                {
                    txtEmail.Text = dsData.Tables[0].Rows[0]["EMail"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                {
                    txtDept.Text = "";
                }
                else
                {
                    txtDept.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value)
                {
                    txtPhone.Text = "";
                }
                else
                {
                    txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
                {
                    txtHRate.Text = "";
                }
                else
                {
                    txtHRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                }
            }
        }

        //Choose which info will populate the textboxes
        protected void drpTech_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpTech.SelectedIndex > 0)
            {
                DisplayTechnician(drpTech.SelectedValue.ToString());
                ButtonsOn();
            }
            else
            {

            }
        }

        //Validate the data in the textboxes
        public bool ValidateText()
        {
            Boolean blnErrorOccurred = false;
            decimal num = 0M;
            long num2 = -1L;
            string str = "";
            if (txtFName.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "First Name is required";
            }
            if (txtLName.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Last Name is required";
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Telephone is required";
            }
            else if (txtPhone.Text.Trim().Length < 10)
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
                    num2 = Convert.ToInt64(txtPhone.Text);
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
            if (txtHRate.Text.Trim().Length < 1)
            {
                blnErrorOccurred = true;
                if (str.Trim().Length > 0)
                {
                    str = str + "; ";
                }
                str = str + "Hourly Rate is required";
            }
            else
            {
                try
                {
                    num = Convert.ToDecimal(this.txtHRate.Text);
                }
                catch (Exception ex)
                {
                    num = -1M;
                }
                if (decimal.Compare(num, 0M) < 0)
                {
                    blnErrorOccurred = true;
                    if (str.Trim().Length > 0)
                    {
                        str = str + "; ";
                    }
                    str = str + "Hourly Rate must be numeric";
                }
            }
            lblError.Text = str;
            return !blnErrorOccurred;
        }

        //Insert added technician to the DB
        protected void InsertTechnician()
        {
            Int32 intRetValue;

            if (Session.Contents["NewTechnicianID"] == null)
            {
                
                intRetValue = clsDatabase.InsertTechnician(txtLName.Text.Trim(), txtFName.Text.Trim(), txtMInit.Text.Trim(), txtEmail.Text.Trim(), txtDept.Text.Trim(), txtPhone.Text.Trim(), Convert.ToDecimal(txtHRate.Text.Trim()));
                if (intRetValue == 0)
                {
                    lblError.Text = "New Tech Added";
                    LoadTechs();
                }
                else
                {
                    lblError.Text = "Error inserting Technician";
                }
            }
        }

        //Update Technician
        protected void UpdateTechnician()
        {
            Int32 intRetValue;
            if (Session.Contents["TechnicianID"] == null)
            {
                intRetValue = clsDatabase.UpdateTechnician(Convert.ToInt32(drpTech.SelectedValue), txtLName.Text.Trim(), txtFName.Text.Trim(), txtMInit.Text.Trim(), txtEmail.Text.Trim(), txtDept.Text.Trim(), txtPhone.Text.Trim(), Convert.ToDecimal(txtHRate.Text));
                if (intRetValue == 0)
                {
                    lblError.Text = "Technician updated";
                }
                else
                {
                    lblError.Text = "Error updating Technician";
                }
            }
        }
    


        //On click add data to the DB if textbox feilds are valid
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            String strTechID;
            if (ValidateText())
            {
                if (drpTech.SelectedIndex == 0)
                {
                    InsertTechnician();
                    strTechID = drpTech.SelectedValue;
                    ButtonsOff();

                    LoadTechs();
                }
                else
                {
                    UpdateTechnician();
                    strTechID = drpTech.SelectedValue;
                    ButtonsOff();

                    LoadTechs();

                }
            }
        }
    }
}