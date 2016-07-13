﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enrollment.aspx.cs" Inherits="BioPluginWebApp.Enrollment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<object id="BioPlugInActX" style="width: 0px; height: 0px" classid="CLSID:05E8280C-D45A-494F-AE42-840A40444AFF">
    <param name="_Version" value="65536" />
    <param name="_ExtentX" value="2646" />
    <param name="_ExtentY" value="2646" />
    <param name="_StockProps" value="0" />
</object>
<head id="Head1" runat="server">
    <title>Enrollment</title>
    <link rel="Stylesheet" type="text/css" href="style.css" />

    <script language="javascript" type="text/javascript" for="BioPlugInActX" event="OnCapture()">
        //	enrollment template
        document.getElementById("Leftbiodata").value = BioPlugInActX.GetSafeLeftFingerData();
		document.getElementById("Rightbiodata").value = BioPlugInActX.GetSafeRightFingerData();
		
        //	captured template for palmvein enrollment
		document.getElementById("LeftCaptureddata").value = BioPlugInActX.GetSafeLeftCaptureTemplate();
		document.getElementById("RightCaptureddata").value = BioPlugInActX.GetSafeRightCaptureTemplate();
		if (document.getElementById("btnCapture_Double").disabled == false) {
                document.getElementById("btnEnroll_Double").disabled = false;
            }
        else {
            document.getElementById("btnEnroll_Single").disabled = false;
        }		
    </script>

    <script type="text/javascript" language="javascript">

	    function StartCapture_Double() {
	        // Capture template for double hand/finger for enrollment
	        BioPlugInActX.CaptureRegisterFingerData(0);
	    }

        function StartCapture_Single() {
            // Capture template for single hand/finger for enrollment
            BioPlugInActX.CaptureRegisterSingleFingerData(0);
        }

        function onOpClick(bValue) {
            document.getElementById("btnCapture_Double").disabled = !bValue;
            document.getElementById("btnCapture_Single").disabled = bValue;            
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0px" cellspacing="0px" align="center">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="pagetitle" align="left">
                                <asp:LinkButton ID="lnlCurrentEngine" runat="server" PostBackUrl="~/Default.aspx">Current Engine</asp:LinkButton>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblEngineType" runat="server" Text="" CssClass="pagetitleValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="pagetitle2" align="left">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Operation.aspx">Operation</asp:LinkButton>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblOperation" runat="server" CssClass="pagetitleValue2" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="width: 350px;">
                        <legend>
                            <input type="radio" name="finger" value="dfinger" onclick="onOpClick(true)" checked="checked" />
                            <asp:Label ID="lblScanFingerDouble" runat="server" Text="Double finger"></asp:Label>
                        </legend>
                        <table cellpadding="3px" cellspacing="0">
                            <tr>
                                <td width="120px">
                                    Registration ID
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegID_D" Width="150px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="btnCapture_Double" type="button" value="Capture" onclick="StartCapture_Double();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEnroll_Double" runat="server" Text="Enroll" Enabled="false" OnClick="btnEnroll_Double_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="Leftbiodata" runat="server" />
                                    <asp:HiddenField ID="Rightbiodata" runat="server" />
                                    <asp:HiddenField ID="LeftCaptureddata" runat="server" />
                                    <asp:HiddenField ID="RightCaptureddata" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="width: 350px;">
                        <legend>
                            <input type="radio" name="finger" value="dfinger" onclick="onOpClick(false)" />
                            <asp:Label ID="lblScanFingerSingle" runat="server" Text="Single finger"></asp:Label>
                        </legend>
                        <table cellpadding="3px" cellspacing="0">
                            <tr>
                                <td width="120px">
                                    Registration ID
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegID_S" Width="150px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="btnCapture_Single" type="button" value="Capture" disabled="disabled" onclick="StartCapture_Single();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEnroll_Single" runat="server" Text="Enroll" Enabled="false" OnClick="btnEnroll_Single_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
