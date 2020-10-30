"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5001/hubs")
    .withAutomaticReconnect()
    .build();

connection.on("ReceiveMessage", function (message) {
    console.log("Notification received: " + message);
});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

connection.onclose(start);

start();