$(document).ready(function() {
//$(".super-container").load("header.html");
    $.get("header.html", function (html_str) {
	$(".super-container").append(html_str);
   },'html');


});