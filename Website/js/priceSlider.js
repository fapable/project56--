jQuery( function() {
    $( "#priceSlider" ).on( 'input', function () {
        $( "#maxPrice" ).val( $( "#priceSlider" ).val() )
    });
    $( "#maxPrice" ).on( 'input', function () {
        $( "#priceSlider" ).val( $( "#maxPrice" ).val() )
    });
});