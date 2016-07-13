using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPWebApplication  
{
    public enum EngineType
    {
        FingerPrint = 1,
        FingerVein = 2,
        PalmVein = 3
    }

    public enum BPScanFinger
    {
        Double = 1,
        Single = 2
    }

    public enum BPOperationType
    {
        Enrollment = 1,
        Identification = 2,
        Verification = 3,
        Update = 4
    }

    public class BPData
    {
        public string LeftTemplate { get; set; }
        public string RightTemplate { get; set; }
        public string LeftDupTemplate { get; set; }
        public string RightDupTemplate { get; set; }

        public string RegID { get; set; }
    }
}
