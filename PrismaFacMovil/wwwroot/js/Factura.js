$(function MyFunction() { 
    var Cliente = [];
    $(document).on("change", "input.Cliente", function () {
        $("#validacionClienteExiste").hide();

        var strValorCliente = $("#txtBuscarCliente").val();
        $.ajax({
            type: "POST",
            url: "ObtenerIdentificacion",
            dataType: "json",
            data: { strIdentificacion: strValorCliente },
            success: function (response) {
                var contenido = '';
                
                if (response.value == null) {
                    $("#validacionClienteExiste").show();
                    $("#txtBuscarCliente").val('');
                    
                } else {
                    $("#Cliente").hide();
                    contenido = '<div class="partner-page-details  mt-16 ClienteSelec" idCliente="' + response.value.IdCliente + '" Identificacion="' + response.value.identificacion + '" TipoIdentificacion="' + response.value.tipoIdentificacion + '" Nombre="' + response.value.nombre1 + '" Apellido="' + response.value.apellido1 + '" Direccion="' + response.value.direccionCliente + '" Correo="' + response.value.correo + '" Telefono="' + response.value.telefono + '"> <div class="partner-page-desciption"><div class="partner-page-img-sec bg-blck"> <h3 class="round-txt-part-page"> ' + response.value.inicialNombre + '</h3> </div> <div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page">' + response.value.nombre1 + '</h4><h5 class="offcial-subtitle-part-page">' + response.value.identificacion + '</h5></div></div></div></div > '
                    $("#DetalleCliente").html(contenido);
                    $("#txtBuscarCliente").val('');
                }

            },
            error: function (req, status, error) {

            }
        });
    });
    $(document).on("click", "div.ClienteSelec", function () {
        var contenido2 = '';
        var IdCliente = $(this).attr("IdCliente"); 
        var Identificacion = $(this).attr("Identificacion"); 
        var TipoIdentificacion = $(this).attr("TipoIdentificacion");
        var Apellido = $(this).attr("Apellido");
        var Direccion = $(this).attr("Direccion");
        var Correo = $(this).attr("Correo");
        var Telefono = $(this).attr("Telefono");
        var Nombre = $(this).attr("Nombre");
        contenido2 = '<a class="nav-link">' + Nombre + ' ' + Apellido + ' </a>'
        $("#NombreCliente").html(contenido2);
        Cliente = {
            "IdCliente": IdCliente,
            "TipoIdentificacion": String(TipoIdentificacion),
            "Identificacion": String(Identificacion),
            "Nombre1": String(Nombre),
            "Apellido1": String(Apellido),
            "DireccionCliente": String(Direccion),
            "Correo": String(Correo),
            "Telefono": String(Telefono),
        }
    });
    var myModal = new bootstrap.Modal(document.getElementById("SeleccionarCliente"), {});
    $("#ContinuarProducto").click(function () {
        if (Cliente == '') {
            myModal.show();
        } else {
            $.ajax({
                type: "POST",
                url: "Guardar",
                data: { Cliente: Cliente },
                dataType: "json",
                success: function (data) {
                    console.log(data.value);

                    window.location.href = 'ListaProducto';


                },
                error: function (request, status, errorThrown) {
                    alert(status);
                }
            }); }
       

    });

});