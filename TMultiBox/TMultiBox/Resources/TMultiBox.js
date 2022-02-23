Type.registerNamespace("Arquitetura.Web.WebControls");

//criando construtor
Arquitetura.Web.WebControls.TMultiBox = function (element) {
    Arquitetura.Web.WebControls.TMultiBox.initializeBase(this, [element]);
    // create variables
    this._ul = null;
    this._count = 0;

    // create properties
    this.MaxCount = 0;
    this.Mask = "";
    this.MaskExp = "";
    this.MaskType = 0;
    this.InputDirection = 0;
    this.Enabled = true;
}

//definindo classe
Arquitetura.Web.WebControls.TMultiBox.prototype = {
    initialize: function () {

        // initialize
        Arquitetura.Web.WebControls.TMultiBox.callBaseMethod(this, 'initialize');

        // create list
        this._ul = this.createUL();

        // get div
        var container = this.get_element();

        // add ul
        container.appendChild(this._ul);

        // verify enabled control
        if (this.Enabled) {
            // add events
            $addHandlers(container, { 'mousedown': this._onMouseDown }, this);
        }
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        Arquitetura.Web.WebControls.TMultiBox.callBaseMethod(this, 'dispose');
    },
    createUL: function () {
        // create ul
        var control = document.createElement('ul');

        // set id
        control.id = this.get_element().id + "_ul";

        // apply style
        control.style.display = "inline-block";
        control.className = "tmultibox_ul";

        // get values
        var values = this.get_hfValues();

        if (values == null) {
            // create default li
            this.addLI(control, "");
        }
        else {
            // add split values
            var arrValues = values.split(";");

            for (var i = 0; i < arrValues.length; i++) {
                var text = arrValues[i].toString();
                if (text.length > 0) {
                    this.addLI(control, text);
                }
            }

            if (this.Enabled) {
                // create default li
                this.addLI(control, "");
            }
        }

        // return
        return control;
    },
    addLI: function (parent, text) {
        // check max count
        if (this.MaxCount != -1
            && parent.childNodes.length >= this.MaxCount) {
            return;
        }

        // create li
        var control = document.createElement('li');

        // set id
        control.id = parent.id + "_li" + this._count;

        // increment count children
        this._count++;

        // apply style
        control.style.display = "inline";
        control.className = "tmultibox_li";

        // add input
        var input = this.createINPUT(control.id, text);
        control.appendChild(input);

        // add span
        var span = this.createSPAN(control.id, text);
        control.appendChild(span);

        // set visibility
        if (text.length > 0) {
            input.style.display = "none";
            span.style.display = "inline";
        }
        else {
            input.style.display = "inline";
            span.style.display = "none";
        }

        // add parent
        parent.appendChild(control);
    },
    removeLI: function (li) {
        // delete mask
        if (this.MaskType != 0) {
            // recuperando
            var input = $get(li.id + "_input");

            // disposing
            input.MaskedEditBehavior.dispose();
            input.TextBoxWrapper.dispose();
        }

        // remove item
        this._ul.removeChild(li);
    },
    createINPUT: function (parent_id, text) {
        // create input
        var input = document.createElement('input');

        // set id
        input.id = parent_id + "_input";

        // apply style
        input.style.display = 'inline';
        input.className = "tmultibox_input";
        input.disabled = !this.Enabled;

        // set text
        input.value = text;

        // verify enabled control
        if (this.Enabled) {
            // add events
            $addHandlers(input, { 'keydown': this._onKeyDown }, this);
            $addHandlers(input, { 'blur': this._onBlur }, this);
        }

        // create mask
        if (this.MaskType != 0) {
            $create(Sys.Extended.UI.MaskedEditBehavior, { "ClientStateFieldID": "mee" + input.id + "_ClientState", "ClearMaskOnLostfocus": false, "CultureAMPMPlaceholder": "", "AutoComplete": false, "CultureCurrencySymbolPlaceholder": "R$", "CultureDateFormat": "DMY", "CultureDatePlaceholder": "/", "CultureDecimalPlaceholder": ",", "CultureName": "pt-BR", "CultureThousandsPlaceholder": ".", "CultureTimePlaceholder": ":", "InputDirection": this.InputDirection, "Mask": this.Mask, "MaskType": this.MaskType, "id": "mee" + input.id }, null, null, input);
        }

        // return
        return input;
    },
    createSPAN: function (parent_id, text) {
        // create container
        var container = document.createElement('div');

        // set id
        container.id = parent_id + "_span";

        // apply style
        container.style.display = 'inline';
        container.className = "tmultibox_span";

        // create span text
        var span1 = document.createElement('span');

        // set id
        span1.id = parent_id + "_spantext";

        // set text
        span1.innerText = text;

        // verify enabled controls
        if (this.Enabled) {
            // add events
            $addHandlers(span1, { 'mousedown': this._onFocus }, this);
        }
        // create span close
        var span2 = document.createElement('span');

        // set id
        span2.id = parent_id + "_spanclose";

        // apply style
        span2.className = "tmultibox_spanclose";

        // verify enabled controls
        if (this.Enabled) {
            // set text
            span2.innerText = "  x ";

            // add events
            $addHandlers(span2, { 'click': this._onClick }, this);
        }

        // create span separator
        var span3 = document.createElement('span');

        // set text
        span3.innerText = "  ";

        //add container
        container.appendChild(span1);
        container.appendChild(span3);
        container.appendChild(span2);

        // return
        return container;
    },
    //evento onclick
    _onClick: function (e) {
        // get li
        var li = $get(e.target.id.replace("_spanclose", ""));

        // remove li
        this.removeLI(li);

        // refresh values
        this.refreshValues();

        // get last input
        var input = $get(this._ul.lastChild.id + "_input");

        // validating event
        if (input.style.display == 'none') {
            // add default li
            this.addLI(this._ul, "");
        }

        // call mousedown
        this._onMouseDown(e);

    },
    //evento onkeydown
    _onKeyDown: function (e) {

        // capture keycode tab
        if (e.keyCode == 9) {
            // cancel key
            event.returnValue = false;

            // call onblur
            this._onBlur(e);
        }

        // capture keycode ;
        if (e.keyCode == 191) {
            // cancel key
            event.returnValue = false;

            // call onblur
            this._onBlur(e);
        }
    },
    //evento onblur
    _onBlur: function (e) {
        // get input
        var input = e.target;

        // validating event
        if (input.style.display != 'inline') {
            event.returnValue = false;

            return;
        }

        // get span
        var span = $get(input.id.replace("_input", "_span"));
        var span2 = $get(input.id.replace("_input", "_spantext"));

        // set text
        span2.innerText = input.value;

        // check length
        if (input.value.length > 0) {
            // get regex
            var rgx = new RegExp(this.MaskExp, "");

            // validate mask
            if (!rgx.test(input.value)) {

                // check is exist mask
                if (this.MaskType != 0) {
                    // set focus
                    input.MaskedEditBehavior._onFocus();
                }

                // validate mask
                if (!rgx.test(input.value)) {
                    this.checkClose(span);

                    this.setCursorEndText(input);

                    event.returnValue = false;

                    return;
                }
            }

            // refresh values
            this.refreshValues();

            // if last child add new li
            var li = $get(span.id.replace("_span", ""));

            if (li.id == this._ul.lastChild.id) {
                // add new li
                this.addLI(this._ul, "");
            }

            // set visibility
            input.style.display = "none";
            span.style.display = "inline";

            // call mousedown
            this._onMouseDown(e);
        }
        else {
            event.returnValue = false;

            // check if close element
            this.checkClose(span);
        }
    },
    //evento onfocus
    _onFocus: function (e) {
        // get span
        var span2 = e.target;
        var span = $get(span2.id.replace("_spantext", "_span"));

        // get input
        var input = $get(span2.id.replace("_spantext", "_input"));

        // set text
        input.value = span2.innerText;

        // set visibility
        input.style.display = "inline";
        span.style.display = "none";

        // set cursor
        this.setCursorEndText(input);
    },
    //evento onmousecdown
    _onMouseDown: function (e) {
        // cancel mousedown span
        if (e.target.id.indexOf("_spantext") != -1) {
            event.returnValue = false;
            return;
        }

        // cancel mousedown input 
        if (e.target.id.indexOf("_input") != -1
            && e.target.style.display == 'inline') {
            event.returnValue = false;
            return;
        }

        // get input
        var input = $get(this._ul.lastChild.id + "_input");

        // check display
        if (input.style.display == 'none') {
            event.returnValue = false;
            return;
        }

        // call focus
        input.focus();
    },
    // metodo que verifica se o tab key é sobre o ultimo elemento vazio, se for então é para sair do componente
    checkClose: function (span) {
        var li = $get(span.id.replace("_span", ""));

        if (li.id == this._ul.lastChild.id) {
            // get input
            var input = $get(span.id.replace("_span", "_input"));

            // clear input
            input.value = "";

            // get div
            var container = this.get_element();

            // set focus em next element
            var f = new Arquitetura.Web.WebControls.FocusUtil();
            f.setNextFocus(container);
        }
    },
    // metodo para colocar o cursos no final do texto do input
    setCursorEndText: function (input) {
        //        if (input.createTextRange) {
        //            var fr = input.createTextRange();
        //            fr.moveStart('character', input.value.length);
        //            fr.collapse();
        //            fr.select();
        //        }
        //        else {
        //            input.value = input.value;
        //        }
        //input.focus();
        input.value = input.value;
    },
    // metodo para atualizar os valores do hidden
    refreshValues: function () {
        var values = "";
        var count = this._ul.childNodes.length;

        for (var i = 0; i < count; i++) {
            // get input
            var input = $get(this._ul.childNodes[i].id + "_spantext");

            if (input.innerText.length > 0) {
                values += input.innerText + ";";
            }
        }

        this.set_hfValues(values);
    },
    set_hfValues: function (values) {
        var hf = $get(this.get_element().id.toUpperCase() + "Values");
        hf.value = values.toString();
    },
    get_hfValues: function () {
        var hf = $get(this.get_element().id.toUpperCase() + "Values");
        return hf.value;
    },
    // get/set property maxCount 
    set_MaxCount: function (value) {
        this.MaxCount = value;
    },
    get_MaxCount: function () {
        return this.MaxCount;
    },
    // get/set property mask
    set_Mask: function (value) {
        this.Mask = value;
    },
    get_Mask: function () {
        return this.Mask;
    },
    // get/set property masktype
    set_MaskType: function (value) {
        this.MaskType = value;
    },
    get_MaskType: function () {
        return this.MaskType;
    },
    // get/set property mask
    set_MaskExp: function (value) {
        this.MaskExp = value;
    },
    get_MaskExp: function () {
        return this.MaskExp;
    },
    // get/set property inputdirection
    set_InputDirection: function (value) {
        this.InputDirection = value;
    },
    get_InputDirection: function () {
        return this.InputDirection;
    },
    // get/set property Enabled
    set_Enabled: function (value) {
        this.Enabled = value;
    },
    get_Enabled: function () {
        return this.Enabled;
    }
}

//register class as a Sys.UI.Control
Arquitetura.Web.WebControls.TMultiBox.registerClass('Arquitetura.Web.WebControls.TMultiBox', Sys.UI.Control);

//notify loaded
if (typeof (Sys) !== 'undefined') {
    Sys.Application.notifyScriptLoaded();
}