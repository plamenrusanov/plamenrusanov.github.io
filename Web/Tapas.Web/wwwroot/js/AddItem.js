
function DisplaySizeName(sizeId) {
    var sizeName = document.getElementById(sizeId).innerHTML;
    document.getElementById("sizeName").innerHTML = sizeName;
}

function GetModel(sizeId) {
    DisplaySizeName(sizeId);
    $.ajax({
        url: `/Administration/Sizes/GetSizeModel?sizeId=${sizeId}`,
        success: function (response) {
            document.getElementById("detailSection").innerHTML = response;
        }
    });
}

function getPrice(str) {
    var index = str.indexOf(" ");
    str = str.substring(0, index);
    str = str.replace(",", ".");
    var number = parseFloat(str);
    return number;
}

function updateSubTotal(qty) {
    var productPrice = document.getElementById("productPrice").innerText;
    productPrice = getPrice(productPrice);
    var packagePrice = document.getElementById("packagePrice").innerText;
    packagePrice = getPrice(packagePrice);
    var maxProd = document.getElementById("maxProducts").innerText;
    maxProd = parseInt(maxProd);
    var subTotal = (productPrice * qty) + (Math.ceil(qty / maxProd) * packagePrice);
    subTotal = subTotal.toFixed(2);
    subTotal = subTotal.toString();
    subTotal = subTotal.replace(".", ",");
    document.getElementById("subTotal").innerHTML = `${subTotal} лв.`;
}

function minus() {
    var input = document.getElementById('theInput');
    if (input.value > 1) {
        input.value = parseInt(input.value, 10) - 1;
        updateSubTotal(input.value);
    }
}

function plus() {
    var input = document.getElementById('theInput');
    if (input.value < 10) {
        input.value = parseInt(input.value, 10) + 1;
        updateSubTotal(input.value);
    }
}