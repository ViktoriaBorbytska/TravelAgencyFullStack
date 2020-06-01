$(document).ready(function () {
    $('#logout-button').click(logout);

    //if (localStorage.getItem("jwt") === null) {
    //  window.location.href = "index.html";
    //}
    generateUserCard();

    function generateUserCard() {
        $('.row.justify-content-center')
            .append(
                generateContainer('<div>', 'col-lg-5 order-1')
                    .append(
                        generateContainer('<div>', 'user-info')
                            .append(
                                generateContainer('<div>', 'row text-center')
                                    .append(
                                        generateContainer('<div>', 'profile-img')
                                            .append(
                                                generateImg('http://ssl.gstatic.com/accounts/ui/avatar_2x.png', 'avatar', 'rounded-circle img-thumbnail')
                                            )
                                    )
                                    .append(
                                        generateContainer('<div>', 'img-upload')
                                            .append($('<input>', {'type': 'file', 'id': 'file', 'class': 'input-file'}))
                                            .append($('<label>', {'for': 'file'})
                                                .append(
                                                    generateContainer('<span>', '', 'Choose a file...')
                                                )
                                            )
                                    )
                            )
                            .append(
                                generateProfileItem('First Name', 'Jane')
                            )
                            .append(
                                generateProfileItem('Last Name', 'Doe')
                            )
                            .append(
                                generateProfileItem('Email', 'janedoe@gmail.com')
                            )
                            .append(
                                generateProfileItem('Phone Number', '123 456 7890')
                            )
                    )
            )
            .append(
                generateContainer('<div>', 'col-lg-5 order-2')
                    .append($('<form>', {'class': 'reset-form'})
                        .append(
                            generateContainer('<div>', 'form-group')
                                .append($('<label>', {'text': 'Old password *'}))
                                .append($('<input>', {'type': 'password', 'class': 'form-control', 'placeholder': 'Your old password', 'required': 'true'}))
                                .append(
                                    generateContainer('<span>', 'message-span mt-2')
                                )
                        )
                        .append(
                            generateContainer('<div>', 'form-group')
                                .append($('<label>', {'text': 'New password *'}))
                                .append($('<input>', {'type': 'password', 'class': 'form-control', 'placeholder': 'Your new password', 'required': 'true'}))
                                .append(generatePasswordHint())
                        )
                        .append(
                            generateContainer('<div>', 'form-group')
                                .append($('<label>', {'text': 'Confirm new password *'}))
                                .append($('<input>', {'type': 'password', 'class': 'form-control', 'placeholder': 'Confirm your new password', 'required': 'true'}))
                                .append(
                                    generateContainer('<span>', 'message-span mt-2')
                                )
                        )
                        .append($('<button>', {'type': 'submit', 'id': 'reset-button', 'class': 'button reset-button', 'text': 'Reset password'}))
                    )
                    .append(
                        generateContainer('<div>', 'logout-field')
                            .append($('<button>', {'type': 'submit', 'id': 'logout-button', 'class': 'button logout-button', 'text': 'Log out'}))
                    )
            );
    }

    function generateProfileItem(itemName, dataToFill) {
        return generateContainer('<div>', 'row profile-item')
            .append(
                generateContainer('<div>', 'col-md-6', itemName)
            )
            .append(
                generateContainer('<div>', 'col-md-6', dataToFill)
            )
    }
});

function logout(event) {
    fetch(`${config.apiDomain}/api/account/logout`, {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify({token: localStorage.getItem("jwt")})
    });
    localStorage.removeItem("jwt");
    localStorage.removeItem("name");
    localStorage.removeItem("role");
    localStorage.removeItem("photoPath");
    window.location.href = "index.html";
}