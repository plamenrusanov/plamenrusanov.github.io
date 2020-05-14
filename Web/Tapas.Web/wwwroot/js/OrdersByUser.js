var connection = null;
setupConnection = () => {
    connection = new signalR.HubConnectionBuilder().withUrl("/orderHub").build();

    connection.on("AlertMessage", function (message) { alert(message); });

    connection.on("StatusChanged", function (result, order, status) {
        if (result) {
            stopMusic();
            var li = document.getElementById(`li${order}`);
            if (status === "Unprocessed") {
                li.className = "btn btn-danger btn-lg";
            } else if (status === "Processed") {
                li.className = "btn btn-warning btn-lg";
                var timer = document.getElementById("#timer");
                timer.innerText = startTime();
                alert(startTime());
            } else if (status === "OnDelivery") {
                li.className = "btn btn-success btn-lg";
            } else if (status === "Delivered") {
                li.className = "btn btn-info btn-lg";
            }
        }
    });

    connection.on("Finished", function () { connection.stop(); });

    connection.start().catch(err => console.error(err.toString()));
};

var audio = document.getElementById('audio');
function playMusic() { audio.play(); };
function stopMusic() { audio.currentTime = 0; audio.pause(); };

function orderDetails(orderId) {
    $.ajax({
        url: `/Orders/UserOrder?orderId=${orderId}`,
        cache: false,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}
