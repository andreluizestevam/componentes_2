<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="MessageBox" />
                <ifr:TMessageBox ID="TMessageBox1" runat="server" MessageOption="Information" Message="Exemplo de mensagem!"
                    Title="Teste">
                </ifr:TMessageBox>
                <br />
                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="ConfirmBox" />
                <ifr:TConfirmBox ID="TConfirmBox1" DefaultButton="ButtonCancel" OnClickOk="TConfirmBox1_ClickOk"
                    OnClickCancel="TConfirmBox1_ClickCancel" Message="Este é um exemplo de confirmação?"
                    runat="server">
                </ifr:TConfirmBox>
                <br />
                <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Text="InputBox" />
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <ifr:TInputBox ID="TInputBox1" OnClickOk="TInputBox1_ClickOk" OnClickCancel="TInputBox1_ClickCancel"
                    Message="Digite uma entrada de dados." WatermarkText="Digite o texto." runat="server">
                </ifr:TInputBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Text="PopupBox1" />
                <ifr:TPopupBox ID="TPopupBox1" DefaultButtonID="Button6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button5" UseSubmitBehavior="false" runat="server" Text="Add" OnClick="Button5_Click" />
                        <asp:Button ID="Button6" UseSubmitBehavior="false" runat="server" Text="Remove" OnClick="Button6_Click" />
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </ContentTemplate>
                </ifr:TPopupBox>
                <asp:Button ID="Button7" OnClick="Button7_Click" runat="server" Text="PopupBox2" />
                <ifr:TPopupBox ID="TPopupBox2" DefaultButtonID="Button8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Button ID="Button8" UseSubmitBehavior="false" runat="server" Text="Remove" />
                    </ContentTemplate>
                </ifr:TPopupBox>
                <ifr:TMessageBox ID="TMessageBox2" runat="server" MessageOption="Information" Message="Exemplo de mensagem!">
                </ifr:TMessageBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
