<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridNormal.aspx.cs" Inherits="WebApplication1.GridNormal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Arquitetura.Web.WC.TGridView" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:TGridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
            </Columns>
        </cc1:TGridView>
    </div>
    
    
    </form>
    
</body>
</html>
