<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessOperation.aspx.cs" Inherits="BioPluginWebApp.ProcessOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ProcessOperations</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0px" cellspacing="0px" align="center">
            <tr>
                <td>
                <table>            
                    <tr>
                        <td class="pagetitle"><asp:LinkButton ID="lnlCurrentEngine" runat="server" PostBackUrl="~/Default.aspx">Current Engine</asp:LinkButton></td>
                        <td>:</td>
                        <td><asp:Label ID="lblEngineType" runat="server" Text="" CssClass="pagetitleValue"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="pagetitle2">Operation</td>
                        <td>:</td>
                        <td><asp:Label ID="lblOperation" runat="server" CssClass="pagetitleValue2" Text=""></asp:Label></td>
                    </tr>
                    <tr><td colspan="3"><hr /></td></tr> 
                </table>
                <br />
                <asp:Label ID="lblResult" runat="server" CssClass="pagetitleValue" Text=""></asp:Label>
                <br />
                <br />
                <table cellpadding="3px" cellspacing="0">
                    <tr><td><a href="Default.aspx">Back To Engines</a></td></tr>        
                    <tr><td><a href="Operation.aspx">Back To Operations</a></td></tr>  
                </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
