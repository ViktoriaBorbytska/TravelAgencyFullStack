$(document).ready(function() {
    $('.popup-with-move-anim').magnificPopup({
        type: 'inline',

        fixedContentPos: false,
        fixedBgPos: true,

        overflowY: 'auto',

        closeBtnInside: true,
        preloader: false,

        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-slide-bottom'
    });

    $('.popup-with-form').magnificPopup({
        type: 'inline',
        preloader: false,
        focus: '#title',
        removalDelay: 300,
        mainClass: 'my-mfp-slide-bottom',

        callbacks: {
            beforeOpen: function() {
                if($(window).width() < 700) {
                    this.st.focus = false;
                } else {
                    this.st.focus = '#title';
                }
            }
        }
    });
});
