<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ligthBox/lytebox.js"></script>
    <link rel="stylesheet" href="ligthBox/lytebox.css" type="text/css" media="screen" />
    <script src="jquery-superbox-0.9.1/jquery.superbox.js" type="text/javascript"></script>
    <link href="jquery-superbox-0.9.1/jquery.superbox.css" rel="stylesheet" type="text/css" />
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
            ModalPopup(data);
        }

        function ModalPopup(data) {
            var url = data.url;
            var width = data.width;
            var height = data.height;

            $.modal('<iframe src="' + url + '" height="' + height + '" width="' + width + '" style="border:10">', {
                focus: true,
                autoPosition: true,
                escClose: false,
                overlayClose: true,
                onClose:myFunction,
                containerCss: {
                    backgroundColor: "#FFFFFF",
                    borderColor: "#FFFFFF",
                    height: height ,
                    opacity: 100,
                    padding: 5,
                    width: width 
                }
            });
        }

        $(function () {
            $.superbox.settings = {
                closeTxt: "Fechar",
                loadTxt: "Processando...",
                nextTxt: "Proxima",
                prevTxt: "Anterior"
            };
            $.superbox();
        });
    </script>
    <script language="javascript">

        function UaiSo(element, value) {
            return value == 'aaa';
        }

        function myFunction() {
            alert('myFunction() called.');
            return true;
        }


        function teste(element, value, param) {
            element = element.parentElement.parentElement;
            return false;
        }

    </script>
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <input id="Button2" type="button" value="button" onclick="Show('http://localhost:9265/WebSiteTeste/Default2.aspx')" />
    <a href="http://localhost:9265/WebSiteTeste/Default2.aspx" rel="superbox[iframe]">Iframe
        Superbox (default dimensions)</a> <a href="http://localhost:9265/WebSiteTeste/Default2.aspx"
            class="lytebox" data-lyte-options="autoResize:false, navTop:true, afterEnd:myFunction">
            Google Search</a>
    <div id="errorContainer" style="z-index: 15001; left: 10px; top: 0px; opacity: 1;
        display: none; position: relative" class="ui-tooltip qtip ui-helper-reset ui-tooltip-shadow ui-tooltip-red ui-tooltip-rounded ui-tooltip-focus ui-tooltip-pos-bc">
        <div style="width: 12px; height: 12px; background-color: transparent; border: 0px none;
            left: 50%; margin-left: -6px; bottom: -12px;" class="ui-tooltip-tip">
            <div style="border-top: 12px solid rgb(217, 82, 82); border-left: 6px dashed transparent;
                border-right: 6px dashed transparent;" class="ui-tooltip-tip-inner">
            </div>
        </div>
        <div class="ui-tooltip-wrapper">
            <div class="ui-tooltip-content errors">
                <ul>
                </ul>
            </div>
        </div>
    </div>
    <div>
        <tb:TTextBox ID="TTextBox3" runat="server" Label-LabelText="Decimal" MaxLength="50"
            ValidationType="Email" Validation-Required="True"></tb:TTextBox>
        <tb:TDateTime runat="server" ID="data" UseCalendar="True"></tb:TDateTime>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <input type="button" value="teste" />
    <div>
        sdf sdf
        <tb:TTextBox ID="TTextBox11" runat="server" Label-LabelText="teste" MaxLength="12"
            Validation-CustomJSValidator="teste" Validation-ErrorText="msg custom" Validation-ServerValidator=""></tb:TTextBox>
    </div>
    &nbsp;<div class="cp_1015">
        <div>
            F 1
            <img src="images/imagesCAGYT7YC.jpg" align="right" />
        </div>
        <div>
            F2
            <img src="images/imagesCAGYT7YC.jpg" align="right" />
        </div>
        <div>
            F4
            <img src="images/imagesCAGYT7YC.jpg" align="right" />
        </div>
    </div>
    </form>
</body>
</html>
