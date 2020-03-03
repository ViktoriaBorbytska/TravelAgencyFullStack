{/* <div class="news-post">
    <div class="post-title">
        <a href="#">The best places to visit in Costa Rica</a>
    </div>
    <div class="post-meta">
        <ul>
            <li><a href="#">by Matt Nomadic</a></li>
            <li>december 20, 2018</li>
            <li><a href="#"></a></li>
        </ul>
    </div>
    <div class="post-image">
        <img src="images/news-post-1.png" alt="User photo">
    </div>
    <div class="post-text">
        <p>Costa Rica is one of the most visited countries in Central America. American
            tourists
            have been flocking to the country for years, and it’s become a hot spot for
            retirees and expats due to its cheap living, great weather, amazing beaches, and
            friendly locals. I love Costa Rica. It was the first place that inspired me to
            travel.
            It holds a special place in my heart. I’ve been back to visit Costa Rica many
            times
            since then, falling in love with it over and over again. But, because it’s not
            as cheap
            to visit as its neighbors, many budget travelers skip over Costa Rica. And,
            while that’s
            true (but there are many ways to save money in Costa Rica), in my opinion, the
            beauty
            of the destinations below is worth the extra price.
        </p>
    </div>
</div> */}

{/* <div class="sidebar-featured">
    <div class="sidebar-featured-post">
        <div class="sidebar-featured-image">
            <img src="images/sidebar-1.png" alt="User photo">
        </div>
        <div class="sidebar-featured-title">
            <a href="#">Top Ten Places to Go for New Year’s Eve</a>
        </div>
        <div class="sidebar-featured-meta">
            <ul>
                <li><a href="#">by Lily Browns</a></li>
                <li>january 5, 2019</li>
                <li><a href="#">13 comments</a></li>
            </ul>
        </div>
    </div> */}
$(document).ready(function(){
    
    fetch(`${config.apiDomain}/api/news/getall`)
        .then(response => response.json())
        .then((res) => {
            for (var i = 0; i < 3; i++) {
                generatePost(res[i]);
            }
        });
    
    function generatePost(responce) {
        var link = $('<a>', {
            'href': `${config.apiDomain}/api/offers/getdetails/${responce['id']}`,
            'text': responce['header']
        });

        var divPostTitle = $('<div>', {
            'class': 'post-title'
        }).append(link);

        var linkLI1 = $('<a>', {
            'href': '#',
            'text': 'by Matt Nomadic'
        });

        var date = new Date(responce['date']);


        var LI2 = $('<li>', {
            'text': date.getMonth() + date.getDay() + ", " + date.getFullYear()
        })

        var linkLI3 = $('<a>', {
            'href': '#',
            'text': '3 comments'
        });

        var ul = $('<ul>').append(linkLI1).append(LI2).append(linkLI3);

        var divPostMeta = $('<div>', {
            'class': 'post-meta'
        }).append(ul);

        var image = $('<img>', {
            'src': responce['imageLink'],
            'alt': 'User photo'
        });

        var divPostImage = $('<div>', {
            'class': 'post-image'
        }).append(image);

        var paragraph = $('<p>', {
            'text': responce['text']
        })

        var divPostText = $('<div>', {
            'class': 'post-text'
        }).append(paragraph);

        var divNewsPost = $('<div>', {
            'class': 'news-post'
        }).append(divPostTitle).append(divPostMeta).append(divPostImage).append(divPostText);

        divNewsPost.appendTo($('.news-posts')[0]);
    }

    function generatePostSide(responce) {
        var image = $('<img>', {
            'src': responce['imageLink'],
            'alt': 'User photo'
        });

        var divSidebarFeaturedImage = $('<div>', {
            'class': 'sidebar-featured-image'
        }).append(image);

        
    }
});