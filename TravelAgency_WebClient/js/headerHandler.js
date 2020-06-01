$(document).ready(function () {
    "use strict";

    let header = $('header');
    let hamb = $('.hamburger');
    let menuContainer = $('.menu-container');
    let hambActive = false;
    let menuActive = false;

    setHeader();

    $(window).on('resize', function () {
        setHeader();
    });

    $(document).on('scroll', function () {
        setHeader();
    });

    initHamburger();

    createUserAccessPanel();

    function setHeader() {
        if ($(window).scrollTop() > 100) {
            header.addClass('scrolled');
        } else {
            header.removeClass('scrolled');
        }
    }

    function initHamburger() {
        if (hamb.length) {
            hamb.on('click', function (event) {
                event.stopPropagation();
                if (!menuActive) {
                    openMenu();
                    $(document).one('click', function cls(e) {
                        if ($(e.target).hasClass('menu-mm')) {
                            $(document).one('click', cls);
                        } else {
                            closeMenu();
                        }
                    });
                } else {
                    closeMenu();
                }
            });
        }
    }

    function openMenu() {
        menuContainer.addClass('active');
        hambActive = true;
        menuActive = true;
    }

    function closeMenu() {
        menuContainer.removeClass('active');
        hambActive = false;
        menuActive = false;
    }

    function createUserAccessPanel() {
        let item1 = renderUserAccessPanelItem(localStorage.getItem("jwt") !== null ? 'profile' : 'login');

        let item2 = renderUserAccessPanelItem('cart');

        generateContainer('<div>', 'user-access d-flex').append(item1).append(item2).prependTo($('.col-md-8')[0]);
    }

    function renderUserAccessPanelItem(type) {
        let item = generateUserAccessPanelItem("fa fa-user", "login.html", " Log in", "user-login ml-auto");

        if (type === 'profile') {
            item = generateUserAccessPanelItem("fa fa-user", "profile.html", " Profile", "user-profile ml-auto");
        } else if (type === 'cart') {
            item = generateUserAccessPanelItem("fa fa-shopping-cart", "cart.html", " Cart", "user-cart");
        } else if (type !== 'login') {
            return;
        }

        return generateContainer('<div>', item.divClass)
            .append(
                generateLink(item.link)
                    .append(
                        generateContainer('<span>', item.iconClass)
                    )
                    .append(item.linkText)
            );
    }

    function generateUserAccessPanelItem(iconClass, link, linkText, divClass) {
        return {
            "iconClass": iconClass,
            "link": link,
            "linkText": linkText,
            "divClass": divClass
        };
    }
});