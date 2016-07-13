<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BioPluginWebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Welcome To M2sys BioPlugin</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table cellpadding="3px" cellspacing="0" align="center">
            <tr><td class="pagetitle"><b>Bioplugin Hybrid Web Application Engines</b></td></tr>   
            <tr><td><hr /></td></tr>     
            <tr><td><asp:LinkButton ID="lnkFingerPrint" runat="server" 
                    onclick="lnkFingerPrint_Click" >Finger Print</asp:LinkButton></td></tr>        
            <tr><td>
                <asp:LinkButton ID="lnkFingerVein" runat="server" onclick="lnkFingerVein_Click">Finger Vein</asp:LinkButton></td></tr>        
            <tr><td><asp:LinkButton ID="lnkPalmVein" runat="server" 
                    onclick="lnkPalmVein_Click" >Palm Vein</asp:LinkButton></td></tr>  
        </table>
    </div>
    </form>
</body>
</html>
