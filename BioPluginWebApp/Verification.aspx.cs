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
    public partial class Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEngineType.Text = SessionManager.CurrentEngine.ToString();
                lblOperation.Text = BPOperationType.Verification.ToString();
                if (SessionManager.CurrentEngine == EngineType.PalmVein)
                {
                    lblScanFingerDouble.Text = "Double hand";
                    lblScanFingerSingle.Text = "Single hand";
                }
            }
        }
        protected void btnVerify_Single_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentScanFinger = BPScanFinger.Single;
            PrepareTemplate();
            Response.Redirect("ProcessOperation.aspx");
        }

        protected void btnVerify_Double_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentScanFinger = BPScanFinger.Double;
            PrepareTemplate();
            Response.Redirect("ProcessOperation.aspx");
        }

        private void PrepareTemplate()
        {
            BPData template = new BPData
            {
                LeftTemplate = Leftbiodata.Value,
                RightTemplate = Rightbiodata.Value,
                LeftDupTemplate = string.Empty,
                RightDupTemplate = string.Empty,
                RegID = (SessionManager.CurrentScanFinger == BPScanFinger.Double) ? txtRegID_D.Text.Trim() : txtRegID_S.Text.Trim()
            };
            SessionManager.CurrentTemplate = template;
            SessionManager.CurrentOperation = BPOperationType.Verification;
        }

    }
}
