(function ($) {

    $.configureDateTimeMasks = function (options) {
        options = $.extend($.configureDateTimeMasks.defaults, options);
        
        /* Máscara para valores combinados de data e hora. */

        $('[-tbzMsk="' + $.configureDateTimeMasks.defaults.dateTime + '"]').setDateTimeMask();
        $('[-tbzMsk="' + $.configureDateTimeMasks.defaults.date + '"]').setDateMask();
        $('[-tbzMsk="' + $.configureDateTimeMasks.defaults.monthAndYear + '"]').setMonthAndYearMask();
        $('[-tbzMsk="' + $.configureDateTimeMasks.defaults.year + '"]').setYearMask();
        $('[-tbzMsk="' + $.configureDateTimeMasks.defaults.hour + '"]').setHourMask();
    }

    /* Definição de máscaras para data e hora (Apenas formato. Não incluem calendário). */

    $.fn.setDateTimeMask = function () {
        return this.each(function () {
            setMask('99/99/9999 99:99:99', $(this))
        });
    }

    $.fn.setDateMask = function () {
        return this.each(function () {
            setMask('99/99/9999', $(this))
        });
    }

    $.fn.setMonthAndYearMask = function () {
        return this.each(function () {
            setMask('99/9999', $(this))
        });
    }

    $.fn.setYearMask = function () {
        return this.each(function () {
            setMask('9999', $(this))
        });
    }

    $.fn.setHourMask = function () {
        return this.each(function () {
            setMask('99:99:99', $(this))
        });
    }
})(jQuery);