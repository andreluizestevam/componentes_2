<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="JavaScript/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.simplemodal-1.4.2.js" type="text/javascript"></script>
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
                crossDomain:true,
                containerCss: {
                    backgroundColor: "#FFFFFF",
                    borderColor: "#FFFFFF",
                    height: height,
                    opacity: 100,
                    padding: 5,
                    width: width
                }
            });
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button2" type="button" value="button" onclick="Show('http://www.google.com.br')" />
    </div>
    </form>
</body>
</html>
