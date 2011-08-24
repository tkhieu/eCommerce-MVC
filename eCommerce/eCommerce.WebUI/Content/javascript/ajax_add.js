$(document).ready(function () {
$('#add_to_cart').removeAttr('onclick');
$('#add_to_cart').click(function () {
$.ajax({
type: 'post',
url: 'index.php?route=module/cart/minicart',
dataType: 'html',
data: $('#product :input'),
success: function (html) {
$('#cart_in_header').html(html);
},
complete: function () {
var image = $('#image').offset();
var cart  = $('#cart_in_header').offset();
$('#big_photo').after('<img src="../account-address-edit_files/' + $('#image').attr('src') + '" id="temp" style="position: absolute; top: ' + image.top + 'px; left: ' + image.left + 'px;" />');
params = {
top : cart.top + 'px',
left : cart.left + 'px',
opacity : 0.0,
width : $('#cart_in_header').width(),
heigth : $('#cart_in_header').height()
};
$('#temp').animate(params, 'slow', false, function () {
$('#temp').remove();
});
}
});
});
});
