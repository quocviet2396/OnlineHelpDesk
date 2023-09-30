
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();

connection.start()

connection.on("ReceiveMessage", function (mess, url) {
    mess ? console.log("aaa") : console.log(mess);
});
