﻿//jQuery(document).ready(function () {
//    $("#input-21f").rating({
//        starCaptions: function (val) {
//            if (val < 3) {
//                return val;
//            } else {
//                return 'high';
//            }
//        },
//        starCaptionClasses: function (val) {
//            if (val < 3) {
//                return 'label label-danger';
//            } else {
//                return 'label label-success';
//            }
//        },
//        hoverOnClear: false
//    });
//    var $inp = $('#rating-input');

//    $inp.rating({
//        min: 0,
//        max: 5,
//        step: 1,
//        size: 'lg',
//        showClear: false
//    });

//    $('#btn-rating-input').on('click', function () {
//        $inp.rating('refresh', {
//            showClear: true,
//            disabled: !$inp.attr('disabled')
//        });
//    });


//    $('.btn-danger').on('click', function () {
//        $("#kartik").rating('destroy');
//    });

//    $('.btn-success').on('click', function () {
//        $("#kartik").rating('create');
//    });

//    $inp.on('rating.change', function () {
//        alert($('#rating-input').val());
//    });


//    $('.rb-rating').rating({
//        'showCaption': true,
//        'stars': '3',
//        'min': '0',
//        'max': '3',
//        'step': '1',
//        'size': 'xs',
//        'starCaptions': { 0: 'status:nix', 1: 'status:wackelt', 2: 'status:geht', 3: 'status:laeuft' }
//    });
//    $("#input-21c").rating({
//        min: 0, max: 8, step: 0.5, size: "xl", stars: "8"
//    });
//});