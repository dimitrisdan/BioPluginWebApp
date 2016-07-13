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
    public partial class ProcessOperation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEngineType.Text = SessionManager.CurrentEngine.ToString();
                lblOperation.Text = SessionManager.CurrentOperation.ToString();
                ProcessData();
            }
        }
        private void ProcessData()
        {
            BPOperationType option = SessionManager.CurrentOperation;
            switch (option)
            {
                case BPOperationType.Enrollment:
                    Enrollment();
                    break;
                case BPOperationType.Identification:
                    Identification();
                    break;
                case BPOperationType.Verification:
                    Verification();
                    break;
                case BPOperationType.Update:
                    Update();
                    break;
                default:
                    break;
            }
        }
        private void Enrollment()
        {
            try
            {
                // bioplugin web service
                bioPluginService.BioPluginService ob = new BioPluginWebApp.bioPluginService.BioPluginService();
              
                //captured template
                BPData template = SessionManager.CurrentTemplate;
                string result = string.Empty;
                if (SessionManager.CurrentEngine == EngineType.PalmVein || SessionManager.CurrentEngine == EngineType.FingerVein)
                {
                    if (SessionManager.CurrentScanFinger == BPScanFinger.Double)
                    { result = ob.RegisterEx(template.RegID, template.LeftTemplate, 1, template.RightTemplate, 1, template.LeftDupTemplate, template.RightDupTemplate, 1);
                    }
                    else
                    {
                       result = ob.RegisterEx(template.RegID, template.LeftTemplate, 1, template.LeftTemplate, 1, template.LeftDupTemplate, template.LeftDupTemplate, 1);
                     }
                }
                else
                {
                    if (SessionManager.CurrentScanFinger == BPScanFinger.Double)
                    {
                        //double finger enrollment except palmvein
                        result = ob.RegisterEx(template.RegID,template.LeftTemplate, 1, template.RightTemplate, 1,template.LeftTemplate,template.RightTemplate , 1);
                    }
                    else
                    {
                        //single finger enrollment except palmvein
                        result = ob.RegisterEx(template.RegID,template.LeftTemplate, 1,template.LeftTemplate,1,template.LeftTemplate,template.LeftTemplate , 1);
                    }
                }
                ProcessResult(result);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void Identification()
        {
            try
            {
                // bioplugin web service
                bioPluginService.BioPluginService ob = new BioPluginWebApp.bioPluginService.BioPluginService();

                // captured template
                BPData template = SessionManager.CurrentTemplate;
                string result = string.Empty;
                result = ob.IdentifyQuick(template.LeftTemplate, 0, 1, 1);
                ProcessResult(result);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void Verification()
        {
            try
            {
                bioPluginService.BioPluginService ob = new BioPluginWebApp.bioPluginService.BioPluginService();

                BPData template = SessionManager.CurrentTemplate;
                string result = string.Empty;

                if (SessionManager.CurrentScanFinger == BPScanFinger.Double)
                {
                    //double hand/finger verification
                    result = ob.Verify(template.LeftTemplate, template.RightTemplate, template.RegID, 1);
                }
                else
                {
                    //single hand/finger verification
                    result = ob.VerifySingle(template.LeftTemplate, template.RegID, 1);
                }

                ProcessResult(result);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void Update()
        {
            try
            {
                bioPluginService.BioPluginService ob = new BioPluginWebApp.bioPluginService.BioPluginService();

                BPData template = SessionManager.CurrentTemplate;
                string result = string.Empty;

                if (SessionManager.CurrentEngine == EngineType.PalmVein || SessionManager.CurrentEngine == EngineType.FingerVein)
                {
                    if (SessionManager.CurrentScanFinger == BPScanFinger.Double)
                    {
                        //Palmvein double hand update
                        result = ob.UpdateEx(template.RegID,template.LeftTemplate, 1, template.RightTemplate, 1,template.LeftDupTemplate,template.RightDupTemplate , 1);
                    }
                    else
                    {
                        //Palmvein single hand update
                        result = ob.UpdateEx(template.RegID,template.LeftTemplate, 1, template.LeftTemplate, 1,template.LeftTemplate,template.LeftTemplate , 1);
                    }
                }
                else
                {
                    if (SessionManager.CurrentScanFinger == BPScanFinger.Double)
                    {
                        //single finger update except palmvein
                        result = ob.UpdateEx(template.RegID,template.LeftTemplate, 1, template.RightTemplate, 1,template.LeftTemplate,template.RightTemplate , 1);
                    }
                    else
                    {
                        //single finger update except palmvein
                        result = ob.UpdateEx(template.RegID,template.LeftTemplate, 1,template.LeftTemplate,1,template.LeftTemplate,template.LeftTemplate , 1);
                    }

                }
                ProcessResult(result);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        private void ProcessResult(string result)
        {
            lblResult.Visible = true;

            switch (result)
            {

                case "SUCCESS":
                    lblResult.Text = string.Format("{0} successfull.", SessionManager.CurrentOperation.ToString());
                    break;
                case "LICENSE_ERROR":
                    lblResult.Text = "License related problem orccured.";
                    break;
                case "INVALID_ENGINE":
                    lblResult.Text = "Requested engine is invalid.";
                    break;
                case "-1":
                    if (SessionManager.CurrentOperation == BPOperationType.Enrollment)
                        lblResult.Text = "Enrollment ID exist in the system";
                    else if (SessionManager.CurrentOperation == BPOperationType.Identification)
                        lblResult.Text = String.Format("Your {0} is not in the system.", SessionManager.CurrentEngine.ToString());
                    else
                        lblResult.Text = "Biometric operation failed.";
                    break;
                case "0":
                    lblResult.Text = "Verified successfully.";
                    break;
                case "":
                    lblResult.Text = "Web service connection failed.";
                    break;
                case "-411":
                    lblResult.Text = "Bioplugin server connection timeout. Please try again.";
                    break;
                default:
                    lblResult.Text = "Template found in the system with ID - " + result;
                    break;
            }
        }

    }
}
