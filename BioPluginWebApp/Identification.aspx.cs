using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BPWebApplication;

namespace BioPluginWebApp
{
    public partial class Identification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEngineType.Text = SessionManager.CurrentEngine.ToString();
                lblOperation.Text = BPOperationType.Identification.ToString();
            }
        }
        protected void btnIdentify_Click(object sender, EventArgs e)
        {
            PrepareTemplate();
            Response.Redirect("ProcessOperation.aspx");
        }

        private void PrepareTemplate()
        {
            BPData template = new BPData
            {
                LeftTemplate = hdnBiodata.Value,
                RightTemplate = string.Empty,
                LeftDupTemplate = string.Empty,
                RightDupTemplate = string.Empty,
                RegID = string.Empty
            };
            SessionManager.CurrentTemplate = template;
            SessionManager.CurrentOperation = BPOperationType.Identification;
        }
    }
}
