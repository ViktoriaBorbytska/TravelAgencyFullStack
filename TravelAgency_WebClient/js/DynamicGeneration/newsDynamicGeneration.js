$(document).ready(function () {

    fetch(`${config.apiDomain}/api/news/getall`)
        .then(response => response.json())
        .then((res) => {
            for (let i = 0; i < 3; i++) {
                generatePost(res[i]);
            }
            for (let i = 3; i < 6; i++) {
                generateSidebarFeatures(res[i]);
            }
        });

    function generatePost(response) {
        let date = new Date(response['date']);

        generateContainer('<div>', 'news-post')
            .append(
                generateContainer('<div>', 'post-title')
                    .append(
                        generateLink(`${config.apiDomain}/api/offers/getdetails/${response['id']}`, response['header'])
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
            .append(
                generateContainer('<div>', 'post-image')
                    .append(
                        generateImg(response['imageLink'], 'User photo')
                    )
            )
            .append(
                generateContainer('<div>', 'post-text')
                    .append($('<p>', {'text': response['text']}))
            )
            .appendTo($('.news-posts')[0]);
    }

    function generateSidebarFeatures(response) {
        let date = new Date(response['date']);

        generateContainer('<div>', 'sidebar-featured-post')
            .append(
                generateContainer('<div>', 'sidebar-featured-image')
                    .append(
                        generateImg(response['imageLink'], 'User photo')
                    )
            )
            .append(
                generateContainer('<div>', 'sidebar-featured-title')
                    .append(
                        generateLink(`${config.apiDomain}/api/offers/getdetails/${response['id']}`, response['header'])
                    )
            )
            .append(
                generateContainer('<div>', 'meta sidebar-featured-meta')
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
            .appendTo($('.sidebar-featured')[0]);
    }
});