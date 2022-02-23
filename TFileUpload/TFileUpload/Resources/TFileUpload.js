Type.registerNamespace("Arquitetura.Web.WebControls");

//criando construtor
Arquitetura.Web.WebControls.TFileUpload = function (element) {
    Arquitetura.Web.WebControls.TFileUpload.initializeBase(this, [element]);

}

//definindo classe
Arquitetura.Web.WebControls.TFileUpload.prototype = {
    initialize: function () {
        // initialize
        Arquitetura.Web.WebControls.TFileUpload.callBaseMethod(this, 'initialize');

        // os eventos do asyncfileupload são independentes. isto e, nao utilizam a instancia.
        // desta forma, os eventos nao podem ter referencia para a esta instancia.

        // get afu
        var afu = $get(this.get_element().id + "AFU");

        // get input
        var input = afu.childNodes[1].firstChild;

        // add events
        $addHandlers(input, { 'keydown': this._onKeyDown }, this);

        // add handlers
        afu.control.add_uploadComplete(this._onUploadComplete);
        afu.control.add_uploadError(this._onUploadError);
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        $clearHandlers($get(this.get_element().id + "AFU"));
        Arquitetura.Web.WebControls.TFileUpload.callBaseMethod(this, 'dispose');
    },
    // evento
    _onKeyDown: function (e) {
        // get container
        var container = this.get_element();

        // set focus em next element
        var f = new Arquitetura.Web.WebControls.FocusUtil();
        f.setNextFocus(container);
    },
    // evento
    _onUploadComplete: function (sender, args) {
        // get instance control
        var control = $get(sender.get_element().id.replace("AFU", ""));

        // build argument
        var filename = args.get_fileName();
        var filesize = args.get_length(); // (args.get_length() / 1024).toFixed(2) + " KB";
        var filetype = args.get_contentType();

        var argument = "UPLOADSUCCESS;" + filename + ";" + filesize + ";" + filetype;

        // force call __doPostBack in upload complete
        javascript: __doPostBack(control.id, argument);
    },
    // evento
    _onUploadError: function (sender, args) {
        // get instance control
        var control = $get(sender.get_element().id.replace("AFU", ""));

        // build argument
        var filename = args.get_fileName();
        var filesize = args.get_length() != null ? args.get_length() : 0;
        var statusMessage = args.get_errorMessage();

        var argument = "UPLOADERROR;" + filename + ";" + filesize + ";" + statusMessage;

        // force call __doPostBack in upload error
        javascript: __doPostBack(control.id, argument);
    }
}

//register class as a Sys.Control
Arquitetura.Web.WebControls.TFileUpload.registerClass('Arquitetura.Web.WebControls.TFileUpload', Sys.UI.Control);

//notify loaded
if (typeof (Sys) !== 'undefined') {
    Sys.Application.notifyScriptLoaded();
}