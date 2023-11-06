$(document).ready(function () {
    
    var Facturas = 0;
    var FacturasConsumidas = 0;
    var FacturasSaldo = 0;
    var Porcentaje = 0;
    var Facturas = '';
    var Consumo = '';
    var Saldo = '';
    $.ajax({
        type: "POST",
        url: "ConsultaRecarga",
        dataType: "json",
        data: {  },
        success: function (response) {
            Facturas = response.value.numeroFacturas;
            FacturasConsumidas = response.value.numeroFacturasConsumidas;
            FacturasSaldo = response.value.numeroFacturasSaldo;
            
            Porcentaje = (FacturasSaldo * 100) / Facturas;
            
            let circularProgress = document.querySelector(".circular-progress"),
                progressValue = document.querySelector(".progress-value");

            let progressStartValue = 0,
                progressEndValue = Porcentaje,
                speed = 10;

            let progress = setInterval(() => {
                progressStartValue++;

                progressValue.textContent = `${FacturasSaldo}`
                circularProgress.style.background = `conic-gradient(#7d2ae8 ${progressStartValue * 3.6}deg, #ededed 0deg)`

                if (progressStartValue == progressEndValue) {
                    clearInterval(progress);
                }
            }, speed);
            Facturas = '<p1>' + response.value.numeroFacturas + '<p1>';
            Consumo = '<p1>' + response.value.numeroFacturasConsumidas + '<p1>';
            Saldo = '<p1>' + response.value.numeroFacturasSaldo + '<p1>';
            $("#Consumo").html(Consumo);
            $("#Saldo").html(Saldo);
            $("#Recarga").html(Facturas);
        },
        error: function (req, status, error) {

        }
    });
    
    
    
    
});