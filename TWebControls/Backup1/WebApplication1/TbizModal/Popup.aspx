<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <%--<link href="../CSS/Control.css" rel="stylesheet" type="text/css" />--%>
    <script src="../JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../jquery.simplemodal-1.4.2.js" type="text/javascript"></script>
    <link href="../CSS/Luciano.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div style="display: none;">
        <img src="/App_Images/loader.gif" alt="" />
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <input id="Button2" value="button" onclick="showProcessModal();" type="button" />
    <input type="text" />
    <tb:TMessageButton ID="btn" runat="server" BeforeSubmitMessage="clicar em sim" ShowMessage="true" />
    <tb:TCheckBoxList ID="TCheckBoxList1" runat="server">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </tb:TCheckBoxList>
    </div>
    </form>
</body>
</html>
