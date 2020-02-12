$(function () {
    $('#chatBody').hide();
    $('#loginBlock').show();
    $('#cbMaster').show();
    // Ссылка на автоматически-сгенерированный прокси хаба
    var chat = $.connection.chatHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    chat.client.addMessage = function (name, message, isMaster) {
        var master = '';
        if (isMaster) {
            master = ' Ведущий';
        }
        // Добавление сообщений на веб-страницу 
        $('#chatroom').append('<p><b>' + htmlEncode(name + master)
            + '</b>: ' + htmlEncode(message) + '</p>');
    };

    chat.client.updateDot = function (ex, ey, x, y, color) {
        //drawDot(x, y, 3);
        drawLine(ex, ey, x, y, color);
    };

    chat.client.clearCanvas = function () {
        clearCanvas();
    };

    chat.client.endGame = function() {
        endGame();
    }

    var canv = $('#hidenCanvas');
    canv.hide();

    // Функция, вызываемая при подключении нового пользователя
    chat.client.onConnected = function (id, userName, allUsers, isMaster) {

        $('#loginBlock').hide();
        $('#chatBody').show();
        // установка в скрытых полях имени и id текущего пользователя
        $('#hdId').val(id);
        $('#username').val(userName);
        //$('#cbMaster')[0].checked = isMaster;
        $('#header').html('<h3>Добро пожаловать, ' + userName + '</h3>');
        // Добавление всех пользователей
        for (i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name, allUsers[i].IsMaster);
        }
        canv.show();
    }

    // Добавляем нового пользователя
    chat.client.onNewUserConnected = function (id, name, isMaster) {

        AddUser(id, name, isMaster);
    }

    // Удаляем пользователя
    chat.client.onUserDisconnected = function (id, userName) {

        $('#' + id).remove();
    }

    // Открываем соединение
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            // Вызываем у хаба метод Send
            chat.server.send($('#username').val(), $('#message').val(), $('#cbMaster')[0].checked);
            $('#message').val('');
        });

        //isAnyMaster();
        // обработка логина
        $("#btnLogin").click(function () {
            
            var name = $("#txtUserName").val();
            var isMaster;
            isMaster = $("#cbMaster")[0].checked;
            if (name.length > 0) {
                chat.server.connect(name, isMaster);
            }
            else {
                alert("Введите имя");
            }
            if (isMaster) {
                //On mouse events on the canvas
                $canvas.mousedown(function (e) {
                    lastEvent = e;
                    mouseDown = true;
                }).mousemove(function (e) {
                    //Draw lines
                    if (mouseDown) {
                        drawLine(lastEvent.offsetX, lastEvent.offsetY, e.offsetX, e.offsetY, color);
                        chat.server.updateCanvas(lastEvent.offsetX, lastEvent.offsetY, e.offsetX, e.offsetY, color);
                        lastEvent = e;
                    }
                }).mouseup(function () {
                    mouseDown = false;
                }).mouseleave(function () {
                    $canvas.mouseup();
                });
            } else {
                $('#canvasControls').hide();
            }
        });
    });

    function drawDot(x, y, size) {
        // Draw a filled circle  
        context.fillStyle = color;
        context.beginPath();
        context.arc(x, y, size, 0, Math.PI * 2, true);
        context.closePath();
        context.fill();
    }

    function drawLine(ex, ey, x, y, color) {
        // Draw a line
        context.beginPath();
        context.moveTo(ex, ey);
        context.lineTo(x, y);
        context.strokeStyle = color;
        //context.lineWidth = 5;
        context.stroke();
    }
    // Clear the canvas context using the canvas width and height     
    function cleanCanvas() {
        clearCanvas();
        chat.server.clearCanvas();
    }

    function clearCanvas() {
        context.clearRect(0, 0, context.canvas.width, context.canvas.height);
    }

    //End of game
    function endGame() {
        var centerX = context.canvas.width / 2;
        var centerY = context.canvas.height / 2;
        var radius = 70;
        var eyeRadius = 10;
        var eyeXOffset = 25;
        var eyeYOffset = 20;

        // draw the yellow circle
        context.beginPath();
        context.arc(centerX, centerY, radius, 0, 2 * Math.PI, false);
        context.fillStyle = 'yellow';
        context.fill();
        //context.lineWidth = 5;
        context.strokeStyle = 'black';
        context.stroke();

        // draw the eyes
        context.beginPath();
        var eyeX = centerX - eyeXOffset;
        var eyeY = centerY - eyeXOffset;
        context.arc(eyeX, eyeY, eyeRadius, 0, 2 * Math.PI, false);
        var eyeX = centerX + eyeXOffset;
        context.arc(eyeX, eyeY, eyeRadius, 0, 2 * Math.PI, false);
        context.fillStyle = 'black';
        context.fill();

        // draw the mouth
        context.beginPath();
        context.arc(centerX, centerY, 50, 0, Math.PI, false);
        context.stroke();
    }

    function isAnyMaster(allUsers) {
        chat.server.isAnyMaster(allUsers);
        for (i = 0; i < allUsers.length; i++) {
            if (allUsers[i].IsMaster) {
                $('#cbMaster')[0].checked = false;
                $('#cbMaster').hide();
                return;
            }
        }
    }

    // Keep track of the mouse button being pressed and draw a dot at current location     
    function sketchpad_mouseDown() {
        mouseDown = 1;
        drawDot(mouseX, mouseY, 8);
        chat.server.updateCanvas(mouseX, mouseY);
    }
    // Keep track of the mouse button being released     
    function sketchpad_mouseUp() {
        mouseDown = 0;
    }
    // Keep track of the mouse position and draw a dot if mouse button is currently pressed     
    function sketchpad_mouseMove(e) {
        // Update the mouse co-ordinates when moved     
        getMousePos(e);
        // Draw a dot if the mouse button is currently being pressed     
        if (mouseDown == 1) {
            drawDot(mouseX, mouseY, 8);
            chat.server.updateCanvas(mouseX, mouseY);
        }
    }
    // Get the current mouse position relative to the top-left of the canvas     
    function getMousePos(e) {
        if (!e)
            var e = event;
        if (e.offsetX) {
            mouseX = e.offsetX;
            mouseY = e.offsetY;
        }
        else if (e.layerX) {
            mouseX = e.layerX;
            mouseY = e.layerY;
        }
    }





    //Problem: No user interaction capability
    //Solution: When user interacts, cause changes appropriately
    var color = $(".selected").css("background-color");;
    var $canvas = $("canvas");
    var context = $canvas[0].getContext("2d");
    var lastEvent;
    var mouseDown = false;

    //When clicking on control list items
    $(".controls").on("click", "li", function () {
        //Deselect sibling elements
        $(this).siblings().removeClass("selected");
        //Select clicked element
        $(this).addClass("selected");
        //cache current color
        color = $(this).css("background-color");
    });


    //When "New Color" is pressed
    $("#revealColorSelect").click(function () {
        //Show color select or hide the color select
        changeColor();
        $("#colorSelect").toggle();
    });

    //update the new color span
    function changeColor() {
        var r = $("#red").val();
        var g = $("#green").val();
        var b = $("#blue").val();

        $("#newColor").css("background-color", "rgb(" + r + "," + g + ", " + b + ")");
    }

    //When color sliders change
    $("input[type=range]").change(changeColor)

    //When "Add Color" is pressed
    $("#addNewColor").click(function () {
        //Append the color to the controls ul
        var $newColor = $("<li></li>");
        $newColor.css("background-color", $("#newColor").css("background-color"));
        $(".controls ul").append($newColor);
        //Select the new color
        $newColor.click();
    });

    $("#btnClean").click(function () {
        cleanCanvas();
    });


});
// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
//Добавление нового пользователя
function AddUser(id, name, isMaster) {

    var userId = $('#hdId').val();
    var master = '';
    if (isMaster) {
        master = '-Ведущий';
    }
    if (userId != id) {

        $("#chatusers").append('<p id="' + id + '"><b>' + name + master + '</b></p>');
    }
}