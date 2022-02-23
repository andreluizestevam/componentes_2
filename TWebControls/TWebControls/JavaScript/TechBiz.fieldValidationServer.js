// Summary: Plugin TechBiz de validação de campos no servidor de aplicação. 
// Author: Alexandre Chestter.
// Date: 24/11/2011
// Remarks:
//     Este plugin implementa uma chamada Ajax ao servidor (controller) para validar campos da página. Ações no cliente serão
//     executadas de acordo com o retorno do controller.
//        
//     Para implementar o controller deve ser herdado de BaseController e implementar o método FieldValidation. (Para maiores informações 
//     a implementação no lado servidor consulte a documentação de BaseController).
//
//     O resultado retornado pelo controller deve ter a seguinte estrutura:
//
//         messageType: Informa o tipo da mensagem a ser exibida no cliente. Pode ser de 3 valores:
//                      None: Nada deve ser executado no cliente.
//                      OK: Deve ser exibida um diálogo do tipo OK.
//                      YesOrNo: Deve ser exibida um diálogo do tipo "Sim ou Não".
//         title: O título da caixa de diálogo.
//         message: A mensgem da caixa de diálogo.
//         fieldBehavior1 e fieldBehavior2: O comportamento que o campo deve ter na saida do diálogo de acordo com o pressionamento dos botões exibidos.
//                      fieldBehavior1 refere-se ao comportamento para os botões OK e Sim e fieldBehavior2 refere-se ao comportamento do botão Não. Os
//                      valores possíveis para estes campos são:
//                      PageDefault: Deve continuar o fluxo normal da página.
//                      StayOnField: O foco deve permanecer no componente atual.
//                      StayOnFieldAndClear: O foco deve permanecer no componente atual e o valor do campo deve ser limpo.
//                      Redirect:  Passa o fluxo de controle da página atual para outra página.
//         url1 e url2: Define as urls de redirecionamento para os comportamentos do tipo Redirect. url1 refere-se ao destino de redirecionamento para os 
//                      botões OK e Sim e url2 refere-se ao destino de redirecionamento para o botão Não.
//         data1 e data2: Define um objeto de dados a ser enviado no post de redirecionamento para url1 e url2 respectivamente.
// Example: 
//     Na view em que deseja implementar a validação de servidor para algum campo execute @Html.validationDialog(); em qualquer lugar.
(function ($) {
    // Summary: Define validações de servidor para uma selação jQuery.
    // Parameter validationUrl: A url do serviço de validação. 
    $.fn.fieldValidationServer = function (validationUrl) {

        // Se o seletor não retornou nenhum campo nada não temos nada a fazer.
        if (this.length == 0) {
            return;
        }

        // Define o comportamento de validação para cada campo retornado no seletor.
        return this.each(function () {
            var form = $(this).parents('form');

            // Se não existir um form na página não é possível efetuar validação de servidor.
            if (form.length == 0) {
                return;
            }

            var field = $(this);

            // Verifica se uma action de validação customizada foi definida.
            if (validationUrl == '' || validationUrl == undefined) {
                var formAction = form.attr('action');
                validationUrl = formAction.substr(0, formAction.indexOf('/', 1)) + '/FieldServerValidation';
            }

            // Recupera o nome do campo a ser validado. A prioridade é pela propriedade name, uma vez que o HttpRequest recupera os valores somente dos campos que tem a propriedade name
            // preenchida. Se o campo não possuir a propriedade nome ainda tentamos recuperar o nome do campo pela propriedade Id. 
            // Se não existirem nenhuma das duas aborta a configuração para o componente corrente.
            var fieldToValidate = field.attr('name');

            if (fieldToValidate == '') {
                fieldToValidate = field.attr('Id');

                if (fieldToValidate == '') {
                    return;
                }
            }

            // Monta o nome do campo no formato NomeEntidade.NomePropriedade.
            fieldToValidate = field.attr('name').replace('-', '.');

            if (form.length > 0) {
                var validationDialog = $('#fieldServerValidationDialog');

                // Define a interceptação do submit do formulário ao qual o campo pertence.
                form.submit(function () {
                    $(this).ajaxSubmit({
                        url: validationUrl,
                        data: { fieldName: fieldToValidate }, // Define campo da validação.
                        dataType: 'json',
                        success: function (srvResponse) {
                            if (srvResponse.messageType != 'None') {
                                var buttons = createButtons(srvResponse, field);

                                // Não foi identificado o tipo da caixa de diálogo. Não poderemos executar nenhuma acão.
                                if (buttons.length == 0) {
                                    return;
                                }

                                // Efetua a ação de acordo com o retorno da validação.
                                validationDialog.dialog({
                                    autoOpen: false,
                                    modal: true,
                                    resizable: false,
                                    title: srvResponse.title,
                                    closeText: '',
                                    buttons: buttons
                                });

                                $('#fieldServerValidationMessage > p').text(srvResponse.message);

                                // Exibe a caixa de diálogo configurada de acordo com as definições do controller.                                
                                validationDialog.dialog('open');
                            }

                            // Tenta setar o foco no primeiro campo possível a partir do campo atual da validação.
                            setFocusToNextFieldFrom(field);
                        }
                    });

                    return false;
                });
            }

            $(this).blur(function () {
                // Dispara o submit customizado do form ao qual o campo pertence, para efetuar a validação.
                var form = $(this).parents('form');

                if (form.length > 0) {
                    form.submit();
                }
            });
        });
    }

    // Summary: Cria os campos da caixa de diálogo de validação de acordo com a parametrização do servidor.
    // Parameter srvResponse: As configurações retornadas pelo servidor.
    // Parameter field: O campo que está sendo validado.
    function createButtons(srvResponse, field) {
        var buttons = new Array();

        if (srvResponse.messageType == 'OK') {
            // Definição de botões para caixa de diálogo do tipo OK.
            buttons.push(
            {
                text: "Ok",
                click: function () { doAction(field, srvResponse.fieldBehavior1, srvResponse.action1, srvResponse.data1); }
            });
        }
        else if (srvResponse.messageType = 'YesOrNo') {
            // Definição de botões para caixa de diálogo do tipo Sim ou Não.
            buttons.push(
            {
                text: "Não", click: function () { doAction(field, srvResponse.fieldBehavior2, srvResponse.action2, srvResponse.data2); }
            },
            {
                text: "Sim", click: function () { doAction(field, srvResponse.fieldBehavior1, srvResponse.action1, srvResponse.data1); }
            });
        }

        return buttons;
    }

    // Summary: Executa a ação para um determinado botão da caixa de diálogo.
    // Parameter field: O campo que está sendo validado.
    // Parameter fieldBehavior: O tipo de comportamento definido para o botão no servidor.
    // Parameter action: Uma ação de controlador associada ao botão.
    // Parameter actionData: Um objeto JSON para ser enviado a ação associada ao botão.
    function doAction(field, fieldBehavior, action, actionData) {
        var validationDialog = $('#fieldServerValidationDialog');

        switch (fieldBehavior) {
            case 'PageDefault':
                // Ação default da página.
                validationDialog.dialog('close');
                setFocusToNextFieldFrom(field);
                break;
            case 'StayOnField':
                // Mantém o foco no campo atual.
                validationDialog.dialog('close');
                field.focus();
                break;
            case 'StayOnFieldAndClear':
                // Mantém o foco no campo atual limpando o seu conteúdo.
                field.val('');
                validationDialog.dialog('close');
                field.focus();
                break;
            case 'Redirect':
                // Redireciona o fluxo para outra ação.
                $.ajax({
                    type: 'POST',
                    url: action,
                    async: false,
                    data: actionData
                });
        }
    }

    // Summery: Seta o foco para o próximo campo focável a partir de um determinado campo.
    // Parameter field: O campo de referência para definição do foco.
    function setFocusToNextFieldFrom(field) {
        var formFields = field.parents('form').find('button,input,textarea,select');

        if (formFields.length > 0) {
            var currentIndex = formFields.index(field);

            // Tenta setar o próximo campo focável a partir do campo atual.
            if (!setFirstFocusableFrom(currentIndex + 1, formFields)) {
                // Se não conseguir seta o primeira campo focável da página.
                setFirstFocusableFrom(0, formFields);
            }
        }
    };

    // Summary: Seta o foco para o primeiro campo focável de um conjunto de elementos a partir de uma determinada posição.
    // Parameter startIndex: O ponto de partida para a procuda do primeiro elemento focável.
    // Parameter range: O conjunto de elementos na qual a procura deve ser realizada.
    function setFirstFocusableFrom(startIndex, range) {
        for (var index = startIndex; index < range.length; index++) {
            var field = $(range[index]);

            // Se o campo não estiver invisível nem desabilitado ele está apto a ser receber o foco.
            if (field.is(':visible') && !field.is(':disabled')) {
                field.focus();
                return true;
            }
        }

        return false;
    }

//    //Seta os serviços Ajax para validação de servidor de campos.
//    $().AddStartupDelegate(function () {
//        $('[servervalidation]').fieldValidationServer();
//    });
})(jQuery);