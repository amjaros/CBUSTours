$(document).ready(function () {
    $(document).hidemenu(function (e) {
        var container = $(".navbar-collapse.in");

        if (!container.is(e.target) // if the target of the click isn't the container...
            && container.has(e.target).length === 0) // ... nor a descendant of the container
        {
            container.hide();
        }
    });

    $(document).showmenu(function (e) {
        var container = $(".navbar-toggle");

        if (!container.is(e.target) // if the target of the click isn't the container...
            && container.has(e.target).length === 0) // ... nor a descendant of the container
        {
            container.slideDown();
        }
    });


});