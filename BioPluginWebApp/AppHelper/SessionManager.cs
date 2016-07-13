using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPWebApplication  
{
    public class SessionManager
    {
        public static EngineType CurrentEngine  
        {
            get { return (EngineType)HttpContext.Current.Session["CurrentEngine"]; }
            set { HttpContext.Current.Session["CurrentEngine"] = value; }
        }

        public static BPOperationType CurrentOperation  
        {
            get { return (BPOperationType)HttpContext.Current.Session["CurrentOperation"]; }
            set { HttpContext.Current.Session["CurrentOperation"] = value; }
        }

        public static BPScanFinger CurrentScanFinger  
        {
            get { return (BPScanFinger)HttpContext.Current.Session["CurrentScanFinger"]; }
            set { HttpContext.Current.Session["CurrentScanFinger"] = value; }
        }

        public static BPData CurrentTemplate
        {
            get { return (BPData)HttpContext.Current.Session["CurrentTemplate"]; }
            set { HttpContext.Current.Session["CurrentTemplate"] = value; }
        }
    }
}
