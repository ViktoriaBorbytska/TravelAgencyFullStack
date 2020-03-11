$(document).ready(function () {

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

    let offerId = params['offerId'];

    fetch(`${config.apiDomain}/api/offers/getdetails/${offerId}`)
        .then(response => response.json())
        .then((res) => {
            generateDetails(res);
        });

    function generateDetails(response) {
        generateContainer('<div>', 'row')
            .append(
                generateContainer('<div>', 'col-lg-6 item-image')
                    .append(
                        generateImg(response['imageLink'], response['destination'])
                    ))
            .append(
                generateContainer('<div>', 'col-lg-6 item-content')
                    .append(
                        generateContainer('<div>', 'item-title', response['destination'])
                    )
                    .append(
                        generateContainer('<div>', 'item-price', 'From $' + response['price'])
                    )
                    .append(
                        generateContainer('<div>', 'rating rating_' + response['mark']).attr('data-rating', response['mark'])
                    )
                    .append(
                        $('<ul>', {'class': 'item-meta'})
                            .append($('<li>', {'text': '1 person'}))
                            .append($('<li>', {'text': '4 nights'}))
                            .append($('<li>', {'text': '3 star hotel'}))
                    )
                    .append(
                        generateContainer('<div>', 'item-hotel', 'Hotel: ')
                            .append(
                                generateLink(response['hotelLink'], response['hotelName'])
                            )
                    )
                    .append(
                        generateContainer('<div>', 'item-text', response['detailedDescription'])
                    )
                    .append(
                        generateContainer('<div>', 'inclusion-list')
                            .append('<h3>', {'text': 'Inclusions:'})
                            .append('<ul>')
                    )
                    .append(
                        $('<form>', {'class': 'resident-to-cart'})
                            .append($('<h3>', {'text': '- Booking -', 'class': 'inner'}))
                            .append(
                                generateContainer('<div>', 'row')
                                    .append(
                                        generateCalendarPicker(' Check in')
                                    )
                                    .append(
                                        generateCalendarPicker(' Check out')
                                    )
                            )
                            .append(
                                generateContainer('<div>', 'row')
                                    .append(
                                        generateIncDecGroup('Adults')
                                    )
                                    .append(
                                        generateIncDecGroup('Children')
                                    )
                            )
                            .append(
                                generateContainer('<div>', 'resident-price')
                                    .append($('<h3>', {'text': 'Trip price:'}))
                                    .append(
                                        generateContainer('<span>', '', '$600'))
                            )
                    )
                    .append(
                        generateContainer('<div>', 'slider-button item-add-button')
                            .append(
                                generateLink('#', 'Want it!')
                            )
                    )
            )
            .appendTo($('.details > .container')[0]);

        for (let i = 0; i < 5; i++) {
            $('div.rating').append(generateContainer('<span>', 'fa fa-star'));
        }

        let inclusions = response['inclusions'].split('|');

        for (let i = 0; i < inclusions.length; i++) {
            $('div.inclusion-list > ul').append($('<li>', {'text': inclusions[i]}));
        }
    }

    function generateCalendarPicker(labelText) {
        let id = 'checkIn';

        if (labelText === ' Check out') {
            id = 'checkOut';
        }

        return generateContainer('<div>', 'col-md-6 col-sm-6')
            .append(
                generateContainer('<div>', 'form-group')
                    .append(
                        $('<label>')
                            .append(
                                generateContainer('<span>', 'fa fa-calendar')
                            )
                            .append(labelText)
                    )
                    .append(
                        $('<input>', {
                            'type': 'text',
                            'id': id,
                            'class': 'form-control',
                            'data-date-format': 'yyyy-mm-dd',
                            'placeholder': labelText
                        })
                    )
            );
    }

    function generateIncDecGroup(labelText) {
        let id = labelText.toLowerCase();

        return generateContainer('<div>', 'col-md-6 col-sm-6')
            .append(
                generateContainer('<div>', 'form-group')
                    .append(
                        $('<label>', {'text': labelText})
                    )
                    .append(
                        generateContainer('<div>', 'numbers-row')
                            .append(
                                $('<input>', {
                                    'type': 'text',
                                    'id': id,
                                    'class': 'form-control display-button',
                                    'value': '1'
                                })
                            )
                            .append(
                                generateContainer('<div>', 'inc inc-button', '+')
                            )
                            .append(
                                generateContainer('<div>', 'dec inc-button', '-')
                            )
                    )
            );
    }
});