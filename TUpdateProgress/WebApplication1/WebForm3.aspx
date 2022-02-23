<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddl1" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" AutoPostBack="true"
                runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="a" Value="a"></asp:ListItem>
                <asp:ListItem Text="b" Value="b"></asp:ListItem>
                <asp:ListItem Text="c" Value="c"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl2" runat="server">
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
