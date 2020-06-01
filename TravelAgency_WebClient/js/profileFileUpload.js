$(document).ready(function () {
    "use strict";

    $('.input-file').each(function () {
        let $input = $(this),
            $label = $input.next('label'),
            labelVal = $label.html();

        $input.on('change', function (e) {
            let fileName = e.target.value.split('\\').pop();
            fileName ? $label.find('span').html(fileName) : $label.html(labelVal);
        });

        $input.on('focus', function () {
            $input.addClass('has-focus');
        })
            .on('blur', function () {
                $input.removeClass('has-focus');
            });
    });
});