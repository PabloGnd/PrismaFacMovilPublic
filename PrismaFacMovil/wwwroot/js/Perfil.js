$(function MyFunction() {
    var miCheckbox = document.getElementById('flexSwitch');
    miCheckbox.addEventListener('click', function () {
        AplicaIva = false;
        if (miCheckbox.checked) {
            AplicaIva = true;
        } else {
            AplicaIva = false;
        }
        $.ajax({
            type: "POST",
            url: "EditarIva",
            data:
                { AplicaIva: AplicaIva },
            dataType: "json",
            success: function (data) {
                

            },
            error: function (request, status, errorThrown) {
                alert(status);
            }
        });
    });
});