$(document).ready(function() {

    $.get("http://localhost:5000/header.html", function (html_str) {
        alert(html_str); 
   },'html');


});