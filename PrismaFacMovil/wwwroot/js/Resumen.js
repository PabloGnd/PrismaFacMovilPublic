$(function MyFunction() {
    var AplicaIva = $("#AplicaIva").val();
    var SubTotal = $("#SubTotal").val();
    var TotalDescuento = $("#TotalDescuento").val();
    var ValorIva = 0;
    var Total = 0;
    if (AplicaIva == 'True') {
        ValorIva = SubTotal * 0.12;
        ValorIva = Number(ValorIva.toFixed(2));
        Total = parseFloat(SubTotal) + ValorIva;
        console.log(Total);
    } else {
        Total = SubTotal;
        ValorIva = 0;
    }
    contenido = '<p class="col-red">' + ValorIva + '</p>'
    $("#Iva").html(contenido);

    contenido1 = '<p class="col-black">' + Total + '</p>'
    $("#Total").html(contenido1);
});