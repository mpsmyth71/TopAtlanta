/*Core code included in every page*/
$.ajaxSetup({ cache: false }); // for IE9

var debounce = function (wait, func) {
    // we need to save these in the closure
    var timeout, args, context, timestamp;

    return function () {

        // save details of latest call
        context = this;
        args = [].slice.call(arguments, 0);
        timestamp = new Date();

        // this is where the magic happens
        var later = function () {

            // how long ago was the last call
            var last = (new Date()) - timestamp;

            // if the latest call was less that the wait period ago
            // then we reset the timeout to wait for the difference
            if (last < wait) {
                timeout = setTimeout(later, wait - last);

                // or if not we can null out the timer and run the latest
            } else {
                timeout = null;
                func.apply(context, args);
            }
        };

        // we only need to set the timer now if one isn't already running
        if (!timeout) {
            timeout = setTimeout(later, wait);
        }
    };
};

function updateTime() {
    $('[data-time]').each(function () {
        $(this).fadeIn();
        $(this).text(moment().subtract(moment($(this).data('time'))).format('mm:ss'));
    });
    setTimeout(updateTime, 1000);
}

function updateTimeago() {
    $('[data-timeago]').each(function () {
        $(this).text(moment($(this).data('timeago')).fromNow())
    });
    setTimeout(updateTimeago, 1000);
}

function updateFromNow() {
    $('[data-fromnow]').each(function () {
        $(this).text(moment($(this).data('fromnow')).fromNow(true))
    });
    setTimeout(updateFromNow, 1000);
}

function updateCaltime() {
    $('[data-caltime]').each(function () {
        $(this).text(moment($(this).data('caltime')).calendar());
    });
    setTimeout(updateCaltime, 1000);
}

$(document).ready(function () {

    $('html').automod();

    $('[autofocus]').focus(); // IE9 only

    updateTime();
    updateTimeago();
    updateFromNow();
    updateCaltime();

    // IE9 only: fix issues when refreshing a module
    // TODO: move into automod?
    $('body').on('refreshed.automod', '[data-module]', function (e) {
        $(this).find('[autofocus]').focus(); // IE9 only
        $.placeholder.shim(); // IE9 only
        console.log("Core.js: refreshed.automod, module=" + $(this).data('module'));
    });

    // IE9 only: fix placeholders when tabbing
    $('body').on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
        //e.target // newly activated tab
        //e.relatedTarget // previous active tab
        $.placeholder.shim();
    })

    // create a keyup event that ignores whitespace
    // TODO: is this in use?
    $('input').on('keyup', function (event) {
        var keyCode = String.fromCharCode(event.keyCode);
        if (keyCode.match(/\S/)) {
            $(this).trigger('keyupNotWhitespace');
        }
    });

});
