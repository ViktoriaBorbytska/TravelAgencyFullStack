$(document).ready(function () {
    generatePasswordHint().appendTo($('.register-form div.form-group')[3]);

    $('.btn').click(submitForm);

    if (localStorage.getItem("jwt") !== null) {
        window.location.href = "index.html";
    }
});

var state = {};

function setStateInfo(message) {
    state.info = message;
    $('.text-danger').text(message);
}

function isEmptyField(field) {
    if (field === "" || field === null || field === undefined) {
        return true;
    }
    return false;
}

function validate() {
    // validation of current state - if all right, successful result will be returned
    let result = {
        message: "",
        successful: false
    };
    if (
        isEmptyField(state.email) ||
        isEmptyField(state.first_name) ||
        isEmptyField(state.last_name) ||
        isEmptyField(state.password) ||
        isEmptyField(state.confirmPassword) ||
        isEmptyField(state.phone)
    ) {
        result.message = "Empty fields are not allowed";
    } else if (state.password !== state.confirmPassword) {
        result.message = "Passwords should match";
    } else {
        result.message = "Validation complited";
        result.successful = true;
    }
    return result;
}

function formDataToState(formData) {
    formData.forEach(data => {
        state[data.name] = data.value;
    });

}

function submitForm(event) {
    event.preventDefault();
    var formData = $('.register-form').serializeArray();
    formDataToState(formData);
    let validation = validate();
    if (!validation.successful) {
        setStateInfo(validation.message);
        return;
    }
    setStateInfo("ᅠ");
    let dto = {
        email: state.email,
        username: state.first_name,
        surname: state.last_name,
        role: "client",
        password: state.password,
        phone: state.phone
    };
    console.log(dto);
    fetch(config.apiDomain + "/api/account/register", {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(res => res.json())
        .then(res => {
            console.log(res);
            if (res.isSuccessful) {
                loginSuccess(res.token);
            } else {
                setStateInfo(res.message);
            }
        });
}

/////////////////
function loginSuccess(token) {
    localStorage.setItem("jwt", token);
    fetch(`${config.apiDomain}/api/account/get/${localStorage.getItem("jwt")}`)
        .then(res => res.json())
        .then(res => {
            if (res && res.email && res.role) {
                localStorage.setItem("name", res.name);
                localStorage.setItem("role", res.role);
                localStorage.setItem("photoPath", "/" + res.photoPath);
                window.location.href = "index.html";
                //this.forceUpdate();
            }
        });
};