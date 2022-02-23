(function ($) {
    var startupDelegates = new Array();

    $.fn.AddStartupDelegate = function (delegate) {
        startupDelegates.push(delegate);
    }

    $.fn.Start = function () {
        for (var i = 0; i < startupDelegates.length; i++) {
            startupDelegates[i]();
        }
    };
})(jQuery);