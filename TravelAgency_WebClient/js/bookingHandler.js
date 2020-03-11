$(document).ready(function () {
    "use strict";

    let dateToday = new Date();
    let checkInElem = '#checkIn';
    let checkOutElem = '#checkOut';

    let now = new Date(dateToday.getFullYear(), dateToday.getMonth(), dateToday.getDate(), 0, 0, 0, 0);
    let checkIn = $(checkInElem).datepicker({
        todayHighlight: !0,
        beforeShowDay: function (e) {
            return e.valueOf() >= now.valueOf()
        },
        autoclose: !0
    }).on("changeDate", function (e) {
        if (e.date.valueOf() > checkOut.datepicker("getDate").valueOf() || !checkOut.datepicker("getDate").valueOf()) {
            let t = new Date(e.date);
            t.setDate(t.getDate() + 1);
            t.setDate(t.getDate() + 1);
            checkOut.datepicker("update", t)
        }
        $("#checkOut")[0].focus()
    });
    let checkOut = $(checkOutElem).datepicker({
        beforeShowDay: function (e) {
            return checkIn.datepicker("getDate").valueOf() ? e.valueOf() > checkIn.datepicker("getDate").valueOf() : e.valueOf() >= (new Date).valueOf()
        },
        autoclose: !0
    }).on("changeDate", function (e) {
    });

    checkIn = $(checkInElem).datepicker({
        todayHighlight: true,
        dateFormat: 'yy-mm-dd',
        changeMonth: false,
        minDate: dateToday,
        onSelect: function (selectedDate) {
            if ($(checkOutElem).length > 0) {
                window.setTimeout($.proxy(function () {
                    if (selectedDate.valueOf() > checkOut.val() || !checkOut.val()) {
                        $(checkInElem).datepicker("hide");
                        let valueArray = selectedDate.split('-');
                        valueArray[2] = +valueArray[2] + 1;
                        $(checkOutElem).val(valueArray.join('-'));
                    }
                    let finalDate = new Date(selectedDate.valueOf());
                    finalDate.setDate(finalDate.getDate() + 1);
                    $(checkOutElem).focus();
                    $(checkOutElem).datepicker("show");
                    $(checkOutElem).datepicker("option", "minDate", finalDate);
                }, this), 1);
            }
        }
    });

    checkOut = $(checkOutElem).datepicker({
        dateFormat: 'yy-mm-dd',
        todayHighlight: true,
        changeMonth: false,
        minDate: '+1d',
        onSelect: function (selectedDate) {
            if ($(checkInElem).length > 0) {
                if (selectedDate.valueOf() < checkIn.val() || !checkIn.val()) {
                    $(checkOutElem).datepicker("hide");
                    let valueArray = selectedDate.split('-');
                    valueArray[2] = +valueArray[2] - 1;
                    $(checkInElem).val(valueArray.join('-'));
                }
            }
        }
    });

    $(".inc-button").on("click", function () {
        let inputDisplay = $(this).parent().find("input");

        if ($(this).text() === "+") {
            inputDisplay.val(parseFloat(inputDisplay.val()) + 1);
        } else if (inputDisplay.val() > 0) {
            inputDisplay.val(parseFloat(inputDisplay.val()) - 1);
        }
    });
});