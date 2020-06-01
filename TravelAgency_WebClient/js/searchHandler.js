$(document).ready(function () {
    "use strict";

    $('.search-button').click(submitSearch);

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

    delete(params[""]);

    if (location.pathname.match(/[^/]*$/)[0] === "offers.html" &&
        JSON.stringify(params) !== "{}" &&
        validateGetRequest(params)) {

        sendSearchRequest(params);
    }
    else if (location.pathname.match(/[^/]*$/)[0] === "offers.html") {
        generateContent();
    }
});

var state = {};

function formDataToState(formData) {
    formData.forEach(data => {
        state[data.name] = data.value;
    });

}

function validateGetRequest(dataObject) {
    return dataObject.hasOwnProperty("offerDestination") &&
           dataObject.hasOwnProperty("priceFrom") &&
           dataObject.hasOwnProperty("priceTo");
}

function submitSearch(event) {
    event.preventDefault();

    var formData = $('.search-form').serializeArray();
    formDataToState(formData);

    window.location.href = `offers.html?offerDestination=${state.offerDestination}&priceFrom=${state.priceFrom}&priceTo=${state.priceTo}`;
}

function sendSearchRequest(dataObject) {
    let dto = {
        offerDestination: dataObject.offerDestination,
        priceFrom: dataObject.priceFrom,
        priceTo: dataObject.priceTo,
        page: 1
    };


    fetch(config.apiDomain + "/api/offers/search", {
        method: "put",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(res => res.json())
        .then(res => {
            generateContent(res);
        });
}