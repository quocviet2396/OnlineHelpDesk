
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();

var hubCount = parseInt($("#hubCount").text());
console.log(hubCount)
connection.on("OnConnected", async function () {
    await onConnected()

    //var email = localStorage.getItem("email");
    //await connection.invoke("CheckNoti", email).catch((err) => console.error(err))
});

connection.on("SendNotiAdmin", async (tickets, mess) => {
    changeUI(tickets)
    console.log(tickets)
    hubCount++;
    $("#hubCount").attr("hidden", false)
    $("#hubCount").text(hubCount)

});
if (hubCount > 0) {
    $("#hubCount").attr("hidden", false)
} else {
    $("#hubCount").attr("hidden", true)
}
const onConnected = () => {
    var email = localStorage.getItem("email");
    console.log(email)
    connection.invoke("saveUser", email).catch((err) => console.error(err))
}

connection.start().then(() => {
    console.log("Connection established.");
}).catch((err) => {
    console.error("Error while connecting:", err);
});

function changeUI(tickets) {
    addNotification(tickets.userNameCreator, tickets.title, tickets.decription, tickets.photoPerson, tickets.ticketId)
}

function addNotification(userName, title, description, photo, ticketId) {
    var newNotification = `
           <li class="card mt-1 p-3">
                                                    <a href="/Ticket/Details/${ticketId}" class="d-flex justify-content-around items-center align-items-center">
                                                        <img ? src="./images/avatars/${photo ? photo : 'avatar_default.jpeg'}" style="width:60px;height:60px" />
                                                        <div>
                                                            <strong>You have a new notification</strong>
                                                            <div class="text">
                                                                <h4>${title}</h4>
                                                                <p>${description}</p>
                                                            </div>
                                                        </div>
                                                           <div class="btn-primary" style="border-radius: 50%;width: 20px; height: 20px"></div>
                                                    </a>
                                                </li>
    `;

    $("#notification-list").prepend(newNotification);
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


function showLoadingAnimation() {
    document.querySelector('.loader-wrapper').style.display = 'block';
}

// Ẩn animation loading khi tác vụ hoàn thành
function hideLoadingAnimation() {
    document.querySelector('.loader-wrapper').style.display = 'none';
}
