$(window).on('load', (function () {
    "use strict";

    initIsotope();

    function initIsotope() {
        let sortingButtons = $('.sorting-item');
        let contentContainer = $('.offers-content');
        let boxView = $('.box-view');
        let detailedView = $('.detailed-view');

        if (contentContainer.length) {
            let grid = contentContainer.isotope({
                itemSelector: '.offers-item',
                getSortData: {
                    priceAsc: getPrice,
                    priceDesc: getPrice,
                    nameAsc: '.item-title',
                    nameDesc: '.item-title',
                    starsAsc: getStars,
                    starsDesc: getStars
                },
                sortAscending: {
                    priceAsc: true,
                    priceDesc: false,
                    starsAsc: true,
                    starsDesc: false,
                    nameAsc: true,
                    nameDesc: false
                },
                animationOptions: {
                    duration: 750,
                    easing: 'linear',
                    queue: false
                }
            });

            sortingButtons.each(function () {
                $(this).on('click', function () {
                    $(this).parent().parent().find('.sorting-description').text($(this).text());
                    grid.isotope(JSON.parse($(this).attr('data-isotope-option')));
                });
            });

            $('.filter-item').on('click', function () {
                $(this).parent().parent().find('.sorting-description').text($(this).text());
                grid.isotope({filter: $(this).attr('data-filter')});
            });

            if (boxView.length) {
                boxView.on('click', function () {
                    if (window.innerWidth > 767) {
                        $('.offers-item').addClass('box');
                        let option = JSON.parse('{ "sortBy": "original-order" }');
                        grid.isotope(option);
                        setTimeout(function () {
                            grid.isotope(option);
                        }, 500);
                    }
                });
            }

            if (detailedView.length) {
                detailedView.on('click', function () {
                    if (window.innerWidth > 767) {
                        $('.offers-item').removeClass('box');
                        let option = JSON.parse('{ "sortBy": "original-order" }');
                        grid.isotope(option);
                        setTimeout(function () {
                            grid.isotope(option);
                        }, 500);
                    }
                });
            }
        }
    }

    function getPrice(itemElement) {
        return parseFloat($(itemElement).find('.item-price').text().replace('From $', ''));
    }

    function getStars(itemElement) {
        return $(itemElement).find('.rating').attr("data-rating");
    }
}));