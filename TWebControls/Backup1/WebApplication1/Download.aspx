<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WebApplication1.Download" %>
<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <tb:TDownloadCommand ID="Teste" runat="server" Text="teste"></tb:TDownloadCommand>
    </div>
    </form>
</body>
</html>
