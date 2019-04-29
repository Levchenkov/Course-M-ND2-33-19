var canvas = document.getElementById('drawingpad');
var ctx = canvas.getContext('2d');

$(function () {
    var drawGame = {
        isDrawing: false,
        startX: 0,
        startY: 0,
    };
    var data = {
        startX: 0,
        startY: 0,
        endX: 0,
        endY: 0
    };

    var draw = $.connection.drawHub;
    draw.client.addLine = function (data) {

        drawLine(ctx, data.startX, data.startY, data.endX, data.endY, 1);
    };

    $('#chatBody').hide();
    $('#loginBlock').show();
    var chat = $.connection.chatHub;
    chat.client.addMessage = function (name, message) {
        $('#chatroom').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>');
    };

    chat.client.onConnected = function (id, userName, allUsers) {

        $('#loginBlock').hide();
        $('#chatBody').show();
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#header').html('<h3>Добро пожаловать, ' + userName + '</h3>');
        for (i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    }
    chat.client.onNewUserConnected = function (id, name) {

        AddUser(id, name);
    }

    chat.client.onUserDisconnected = function (id, userName) {

        $('#' + id).remove();
    }

    $.connection.hub.start().done(function () {

        canvas.addEventListener("mousedown", mousedown, false);
        canvas.addEventListener("mousemove", mousemove, false);
        canvas.addEventListener("mouseup", mouseup, false);

        $('#sendmessage').click(function () {
            chat.server.send($('#username').val(), $('#message').val());
            $('#message').val('');
        });

        $("#btnLogin").click(function () {

            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            }
            else {
                alert("Введите имя");
            }
        });
    });

    function drawLine(ctx, x1, y1, x2, y2, thickness) {
        ctx.beginPath();
        ctx.moveTo(x1, y1);
        ctx.lineTo(x2, y2);
        ctx.lineWidth = thickness;
        ctx.strokeStyle = ctx.strokeStyle;
        ctx.stroke();
    }

    function mousedown(e) {
        var mouseX = e.layerX || 0;
        var mouseY = e.layerY || 0;
        drawGame.startX = mouseX;
        drawGame.startY = mouseY;
        drawGame.isDrawing = true;
    };

    function mousemove(e) {

        if (drawGame.isDrawing) {

            var mouseX = e.layerX || 0;
            var mouseY = e.layerY || 0;
            if (!(mouseX == drawGame.startX &&
                mouseY == drawGame.startY)) {
                drawLine(ctx, drawGame.startX,
                    drawGame.startY, mouseX, mouseY, 1);

                data.startX = drawGame.startX;
                data.startY = drawGame.startY;
                data.endX = mouseX;
                data.endY = mouseY;
                draw.server.send(data);

                drawGame.startX = mouseX;
                drawGame.startY = mouseY;
            }
        }
    };

    function mouseup(e) {
        drawGame.isDrawing = false;
    }
});
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

function AddUser(id, name) {

    var userId = $('#hdId').val();

    if (userId != id) {

        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}

function changeColor(color) {
    ctx.strokeStyle = color;
}