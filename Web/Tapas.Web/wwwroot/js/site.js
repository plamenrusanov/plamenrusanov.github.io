
var audio = document.getElementById('audio');
function playMusic() { audio.play(); };
function stopMusic() { audio.currentTime = 0; audio.pause(); };



var connection = null;
setupConnection = () => {
    connection = new signalR.HubConnectionBuilder().withUrl("/orderHub").build();

    connection.on("NewOrder", function (id) { insertOrder(id); playMusic(); });

    connection.on("AlertMessage", function (message) { alert(message); });

    connection.on("StatusChanged", function (result, order) { if (result) { stopMusic(); var li = document.getElementById(`li${order}`); li.className = "btn btn-success btn-lg";  } });

    connection.on("Finished", function () { connection.stop(); });

    connection.start().catch(err => console.error(err.toString()));
};

setupConnection();

function insertOrder(id) { var li = document.createElement("li"); li.className = "btn btn-danger btn-lg"; li.setAttribute("onclick", `orderDetails(${id})`); li.id = `li${id}`; var h5 = document.createElement("h5"); h5.textContent = `Поръчка: ${id}`; li.appendChild(h5); var list = document.getElementById("listOrders"); list.insertBefore(li, list.childNodes[0]); };

function cStatus(status, order) { connection.invoke("ChangeStatus", status, order); };

function changeStatus() { var status = $("#statusValue").val(); var order = document.getElementById("order").innerHTML; cStatus(status, order);};

function orderDetails(orderId) {
    $.ajax({
        url: `/Orders/Details?orderId=${orderId}`,
        cache: false,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}
