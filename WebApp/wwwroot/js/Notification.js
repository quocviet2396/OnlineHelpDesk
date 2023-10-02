
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();


connection.on("OnConnected", function () {
    onConnected()
});

const onConnected = () => {
    var email = localStorage.getItem("email");
    console.log(email)
    connection.invoke("saveUser", email).catch((err) => console.error(err))
}

connection.start()
    .then(() => { console.log("successfull") })
    .catch((err) => { return console.error(err.toString()) });
