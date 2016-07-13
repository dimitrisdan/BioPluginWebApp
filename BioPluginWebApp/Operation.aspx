<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operation.aspx.cs" Inherits="BioPluginWebApp.Operation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Operations</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0px" cellspacing="0px" align="center">
            <tr>
                <td>                
                    <span class="pagetitle"><asp:LinkButton ID="lnlCurrentEngine" runat="server" PostBackUrl="~/Default.aspx">Current Engine: </asp:LinkButton></span>
                    <asp:Label ID="lblEngineType" runat="server" Text="" CssClass="pagetitleValue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>                
                <div id="mnu">
                <table cellpadding="3px" cellspacing="0" width="400px">
                    <tr><td><hr /></td></tr>     
                    <tr><td><a href="Enrollment.aspx">Enrollment</a></td></tr>        
                    <tr><td><a href="Identification.aspx">Identification</a></td></tr>  
                    <tr><td><a href="Verification.aspx">Verification</a></td></tr>   
                    <tr><td><a href="Update.aspx">Update</a></td></tr>   
                </table>
                </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
