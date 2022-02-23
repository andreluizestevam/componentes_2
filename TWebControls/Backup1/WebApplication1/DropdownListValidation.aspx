<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropdownListValidation.aspx.cs" Inherits="WebApplication1.DropdownListValidation" %>
<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Luciano.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Control.css" rel="stylesheet" type="text/css" />
    <link href="JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <tb:TRadioButton runat="server" ID="rd" GroupName="Teste" Validation-Required="true" Validation-RequiredErrorText="Inválido 1" Validation-ErrorText="Inválido 1" />
        <tb:TRadioButton runat="server" ID="rd1" GroupName="Teste" Validation-Required="true" Validation-RequiredErrorText="Inválido 2" />
        <input id="Submit1" type="submit" value="submit" />
    </div>
    </form>
</body>
</html>