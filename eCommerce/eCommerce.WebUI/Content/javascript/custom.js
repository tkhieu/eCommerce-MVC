$(document).ready(function(){
$(".product_container").hover(function() {
$(this).find(".product_hidden").stop()
.animate({top: "0"}, "fast")
.css("display","block");

$(this).find(".n_price").animate({
	left: "-100"
  }, 500, function() {
    // Animation complete.
});

$(this).find(".s_price").animate({
	left: "-100"
  }, 500, function() {
    // Animation complete.
});


}, function() {
$(this).find(".product_hidden").stop()
.animate({top: "260"}, "medium");


$(this).find(".n_price").animate({
	left: "10"
  }, 500, function() {
    // Animation complete.
});

$(this).find(".s_price").animate({
	left: "10"
  }, 500, function() {
    // Animation complete.
});


});

/*-
/* IMAGE HOVER
/*-*/
jQuery(function() {

jQuery("#product_top img").hover(function () {
jQuery(this).stop().animate({ opacity: 0.5 }, "medium"); },
function () {
jQuery(this).stop().animate({ opacity: 1.0 }, "slow");
});
});



jQuery(function() {
jQuery("#column_left ul li a").hover(function () {
jQuery(this).stop().animate({ left: "5" }, "fast"); },
function () {
jQuery(this).stop().animate({ left: "0" }, "medium");
});
});



});


Cufon.replace('h1, h2, #customHome h2, h3, h4, h5, .category_name, #content h1, .heading, #top-menu a, #learn_more, .n_price span, .s_price span , .product_hidden .product_name, .product_hidden .product_model, .product_hidden .n_price_h, .button_add, .button_add:visited, .button_add, .button_add:visited , .box .top, .n_price_prod, .button span , .page-link, input .button_add'); // Requires a selector engine for IE 6-7, see above