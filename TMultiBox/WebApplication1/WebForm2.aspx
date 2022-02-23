<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teste</title>
    <script type="text/javascript">
        function findNextFocus(container) {
            // get next
            var next1 = findFull(container.nextSibling);

            // check if found
            if (next1 != null) {
                // set focus
                next1.focus();
            }
        }

        function findFull(control) {
            // get parent
            var parent = control;

            // iteration
            do {
                // find top down
                control = findTopDown(control);

                // check if found
                if (control != null) {
                    // return control
                    return control;
                }

                // get parent
                parent = parent.parentNode;

                // check if parent is not null
                if (parent != null) {
                    // get first child
                    control = parent.nextSibling;
                }

                // check if pareent is root
                if (parent != null
                    && parent.nodeName == "BODY") {

                    // cancel loop
                    parent = null;
                }

            } while (parent != null);

            // return control
            return control;
        }

        function findBottomUp(control) {
            // get parent
            var parent = control;

            // iteration
            do {
                // iteration
                while (control != null) {
                    // check is focusable
                    if (isFocusable(control)) {
                        // return control
                        return control;
                    }

                    // get next element
                    control = control.nextSibling;
                }

                // get parent
                parent = parent.parentNode;

                // check if parent is not null
                if (parent != null) {
                    // get first child
                    control = parent.nextSibling;
                }

                // check if pareent is root
                if (parent != null
                    && parent.nodeName == "BODY") {

                    // cancel loop
                    parent = null;
                }

            } while (parent != null);

            // return control
            return control;
        }

        function findTopDown(control) {
            // iteration
            while (control != null) {
                // check is focusable
                if (isFocusable(control)) {
                    // return control
                    return control;
                }

                // if has children
                if (control.hasChildNodes()) {
                    for (var idx = 0; idx < control.childNodes.length; idx++) {
                        // get child
                        var child = control.childNodes[idx];

                        // getr result find
                        var result = findTopDown(child);

                        // check if found
                        if (result != null) {
                            // return control
                            return result;
                        }
                    }
                }

                // get next element
                control = control.nextSibling;
            }

            // return control
            return control;
        }

        function isFocusable(control) {
            // verificando elementos com suporte a tab key (tabindex)
            // ver http://www.w3.org/TR/html401/interact/forms.html#tabbing-navigation
            // ver 17.11.1 Tabbing navigation
            // adicionado DIV para suporte ao componente
            if ((control.nodeName == "A"
                    || control.nodeName == "AREA"
                    || control.nodeName == "BUTTON"
                    || control.nodeName == "INPUT"
                    || control.nodeName == "OBJECT"
                    || control.nodeName == "SELECT"
                    || control.nodeName == "TEXTAREA")
                && control.type != "hidden"
                && control.style.display != "none"
                && !control.disabled
                && control.nodeType == 1) {

                return true;
            }

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Button ID="Button1" OnClientClick="javascript:findNextFocus(this);" runat="server"
                Text="Button" />
        </div>
        <br />
        <div>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <br />
            <p>
                <a>
                    <textarea id="TraceConsole" name="TraceConsole" rows="100" cols="100"></textarea>
                </a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
