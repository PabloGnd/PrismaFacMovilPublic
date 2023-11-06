$(function MyFunction() {
    $(document).on("click", "a.producto", function () {
        var myModalProducto = new bootstrap.Modal(document.getElementById("ModalProducto"), {});
        var intIdFactura = $(this).attr("name");
        
        $.ajax({
            type: "POST",
            url: "ConsultaProducto",
            dataType: "json",
            data: { IdFactura: intIdFactura },
            success: function (response) {
                var descuento = 0;
                var contenidoProducto = '';
                $("#ProductoView").html("");
                

                $.each(response.value, function (index, value) {
                    if (value.porcentajeDescuento == 0) {
                        
                        contenidoProducto += '<div class="partner-page-desciption"><div class="partner-page-img-sec bg-blck" ><h3 class="round-txt-part-page"> ' + value.nemonico + '</h3></div><div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page">' + value.descripcion + '</h4><h5 class="offcial-subtitle-part-page">Precio: ' + value.precioUnitario + '$</h5><h5 class="offcial-subtitle-part-page">Descuento: 0$</h5></div></div></div >';

                    } else {
                        DescuentoProducto = (value.precioUnitario * (value.porcentajeDescuento * 0.01));
                        descuento = value.precioUnitario - (value.precioUnitario * (value.porcentajeDescuento * 0.01));
                        contenidoProducto += '<div class="partner-page-desciption"><div class="partner-page-img-sec bg-blck" ><h3 class="round-txt-part-page"> ' + value.nemonico + '</h3></div><div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page">' + value.descripcion + '</h4><h5 class="offcial-subtitle-part-page">Precio: ' + value.precioUnitario + '$</h5><h5 class="offcial-subtitle-part-page">Descuento: ' + DescuentoProducto +'$</h5></div></div></div >';
                    }

                });

                $("#ProductoView").html(contenidoProducto);

                myModalProducto.show();
            },
            error: function (req, status, error) {

            }
        });
        
    });
    $("#BuscarFacturas").click(function () {
        
        $('#offcanvas').offcanvas('show');

    });

    $(document).on("change", "input.Fecha", function () {
        alert('entro');
    });
});