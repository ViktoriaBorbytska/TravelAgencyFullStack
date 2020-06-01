$(document).ready(function () {

    if (localStorage.getItem("jwt") === null) {
        generateEmptyCartSign();
    } else {
        fetch(config.apiDomain + `/api/booking/of-client/${localStorage.getItem("jwt")}`, {
            method: "get",
        })
            .then(res => res.json())
            .then(res => {
                let booked = [];
                let notBooked = [];

                if (res.length === 0) {
                    generateEmptyCartSign();
                    generatePolicyInfo();
                } else {
                    res.forEach(card => {
                    if (card.isBooked) {
                        booked.push(card);
                    } else {
                        notBooked.push(card);
                    }});

                    notBooked.forEach(card => {
                        generateCartCard(false, card.id, card);
                    });

                    booked.forEach(card => {
                        generateCartCard(true, card.id, card);
                    });
                    generatePolicyInfo();
                }
            });
    }

    $('body').on('click', '.book-order', function(event) {
        console.log(event.currentTarget.id);
        let dto = {
            token: localStorage.getItem("jwt"),
            orderId: event.currentTarget.id.replace(/\D+/g,"")
        }

        fetch(config.apiDomain + `/api/booking/book`, {
            method: "post",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(dto)
        })
            .then(res => res.json())
            .then(res => {
                if (res.isSuccessful) {
                    window.location.href = "cart.html";
                }
            });
    });

    function generateEmptyCartSign() {
        $('<h3>', {'text': 'Wow! Looks like you haven\'t chosen anything yet... Check out '})
            .append(
                generateLink('offers.html', 'our offers')
            )
            .append(' to find the right one!')
            .appendTo('.cart-content');
    }

    function formatDate(dateStr) {
        let date = new Date(dateStr);

        var month = new Array();
        month[0] = "January";
        month[1] = "February";
        month[2] = "March";
        month[3] = "April";
        month[4] = "May";
        month[5] = "June";
        month[6] = "July";
        month[7] = "August";
        month[8] = "September";
        month[9] = "October";
        month[10] = "November";
        month[11] = "December";

        return date.getDate() + ' ' 
        + month[date.getMonth()] + ' ' 
        + date.getFullYear()
    }

    function generateCartCard(isBooked, id, card) {
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
                        .append($('<tr>', {'id': "addedrow"+id})
                            .append($('<td>', {'class': 'residence-holder'})
                                .append(
                                    generateLink('details.html', 'Paris, France', 'residence-name')
                                )
                                .append(
                                    generateLink('https://www.hotel-la-nouvelle-republique.paris/en/', 'Hôtel La Nouvelle République', 'residence-hotel')
                                )
                            )
                            .append($('<td>', {'text': card.adultCount}))
                            .append($('<td>', {'text': card.childrenCount}))
                            .append($('<td>', {'text': formatDate(card.checkIn)}))
                            .append($('<td>', {'text': formatDate(card.checkOut)}))
                            .append($('<td>', {'text': card.price}))
                        )
                    )
            )
            .append(
                generateContainer('<div>', 'card-note', "", "addedcard-note"+id)
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
                .appendTo($('tbody tr#addedrow'+id));
            generateContainer('<span>', 'unbooked-card', 'This order is not booked yet. ')
                .append(
                    generateLink('#', 'Book it now!', 'book-order', "book-order"+id)
                )
                .appendTo($('.card-note#addedcard-note'+id));
        } else {
            $('<td>', {'class': 'card-option'})
                .append(
                    generateLink('contacts.html', '', 'contact')
                        .append(
                            generateContainer('<span>', 'fa fa-envelope')
                        )
                        .append(' Contact manager')
                )
                .appendTo($('tbody tr#addedrow'+id));
            generateContainer('<span>', 'booked-card', 'This order is already booked.')
                .appendTo($('.card-note#addedcard-note'+id));
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