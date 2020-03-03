$(document).ready(function () {
    "use strict";

    var ctrl = new ScrollMagic.Controller();

    initMilestones();

    function initMilestones() {
        if ($('.milestone-counter').length) {
            var milestoneItems = $('.milestone-counter');

            milestoneItems.each(function (i) {
                var ele = $(this);
                var endValue = ele.data('end-value');
                var eleValue = ele.text();

                var signBefore = "";
                var signAfter = "";

                if (ele.attr('data-sign-before')) {
                    signBefore = ele.attr('data-sign-before');
                }

                if (ele.attr('data-sign-after')) {
                    signAfter = ele.attr('data-sign-after');
                }

                var milestoneScene = new ScrollMagic.Scene({
                    triggerElement: this,
                    triggerHook: 'onEnter',
                    reverse: false
                })
                    .on('start', function () {
                        var counter = {value: eleValue};
                        var counterTween = TweenMax.to(counter, 4,
                            {
                                value: endValue,
                                roundProps: "value",
                                ease: Circ.easeOut,
                                onUpdate: function () {
                                    document.getElementsByClassName('milestone-counter')[i].innerHTML = signBefore + counter.value + signAfter;
                                }
                            });
                    })
                    .addTo(ctrl);
            });
        }
    }
});