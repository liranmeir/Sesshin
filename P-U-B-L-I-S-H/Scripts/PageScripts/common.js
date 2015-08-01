$.fn.delay = function(time, callback) {
    // Empty function:
    jQuery.fx.step.delay = function() {
    };
    // Return meaningless animation, (will be added to queue)
    return this.animate({ delay: 1 }, time, callback);
};

jQuery.fn.blink = function() {

    pgUtils.blink(this);
};

jQuery.fn.isEmail = function() {
    return pgUtils.validateEmail($(this).val());
};

jQuery.fn.isPhone = function() {
    return pgUtils.validatePhone($(this).val());
};
jQuery.fn.isEmpty = function() {
    return ($(this).val().length === 0);
};

var pgUtils = function () {
    return {
    //validateFullName
        validateFullName: function(elementValue) {

            var fullNamePattern = /^[a-zA-Z]{2,}\s*([a-zA-Z]{2,})?\s*([a-zA-Z]{2,})?$|^['א-ת]{2,}\s*(['א-ת]{2,})?\s*(['א-ת]{2,})?$/ ;
            return fullNamePattern.test(elementValue);
        },
        //validatePhone
        validatePhone: function(elementValue) {
            elementValue = elementValue.split(' ').join('');
            var phonePattern = /^0[23489]{1}(\-)?[^0\D]{1}\d{6}$|^0(5[023479]{1}|7[234678]{1})(\-)?[^0\D]{1}\d{6}$/ ;
            return phonePattern.test(elementValue);
        }, //validateEmail
        validateEmail: function(elementValue) {
            var emailPattern = new RegExp( /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i );

            var blackListPattern = new RegExp( /^[a-z]@/ );
            if (blackListPattern.test(elementValue)) return false;

            return emailPattern.test(elementValue);
        }, //validateID
        validateID: function(elementValue) {
            var idPattern = /^\d{7,9}$/ ;
            return idPattern.test(elementValue);
        },
        //blink
        blink: function(obj) {
            if (obj.attr('blink') === 'blink')
                return;

            obj.attr('blink', 'blink');
            var color = obj.css('color');
            obj.css('color', 'red');
            obj.fadeIn(300)
                .fadeOut(300)
                .fadeIn(300)
                .fadeOut(300)
                .fadeIn(300)
                .fadeOut(300)
                .fadeIn(300, function() {
                    obj.css('color', color);
                    obj.removeAttr('blink');
                });

        }
    };
} ();


