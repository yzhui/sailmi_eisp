using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lstMultipleValues.Attributes.Add("onclick", "FindSelectedItems(this," + txtSelectedMLValues.ClientID + ");");
            SetMultiValue();
            lblDescription.Text = "On click of dropdown, the multi select option will appear.<br /> Once you remove focus from the dropdown"
            + " area it will get auto collapsed. <br />In case needed, you can go ahead and close it with the close ('X') provided at the bottom.<br />";
        }
    }

    protected void SetMultiValue()
    {
        DataTable dt = new DataTable("Table1");
        
        DataColumn dc1 = new DataColumn("Text");
        DataColumn dc2 = new DataColumn("Value");
        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);

        //To get enough data for scroll
        dt.Rows.Add("Bangalore", 1);
        dt.Rows.Add("Kolkata", 2);
        dt.Rows.Add("Pune", 3);
        dt.Rows.Add("Mumbai", 4);
        dt.Rows.Add("Noida", 5);
        dt.Rows.Add("Gurgaon", 6);
        dt.Rows.Add("Hyderabad", 7);
        dt.Rows.Add("Chennai", 8);
        dt.Rows.Add("Jaipur", 8);
        dt.Rows.Add("Patna", 8);
        dt.Rows.Add("Ranchi", 8);

        lstMultipleValues.DataSource = dt;
        lstMultipleValues.DataTextField = "Text";
        lstMultipleValues.DataValueField = "Value";
        lstMultipleValues.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Text showed that were selected
        lblTextSelected.Text = "Submitted Values: " + txtSelectedMLValues.Value;

        // One can loop through the checkboxlist control to get the Values too for the text selected if required.
    }
}