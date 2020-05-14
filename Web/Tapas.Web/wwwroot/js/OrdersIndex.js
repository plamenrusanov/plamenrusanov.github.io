
var audio = document.getElementById('audio');
function playMusic() { audio.play(); };
function stopMusic() { audio.currentTime = 0; audio.pause(); };

function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    // add a zero in front of numbers<10
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('time').innerHTML = h + ":" + m + ":" + s;
    t = setTimeout(function () {
        startTime()
    }, 500);
}



var connection = null;
setupConnection = () => {
    connection = new signalR.HubConnectionBuilder().withUrl("/orderHub").build();

    connection.on("NewOrder", function (id) { insertOrder(id); playMusic(); });

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

setupConnection();

function insertOrder(id) { var li = document.createElement("li"); li.className = "btn btn-danger btn-lg"; li.setAttribute("onclick", `orderDetails(${id})`); li.id = `li${id}`; li.style.width = "100%"; var h5 = document.createElement("h5"); h5.textContent = `Поръчка: ${id}`; li.appendChild(h5); var list = document.getElementById("listOrders"); list.insertBefore(li, list.childNodes[0]); };

function cStatus(status, order, setTime) { connection.invoke("ChangeStatus", status, order, setTime); };

function changeStatus(status) {
    var order = document.getElementById("order").innerHTML;
    var setTime = document.getElementById('theInput').value;
    alert(setTime);
    cStatus(status, order, setTime);
};

function orderDetails(orderId) {
    $.ajax({
        url: `/Orders/Details?orderId=${orderId}`,
        cache: false,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}

function minus() {
    var input = document.getElementById('theInput');
    if (input.value > 30) {
        input.value = parseInt(input.value, 10) - 5;
    }
}

function plus() {
    var input = document.getElementById('theInput');
    if (input.value < 100) {
        input.value = parseInt(input.value, 10) + 5;
    }
}
