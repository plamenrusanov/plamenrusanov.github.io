
function SetDescription() {
    var itemId = document.getElementById("sciId").value;
    var message = document.getElementById("message-text").value;
    if (message.length <= 150) {
        $.ajax({
            url: `/ShopingCart/SetDescription?id=${itemId}&message=${message}`,
            success: function (responce) {
                var el = document.getElementById("closeModal");
                el.click();
            }

        });
    }
}


function GetDescription(itemId) {
    $.ajax({
        url: `/ShopingCart/GetDescription?id=${itemId}`,
        success: function (response) {
            var el = document.getElementById(`button${itemId}`);
            el.click();
            var elem = document.getElementById("message-text");
            elem.value = response;
            var productName = document.getElementById(`name${itemId}`).innerText;
            document.getElementById("exampleModalLongTitle").innerText = productName;
            var sciId = document.getElementById("sciId");
            sciId.value = itemId;
        }
    });
}

function displayDeliveryTax() {
    var el = document.getElementById(`btnDeliveryTax`);
    el.click();
}

var area = document.getElementById("message-text");
var message = document.getElementById("message");
var maxLength = 150;
var checkLength = function () {
    if (area.value.length <= maxLength) {
        message.innerHTML = `${area.value.length}/150`;
    }
}
setInterval(checkLength, 10);
