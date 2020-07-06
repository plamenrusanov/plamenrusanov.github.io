function displayDeliveryTax() {
    var el = document.getElementById(`btnDeliveryTax`);
    el.click();
}

function fChange(elm) {
    var adr = document.getElementById("addressDiv");
    var del = document.getElementById("deliveryDiv");
    var hr = document.getElementById("deliveryHr");
    var aId = document.getElementById("AddressId");
    if ($(elm).is(':checked')) {
        if (adr) {
            adr.style.display = "none";
        }
        if (del) {
            del.style.display = "none";
        }
        if (hr) {
            hr.style.display = "none";
        }
        if (aId) {
            aId.children[0].value = "1";
            aId.children[0].defaultSelected = true;
        }
    } else {
        if (adr) {
            adr.style.display = "flex";
        }
        if (del) {
            del.style.display = "inline-block";
        }
        if (hr) {
            hr.style.display = "block";
        }
        if (aId) {
            aId.children[0].value = "";
            aId.children[0].defaultSelected = false;
        }
    }
}