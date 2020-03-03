$(document).ready(function () {
    "use strict";

    var header = $('header');
    var hamb = $('.hamburger');
    var hambActive = false;
    var menuActive = false;

    setHeader();

    $(window).on('resize', function () {
        setHeader();
    });

    $(document).on('scroll', function () {
        setHeader();
    });

    initHamburger();

    createUpperItems();

    function setHeader() {
        if (window.innerWidth < 992) {
            if ($(window).scrollTop() > 100) {
                header.addClass('scrolled');
            } else {
                header.removeClass('scrolled');
            }
        } else {
            if ($(window).scrollTop() > 100) {
                header.addClass('scrolled');
            } else {
                header.removeClass('scrolled');
            }
        }
    }

    function initHamburger() {
        if ($('.hamburger').length) {
            hamb.on('click', function (event) {
                event.stopPropagation();
                if (!menuActive) {
                    openMenu();
                    $(document).one('click', function cls(e) {
                        if ($(e.target).hasClass('menu_mm')) {
                            $(document).one('click', cls);
                        } else {
                            closeMenu();
                        }
                    });
                } else {
                    $('.menu-container').removeClass('active');
                    menuActive = false;
                }
            });
        }
    }

    function openMenu() {
        var fs = $('.menu-container');
        fs.addClass('active');
        hambActive = true;
        menuActive = true;
    }

    function closeMenu() {
        var fs = $('.menu-container');
        fs.removeClass('active');
        hambActive = false;
        menuActive = false;
    }

    function createUpperItems() {

        var item1 = renderUpperItem(localStorage.getItem("jwt") !== null ? 'profile' : 'login');
        
        var item2 = renderUpperItem('cart');

        renderItems(item1, item2);
    }

    function renderUpperItem(type) {
        let item = {
            "iconClass": "fa fa-user",
            "link": "login.html",
            "linkText": " Log in",
            "divClass": "user-login ml-auto"
        };

        if (type === 'profile') {
            item.link = "profile.html";
            item.linkText = " Profile";
            item.divClass = "user-profile ml-auto";
        } else if (type === 'cart') {
            item.iconClass = "fa fa-shopping-cart";
            item.link = "cart.html";
            item.linkText = " Cart";
            item.divClass = "user-cart";
        } else if (type !== 'login') {
            return;
        }

        let icon = $('<span>', {
            'class': item.iconClass
        });

        let link = $('<a>', {
            'href': item.link
        }).append(icon);

        link.append(item.linkText);

        let div =  $('<div>', {
            'class': item.divClass
        }).append(link);

        return div;
    }

    function renderItems(item1, item2) {
        var div = $('<div>', {
            'class': 'user-access d-flex'
        }).append(item1).append(item2);

        div.prependTo($('.col-md-8')[0]);
    }
});

// <!-- <div class="login ml-auto">
// <a href="login.html">
//     <span class="fa fa-user"></span> Log in
// </a>
// </div>
// <div class="user-profile ml-auto">
// <a href="profile.html">
//     <span class="fa fa-user"></span> Profile
// </a>
// </div>
// <div class="cart">
// <a href="cart.html">
//     <span class="fa fa-shopping-cart"></span> Cart
// </a>
// </div>
// </div>