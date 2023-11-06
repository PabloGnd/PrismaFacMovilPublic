$(function MyFunction() {
    DetalleFactura = [];
    lstProducto = [];
    var TotalConDescuento = 0;
    var Total = 0;
    var Iva = 0;
    var Descuento = 0;
    var Factura = '';
    var Producto = '';

    $(document).on("change", "input.BuscarProducto", function () {
        $("#validacionClienteExiste").hide();
        var TieneCantidad = 0;
        var strValorProducto = $("#txtBuscarProducto").val();
        $.ajax({
            type: "POST",
            url: "ObtenerNemonicoDescripcion",
            dataType: "json",
            data: { strDescripcion: strValorProducto },
            success: function (response) {
                var contenido = '';


                if (response.value == null) {
                    $("#validacionProductoExiste").show();
                    $("#txtBuscarProducto").val('');

                } else {


                    $.each(response.value, function (index, value) {
                        $.each(lstProducto, function (index, valor) {

                            if (value.idProducto == valor.IdProducto) {

                                contenido += '<div class="partner-page-desciption" ><div class="partner-page-img-sec bg-green"><h3 class="round-txt-part-page">' + value.nemonico + '</h3></div><div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page">' + value.descripcion + '</h4><h5 class="offcial-subtitle-part-page"> Precio' + value.precioUnitario + '</h5><h5 class="offcial-subtitle-part-page"> % Descuento' + value.porcentajeDescuento + '</h5></div></div><div class="quantity"><a href="javascript:void(0)" class="quantity__minus sub"><span><svg width="8" height="8" viewBox="0 0 8 2" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M1 1H7" stroke="#666666" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></span></a><input name="quantity" type="text" class="quantity__input Cantidad" value="' + valor.Cantidad + '" PrecioUnitario="' + value.precioUnitario + '" PorcentajeDescuento="' + value.porcentajeDescuento + '" Stok ="' + value.stok + '" IdProducto="' + value.idProducto + '" Descripcion="' + value.descripcion + '" Nemonico=" ' + value.nemonico + '"><a href="javascript:void(0)" class="quantity__plus add"><span><svg width="8" height="8" viewBox="0 0 8 8" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M1 4H7" stroke="#0EA5E9" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" /><path d="M4 7V1" stroke="#0EA5E9" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></span></a></div></div>'
                                TieneCantidad = 1;
                                
                            }


                        });
                        if (TieneCantidad == 0) {
                            contenido += '<div class="partner-page-desciption" ><div class="partner-page-img-sec bg-green"><h3 class="round-txt-part-page">' + value.nemonico + '</h3></div><div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page">' + value.descripcion + '</h4><h5 class="offcial-subtitle-part-page"> Precio' + value.precioUnitario + '</h5><h5 class="offcial-subtitle-part-page"> % Descuento' + value.porcentajeDescuento + '</h5></div></div><div class="quantity"><a href="javascript:void(0)" class="quantity__minus sub"><span><svg width="8" height="8" viewBox="0 0 8 2" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M1 1H7" stroke="#666666" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></span></a><input name="quantity" type="text" class="quantity__input Cantidad" value="0" PrecioUnitario="' + value.precioUnitario + '" PorcentajeDescuento="' + value.porcentajeDescuento + '" Stok ="' + value.stok + '" IdProducto="' + value.idProducto + '" Descripcion="' + value.descripcion + '" Nemonico=" ' + value.nemonico + '"><a href="javascript:void(0)" class="quantity__plus add"><span><svg width="8" height="8" viewBox="0 0 8 8" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M1 4H7" stroke="#0EA5E9" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" /><path d="M4 7V1" stroke="#0EA5E9" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg></span></a></div></div>'

                        } else {
                            TieneCantidad = 0;
                        }

                    });

                    $("#Producto").html('');
                    $("#DetalleProducto").html(contenido);
                    $("#txtBuscarProducto").val('');

                }

            },
            error: function (req, status, error) {

            }
        });

    });

    /*------------------------------------- Incerment Decrement -------------------------------------*/
    
    var myModalInsuficiente = new bootstrap.Modal(document.getElementById("ProductoInsuficiente"), {});
    $(document).on("click", "a.add", function () {
        
        DetalleFactura = [];
        /*lstProducto = [];*/
        var TotalConDescuento = 0;
        var SubTotal = 0;
        var Iva = 0;
        var SumaCantidad = 0;
        var Descuento = 0;
        if ($(this).prev().val() < 100) {
            $(this).prev().val(+$(this).prev().val() + 1);
        }

        $("input.Cantidad").each(function () {
            
            var Cantidad = $(this).val();
            var PrecioU = $(this).attr("PrecioUnitario");
            var PorcentajeD = $(this).attr("PorcentajeDescuento");
            var Stok = $(this).attr("Stok");
            var IdProducto = $(this).attr("IdProducto");
            var Descripcion = $(this).attr("Descripcion");
            var Nemonico = $(this).attr("Nemonico");
            
            if (Cantidad != 0) {
                if (Stok < parseFloat(Cantidad)) {
                    myModalInsuficiente.show();
                    $(this).val('1');
                    
                } else {
                    
                    Producto = {
                        "IdProducto": IdProducto,
                        "Descripcion": Descripcion,
                        "Nemonico": Nemonico,
                        "PrecioUnitario": PrecioU,
                        "PorcentajeDescuento": PorcentajeD,
                        "Stok": Stok,
                        "Cantidad": Cantidad,
                    }
                    
                    if (lstProducto == '') {
                        
                        lstProducto.push(Producto);
                    }
                    
                    $.each(lstProducto, function (index, valorProducto) {
                        
                        if (valorProducto.IdProducto == IdProducto) {
                            console.log(Cantidad);
                            lstProducto.splice(index, 1, Producto);
                            
                            
                        } else { 
                            lstProducto.push(Producto);
                            
                        }
                    });
                }
            }
        });
        
        $.each(lstProducto, function (index, valorPro) {
            
            var Cantidad = valorPro.Cantidad;
            var PrecioU = valorPro.PrecioUnitario;
            var PorcentajeD = valorPro.PorcentajeDescuento;
            var Stok = valorPro.Stok;
            var IdProducto = valorPro.IdProducto;
            var Descripcion = valorPro.Descripcion;
            var Nemonico = valorPro.Nemonico;
            if (PorcentajeD == 0) {
                SubTotal = PrecioU * Cantidad + SubTotal;
                TotalConDescuento = PrecioU * Cantidad + TotalConDescuento;
                SumaCantidad = SumaCantidad + parseFloat(Cantidad);
            } else {
                SubTotal = PrecioU * Cantidad + SubTotal;
                TotalConDescuento = ((PrecioU - (PrecioU * PorcentajeD * 0.01)) * Cantidad) + TotalConDescuento;
                SumaCantidad = SumaCantidad + parseFloat(Cantidad);
                Descuento = ((PorcentajeD * PrecioU * 0.01) * Cantidad) + Descuento;
            }
            TotalConDescuento = Number(TotalConDescuento.toFixed(2));
            Descuento = Number(Descuento.toFixed(2));
            Factura = {
                "Total": TotalConDescuento,
                "SubTotal": SubTotal,
                "TotalDescuento": Descuento,
            };
            obj1 = {
                "IdProducto": IdProducto,
                "Cantidad": Cantidad,
            }
            /*console.log(TotalConDescuento);*/
            DetalleFactura.push(obj1);
            contenido2 = '<p style="font-size: 11px">' + SumaCantidad + ' Productos </p> <p style="font-size: 12px"> <strong>Total: ' + TotalConDescuento + '$</strong> </p>'
            $("#DatosFactura").html(contenido2);
        });
    });
    $(document).on("click", "a.sub", function () {
        DetalleFactura = [];
        var TotalConDescuento = 0;
        var SubTotal = 0;
        var SumaCantidad = 0;
        var Descuento = 0;
        lstProducto = [];
        if ($(this).next().val() > 0) {
            if ($(this).next().val() > 0) $(this).next().val(+$(this).next().val() - 1);
        }
        $("input.Cantidad").each(function () {

            var Cantidad = $(this).val();
            var PrecioU = $(this).attr("PrecioUnitario");
            var PorcentajeD = $(this).attr("PorcentajeDescuento");
            var Stok = $(this).attr("Stok");
            var IdProducto = $(this).attr("IdProducto");
            var Descripcion = $(this).attr("Descripcion");
            var Nemonico = $(this).attr("Nemonico");
            if (Cantidad != 0) {
                if (Stok < parseFloat(Cantidad)) {
                    $(this).val('1');
                    alert("No hay suficiente producto");
                } else {

                    Producto = {
                        "IdProducto": IdProducto,
                        "Descripcion": Descripcion,
                        "Nemonico": Nemonico,
                        "PrecioUnitario": PrecioU,
                        "PorcentajeDescuento": PorcentajeD,
                        "Stok": Stok,
                        "Cantidad": Cantidad,
                    }
                    
                    if (lstProducto == '') {
                       
                        lstProducto.push(Producto);
                    }
                    
                    $.each(lstProducto, function (index, valorProducto) {

                        if (valorProducto.IdProducto == IdProducto) {
                            lstProducto.splice(index, 1, Producto);
                            
                        } else {
                            lstProducto.push(Producto);
                            
                        }
                    });
                }
            }
        });

        $.each(lstProducto, function (index, valorPro) {
            var Cantidad = valorPro.Cantidad;
            var PrecioU = valorPro.PrecioUnitario;
            var PorcentajeD = valorPro.PorcentajeDescuento;
            var Stok = valorPro.Stok;
            var IdProducto = valorPro.IdProducto;
            var Descripcion = valorPro.Descripcion;
            var Nemonico = valorPro.Nemonico;
            if (PorcentajeD == 0) {
                SubTotal = PrecioU * Cantidad + SubTotal;
                TotalConDescuento = PrecioU * Cantidad + TotalConDescuento;
                SumaCantidad = SumaCantidad + parseFloat(Cantidad);
            } else {
                SubTotal = PrecioU * Cantidad + SubTotal;
                TotalConDescuento = ((PrecioU - (PrecioU * PorcentajeD * 0.01)) * Cantidad) + TotalConDescuento;
                SumaCantidad = SumaCantidad + parseFloat(Cantidad);
                Descuento = ((PorcentajeD * PrecioU * 0.01) * Cantidad) + Descuento;
            }
            TotalConDescuento = Number(TotalConDescuento.toFixed(2));
            Descuento = Number(Descuento.toFixed(2));
            Factura = {
                "Total": TotalConDescuento,
                "SubTotal": SubTotal,
                "TotalDescuento": Descuento,
            };
            obj1 = {
                "IdProducto": IdProducto,
                "Cantidad": Cantidad,
            }
            DetalleFactura.push(obj1);
            contenido2 = '<p style="font-size: 11px">' + SumaCantidad + ' Productos </p> <p style="font-size: 12px"> <strong>Total: ' + TotalConDescuento + '$</strong> </p>'
            $("#DatosFactura").html(contenido2);
        });


    });
    var myModal = new bootstrap.Modal(document.getElementById("SeleccionarProducto"), {});
    $("#btnConcluirFactura").click(function () {
        if (DetalleFactura == '') {
            myModal.show();
        } else {
            $.ajax({
                type: "POST",
                url: "GuardarProducto",
                data:
                    { Factura: Factura, DetalleFactura: DetalleFactura, lstProducto: lstProducto },
                dataType: "json",
                success: function (data) {
                    console.log(data.value);

                    window.location.href = 'Resumen';


                },
                error: function (request, status, errorThrown) {
                    alert(status);
                }
            });
        }
        

    });

});