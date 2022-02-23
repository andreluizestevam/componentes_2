// variaveis
var counterTimer = 0;
var counterInternalID;
var modalTarget;
var isBegin = false;

// declaracao
with (Sys.WebForms.PageRequestManager.getInstance()) {
    add_initializeRequest(this._onInitializeRequest);
    add_beginRequest(this._onBeginRequest);
    add_endRequest(this._onEndRequest);
    add_pageLoaded(this._onPageLoaded);
}

//evento
function _onInitializeRequest(sender, args) {
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    // se tiver em execução, cancela a execução
    if (prm.get_isInAsyncPostBack()) {
        prm.abortPostBack();
        args.set_cancel(true);
    }

    // ocultando
    _Hidden();
}

//evento
function _onBeginRequest(sender, args) {
    // configurando flag
    isBegin = true;

    // apresentando
    _Visible();
}

//evento
function _onPageLoaded(sender, args) {
    // se não lançou begin, então não trata
    if (!isBegin) {
        return;
    }

    // configurando flag
    isBegin = false;

    // ocultando
    _Hidden();
}

//evento
function _onEndRequest(sender, args) {
    // se não lançou begin, então não trata
    if (!isBegin) {
        return;
    }

    // configurando flag
    isBegin = false;

    // ocultando
    _Hidden();
}

// metodo
function _Visible() {
    // iniciando contador de tempo
    _StartTime();

    // call show modal
    _ShowModal();
}

// metodo
function _Hidden() {
    // parando contador de tempo
    _StopTime();

    // call close modal
    _CloseModal();
}

// metodo
function _StartTime() {
    // recuperando elemento
    var element = $get("UpdateProgressCounterTimer");

    // se encontrou é porque está habilitado
    if (element != null) {
        // iniciando
        _UpdateTime();

        // iniciando intervalo
        counterInternalID = setInterval(function () { _UpdateTime(); }, 1000);
    }
}

// metodo
function _StopTime() {
    // zerando
    counterTimer = 0;

    // cancelando intervalo
    clearInterval(counterInternalID);

    // recuperando elemento
    var element = $get("UpdateProgressCounterTimer");

    // se encontrou é porque está habilitado
    if (element != null) {
        // limpando
        _ChangeText(element, "");
    }
}

// metodo
function _UpdateTime() {
    // incrementando
    counterTimer = counterTimer + 1000;

    // criando data vazia
    var counterDate = new Date("01/01/0001 00:00:00");

    // configurando milisegundos contados
    counterDate.setMilliseconds(counterTimer);

    // recuperando elemento
    var element = $get("UpdateProgressCounterTimer");

    // mostrando tempo
    _ChangeText(element, counterDate.toTimeString().substr(0, 8));
}

// metodo
function _ChangeText(element, text) {
    if (element.textContent) {
        element.textContent = text;
    } else {
        element.innerHTML = text;
    }
}

// metodo
function _ShowModal() {
    // configurando funcao para resize
    //$(window).bind("resize.modal", _ResizeModal);

    // cancelando behavior
    //e.preventDefault();

    // recuperando popup e modal
    var popup = $('#UpdateProgress');
    var modal = $('#UpdateProgressModal');

    // recuperando tamanhos
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    // configurando tamanhos
    modal.css({ 'width': maskWidth, 'height': maskHeight });

    // configurando posicao
    popup.css({ 'top': 0, 'left': 0 });

    // exibindo
    modal.show();
    popup.show();
}

// metodo
function _CloseModal() {
    // desconfigurando funcao para resize
    //$(window).unbind("resize.modal");

    // escondendo
    $('#UpdateProgressModal').hide();
    $('#UpdateProgress').hide();
}

// metodo
function _ResizeModal() {
    // recuperando popup e modal
    var popup = $('#UpdateProgress');
    var modal = $('#UpdateProgressModal');

    // recuperando tamanhos
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    // configurando tamanhos
    modal.css({ 'width': maskWidth, 'height': maskHeight });

    // configurando posicao
    popup.css({ 'top': 0, 'left': 0 });
}