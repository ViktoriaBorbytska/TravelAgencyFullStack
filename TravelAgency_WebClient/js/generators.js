function generateContainer(type, className, text) {
    return $(type, {
        'class': className,
        'text': text
    });
}

function generateImg(src, alt, className) {
    return $('<img>', {
        'src': src,
        'alt': alt,
        'class': className
    });
}

function generateLink(href, text, className) {
    return $('<a>', {
        'href': href,
        'text': text,
        'class': className
    })
}

function generatePasswordHint() {
    return generateContainer('<div>', 'password-info')
        .append($('<h6>', {'class': 'mt-2', 'text': 'Password must meet the following requirements:'}))
        .append($('<ul>')
            .append($('<li>', {'id': 'letter', 'text': 'At least '})
                .append($('<strong>', {'text': 'one letter'}))
            )
            .append($('<li>', {'id': 'capital', 'text': 'At least '})
                .append($('<strong>', {'text': 'one capital letter'}))
            )
            .append($('<li>', {'id': 'number', 'text': 'At least '})
                .append($('<strong>', {'text': 'one number'}))
            )
            .append($('<li>', {'id': 'length', 'text': 'Be at least '})
                .append($('<strong>', {'text': '8 characters'}))
            )
        )
}

const months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
]