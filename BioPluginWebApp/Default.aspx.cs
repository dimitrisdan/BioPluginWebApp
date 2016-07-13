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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkFingerPrint_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentEngine = EngineType.FingerPrint;
            Response.Redirect("Operation.aspx");
        }

        protected void lnkPalmVein_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentEngine = EngineType.PalmVein;
            Response.Redirect("Operation.aspx");
        }

        protected void lnkFingerVein_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentEngine = EngineType.FingerVein;
            Response.Redirect("Operation.aspx");
        }

    }
}
