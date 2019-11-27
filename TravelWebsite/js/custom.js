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
});