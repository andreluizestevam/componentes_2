﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validators.aspx.cs" Inherits="Validators" %>

<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="JavaScriptControle/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.validate.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.additional-methods.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.numeric.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.date.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.formatInputs.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.fieldValueValidate.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.textAreaControl.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.metadata.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.messageBox.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.searchabledropdown-1.0.7.src.js" type="text/javascript"></script>
    <script src="JavaScriptControle/Techbiz.js" type="text/javascript"></script>

    <script language=javascript>
        function xx() {
            return false;
        }
    </script>

    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <tb:TDropDownList runat="server" ID="ct" Validation-CustomClientValidator="xx">
        </tb:TDropDownList>

       <input id="Submit1" type="submit"
    value="submit" />
    </div>
    </form>
</body>
</html>
