<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTeste.aspx.cs" Inherits="FileTeste" %>

<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/Control.css" rel="stylesheet" type="text/css" />

    </script>
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <fieldset>
        <legend>Your file</legend>
        <ol>
            <li class="jqUploader">
                <label for="example1">
                    Choose a file to upload:
                </label>
                <input name="MAX_FILE_SIZE" value="1048576" type="hidden" />
                <input name="example1" id="example1" type="file" />
            </li>
        </ol>
    </fieldset>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
