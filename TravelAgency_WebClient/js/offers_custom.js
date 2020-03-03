$(document).ready(function () {
    "use strict";

    initIsotope();

    function initIsotope() {
        var sortingButtons = $('.sorting-item');

        if ($('.offers-content').length) {
            var grid = $('.offers-content').isotope({
                itemSelector: '.offers-item',
                getSortData: {
                    priceAsc: function (itemElement) {
                        var priceEle = $(itemElement).find('.item-price').text().replace('From $', '');
                        return parseFloat(priceEle);
                    },
                    priceDesc: function (itemElement) {
                        var priceEle = $(itemElement).find('.item-price').text().replace('From $', '');
                        return parseFloat(priceEle);
                    },
                    nameAsc: '.item-title',
                    nameDesc: '.item-title',
                    starsAsc: function (itemElement) {
                        var starsEle = $(itemElement).find('.rating');
                        var stars = starsEle.attr("data-rating");
                        return stars;
                    },
                    starsDesc: function (itemElement) {
                        var starsEle = $(itemElement).find('.rating');
                        var stars = starsEle.attr("data-rating");
                        return stars;
                    }
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
                    var parent = $(this).parent().parent().find('.sorting-description');
                    parent.text($(this).text());
                    var option = $(this).attr('data-isotope-option');
                    option = JSON.parse(option);
                    grid.isotope(option);
                });
            });

            $('.filter-item').on('click', function () {
                var parent = $(this).parent().parent().find('.sorting-description');
                parent.text($(this).text());
                var filterValue = $(this).attr('data-filter');
                grid.isotope({filter: filterValue});
            });

            if ($('.box-view').length) {
                var box = $('.box-view');
                box.on('click', function () {
                    if (window.innerWidth > 767) {
                        $('.offers-item').addClass('box');
                        var option = '{ "sortBy": "original-order" }';
                        option = JSON.parse(option);
                        grid.isotope(option);
                        setTimeout(function () {
                            grid.isotope(option);
                        }, 500);
                    }
                });
            }

            if ($('.detailed-view').length) {
                var detail = $('.detailed-view');
                detail.on('click', function () {
                    if (window.innerWidth > 767) {
                        $('.offers-item').removeClass('box');
                        var option = '{ "sortBy": "original-order" }';
                        option = JSON.parse(option);
                        grid.isotope(option);
                        setTimeout(function () {
                            grid.isotope(option);
                        }, 500);
                    }
                });
            }
        }
    }
});