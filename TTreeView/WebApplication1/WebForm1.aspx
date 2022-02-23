<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .treeviewClassificacao
        {
            color: Gray;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="position:absolute;"><wc:TTreeView runat="server" ShowCheckBoxes="All" ShowLines="True" ID="tv" AutoCheck="true" /></div>
               <div style="position:absolute; left:200px;">
                <wc:TTreeView ID="trvClassificacao" CssClass="check" runat="server" 
                    ShowLines="true" ShowCheckBoxes="All"></wc:TTreeView></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
