$(document).ready(function () {
   
    $("#PopupRecarga").click(function () {

        $('#offcanvas').offcanvas('show');

    });
    $(document).on("change", "input.Valor", function () {

        var valor = document.getElementById("Valor").value;
        if (valor.length > 0) {
            $("#validacionValor").hide();

        } else {
            $("#validacionValor").show();
        }
    });
    $(document).on("change", "input.NumeroComprobante", function () {

        var valor = document.getElementById("NumeroComprobante").value;
        if (valor.length > 0) {
            $("#validacionNumeroComprobante").hide();

        } else {
            $("#validacionNumeroComprobante").show();
        }
    });
    $("#NuevaRecarga").click(function () {
        var intValorRecarga = document.getElementById("Valor").value;
        var intNumeroComprobante = document.getElementById("NumeroComprobante").value;
        if (intNumeroComprobante.length == 0) {
            $("#validacionNumeroComprobante").show();
        } else if (intValorRecarga.length == 0) {
            $("#validacionValor").show();
        } else {

            $.ajax({
                type: "POST",
                url: "GenerarRecarga",
                dataType: "json",
                data: { intNumeroComprobante: intNumeroComprobante, intValorRecarga: intValorRecarga },
                success: function (response) {
                    
                    window.location.href = 'Index';
                },
                error: function (req, status, error) {

                }
            });
        }

    });
});