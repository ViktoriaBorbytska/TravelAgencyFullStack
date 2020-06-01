var state = {
    email: "",
    password: "",
    emailError: "",
    passwordError: "",
    message: "",
    success: false
};

function setState(data) {
    state[data.name] = data.value;
}

function submitForm(event) {
    event.preventDefault();
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
            setState({ name: "success", value: true });
            this.props.successCallback(res.token);
            this.props.history.goBack();
          } else {
            this.setState({ message: res.message });
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
          this.forceUpdate();
        }
      });
  };