<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Control.css" rel="stylesheet" type="text/css" />
    <link href="CSS/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="JavaScriptControle/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.messageBox.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.messageBox.js" type="text/javascript"></script>
    <script language="javascript">
        var jaVerificado = false;

        function mizz() {
            alert('Nao');
        }

        function ShowSubmitMessageq(mensagem) {
            var options =
                    {
                        message: mensagem,
                        messageType: 'YesOrNo',
                        buttons: [{ behavior: "SubmitPage", text: "Sim" },
                        { behavior: "None", text: "Não", callBackFuncion: function () {
                            alert('sss');
                        }
                        }]
                    };

            $.messageBox(options);

            if (jaVerificado) {
                return true;
            }

            jaVerificado = true;

            return false;
        }



        $(document).ready(function () {
            $("#frmPrincipal").submit(function () {
                return ShowSubmitMessageq("teste");
            });
        });

    </script>
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div class="img_Alerta">
        <asp:Button ID="btnErro" runat="server" Text="Erro" OnClick="btnErro_Click" />
        <asp:Button ID="btnAlerta" runat="server" Text="Alerta" OnClick="btnAlerta_Click" />
        <asp:Button ID="btnConfirmacao" runat="server" Text="ConfirmacaoCancel" OnClick="btnConfirmacao_Click" />
        <asp:Button ID="BtnConfirmacao1" runat="server" Text="Confirmação" OnClick="BtnConfirmacao1_Click" />
        <input type="submit" value="MsgConfirm" />
    </div>
    </form>
</body>
</html>
