$(document).ready(function() {
  $('#logout-button').click(logout);

    if(localStorage.getItem("jwt") === null) {
      window.location.href = "index.html";
    }
});

function logout(event) {
  fetch(`${config.apiDomain}/api/account/logout`, {
    method: "post",
    headers: {
      "Content-type": "application/json"
    },
    body: JSON.stringify({ token: localStorage.getItem("jwt") })
  });
  localStorage.removeItem("jwt");
  localStorage.removeItem("name");
  localStorage.removeItem("role");
  localStorage.removeItem("photoPath");
  window.location.href = "index.html";
}