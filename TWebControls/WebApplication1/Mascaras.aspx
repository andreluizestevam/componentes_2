<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mascaras.aspx.cs" EnableEventValidation="false"
    Inherits="Default2" %>

<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
   
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <tb:TTextBox ID="TTextBox1" runat="server" CustomMask="[0-9]"  MaxLength="3" MaskType="Custom"></tb:TTextBox>
    </div>
    </form>
</body>
</html>
