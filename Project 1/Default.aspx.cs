using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ServiceBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Service.aspx");
        }

        protected void ProblemBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Problem.aspx");
        }

        protected void ReportsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Reports.aspx");
        }

        protected void TechniciansBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Technicians.aspx");
        }
    }
}