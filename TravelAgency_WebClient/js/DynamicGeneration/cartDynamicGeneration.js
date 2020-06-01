$(document).ready(function () {

    generateEmptyCartSign();
    generateCartCard(false, 1);
    generateCartCard(true, 2);
    generatePolicyInfo();

    function generateEmptyCartSign() {
        $('<h3>', {'text': 'Wow! Looks like you haven\'t chosen anything yet... Check out '})
            .append(
                generateLink('offers.html', 'our offers')
            )
            .append(' to find the right one!')
            .appendTo('.cart-content');
    }

    function generateCartCard(isBooked, id) {
        generateContainer('<div>', 'card-holder')
            .append(
                $('<table>', {'class': 'cart-card'})
                    .append($('<thead>')
                        .append($('<tr>')
                            .append($('<th>', {'text': 'Residence'}))
                            .append($('<th>', {'text': 'Adults'}))
                            .append($('<th>', {'text': 'Children'}))
                            .append($('<th>', {'text': 'Checkin Date'}))
                            .append($('<th>', {'text': 'Checkout Date'}))
                            .append($('<th>', {'text': 'Price'}))
                            .append($('<th>', {'text': 'Options'}))
                        )
                    )
                    .append($('<tbody>')
                        .append($('<tr>')
                            .append($('<td>', {'class': 'residence-holder'})
                                .append(
                                    generateLink('details.html', 'Paris, France', 'residence-name')
                                )
                                .append(
                                    generateLink('https://www.hotel-la-nouvelle-republique.paris/en/', 'Hôtel La Nouvelle République', 'residence-hotel')
                                )
                            )
                            .append($('<td>', {'text': '2'}))
                            .append($('<td>', {'text': '0'}))
                            .append($('<td>', {'text': '17 January 2020'}))
                            .append($('<td>', {'text': '18 January 2020'}))
                            .append($('<td>', {'text': '$1200'}))
                        )
                    )
            )
            .append(
                generateContainer('<div>', 'card-note')
            )
            .appendTo('.cart-content');

        if (isBooked === false) {
            $('<td>', {'class': 'card-option'})
                .append(
                    generateLink('#', '', 'remove-order')
                        .append(
                            generateContainer('<span>', 'fa fa-trash')
                        )
                        .append(' Remove order')
                )
                .appendTo($('tbody tr')[id-1]);
            generateContainer('<span>', 'unbooked-card', 'This order is not booked yet. ')
                .append(
                    generateLink('#', 'Book it now!', 'book-order')
                )
                .appendTo($('.card-note')[id-1]);
        } else {
            $('<td>', {'class': 'card-option'})
                .append(
                    generateLink('contacts.html', '', 'contact')
                        .append(
                            generateContainer('<span>', 'fa fa-envelope')
                        )
                        .append(' Contact manager')
                )
                .appendTo($('tbody tr')[id-1]);
            generateContainer('<span>', 'booked-card', 'This order is already booked.')
                .appendTo($('.card-note')[id-1]);
        }
    }

    function generatePolicyInfo() {
        generateContainer('<div>', 'policy-info')
            .append($('<h4>', {'text': 'Cancellation '})
                .append(
                    generateContainer('<span>', '', 'policy')
                )
            )
            .append($('<p>'), {'text': 'In the event of cancellation of tour / travel services due to any avoidable / unavoidable reason/s we must be notified of the same in writing. Cancellation charges will be effective from the date we receive advice in writing, and cancellation charges would be as follows:'})
            .append($('<ul>')
                .append($('<li>', {'text': '60 days prior to arrival: 10% of the Tour / service cost'}))
                .append($('<li>', {'text': '45 days prior to arrival: 20% of the Tour / service cost'}))
                .append($('<li>', {'text': '15 days prior to arrival: 25% of the Tour / service cost'}))
                .append($('<li>', {'text': '07 days prior to arrival: 50% of the Tour / service cost'}))
            )
            .append($('<p>', {'text': 'Less than 72 hours or no show: no refund. In case of Special Trains Journeys and peak season hotel bookings a separate cancellation policy is applicable (which can be advised as and when required).'}))
            .appendTo('.cart-content');
    }
});