var connection = null;

$(document).ready(() => setupConnection());


function setupConnection(){
    connection = new signalR.HubConnectionBuilder().withUrl("/userOrdersHub").build();

    connection.on("UserAlertMessage", function (message) { alert(message); });

    connection.on("UserStatusChanged", function (order, status) {       
            var li = document.getElementById(`li${order}`);
            if (status === "Unprocessed") {
                li.className = "btn btn-danger btn-lg";
            } else if (status === "Processed") {
                li.className = "btn btn-warning btn-lg";
            } else if (status === "OnDelivery") {
                li.className = "btn btn-success btn-lg";
            } else if (status === "Delivered") {
                li.className = "btn btn-info btn-lg";
            }
            li.click();
            playMusic();       
    });

    connection.on("UserFinished", function () { connection.stop(); });

    connection.start().catch(err => console.error(err.toString()));
};

function playMusic() {
    var audio = document.getElementById("audio");
    audio.play();
}

function orderDetails(orderId) {
    $.ajax({
        url: `/Orders/UserOrderDetails?orderId=${orderId}`,
        cache: false,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}
