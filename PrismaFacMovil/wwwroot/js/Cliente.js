$(document).ready(function () {
    var Identificacion = 1;
    var Apellidos = 0;
    var Nombres = 0;
    
    $("#BuscarCliente").click(function () {
        
        $('#offcanvas').offcanvas('show');

    });

    $("#select-lang2").click(function () {
        var contenido = '';
        Apellidos = 1;
        Nombres = 0;
        Identificacion = 0;
        $("#IdentificacionInput").hide();
        contenido = '<div class="form-sec mt-16" id="NombreInput"><input type = "text" class="form-control" placeholder = "Nombres" aria - label="inputBuscar" name = "inputBuscar" id="inputBuscarNombre" aria - describedby="inputGroupPrepend" ><div class="form_bottom_boder"></div></div>'
        $("#PresentarInput").html(contenido);

    });
    $("#select-lang1").click(function () {
        var contenido = '';
        Identificacion = 1;
        Nombres = 0;
        Apellidos = 0;
        $("#NombreInput").hide();
        $("#ApellidoInput").hide();
        contenido = '<div class="form-sec mt-16" id="IdentificacionInput"><input type = "number" class="form-control" placeholder = "Identificacion" aria - label="inputBuscar" name = "inputBuscar" id="inputBuscarIdentificacion" aria - describedby="inputGroupPrepend" ><div class="form_bottom_boder"></div></div>'
        $("#PresentarInput").html(contenido);
    });
    $("#select-lang3").click(function () {
        var contenido = '';
        Nombres = 1;
        Identificacion = 0;
        Apellidos = 0;
        $("#IdentificacionInput").hide();
        $("#NombreInput").hide();
        contenido = '<div class="form-sec mt-16" id="ApellidoInput"><input type = "text" class="form-control" placeholder = "Apellidos" aria - label="inputBuscar" name = "inputBuscar" id="inputBuscarApellidoInput" aria - describedby="inputGroupPrepend" ><div class="form_bottom_boder"></div></div>'
        $("#PresentarInput").html(contenido);
    });

    $("#btnBuscar").click(function () {
        var strIdentificacion = $("#inputBuscarIdentificacion").val();
        var strNombre = $("#inputBuscarNombre").val();
        var strApellido = $("#inputBuscarApellido").val();
        
        $.ajax({
            type: "POST",
            url: "ObtenerIdentificacionApellidoNombre",
            dataType: "json",
            data: { strIdentificacion: strIdentificacion, strApellido: strApellido, strNombre: strNombre },
            success: function (response) {
                var contenido = '';
                console.log(response.value);
                if (response.value == null) {

                } else {
                    $("#Cliente").hide();
                    $('#offcanvas').offcanvas('hide');
                    $.each(response.value, function (index, value) {
                        contenido += '<div class="partner-page-details  mt-16"><div class="partner-page-desciption"><div class="partner-page-img-sec bg-blck"><h3 class="round-txt-part-page">' + value.inicialApellido + '' + value.inicialNombre + '</h3></div><div class="partner-page-content"><div class="partner-page-content-full"><h4 class="offcial-title-part-page" > ' + value.nombre1 + ' ' + value.apellido1 + '</h4><h5 class="offcial-subtitle-part-page" >' + value.identificacion + '</h5></div><div class="col cliente2 p-1"><a class="nav-link px-0 align-middle " href="/Cliente/ObtenerCliente?IdCliente=' + value.idCliente + '"><i class="fa-solid fa-pen"></i></a></div></div></div ></div>'

                    });
                }
                $("#DetalleCliente").html(contenido);
            },
            error: function (req, status, error) {

            }
        });
    });

    var myModal = new bootstrap.Modal(document.getElementById("cliente-existenteModal"), {});
    document.onreadystatechange = function () {
        myModal.show();
    };
});