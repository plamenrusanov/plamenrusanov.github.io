
function GetIndex() {
    for (i = 0; i < 100; i++) {
        var x = document.getElementsByName(`Sizes[${i}].SizeName`);
        if (x.length === 0) {
            GetSizeHtml(i);
            i = 100;
        }
    }
};

function GetSizeHtml(index) {
    $.ajax({
        url: `/Administration/Sizes/AddSizeModel?index=${index}`,
        success: function (response) {
            var list = document.getElementById("list");
            var li = document.createElement("li");
            li.className = "row form-row";
            li.style.borderBottom = "1px, solid, black;";
            li.id = `li${index}`;
            li.innerHTML = response;
            list.insertAdjacentElement('beforeEnd', li);
        }
    });
};

function Remove(id, position) {
    if (id !== 0) {
        $.ajax({
            url: `/Administration/Sizes/Remove?id=${id}`,
            success: function () {
                location.reload();
            }
        });
    } else {
        var li = document.getElementById(`li${position}`);
        li.parentNode.removeChild(li);

    }
};
