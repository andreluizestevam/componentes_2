<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buttons.aspx.cs" Inherits="WebApplication1.Buttons" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Control.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.simplemodal-1.4.2.js" type="text/javascript"></script>
    <script language="javascript">
        function testeAjax() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Buttons.aspx/TesteAjax",
                error: function (msg) { },
                success: function () {

                }
            });
        }
    </script>
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <tb:TMessageButton ID="btn" Text="Submit message"  runat="server" 
            BeforeSubmitMessage="clicar em sim" ShowMessage="true" onclick="btn_Click" />
        <tb:TMessageButton ID="TMessageButton1" runat="server" BeforeSubmitMessage="Voltar pg anterior"
            ShowMessage="true" Text="goback" UseGoBackBehavior="true" />
        <tb:TMessageButton ID="TMessageButton2" runat="server" BeforeSubmitMessage="Redirecinar uma pg"
            Text="Redirect" ShowMessage="true" RedirectPageName="Default.aspx" />
        <input type="button" id="btnServer" value="ajax teste" onclick="testeAjax();" />

        <tb:TMessageButton ID="TMessageButton3" runat="server" 
            Text="Redirect sem msg" RedirectPageName="Default.aspx" />
        <tb:TMessageButton ID="TMessageButton4" runat="server" Text="goback sem msg" UseGoBackBehavior="true" />



    </div>
    </form>
</body>
</html>
