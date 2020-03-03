{/* 
<div class="row">
    <div class="col-lg-6 item-image">
        <img class="top-image" src="images/top-1.png" alt="Paris">
    </div>
    
    <div class="col-lg-6 item-content">
        <div class="item-title">Paris, France</div>
        <div class="item-price">From $600</div>
        <div class="rating rating_4" data-rating="4">
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
        </div>
        <ul class="item-meta">
            <li>1 person</li>
            <li>4 nights</li>
            <li>3 star hotel</li>
        </ul>
        <div class="item-hotel">Hotel:
            <a href="https://www.hotel-la-nouvelle-republique.paris/en/">Hôtel La Nouvelle République</a>
        </div>
        <div class="item-text">
            Your evening tour begins at a meeting point in the heart of Paris. Climb aboard the
            air-conditioned coach head to either the Eiffel Tower or a Seine riverboat, according to your
            preference.
            If the former, enjoy a gourmet meal with wine, beer, or soft drinks in a heated bubble-dome on
            the Eiffel Tower’s terrace. It offers guests unbeatable views of the City of Lights. After
            dinner, head to the Seine for a riverboat tour and to admire landmarks as they pass by.
            If you’ve chosen the second option, tuck into a gourmet 3-course meal aboard the riverboat and
            sightsee. After your meal, visit the Eiffel Tower’s second-floor observation deck with its
            panoramic views.
            Then travel by coach to your third destination: the Moulin Rouge, a landmark cabaret bar founded
            in the 19th century. See dozens of dancers, acrobats, and performers take to the stage as you
            toast with Champagne.
            Following the performance, the coach returns you to central Paris, where the tour ends.
            Note: If the late evening Moulin Rouge performance is fully booked, you see an earlier showing
            and receive vouchers to the Eiffel Tower or Seine river cruise.
        </div>
        <div class="inclusion-list">
            <h3>Inclusions:</h3>
            <ul>
                <li>Luxury air-conditioned coach transport</li>
                <li>Découverte’ dinner cruise on the Seine (first service of the Marina restaurant) with
                    drinks (if option selected)
                </li>
                <li>Féerie show at the Moulin Rouge with 1/2 bottle (or 1 glass) of champagne depending on
                    option selected( if option selected)
                </li>
                <li>French Style Gourmet Meal in heated Dome on 1st Floor Eiffel Tower's Terrace( if option
                    selected)
                </li>
                <li>One-hour Seine cruise by glass-enclosed boat with recorded commentary and personal
                    headphones to listen in the language of your choice (French, English, Spanish, Italian,
                    German, Portuguese, Russian, Polish, Dutch, Hindi, Arabic, Chinese, Japanese and Korean)
                </li>
                <li>Multilingual hostess at your service</li>
                <li>Entry/Admission - Eiffel Tower</li>
                <li>Entry/Admission - Seine River</li>
                <li>Entry/Admission - Moulin Rouge</li>
                <li>Guaranteed to skip the lines</li>
            </ul>
        </div>
        <div class="item-add-button"><a href="#">Want it!</a></div>
    </div>

</div> */}

$(document).ready(function(){

    var params = window
    .location
    .search
    .replace('?','')
    .split('&')
    .reduce(
        function(p,e){
            var a = e.split('=');
            p[ decodeURIComponent(a[0])] = decodeURIComponent(a[1]);
            return p;
        },
        {}
    );

    var offerId = params['offerId'];

    fetch(`${config.apiDomain}/api/offers/getdetails/${offerId}`)
        .then(response => response.json())
        .then((res) => {
            generateDetatils(res);
        });

    function generateDetatils(responce) {
        var img = $('<img>', {
            'class': 'top-image',
            'src': responce['imageLink'],
            'alt': responce['destination']
        });

        var divItemImage = $('<div>', {
            'class': 'col-lg-6 item-image'
        }).append(img);

        var divItemTitle = $('<div>', {
            'class': 'item-title',
            'text': responce['destination']
        });

        var divItemPrice = $('<div>', {
            'class': 'item-price',
            'text': 'From $' + responce['price']
        });

        var divRating = $('<div>', {
            'class': 'rating rating_4',
            'data-rating': responce['mark']
        });
        
        for (var i = 0; i < 5; i++) {
            divRating.append('<span class="fa fa-star"></span>');
        }
        
        var ulItemMeta = $('<ul>', {
            'class': 'item-meta'
        }).append($('<li>', {
            'text': '1 person'
        })).append($('<li>', {
            'text': '4 nights'
        })).append($('<li>', {
            'text': '3 star hotel'
        }));

        var divItemHotel = $('<div>', {
            'class': 'item-hotel',
            'text': 'Hotel: '
        }).append($('<a>', {
            'href': responce['hotelLink'],
            'text': responce['hotelName']
        }));

        var divItemText = $('<div>', {
            'class': 'item-text',
            'text': responce['detailedDescription']
        });

        var ul = $('<ul>');

        var inclusions = responce['inclusions'].split('|');
        
        for (var i = 0; i < inclusions.length; i++) {
            ul.append($('<li>', {
                'text': inclusions[i]
            }));
        }

        var divInclusionsList = $('<div>', {
            'class': 'inclusion-list'
        }).append('<h3>', {
            'text': 'Inclusions:'
        }).append(ul);

        var divItemAddButton = $('<div>', {
            'class': 'item-add-button'
        }).append($('<a>', {
            'href': '#',
            'text': 'Want it!'
        }));

        var divItemContent = $('<div>', {
            'class': 'col-lg-6 item-content'  
        })
        .append(divItemTitle)
        .append(divItemPrice)
        .append(divRating)
        .append(ulItemMeta)
        .append(divItemHotel)
        .append(divItemText)
        .append(divInclusionsList)
        .append(divItemAddButton);

        var divRow = $('<div>', {
            'class': 'row'
        }).append(divItemImage)
        .append(divItemContent);

        divRow.appendTo($('.details>.container')[0]);
    }
});