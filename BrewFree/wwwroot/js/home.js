// Preloader
jQuery(window).load(function() {
    // will first fade out the loading animation
    jQuery("#status").fadeOut();
    // will fade out the whole DIV that covers the website.
    jQuery("#preloader").delay(1000).fadeOut("slow");
});

// jQuery to collapse the navbar on scroll
$(window).scroll(function () {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    $("a.page-scroll").bind("click", function (event) {
        var $anchor = $(this);
        $("html, body").stop().animate({
            scrollTop: ($($anchor.attr("href")).offset().top - 64)
        }, 1500, "easeInOutExpo");
        event.preventDefault();
    });
});

// Highlight the top nav as scrolling occurs
$("body").scrollspy({
    target: ".navbar-fixed-top",
    offset: 65
});

// Closes the Responsive Menu on Menu Item Click
$(".navbar-collapse ul li a").click(function () {
    $(".navbar-toggle:visible").click();
});

// Countdown
$("#clock").countdown("2017/09/01 0:00:00").on("update.countdown", function (event) {
    $(this).html(event.strftime(""
        + "<div><span>%-w</span>week%!w</div>"
        + "<div><span>%-d</span>day%!d</div>"
        + "<div><span>%H</span>hr%!H</div>"
        + "<div><span>%M</span>min%!M</div>"
        + "<div><span>%S</span>sec%!S</div>"));
});

// HTML5 Placeholder
$(function () {
    $("input, textarea").placeholder();
});

// Load WOW.js on non-touch devices
var isPhoneDevice = "ontouchstart" in document.documentElement;
$(document).ready(function () {
    if (isPhoneDevice) {
        //mobile
    } else {
        //desktop
        // Initialize WOW.js
        window.wow = new WOW({
            offset: 50
        });
        window.wow.init();
    }
});

$("body").vegas({
    delay: 9000,
    timer: false,
    transitionDuration: 2000,
    slides: [
        { src: "images/0.jpg" },
        { src: "images/1.jpg" },
        { src: "images/2.jpg" },
        { src: "images/3.jpg" },
        { src: "images/4.jpg" }
    ],
    transition: "swirlRight",
    animation: "kenburns"
});
