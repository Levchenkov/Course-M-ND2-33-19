"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/charadesHub", {}).build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = false;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " : " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("AskName", function () {
    var name;
    do {
        name = prompt("Please enter your name", "Charades God");
    } while (!name);
    connection.invoke("RegisterMember", name).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("Notify", function (message) {
    var li = document.createElement("li");
    li.textContent = message.bold();
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());

});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

var context = document.getElementById("canvas").getContext("2d");
var clickX = new Array();
var clickY = new Array();
var clickDrag = new Array();
var counter = 0;
var paint = false;



connection.on("AddClick",
    function (x, y, dragging) {
        clickX.push(x);
        clickY.push(y);
        clickDrag.push(dragging);
    });

connection.on("Draw",
    function () {
        context.strokeStyle = "#df4b26";
        context.lineJoin = "round";
        context.lineWidth = 5;

        for (var i = counter; i < clickX.length; i++) {
            context.beginPath();
            if (clickDrag[i] && i) {
                context.moveTo(clickX[i - 1], clickY[i - 1]);
            } else {
                context.moveTo(clickX[i] - 1, clickY[i]);
            }
            context.lineTo(clickX[i], clickY[i]);
            context.closePath();
            context.stroke();
            counter++;
        }
    });

connection.on("ClearCanvas",
    function () {
        context.clearRect(0, 0, context.canvas.width, context.canvas.height);
        clickX = new Array();
        clickY = new Array();
        clickDrag = new Array();
        counter = 0;
    });


connection.on("InitCharades", function () {
    $('#canvas').mousedown(function (e) {
        paint = true;
        connection.invoke("UpdateCanvas", e.pageX - this.offsetLeft, e.pageY - this.offsetTop, false);
    });

    $('#canvas').mousemove(function (e) {
        if (paint) {
            connection.invoke("UpdateCanvas", e.pageX - this.offsetLeft, e.pageY - this.offsetTop, true);
        }
    });

    $('#canvas').mouseup(function (e) {
        paint = false;
    });

    $('#canvas').mouseleave(function (e) {
        paint = false;
    });

    $('#clearCanvas').click(function () {
        connection.invoke("ClearCanvas");
    });
});