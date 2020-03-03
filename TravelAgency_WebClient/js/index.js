
{/* <div class="col-lg-3 col-md-6">
    <div class="top-item">
        <a href="#">
            <div class="top-item-image">
                <img src="images/top-1.png" alt="Paris">
            </div>
            <div class="top-item-content">
                <div class="top-item-price">From $600</div>
                <div class="top-item-destination">Paris, France</div>
            </div>
        </a>
    </div>
</div> */}

{/* <div class="popular-item">
    <a href="offers.html">
        <div class="popular-item-image">
            <img src="images/popular-1.png" alt="Paris">
        </div>
        <div class="popular-item-content">
            <div class="popular-item-price">From $600</div>
            <div class="popular-item-destination">Paris</div>
        </div>
    </a>
</div> */}

var topDestinations = [
    {'price': 600, 'destination': 'Paris, France', 'imageLink': 'images/top-1.png', 'id':1},
    {'price': 500, 'destination': 'Rome, Italy', 'imageLink': 'images/top-2.png', 'id':2},
    {'price': 800, 'destination': 'London, UK', 'imageLink': 'images/top-3.png', 'id':3},
    {'price': 300, 'destination': 'Florence, Italy', 'imageLink': 'images/top-4.png', 'id':4}
]

$(document).ready(function(){
    fetch(`${config.apiDomain}/api/offers/gettop`)
        .then(response => response.json())
        .then((res) => {
            for(var i = 0; i < 4; i++) {
                generateTop(i, res);
            }
        });

    fetch(`${config.apiDomain}/api/offers/getall`)
        .then(response => response.json())
        .then((res) => {
            for(var i = 0; i < res.length; i++) {
                if (res[i]['mark'] < 5) {
                    generateAll(res[i]);
                }
            }
        });

    function generateTop(i, tops) {
        var imageElement = $('<img>', {
            'src': tops[i]['imageLink'],
            'alt': tops[i]['destination']
        });
    
        var divTopItemImage = $('<div>', {
            'class': 'top-item-image'
        }).append(imageElement);
    
        var divTopItemPrice = $('<div>', {
            'class': 'top-item-price',
            'text': 'From $' + tops[i]['price']
        });
    
        var divTopItemDestination = $('<div>', {
            'class': 'top-item-destination',
            'text': tops[i]['destination']
        });
    
        var divTopItemContent = $('<div>', {
            'class': 'top-item-content'
        }).append(divTopItemPrice).append(divTopItemDestination);
    
        var link = $('<a>', {
            'href': `details.html?offerId=${tops[i]['id']}`
        }).append(divTopItemImage).append(divTopItemContent);
    
        var divTopItem = $('<div>', {
            'class': 'top-item'
        }).append(link);
    
        var divCollg3 = $('<div>', {
            'class': 'col-lg-3 col-md-6'
        }).append(divTopItem);
    
        divCollg3.appendTo($('.top-content')[0]);
    }

    function generateAll(responce){
        var imageElement = $('<img>', {
            'src': responce['imageLink'],
            'alt': responce['destination']
        });
    
        var divPopularItemImage = $('<div>', {
            'class': 'popular-item-image'
        }).append(imageElement);
    
        var divPopularItemPrice = $('<div>', {
            'class': 'popular-item-price',
            'text': 'From $' + responce['price']
        });
    
        var divPopularItemDestination = $('<div>', {
            'class': 'popular-item-destination',
            'text': responce['destination']
        });
    
        var divPopularItemContent = $('<div>', {
            'class': 'popular-item-content'
        }).append(divPopularItemPrice).append(divPopularItemDestination);
    
        var link = $('<a>', {
            'href': `details.html?offerId=${responce['id']}`//`${config.apiDomain}/api/offers/getdetails/${responce['id']}`
        }).append(divPopularItemImage).append(divPopularItemContent);
    
        var divTopItem = $('<div>', {
            'class': 'popular-item'
        }).append(link);

        divTopItem.appendTo($('.popular-content')[0]);
    }
});