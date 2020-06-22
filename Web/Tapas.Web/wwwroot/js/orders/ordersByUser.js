function orderDetails(orderId) {
    $.ajax({
        url: `/Orders/Details?orderId=${orderId}`,
        cache: false,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}

function changeStatus(status) {

    if (document.getElementById(`order`)) {
        var orderId = document.getElementById(`order`).innerText;

        $.ajax({
            url: `/Orders/ChangeStatus?orderId=${orderId}&status=${status}`,
            success: function (response) {
                var li = document.getElementById(`li${orderId}`);
                switch (status) {
                    case "Processed": li.className = "btn btn-warning"; break;
                    case "OnDelivery": li.className = "btn btn-success"; break;
                    case "Delivered": li.className = "btn btn-info"; break;
                    default: break;
                }
                li.click();
            }
        });
    }
   
}