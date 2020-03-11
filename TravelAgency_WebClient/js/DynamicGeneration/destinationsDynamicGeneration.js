$(document).ready(function () {
    fetch(`${config.apiDomain}/api/offers/gettop`)
        .then(response => response.json())
        .then((res) => {
            for (let i = 0; i < 4; i++) {
                generateDestinationCard(res[i], 'top-');
            }
        });

    fetch(`${config.apiDomain}/api/offers/getall`)
        .then(response => response.json())
        .then((res) => {
            for (let i = 0; i < res.length; i++) {
                if (res[i]['mark'] < 5) {
                    generateDestinationCard(res[i], 'popular-');
                }
            }
        });

    function generateDestinationCard(response, prefix) {
        let cardContainer = generateContainer('<div>', prefix + 'item')
            .append(
                generateLink(`details.html?offerId=${response['id']}`)
                    .append(
                        generateContainer('<div>', prefix + 'item-image')
                            .append(
                                generateImg(response['imageLink'], response['destination'])
                            )
                    )
                    .append(
                        generateContainer('<div>', prefix + 'item-content')
                            .append(
                                generateContainer('<div>', prefix + 'item-price', 'From $' + response['price']))
                            .append(
                                generateContainer('<div>', prefix + 'item-destination', response['destination'])
                            )
                    )
            );

        if (prefix === 'top-') {
            cardContainer = generateContainer('<div>', 'col-lg-3 col-md-6').append(cardContainer);
        }

        cardContainer.appendTo($('.' + prefix + 'content')[0]);
    }
});