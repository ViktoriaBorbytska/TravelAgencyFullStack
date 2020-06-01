
    function generateContent(searchResult) {

        if (searchResult === undefined) {

            fetch(`${config.apiDomain}/api/offers/getall`)
                .then(response => response.json())
                .then((res) => {
                    for (let i = 0; i < 4; i++) {
                        generateOfferCard(res[i]);
                    }
                });
        }
        else {
            for (let i = 0; i < searchResult.length; i++) {
                generateOfferCard(searchResult[i]);
            }
        }
    }

    function generateOfferCard(response) {
        generateContainer('<div>', 'offers-item clearfix rating_' + response['mark'])
            .append(
                generateContainer('<div>', 'item-image')
                    .append(
                        generateImg(response['imageLink'], response['destination'], 'top-image')
                    )
            )
            .append(
                generateContainer('<div>', 'item-content')
                    .append(
                        generateContainer('<div>', 'item-price', 'From $' + response['price'])
                    )
                    .append(
                        generateContainer('<div>', 'item-title', response['destination'])
                    )
                    .append(
                        $('<ul>')
                            .append($('<li>', {'text': '1 person'}))
                            .append($('<li>', {'text': '4 nights'}))
                            .append($('<li>', {'text': '3 star hotel'}))
                    )
                    .append(
                        generateContainer('<div>', 'rating').attr('data-rating', response['mark'])
                    )
                    .append(
                        generateContainer('<div>', 'item-text', response['detailedDescription'])
                    )
                    .append(
                        generateContainer('<div>', 'item-more')
                            .append(
                                generateLink(`details.html?offerId=${response['id']}`, 'Read More')
                            )
                            .append('<ul>')
                    )
            )
            .appendTo($('.offers-content')[0]);

        for (let i = 0; i < 5; i++) {
            generateContainer('<span>', 'fa fa-star').appendTo($('div.rating')[response['id']-1]);
        }
    }
