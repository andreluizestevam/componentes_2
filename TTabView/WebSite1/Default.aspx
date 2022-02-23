<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Arquitetura.Web.WC.TTabView" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .menuaba
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 11px;
            background: url(tab-line.gif) repeat-x bottom;
            width: 700px; /*margin-left: 25px;*/
            color: #006699;
            clear: both;
        }
        .aba_menu
        {
            background-color: #F3F3F3;
            border: 1px solid #D0D0D0;
            border-top: 1px solid #D0D0D0;
            border-bottom: 0px solid #999;
            font-size: 11px;
            margin-top: 2px;
            padding: 5px 15px;
            width: 150px;
            float: left;
            margin-left: 5px;
        }
        .aba_menu:hover
        {
            text-decoration: underline;
            background: url(setaBottom.gif) no-repeat right top;
            background-color: #FFFFFF !important;
            border-top: 1px solid #999;
        }
        .aba_menu_Ativa
        {
            background: url(setaBottom.gif) no-repeat right top;
            background-color: #FFFFFF !important;
            border-top: 1px solid #999;
            border-left: 1px solid #999;
            border-right: 1px solid #999;
            border-bottom: 0px solid #999;
            width: 150px;
            float: left;
            margin-top: 2px;
            margin-left: 5px;
            font-size: 11px;
            padding: 5px 15px;
        }
        .conteudoaba
        {
            border: 1px solid #D0D0D0;
            background-color: #FFFFFF;
            padding: 5px 5px;
            font-size: 12px;
            margin-left: 5px;
            float: left;
            display: block;
            clear: both;
            width: 700px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    --%>
    <cc1:TTabView ID="TTabView1" ActiveViewIndex="0" ContainerCssClass="menuaba" ContentTabCssClass="conteudoaba"
        ActiveTabCssClass="aba_menu_Ativa" DeactiveTabCssClass="aba_menu" runat="server">
        <cc1:TTab ID="TTab1" Name="Aba1" runat="server">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" Width="150px" runat="server" Text="OK" OnClick="Button1_Click" /><br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </cc1:TTab>
        <cc1:TTab ID="TTab2" Name="Aba2" Enabled="true" runat="server">
            <cc1:TTabView ID="TTabView2" ActiveViewIndex="0" ContainerCssClass="menuaba" ContentTabCssClass="conteudoaba"
                ActiveTabCssClass="aba_menu_Ativa" DeactiveTabCssClass="aba_menu" runat="server">
                <cc1:TTab ID="TTab5" Name="Aba3" runat="server">
                    conteúdo aba 3
                </cc1:TTab>
                <cc1:TTab ID="TTab6" Name="Aba4" runat="server">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" Width="150px" runat="server" Text="OK" OnClick="Button2_Click" /><br />
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </cc1:TTab>
            </cc1:TTabView>
        </cc1:TTab>
    </cc1:TTabView>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>
    --%>
    </form>
</body>
</html>
