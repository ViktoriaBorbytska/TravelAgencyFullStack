$(document).ready(function () {
    "use strict";

    $('input[type=password]').keyup(function() {
        let pswd = $(this).val();
        let pswdContainer = $('.password-info');
        pswd === '' ? pswdContainer.css('display', 'none') : pswdContainer.css('display', 'block');
        classSetter('#length', pswd.length >= 8);
        classSetter('#letter', pswd.match(/[A-z]/));
        classSetter('#capital', pswd.match(/[A-Z]/));
        classSetter('#number', pswd.match(/\d/));
    });

    function classSetter(id, statement) {
        statement ? $(id).addClass('valid') : $(id).removeClass('valid');
    }
});