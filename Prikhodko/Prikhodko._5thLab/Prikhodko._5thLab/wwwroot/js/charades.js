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