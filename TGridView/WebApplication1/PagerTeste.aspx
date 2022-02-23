<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagerTeste.aspx.cs" Inherits="WebApplication1.PagerTeste" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Arquitetura.Web.WC.TGridView" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Pager.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListView1" runat="server" 
            onselectedindexchanging="ListView1_SelectedIndexChanging" 
            onpagepropertieschanging="ListView1_PagePropertiesChanging">
            <ItemTemplate>
                <asp:Label runat="server" ID="lbl" Text='<%# Eval("Valor") %>'></asp:Label>
                <br />
            </ItemTemplate>
        </asp:ListView>
        <br />
        <br />
        <cc1:TDataPager runat="server" ID="pagerTeste" PagedControlID="ListView1" PageSize="10">

        </cc1:TDataPager>
    </div>
    </form>
</body>
</html>
