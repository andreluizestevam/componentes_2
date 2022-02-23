<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pg.aspx.cs" Inherits="WebApplication1.TbizModal.pg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Control.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../jquery.simplemodal-1.4.2.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="submit" class="simplemodal-close" value="Close" onclick="HidePagina()" />
        <tb:TMessageButton ID="btn" runat="server" BeforeSubmitMessage="clicar em sim" ShowMessage="true" />
    </div>
    </form>
</body>
</html>
