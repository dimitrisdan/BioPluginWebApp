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
    public partial class Enrollment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEngineType.Text = SessionManager.CurrentEngine.ToString();
                lblOperation.Text = BPOperationType.Enrollment.ToString();
                if (SessionManager.CurrentEngine == EngineType.PalmVein)
                {
                    lblScanFingerDouble.Text = "Double hand";
                    lblScanFingerSingle.Text = "Single hand";
                }
            }
        }
        
        protected void btnEnroll_Single_Click(object sender, EventArgs e)
        {            
            SessionManager.CurrentScanFinger = BPScanFinger.Single;
            PrepareTemplate();
            Response.Redirect("ProcessOperation.aspx");
        }

        protected void btnEnroll_Double_Click(object sender, EventArgs e) 
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
                LeftDupTemplate = LeftCaptureddata.Value,
                RightDupTemplate = RightCaptureddata.Value,
                RegID = (SessionManager.CurrentScanFinger == BPScanFinger.Double) ? txtRegID_D.Text.Trim() : txtRegID_S.Text.Trim()
            };
            SessionManager.CurrentTemplate = template;
            SessionManager.CurrentOperation = BPOperationType.Enrollment;
        }
    }
}
