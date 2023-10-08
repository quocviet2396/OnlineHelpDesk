
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();

var currentTickets = localStorage.getItem("tickets");
var tickets = JSON.parse(currentTickets)
connection.on("OnConnected", function () {
    onConnected()
});

connection.on("SendNotiAdmin", (tickets, mess) => {
    if (!currentTickets) {
        currentTickets = [];
    } else {
        currentTickets = JSON.parse(currentTickets);
    }
    var newTickets = JSON.parse(tickets);
    newTickets.forEach(function (ticket) {
        var isDuplicate = false;

        for (var i = 0; i < currentTickets.length; i++) {
            if (currentTickets[i].TicketId === ticket.TicketId) {
                isDuplicate = true;
                break;
            }
        }
        if (!isDuplicate) {
            currentTickets.push(ticket);
        }
    });
    localStorage.setItem("tickets", JSON.stringify(currentTickets));

    changeUI(currentTickets)
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

    var ticketsWithNullStatus = tickets.filter(function (ticket) {
        return ticket.TicketStatus === null;
    });
    console.log(ticketsWithNullStatus)
    if (ticketsWithNullStatus.length >= 0) {
        $("#hubCount").text(ticketsWithNullStatus.length)
        $("#hubCount").attr("hidden", false)
    } else {
        $("#hubCount").hide()
    }
    tickets.forEach((item) => {
        addNotification(item.UserNameCreator, item.Title, item.Decription)
    })
}

function addNotification(userName, title, description) {
    var newNotification = `
        <li class="notifications-item">
            <strong><b>${userName}</b> send a new request</strong>
            <div class="text">
                <h4>${title}</h4>
                <p>${description}</p>
            </div>
        </li>
    `;

    $("#notification-list").append(newNotification);
}

changeUI(tickets);