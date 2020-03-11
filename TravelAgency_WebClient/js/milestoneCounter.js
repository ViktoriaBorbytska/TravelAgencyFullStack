$(document).ready(function () {
    "use strict";

    let ctrl = new ScrollMagic.Controller();

    initMilestones();

    function initMilestones() {
        let milestoneItems = $('.milestone-counter');
        if (milestoneItems.length) {
            milestoneItems.each(function (i) {
                let ele = $(this);
                let endValue = ele.data('end-value');
                let eleValue = ele.text();

                let signBefore = "";
                let signAfter = "";

                if (ele.attr('data-sign-before')) {
                    signBefore = ele.attr('data-sign-before');
                }

                if (ele.attr('data-sign-after')) {
                    signAfter = ele.attr('data-sign-after');
                }

                let milestoneScene = new ScrollMagic.Scene({
                    triggerElement: this,
                    triggerHook: 'onEnter',
                    reverse: false
                })
                    .on('start', function () {
                        let counter = {value: eleValue};
                        let counterTween = TweenMax.to(counter, 4,
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