<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Control.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.simplemodal-1.4.2.js" type="text/javascript"></script>
    <%--<link href="css/dark-hive/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/Control.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.jgrowl.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">

        function Show(site) {
            data =
            {
                url: site,
                width: 800,
                height: 430
            }
            ModalPopupq(data);
        }

        function ModalPopupq(data) {
            var url = data.url;
            var width = data.width;
            var height = data.height;

            $.modal('<iframe frameborder="0" src="' + url + '" height="' + height + '" width="' + width + '" />', {
                focus: true,
                autoPosition: true,
                escClose: false,
                overlayClose: true,
                containerCss: {
                    backgroundColor: "#FFFFFF",
                    borderColor: "#FFFFFF",
                    height: height,
                    opacity: 100,
                    padding: 5,
                    width: width,
                    frameborder:0
                }
            });
        }

    </script>

    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <input id="Button2" type="button" value="button" onclick="Show('Default3.aspx')" />
    <asp:Button ID="Button3" runat="server" Text="val" />
    <asp:Button ID="Button4" runat="server" CausesValidation="False" Text="nval" />
    <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    </form>
</body>
</html>
