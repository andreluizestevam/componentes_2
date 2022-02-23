<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Arquitetura.Web.WC.TFileUpload" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <div>
                    <wc:TFileUpload ID="fileUpload1" StrategyStore="Cache" AllowMultiples="true" Width="400px"
                        runat="server" />
                </div>
                <br />
                <br />
                <div>
                    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
                </div>
                <a href="WebForm3.aspx">WebForm3.aspx</a>
                <ifr:TMessageBox ID="mbxMensagem" runat="server">
                </ifr:TMessageBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
