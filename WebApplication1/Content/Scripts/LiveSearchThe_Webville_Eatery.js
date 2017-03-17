//Remember always check Cache or clear cache if not working

$(document).ready(function () {
    $('#thai').mouseenter(function () {
        $('.menu_list1').slideDown(300);
    });
    $('#thai').mouseleave(function () {
        $('.menu_list1').slideUp(300);
    });
});

$(function () {
    $('#Panini').mouseenter(function () {
        $('.menu_list2').slideDown(300);
    });
    $('#Panini').mouseleave(function () {
        $('.menu_list2').slideUp(300);
    });
});

$(function () {
    $('#Southwest').mouseenter(function () {
        $('.menu_list3').slideDown(300);
    });
    $('#Southwest').mouseleave(function () {
        $('.menu_list3').slideUp(300);
    });
});








//<!-- Working -->        // this wont work because of ('data-panelid') it was a created attribute on htmlpage
$(function () { 
    $('.panel-button').on('click', function () {
        var panelId = $(this).attr('data-panelid');

        $('.menu_list' + panelId).slideDown(300);
    });
    $('.panel-button').mouseleave(function () {
        var panelId = $(this).attr('data-panelid');

        $('.menu_list' + panelId).slideUp(100);
    });
});


$(document).ready(function () {
    $("#thaiwan").on('click', function () {
        $("#thaiwan").slideToggle(500);
        $("#thaiwan").slideToggle(10);
    });
});

$(document).ready(function () {
    $(".test1").css("background-color", "green");
    $(".test1").on("click", function () {
        alert("xxx");
    });
    $(".test1").on("click", function () {
        $(".test1").css("background-color", "red");
    })
});

//<!-- Working  -->
