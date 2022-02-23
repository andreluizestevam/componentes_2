<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Arquitetura.Web.WC.TMultiBox" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <title></title>
    <!--<style type="text/css">
        li span:hover
        {
            border: 1px solid blue;
            padding: 1px 1px 1px 3px;
        }
    </style>-->
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <div>
                    <div>
                        <div>
                            <div>
                                <div>
                                    <b>Emails:&nbsp;</b>
                                    <wc:TMailBox ID="mbEmailsAdicionais" MaxCount="10" CssClass="TMailBox" runat="server"
                                                        TabIndex="322"></wc:TMailBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div>
                    <b>Telefones:&nbsp;</b>
                    <wc:TPhoneBox ID="TPhoneBox1" Width="500px" Height="50px" MaxCount="5" runat="server" />
                </div>
                <br />
                <br />
                <div>
                    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
                </div>
                <textarea id="TraceConsole" name="TraceConsole" rows="100" cols="100"></textarea>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
