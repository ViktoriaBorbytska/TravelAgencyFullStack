$(document).ready(function () {
    $('.btn').click(submitForm);

    if (localStorage.getItem("jwt") !== null) {
        window.location.href = "index.html";
    }
});

let state = {
    email: "",
    password: "",
    emailError: "",
    passwordError: "",
    message: "",
    success: false
};

function formDataToState(formData) {
    formData.forEach(data => {
        state[data.name] = data.value;
    });

}

function setState(data) {
    state[data.name] = data.value;
}

function submitForm(event) {
    event.preventDefault();
    let formData = $('.login-form').serializeArray();
    formDataToState(formData);
    fetch(`${config.apiDomain}/api/account/login`, {
        method: "post",
        body: JSON.stringify({
            email: state.email,
            password: state.password
        }),
        headers: {
            "Content-type": "application/json"
        }
    })
        .then(res => res.json())
        .then(res => {
            console.log(res);
            if (res.isSuccessful) {
                setState({name: "success", value: true});
                loginSuccess(res.token);
            } else {
                setState({name: "message", value: "res.message"});
            }
        });
}

function loginSuccess(token) {
    localStorage.setItem("jwt", token);
    fetch(`${config.apiDomain}/api/account/get/${localStorage.getItem("jwt")}`)
        .then(res => res.json())
        .then(res => {
            if (res && res.email && res.role) {
                localStorage.setItem("name", res.name);
                localStorage.setItem("role", res.role);
                window.location.href = "index.html";
            }
        });
};