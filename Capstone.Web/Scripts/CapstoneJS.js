$(window).on('load', function () {
    $("dropdown .dropbtn, .dropdown-content").hover(function () {
        $(this).next().toggleClass("glyphicon-arrow-up glyphicon-arrow-down");
    });

    $(".open_for_business_dropdown_title p").click(function () {
        $(this).next().slideToggle('fast');
        $(this).parent().find("span").toggleClass("glyphicon-plus glyphicon-minus");
    });
});


