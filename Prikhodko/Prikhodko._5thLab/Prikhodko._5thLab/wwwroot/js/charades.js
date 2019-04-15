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
var paint = false;

$('#canvas').mousedown(function (e) {
	paint = true;
	addClick(e.pageX - this.offsetLeft, e.pageY - this.offsetTop);
	redraw();
});

$('#canvas').mousemove(function (e) {
	if (paint) {
		addClick(e.pageX - this.offsetLeft, e.pageY - this.offsetTop, true);
		redraw();
	}
});

$('#canvas').mouseup(function (e) {
	paint = false;
});

$('#canvas').mouseleave(function (e) {
	paint = false;
});


function addClick(x, y, dragging) {
	clickX.push(x);
	clickY.push(y);
	clickDrag.push(dragging);
}

function redraw() {
	context.clearRect(0, 0, context.canvas.width, context.canvas.height); // Clears the canvas

	context.strokeStyle = "#df4b26";
	context.lineJoin = "round";
	context.lineWidth = 5;

	for (var i = 0; i < clickX.length; i++) {
		context.beginPath();
		if (clickDrag[i] && i) {
			context.moveTo(clickX[i - 1], clickY[i - 1]);
		} else {
			context.moveTo(clickX[i] - 1, clickY[i]);
		}
		context.lineTo(clickX[i], clickY[i]);
		context.closePath();
		context.stroke();
	}
}

$('#clearCanvas').click(function () {
	context.clearRect(0, 0, context.canvas.width, context.canvas.height);
	clickX = new Array();
	clickY = new Array();
	clickDrag = new Array();
}) 