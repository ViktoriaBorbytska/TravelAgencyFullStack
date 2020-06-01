$(window).on('load', (function () {
    "use strict";

    let globalPriceFlag = true;
    let globalPrice = parseInt($('#trip-price').text().replace(/\D+/g,""));
    let globalCompudedPrice = 0;
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
        $('#trip-price').text('$' + getNewPrice());
    });
    let checkOut = $(checkOutElem).datepicker({
        beforeShowDay: function (e) {
            return checkIn.datepicker("getDate").valueOf() ? e.valueOf() > checkIn.datepicker("getDate").valueOf() : e.valueOf() >= (new Date).valueOf()
        },
        autoclose: !0
    }).on("changeDate", function (e) {
        $('#trip-price').text('$' + getNewPrice());
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

    function getNumberOfDays() {
        let checkoutDateTime = new Date($("#checkOut")[0].value).getTime();
        let checkinDateTime = new Date($("#checkIn")[0].value).getTime();
        return (checkoutDateTime - checkinDateTime)/(1000 * 3600 * 24);
    }

    function getNewPrice(){
        if (globalPriceFlag) {
            globalPrice = parseInt($('#trip-price').text().replace(/\D+/g,""));
            globalPriceFlag = false;
        }

        let adultCount = parseInt($('#adults').val());
        let childrenCount = parseInt($('#children').val());
        let days = getNumberOfDays()
        if (isNaN(days)) {
            days = 1;
        }

        let adultPrice = globalPrice * adultCount * days;
        let childrenPrice = globalPrice * childrenCount * days * 0.7;

        return Math.round(adultPrice + childrenPrice);
    }

    //$("body").on('click', checkInElem, () => {$(checkInElem).datepicker("show");});
    //$("body").on('click', checkOutElem, () => {$(checkOutElem).datepicker("show");});

    $("body").on("click", ".inc-button", function () {
        let inputDisplay = $(this).parent().find("input");

        if ($(this).text() === "+") {
            inputDisplay.val(parseFloat(inputDisplay.val()) + 1);
        } else if (inputDisplay.val() > 0) {
            if (inputDisplay.attr('id') === "adults" && inputDisplay.val() === '1') {
                return;
            }
            inputDisplay.val(parseFloat(inputDisplay.val()) - 1);            
        }
        $('#trip-price').text('$' + getNewPrice());
    });

    $('body').on("click", ".item-add-button", () => {
        addToCart();
    });

    var state = {};

    function addToCart() {
        if (localStorage.getItem("jwt") === null) {
            window.location.href = "login.html";
        }

        var formData = $('.resident-to-cart').serializeArray();
        formDataToState(formData);

        let dto = {
            token: localStorage.getItem("jwt"),
            offerId: getOfferId(),
            childrenCount: state.children,
            adultCount: state.adults,
            price: parseInt($('#trip-price').text().replace(/\D+/g,"")),
            checkIn: state.checkIn,
            checkOut: state.checkOut
        };

        fetch(config.apiDomain + "/api/booking/add", {
            method: "post",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(dto)
        })
            .then(res => res.json())
            .then(res => {
                console.log(res);
                if (res.isSuccessful) {
                    window.location.href = "cart.html";
                }
                // } else {
                //     setStateInfo(res.message);
                // }
            });
    }

    function formDataToState(formData) {
        formData.forEach(data => {
            state[data.name] = data.value;
        });
    }

    function getOfferId() {
        let params = window
        .location
        .search
        .replace('?', '')
        .split('&')
        .reduce(
            function (p, e) {
                let a = e.split('=');
                p[decodeURIComponent(a[0])] = decodeURIComponent(a[1]);
                return p;
            },
            {}
        );

        return params['offerId'];
    }
}));