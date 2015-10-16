// the semi-colon before function invocation is a safety net against concatenated
// scripts and/or other plugins which may not be closed properly.
; (function ($, window, document, undefined) {

    // undefined is used here as the undefined global variable in ECMAScript 3 is
    // mutable (ie. it can be changed by someone else). undefined isn't really being
    // passed in so we can ensure the value of it is truly undefined. In ES5, undefined
    // can no longer be modified.

    // window and document are passed through as local variable rather than global
    // as this (slightly) quickens the resolution process and can be more efficiently
    // minified (especially when both are regularly referenced in your plugin).

    // Create the defaults once
    var pluginName = "automod",
            defaults = {
                debounce: 400
            };

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

    var refresh = function (e, data) {
        e.stopPropagation();
        // TODO: show loading animation
        var href = $(this).data('url');
        $.get(href, data).always(replace);
    };

    var empty = function (e) {
        e.stopPropagation();
        $(this).empty();
        if ($(this).is('.box')) $(this).removeClass('box');
    }

    var select = function (e) {
        e.preventDefault();
        e.stopPropagation();

        var $trigger = $(this);

        // handle selectable
        if ($trigger.is('.selectable')) {
            $trigger.siblings('.selectable').removeClass('selected');
            $trigger.addClass('selected');
        }

        e = $.Event("selected.automod", { relatedTarget: $trigger });
        var data = $trigger.data();
        $trigger.closest('[data-module]').trigger(e, data);
    };

    var comboselect = function (e) {
        var name = $(this).closest('li').data('name');
        var val = $(this).closest('li').data('value');
        var s = $(this).closest('div.combo');
        s.find('input:hidden').val(val).trigger('change');
        s.find('span.term').text(name);
        //replace the icon in the search field
        // TODO: figure out generic way
        if ($(this).is('a')) {
            var newIcon = $(this).find('svg circle').first().clone(true);
            s.find('svg.cat circle').replaceWith(newIcon);
        }
    };

    //var autoselect = function () {
    //    e.stopPropagation();
    //    var $mod = $(this);
    //    var data = $mod.find('.selected').data();
    //    $mod.trigger('selected.automod', data);
    //};

    var search = function (e) {
        var $form = $(e.target).closest('form');
        $.post($form.attr('action'), $form.serialize()).always(replace);
    };

    var get = function (e) {
        e.preventDefault();
        var $trigger = $(this);

        if (!$trigger.data('bubble')) e.stopPropagation();

        $.get($trigger.data('get')).always(replace);
    };

    var post = function (e) {
        e.preventDefault();
        var $trigger = $(this);
        var data = $trigger.closest('form').serialize();
        $.post($trigger.data('post'), data).always(replace);
    };

    var submit = function (e) {
        e.preventDefault();
        var $form = $(this);
        // TODO: trigger loading on nearest module
        $.post($form.attr('action'), $form.serialize()).always(replace);
    };

    var keyup = function (e) {

        // ignore tabs
        if (e.which === 9) return;

        // ignore shifts
        if (e.which === 16) return;

        // TODO: ignore spaces?

        e.data(e); // call debounceSearch
    };

    var toggle = function (e) {
        var show = $(this).data('toggle');

        if ($(this).is(':checkbox')) {
            // for checkbox, just show or hide the exact item
            var visible = $(this).prop('checked');
            var target = $(this).closest('[data-module]').find('[data-show=' + show + ']');
            if (visible) target.fadeIn(); // don't use toggleFade since it may already be visible
            else target.fadeOut();
        } else if ($(this).is('select') || $(this).is(':radio')) { // TODO: support radio too?
            // for exclusive choice, show selected, hide all the others
            var val = $(this).val();
            $(this).closest('[data-module]')
            .find('[data-show^=' + show + ']').each(function () {
                var visible = $(this).data('show') == show + '-' + val;
                $(this).toggle(visible);
            });
        }
        else {//Simply toggle the item that is identified by the data-toggle selector
            $(show).toggle();
        }
        $.placeholder.shim(); // IE9 hack
    };

    var disable = function (e) {
        var selector = $(this).data('disable');
        if ($(this).is(':checkbox')) {
            var checked = $(this).prop('checked');
            if (checked) {
                $(selector).prop('disabled', false);
            }
            else {
                $(selector).prop('checked', false);
                $(selector).prop('disabled', true);
            }
        }
    };

    var change = function (e) {
        var cb = $(this).find(':checkbox');
        var checked = !cb.prop('checked');
        cb.prop('checked', checked);
        morph($(this), checked);
        cb.trigger('change');
    };

    var morph = function ($toggle, checked) {
        var d = checked ? $toggle.data('path-checked') : $toggle.data('path-unchecked');

        var path = new Snap($toggle.find('path')[0]);
        path.animate({ d: d }, 500);
    };

    var clear = function (e) {
        e.preventDefault();

        // take over reset manually
        var $form = $(this).closest('form');
        $form[0].reset();

        // refresh drop down data selects
        $form.find('.jq-dropdown [data-select]').each(function () {
            $(this).find('input[type=radio]').first().trigger('change.automod');
        });

        // refresh all snap toggles by morphing to default value
        $form.find('.snap-toggle').each(function () {
            morph($(this), $(this).find(':checkbox').prop('checked'));
        });

        // fix placeholds by blur for IE9 only
        $form.find('input[placeholder]').trigger('blur');

        // finally resubmit to refresh list results
        $form.trigger('submit.automod');
    };

    var drop = function (e) { // refreshes the dropdown text
        var select = $(this).closest('[data-select]');
        // get label text of checked radio
        var text = select.find(':checked').parent().text();

        var id = $(this).closest('.jq-dropdown')[0].id;
        var trigger = $('[data-dropdown=#' + id + ']');
        trigger.text(text);
    };

    var addrenter = function (e) {
        if (e.which === 13) { // enter key
            e.preventDefault();
            addrval($(this).closest('[data-address]'));
        }
    };

    var addrclick = function () {
        addrval($(this).closest('[data-address]'));
    };

    var addrval = function (container) {
        var url = container.data('address');
        // serialize without prefix
        var data = {
            addressline1: container.find('input[name$=AddressLine1]').val(),
            secondaryaddress: container.find('input[name$=SecondaryAddress]').val(),
            city: container.find('input[name$=City]').val(),
            postalCode: container.find('input[name$=PostalCode]').val()
        };
        $.post(url, data).always(replace);
    };

    var addrdirty = function (e) {
        if (e.which !== 0) { // if character typed, consider it dirty

            var addr = $(this).closest('[data-address]');
            // only continue if it isn't already unverified
            if (addr.find('[name$=IsVerified]').val() === 'false') return;

            var container = addr.find('[data-val-icon]');

            var color = container.data('color-unverified');
            var count = 0;
            var shadePercent = 0.90;
            var shadeColor2 = function (color, percent) {
                var f = parseInt(color.slice(1), 16), t = percent < 0 ? 0 : 255, p = percent < 0 ? percent * -1 : percent, R = f >> 16, G = f >> 8 & 0x00FF, B = f & 0x0000FF;
                return "#" + (0x1000000 + (Math.round((t - R) * p) + R) * 0x10000 + (Math.round((t - G) * p) + G) * 0x100 + (Math.round((t - B) * p) + B)).toString(16).slice(1);
            };
            var pulseAnimation = function () {
                if (count > 5 && shadePercent === 0) return;
                shadePercent = shadePercent === 0 ? 0.90 : 0;
                var shaded = shadeColor2(color, shadePercent);
                count++;
                new Snap(container.find('g')[0]).animate({ fill: shaded, stroke: shaded }, 500, pulseAnimation);
            };

            var d = container.data('path-unverified');
            new Snap(container.find('path')[0]).animate({ d: d }, 500, pulseAnimation);


            // mark as unverified
            addr.find('[name$=IsVerified]').val('false');
            addr.find('[data-name=State]').text('__');
            addr.find('[data-name=PostalCodeEx]').text('____');
        }
    };

    var searchenter = function (e) {
        if (e.which === 13) { // enter key
            e.preventDefault();
            search(e)
        }
    };

    var replace = function (data, textStatus, xhr) {
        if (xhr.status == 205) window.location.replace(xhr.getResponseHeader('location'));

        console.log('------ replace begin');

        var after = function ($newMod, target) {
            var oldMod = $('[data-module=' + target + ']');
            console.log('replacing ' + target + ' after ' + $newMod.data('module'));
            $newMod.hide();
            $.placeholder.shim();
            oldMod.after($newMod);
            $newMod.trigger($.Event('refreshed.automod'));
            $newMod.fadeIn();
        };

        var allAfter = function (target) {
            var afterMods = $(data).filter('[data-after=' + target + ']').each(function () {
                after($(this), target);
            });
        };

        $(data).filter('[data-module]').each(function () {
            var name = $(this).data('module');
            var target = $(this).data('replace') || $(this).data('after') || name;

            if ($(this).is('ul')) { // do list animation fade in
                var ul = $('[data-module=' + name + ']');
                console.log('fadding list items for ' + target);
                ul.empty();
                $(data).find('li').each(function (i) {
                    var item = $(this);
                    item.hide();
                    ul.append(item);
                    item.delay(100 * i).fadeIn();
                });
                ul.trigger($.Event('refreshed.automod'));
            } else if ($(this).is(':not([data-after])')) { // do regular fade out->in
                var newMod = $(this).hide();
                $('[data-module=' + target + ']').fadeTo(300, 0.1, function () {
                    newMod.fadeIn();
                    console.log('replacing ' + target + ' with ' + name);
                    $(this).replaceWith(newMod);
                    $.placeholder.shim();
                    newMod.trigger($.Event('refreshed.automod'));
                    // now insert all mods that go after this mod
                    allAfter(name);
                });
            } else if ($(this).is('[data-after]')) {
                // we are only safe to insert if the mod to insert after is already inserted
                // TODO: this code was wrong, and is not yet needed
                //if ($(data).has('[data-module=' + target + ']').length === 0) {
                //    after($(this), target);
                //}
            }
        });
        console.log('------ replace end');
    };

    // The actual plugin constructor
    function Automod(element, options) {
        this.element = element;
        // jQuery has an extend method which merges the contents of two or
        // more objects, storing the result in the first object. The first object
        // is generally empty as we don't want to alter the default options for
        // future instances of the plugin
        this.settings = $.extend({}, defaults, options);
        this._defaults = defaults;
        this._name = pluginName;
        this.init();
    }

    // Avoid Plugin.prototype conflicts
    $.extend(Automod.prototype, {
        init: function () {
            var debounceSearch = debounce(this.settings.debounce, search);

            $(this.element).on('refresh.automod', '[data-module][data-url]', refresh);
            $(this.element).on('empty.automod', '[data-module]', empty);
            $(this.element).on('refreshed.automod', '[data-module][data-module]:not(.jq-dropdown)', function (e) { e.stopPropagation() });
            $(this.element).on('refreshed.automod', '.jq-dropdown', function (e) { e.stopPropagation(); $(this).hide(); });
            $(this.element).on('click.automod', '[data-module] .selectable', select);

            $(this.element).on('click.automod', '[data-get]', get);
            $(this.element).on('click.automod', '[data-post]', post);
            $(this.element).on('submit.automod', 'form[data-module]', submit);
            /*$(this.element).on('keyup.automod', 'form[data-debounce] input[type=text]', debounceSearch, keyup);*/
            $(this.element).on('keydown', 'form[data-debounce] input[type=text]', searchenter);

            $(this.element).on('change.automod', 'form[data-debounce] input[type=radio]', search);
            $(this.element).on('change.automod', 'form[data-debounce] input[type=checkbox]', search);
            $(this.element).on('change.automod', 'form[data-debounce] select', search);
            $(this.element).on('click.automod', 'form[data-debounce] [type=reset]', clear);
            $(this.element).on('change.automod', 'form .jq-dropdown [data-select] input[type=radio]', drop);
            $(this.element).on('click.automod', '.snap-toggle', change);
            $(this.element).on('change.automod', '[data-toggle]:input', toggle);
            $(this.element).on('change.automod', '[data-disable]', disable);
            $(this.element).on('click.automod', 'button[data-toggle], a[data-toggle]', toggle);

            $(this.element).on('textchange', '[data-address] input[type=text]', addrdirty); // can't use input because IE9 sux
            $(this.element).on('keydown', '[data-address] input[type=text]', addrenter);
            $(this.element).on('click', '[data-address] [data-val-icon]', addrclick);

            // ************* Ajax search drop down ******************
            // when search dropdown shown, prefocus/select search term
            $(this.element).on('show', 'div[data-search] div.jq-dropdown', function () {
                $(this).find('input[name=term]').focus().select();
            });

            // when user pushes enter key, force search
            $(this.element).on('keypress', 'div[data-search] div.jq-dropdown input[name=term]', function (e) {
                if (e.which === 13) { // enter key
                    e.preventDefault();
                    var url = $(this).closest('div[data-search]').data('search');
                    $('body').automodGet(url, { term: $(this).val() });
                    e.stopPropagation(); // don't let IE submit the form
                }
            });

            // when user selects a search result, update form field and display text
            $(this.element).on('click', 'div.combo div.jq-dropdown button[name=select]', comboselect);
            $(this.element).on('click', 'div.combo div.jq-dropdown a[rel=select]', comboselect);

            // when user clicks "X" clear the form field and display text
            //$(this.element).on('click', 'div[data-search] button[name=clear]', function () {
            //    var s = $(this).closest('div[data-search]');
            //    s.find('input:hidden').val('');
            //    s.find('span.term').text('');
            //});

            // ************* Customer/Site edit event registrations *********
            // add phone
            $(this.element).on('click', 'button[name=add]', function () {
                var url = $(this).data('url');
                var list = $($(this).data('list'));
                $.get(url).success(function (data) {
                    list.append(data);
                    $.placeholder.shim();
                });
            });

            // del phone
            $(this.element).on('click', 'button[name=del]', function () {
                $(this).closest('.row').remove().empty();
                $.placeholder.shim();
            });

            $(this.element).on('change', '#phoneList :radio', function () {
                // hide delete link for primary, show for all secondary
                var selName = $(this).attr('name');
                $('#phoneList :radio').each(function () {
                    // only one radio should be checked
                    $(this).prop('checked', $(this).attr('name') == selName);

                    if ($(this).prop('checked')) $(this).closest('.row').find('[name=del]').css('visibility', 'hidden');
                    else $(this).closest('.row').find('[name=del]').css('visibility', 'visible');
                });
            });

            $(this.element).on('change', 'select[name$="IsOwner"]', function () {
                if ($(this).val() == 'false')
                    $(this).closest('.form-group').next().removeClass('hidden');
                else
                    $(this).closest('.form-group').next().addClass('hidden');
            });

            $(this.element).on('change', 'select[name$="SiteId"]', function () {
                if ($(this).val() > 0)
                    $(this).closest('form').find('[name="OwnerCheck"]').removeClass('hidden');
                else
                    $(this).closest('form').find('[name="OwnerCheck"]').addClass('hidden');
            });
        },
    });

    // Expose our replace function through jquery
    $.fn['automodReplace'] = function (data, textStatus, xhr) {
        replace(data, textStatus, xhr);
    };
    // Expose our replace function through jquery
    $.fn['automodGet'] = function (url, data, callback) {
        $.get(url, data).always(replace).then(callback);
    };
    // Expose our replace function through jquery
    $.fn['automodPost'] = function (url, data, callback) {
        $.post(url, data).always(replace).then(callback);
    };

    // A really lightweight plugin wrapper around the constructor,
    // preventing against multiple instantiations
    $.fn[pluginName] = function (options) {
        this.each(function () {
            if (!$.data(this, "plugin_" + pluginName)) {
                $.data(this, "plugin_" + pluginName, new Automod(this, options));
            }
        });

        // chain jQuery functions
        return this;
    };

})(jQuery, window, document);