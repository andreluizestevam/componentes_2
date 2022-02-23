<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<%@ Register Assembly="Arquitetura.Web.WC.TUpdateProgress" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="wc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Button" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
