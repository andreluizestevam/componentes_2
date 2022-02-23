// declaracao
with (Sys.WebForms.PageRequestManager.getInstance()) {
    add_pageLoaded(this._onPageLoaded);
    add_beginRequest(this._onBeginRequest);
    add_endRequest(this._onEndRequest);
}

//evento
function _onPageLoaded(sender, args) {
    // iniciando
    _StartTime();
}

//evento
function _onBeginRequest(sender, args) {
    // parando
    _StopTime();
}

//evento
function _onEndRequest(sender, args) {
    // iniciando
    _StartTime();
}

// variaveis
var counterTimer = 0;
var counterInternalID;

// metodo
function _StartTime() {
    // recuperando elemento
    var element1 = $get("__SESSIONTIMEOUT");

    // recuperando elemento
    var element2 = $get("SessionProgress");

    // se encontrou é porque está habilitado
    if (element1 != null
        && element2 != null) {
        // configurando valor
        counterTimer = (parseInt(element1.value) * 60) * 1000;

        // configurando visibilidade
        element2.style.display = 'inline';

        // iniciando
        _UpdateTime();

        // iniciando intervalo
        counterInternalID = setInterval(_UpdateTime, 1000);
    }
}

// metodo
function _StopTime() {
    // zerando
    counterTimer = 0;

    // cancelando intervalo
    clearInterval(counterInternalID);

    // recuperando elemento
    var element = $get("SessionProgress");

    // se encontrou é porque está habilitado
    if (element != null) {
        // limpando
        element.style.display = 'none';
    }
}

// metodo
function _UpdateTime() {
    // incrementando
    counterTimer = counterTimer - 1000;

    // criando data vazia
    var counterDate = new Date("01/01/0001 00:00:00");

    // configurando milisegundos contados
    counterDate.setMilliseconds(counterTimer);

    // recuperando elemento
    var element = $get("SessionProgressCounterTimer");

    // mostrando tempo
    element.innerText = counterDate.toTimeString().substr(0, 8);
}