Type.registerNamespace("Arquitetura.Web.WebControls");

//criando construtor
Arquitetura.Web.WebControls.FocusUtil = function () {
}

//definindo classe
Arquitetura.Web.WebControls.FocusUtil.prototype = {
    initialize: function () {
        // initialize
        Arquitetura.Web.WebControls.FocusUtil.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        Arquitetura.Web.WebControls.FocusUtil.callBaseMethod(this, 'dispose');
    },

    // metodo que seta o proximo elemento com suporte a focus da pagina
    setNextFocus: function (container) {
        // get control
        var control1 = this.findNextSibling(container);

        // get next
        var control2 = this.findFull(control1);

        // check if found
        if (control2 != null) {
            // set focus
            control2.focus();
        }
    },
    // metodo que procura ou irmao ou proximo pai
    findNextSibling: function (control) {
        // iteration
        while (control != null && control.nodeName != "BODY") {
            // check if has next
            if (control.nextSibling != null) {
                return control.nextSibling
            }
            control = control.parentNode;
        }

        // return control
        return control;
    },
    // metodo que procura de cima pra baixo e baixo pra cima
    findFull: function (control) {
        // get parent
        var parent = control;

        // iteration
        do {
            // find top down
            control = this.findTopDown(control);

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
    },

    // metodo que procura de baixo para cima
    findBottomUp: function (control) {
        // get parent
        var parent = control;

        // iteration
        do {
            // iteration
            while (control != null) {
                // check is focusable
                if (this.isFocusable(control)) {
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
    },

    // metodo que procura de cima pra baixo
    findTopDown: function (control) {
        // iteration
        while (control != null) {
            // check is focusable
            if (this.isFocusable(control)) {
                // return control
                return control;
            }

            // if has children
            if (control.hasChildNodes()) {
                for (var idx = 0; idx < control.childNodes.length; idx++) {
                    // get child
                    var child = control.childNodes[idx];

                    // getr result find
                    var result = this.findTopDown(child);

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
    },

    // metodo que verifica elementos com suporte a tab key (tabindex)
    isFocusable: function (control) {
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
}

//register class as a Sys.IDisposable
Arquitetura.Web.WebControls.FocusUtil.registerClass('Arquitetura.Web.WebControls.FocusUtil', null, Sys.IDisposable);

//notify loaded
if (typeof (Sys) !== 'undefined') {
    Sys.Application.notifyScriptLoaded();
}
