
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();



connection.on("OnConnected", async function () {
    await onConnected()

    //var email = localStorage.getItem("email");
    //await connection.invoke("CheckNoti", email).catch((err) => console.error(err))
});

connection.on("SendNotiAdmin", async (tickets, mess) => {
    changeUI(tickets)
    console.log(tickets)

});

const onConnected = () => {
    var email = localStorage.getItem("email");
    connection.invoke("saveUser", email).catch((err) => console.error(err))
}

connection.start().then(() => {
    console.log("Connection established.");
}).catch((err) => {
    console.error("Error while connecting:", err);
});

function changeUI(tickets) {
    addNotification(tickets.userNameCreator, tickets.title, tickets.decription)
}

function addNotification(userName, title, description) {
    var newNotification = `
        <li class="card mt-2">
            <div>
                <strong><b>${userName}</b> send a new request</strong>
                <div class="text">
                    <h4>${title}</h4>
                    <p>${description}</p>
                </div>
            </div>
            <div></div>
        </li>
    `;

    $("#notification-list").append(newNotification);
}

$(document).ready(() => {
    $("#notification-icon").on("click", (event) => {
        event.stopPropagation();
        $('#notification-content').toggle();
    })

    $(document).click(function (event) {
        if (!$(event.target).closest('#notification-icon, #notification-content').length) {
            $('#notification-content').hide();
        }
    });
})
