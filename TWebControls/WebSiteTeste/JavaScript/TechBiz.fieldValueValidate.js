(function ($) {
    $.fieldValueValidate = function (options) {
        $('*[-tbzValdt]').createValidate();
    }

    /* Validação de CNPJ. */
    jQuery.validator.addMethod("cnpj", function (value, element, param) {
        return this.optional(element) || isCnpjValid(value);
    }, "CNPJ Inválido");

    /* Validação de CPF. */
    jQuery.validator.addMethod("cpf", function (value, element, param) {
        return this.optional(element) || isCpfValid(value);
    }, "CPF Inválido");

    /* Validação de script customizado. */
    jQuery.validator.addMethod("customJS", function (value, element, param) {
        return this.optional(element) || isCustomValid(value, element, param);
    }, "Valor inválido");

    /* Validação de expressão regular. */
    jQuery.validator.addMethod("validaRegex", function (value, element, param) {
        return this.optional(element) || isRegexValid(value, element, param);
    }, "Valor inválido");

    /* Validação de Email. */
    jQuery.validator.addMethod("email", function (value, element, param) {
        return this.optional(element) || isEmailValid(value);
    }, "Email inválido");

    /* Validação de Telefone. */
    jQuery.validator.addMethod("telefone", function (value, element, param) {
        var valor = value.replace(/[^0-9]+/g, '');
        var length = this.getLength($.trim(valor), element);
        return this.optional(element) || (length >= 10 && length <= 11);
    }, "Telefone deve ter no mínimo 10 números");

    /* Funções privadas. Uso interno do plugin. */
    /*Elemento requerido*/
    $.fn.createValidate = function () {
        return this.each(function (index, element) {
            var opt = $.parseJSON($(this).attr('-tbzValdt'));
            opt.messages = $.extend($.fieldValueValidate.defaults.messages, opt.messages);
            options = $.extend($.fieldValueValidate.defaults, opt);
            $(this).rules("add", options);
        });
    }

    function isEmailValid(email) {
        var regexp = new RegExp('^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+)(\\.[a-zA-Z0-9]{2,4})((\\.[a-zA-Z0-9]{2}){0,1})$', 'i');
        return regexp.test(email);
    }

    function temSomenteNumerosIguais(numero) {
        for (var i = 1; i < numero.length; i++) {
            if (numero[i] != numero[i - 1]) {
                return false;
            }
        }

        return true;
    }

    function formataNumero(numero, caracteresFormatacao, tamanhoNumero, caractereComplemento) {
        // Elimina os caracteres especiais.
        var chars = caracteresFormatacao.split(';');

        for (var i = 0; i < chars.length; i++) {
            numero = replaceAll(numero, chars[i], '');
        }

        numero = trim(numero);
        numeroInt = new Array();

        if (numero.length > 0) {

            // Coloca o número com o tamanho correto.
            if (numero.length < tamanhoNumero) {
                numero = repeat('0', tamanhoNumero - numero.length) + numero;
            }

            // Converte para números.
            for (var j = 0; j < tamanhoNumero; j++) {
                numeroInt.push(parseInt(numero.substring(j, j + 1)));
            }
        }

        return numeroInt;
    }

    function isCustomValid(value, element, param) {
        var retorno = window[param].call(null, element, value)
        return retorno;
    }

    function isRegexValid(value, element, param) {
        var regexp = new RegExp(param, 'i');
        return regexp.test(value);
    }

    function isCpfValid(cpf) {
        try {
            numCpf = formataNumero(cpf, ".;-", 11, '0');

            if (numCpf.Length == 0) {
                return false;
            }

            if (temSomenteNumerosIguais(numCpf)) {
                return false;
            }

            // Calcula o primeiro dígito verificador.
            var digito = 0;

            digito = 11 - (
                    (10 * numCpf[0] + 9 * numCpf[1] + 8 * numCpf[2] + 7 * numCpf[3] + 6 * numCpf[4] + 5 * numCpf[5] +
                    4 * numCpf[6] + 3 * numCpf[7] + 2 * numCpf[8])
                    % 11);

            if (digito == 10 | digito == 11) {
                digito = 0;
            }

            // Se o primeiro dígito for diferente o CPF já é inválido.
            if (digito != numCpf[9]) {
                return false;
            }

            // Calcula o segundo dígito verificador.
            digito = 0;

            digito = 11 - (
                    (11 * numCpf[0] + 10 * numCpf[1] + 9 * numCpf[2] + 8 * numCpf[3] + 7 * numCpf[4] + 6 * numCpf[5] +
                    5 * numCpf[6] + 4 * numCpf[7] + 3 * numCpf[8] + 2 * numCpf[9])
                    % 11);

            if (digito == 10 | digito == 11) {
                digito = 0;
            }

            // Verifica a validade com o segundo dígito.
            return digito == numCpf[10];
        }
        catch (err) {
            return false;
        }
    }

    function isCnpjValid(cnpj) {
        try {
            numCnpj = formataNumero(cnpj, '.;/;-', 14, '0');
            if (numCnpj.length == 0) {
                return true;
            }

            if (temSomenteNumerosIguais(numCnpj)) {
                return false;
            }

            // Calcula o primeiro dígito verificador.
            var digito = 0;
            digito = 11 - (
                    (5 * numCnpj[0] + 4 * numCnpj[1] + 3 * numCnpj[2] + 2 * numCnpj[3] + 9 * numCnpj[4] + 8 * numCnpj[5] +
                    7 * numCnpj[6] + 6 * numCnpj[7] + 5 * numCnpj[8] + 4 * numCnpj[9] + 3 * numCnpj[10] + 2 * numCnpj[11])
                    % 11);

            if (digito == 10 | digito == 11) {
                digito = 0;
            }

            // Se o primeiro dígito verificador não for igual o CNPJ já é inválido.
            if (digito != numCnpj[12]) {
                return false;
            }

            // Calcula o segundo dígito verificador.
            digito = 0;
            digito = 11 - (
                    (6 * numCnpj[0] + 5 * numCnpj[1] + 4 * numCnpj[2] + 3 * numCnpj[3] + 2 * numCnpj[4] + 9 * numCnpj[5] +
                    8 * numCnpj[6] + 7 * numCnpj[7] + 6 * numCnpj[8] + 5 * numCnpj[9] + 4 * numCnpj[10] + 3 * numCnpj[11] +
                    2 * numCnpj[12])
                    % 11);

            // Retorna verdadeiro ou falso de acordo com a comparação do segundo dígito verificador.
            if (digito == 10 | digito == 11) {
                digito = 0;
            }

            // Verifica a validade com o segundo dígito.
            return digito == numCnpj[13];
        }
        catch (err) {
            return false;
        }
    }

    /* Validações de campos com combinação de data e hora. */

    function setDateTimeValidate(selector, options, format) {
        options = $.extend($.fieldValueValidate.defaults, options);
        return selector.each(function (index, element) {
            $(element).blur(function () {
                validateDate($(this), options.message, options.brazilianDate, format);
            });
        });
    }

    function validateDate(element, message, brazilianDate, format) {
        var date = element.val();

        if (date != '') {
            var fieldName;

            // Monta hora da validação.
            switch (format) {
                case 'dateTime':
                    format = 'Data e Hora';
                    break;
                case 'date':
                    format = 'Data';
                    date = date + ' 00:00:00';
                    break;
                case 'monthAndYear':
                    format = 'Mês e Ano';
                    date = '01/' + date + ' 00:00:00';
                    break;
                case 'year':
                    format = 'Ano';
                    date = '01/01/' + date + ' 00:00:00';
                    break;
                case 'hour':
                    format = 'Hora';
                    date = '01/01/1800 ' + date;
                    break;
                default:
                    fieldName = '';
            }

            if (fieldName == '') {
                return;
            }

            // Decodifica a data.
            dDate = decodeDate(date, brazilianDate);

            // Se não conseguiu decodificar a data, a data é inválida.
            var isValid = dDate.length > 0;

            // Conseguiu decodificar a data. Verifica se é uma data válida.
            if (isValid) {
                isValid = isValidDate(dDate);
            }

            if (!isValid) {
                showAlert(element, message, format);
            }
        }
    }

    function isValidDate(dDate) {
        // Valida ano.
        if (dDate[2] < 1800) return false;

        // Valida meses e primeiro dia do mês.
        if (dDate[1] < 1 || dDate[1] > 12 || dDate[0] < 1) return false;

        // Valida meses com 31 dias 
        if ((dDate[1] == 1 || dDate[1] == 3 || dDate[1] == 5 || dDate[1] == 7 || dDate[1] == 8 || dDate[1] == 10 || dDate[1] == 12) && dDate[0] > 31) return false;

        // Valida meses com 30 dias 
        if ((dDate[1] == 2 || dDate[1] == 4 || dDate[1] == 6 || dDate[1] == 9 || dDate[1] == 11) && dDate[0] > 30) return false;

        // Valida mês de Fevereiro.
        // Verifica se o ano é bissexto. Para o ano ser bissexto ele deve ser divisível por 4, não términar com zero duplo ou, 
        // em caso de términar com zero duplo, deve ser divisível por 400.
        var isBissexto = (dDate[2] % 4 == 0) && ((dDate[2].toString().substring(2) != '00') || (dDate[2] % 400 == 0));

        if ((dDate[1] == 2) && ((isBissexto && dDate[0] > 29) || (dDate[0] > 28))) return false;

        // Valida horas.
        if (dDate[3] < 0 || dDate[3] > 23) return false;

        // Valida minutos e segundos.
        if ((dDate[4] < 0 || dDate[4] > 59) || (dDate[5] < 0 || dDate[5] > 59)) return false;

        return true;
    }

    function decodeDate(dateTime, brazilianDate) {
        var dDate = new Array();

        if (dateTime != undefined && dateTime != '') {
            if (brazilianDate == undefined) {
                brazilianDate = true;
            }

            try {
                if (brazilianDate) {
                    dDate.push(parseInt(dateTime.substring(0, 2)));
                    dDate.push(parseInt(dateTime.substring(3, 5)));
                }
                else {
                    dDate.push(parseInt(dateTime.substring(3, 5)));
                    dDate.push(parseInt(dateTime.substring(0, 2)));
                }

                dDate.push(parseInt(dateTime.substring(6, 10)));
                dDate.push(parseInt(dateTime.substring(11, 13)));
                dDate.push(parseInt(dateTime.substring(14, 16)));
                dDate.push(parseInt(dateTime.substring(17)));
            } catch (error) {
                // Não faz nada, apenas impede erros de script.
            }
        }

        return dDate;
    }

    /* Validação de máscaras por expressão regular. */

    function validateByRegex(selector, options, pattern, fieldName, callBack) {
        options = $.extend($.fieldValueValidate.defaults, options);

        return selector.each(function (index, element) {
            $(element).blur(function () {
                var value = $(this).val();

                if (value != '') {
                    var regexp = new RegExp(pattern, 'i');
                    var isValid = regexp.test(value);

                    if (callBack != null) {
                        isValid = isValid && callBack(value);
                    }

                    if (!isValid) {
                        showAlert($(element), options.message, fieldName);
                    }
                }
            });
        });
    }

    /* Exibe mensagens de aviso para o usuário. */

    function showAlert(element, message, fieldName) {
        $.messageBox({
            message: replaceAll(message, '{0}', fieldName),
            callBack1: function () {
                element.select();
                element.focus();
            }
        });
    }

    /* Valores default para os nomes de classes css que definem campos de documento para validação. */

    $.fieldValueValidate.defaults = {
        messages: {
            required: "O campo é obrigatório.",
            remote: "Please fix this field.",
            email: "Email inválido.",
            url: "Url inválida.",
            date: "Entre com uma data válida.",
            number: "Entre com um número válido.",
            equalTo: "Please enter the same value again.",
            accept: "Please enter a value with a valid extension.",
            maxlength: "Please enter no more than {0} characters.",
            minlength: "É necessário inserir no mínimo {0} caracteres.",
            rangelength: "Please enter a value between {0} and {1} characters long.",
            range: "Please enter a value between {0} and {1}.",
            max: "Please enter a value less than or equal to {0}.",
            min: "Please enter a value greater than or equal to {0}."
        }
    };

})(jQuery);
