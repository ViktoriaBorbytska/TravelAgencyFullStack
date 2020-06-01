$(document).ready(function () {

    fetch(`${config.apiDomain}/api/reviews/getall`)
        .then(response => response.json())
        .then((res) => {
            for (let i = 0; i < 3; i++) {
                generatePost(res[i]);
            }
        });

    function generatePost(response) {
        let date = new Date(response['date']);

        generateContainer('<div>', 'reviews-post')
            .append(
                generateContainer('<div>', 'post-title')
                    .append($('<blockquote>')
                        .append($('<p>', {'text': response['header']}))
                    )
            )
            .append(
                generateContainer('<div>', 'post-text')
                    .append($('<p>', {'text': response['text']}))
                    .append(
                        generateContainer('<div>', 'item-more')
                            .append(
                                generateLink('#', 'Read More')
                            )
                    )
            )
            .append(
                generateContainer('<div>', 'post-image')
                    .append(
                        generateImg(response['imageLink'], 'User image')
                    )
            )
            .append(
                generateContainer('<div>', 'meta')
                    .append(
                        $('<ul>')
                            .append(
                                $('<li>', {'text': /*response['userName']*/ 'by Will Willson'})
                            )
                            .append(
                                $('<li>', {'text': months[date.getMonth()] + ' ' + date.getDate() + ", " + date.getFullYear()})
                            )
                    )
            )
            .appendTo($('.reviews-posts')[0]);
    }
});