$(function MyFunction() {
    /*$('#FrmRegistro').attr('autocomplete', 'off');*/
    $(document).on("change", "input.Ruc", function () {

        var number = document.getElementById('ruc').value;
        var dto = number.length;
        var valor;
        var acu = 0;

        for (var i = 0; i < dto; i++) {
            valor = number.substring(i, i + 1);
            if (valor == 0 || valor == 1 || valor == 2 || valor == 3 || valor == 4 || valor == 5 || valor == 6 || valor == 7 || valor == 8 || valor == 9) {
                acu = acu + 1;
            }
        }
        if (acu == dto) {
            while (number.substring(10, 13) != 001) {
                $("#validacionRuc").show();
                $("#validacionVacio").hide();
                $("#ruc").val('');
                return;

            }
            $("#validacionVacio").hide();
            $("#validacionRuc").hide();
            RucInput = true;
        }
    });
    
    $(document).on("change", "input.RazonSocial", function () {

        var valor = document.getElementById("RazonSocial").value;
        if (valor.length > 0) {
            $("#validacionCamposRazonSocial").hide();
            
        } else {
            $("#validacionCamposRazonSocial").show();
        }



    });
    $(document).on("change", "input.Direccion", function () {

        var valor = document.getElementById("Direccion").value;
        if (valor.length > 0) {
            $("#validacionCamposDireccion").hide();
            
        } else {
            $("#validacionCamposDireccion").show();
        }
    });
    $(document).on("change", "input.Telefono", function () {

        var valor = document.getElementById("Telefono").value;
        if (valor.length > 0) {
            $("#validacionCamposTelefono").hide();

        } else {
            $("#validacionCamposTelefono").show();
        }
    });
    $(document).on("change", "input.ContraceñaCertificado", function () {

        var valor = document.getElementById("ContraceñaCertificado").value;
        if (valor.length > 0) {
            $("#validacionCamposCertificado").hide();
            
        } else {

            $("#validacionCamposCertificado").show();
        }
    });
    $(document).on("change", "input.ValidacionFile", function () {

        var selectedFile = document.getElementById('fileInput').value;
        var allowed_extensions = new Array("p12");
        var file_extension = selectedFile.split('.').pop();

        for (var i = 0; i < allowed_extensions.length; i++) {
            if (allowed_extensions[i] == file_extension) {
                ArchivoInput = true;
                $("#FormatoCorrecto").show();
                $("#validationFormato").hide();
                $("#validationArchivo").hide();
                el.innerHTML = "";
                return;
            }
        }
        $("#validationArchivo").hide();
        $("#FormatoCorrecto").hide();
        $("#validationFormato").show();
        document.getElementById('fileInput').value = '';
    });

    $("#FrmRegistro").submit(function (e) {
        e.preventDefault();
        var number = document.getElementById('ruc').value;
        var RazonSocial = document.getElementById("RazonSocial").value;
        var Direccion = document.getElementById("Direccion").value;
        var ContraceñaCertificado = document.getElementById("ContraceñaCertificado").value;
        var Archivo = $("#fileInput").val();

        if (number.length == 0) {
            $("#validacionVacio").show();
        } else if (RazonSocial.length == 0) {
            $("#validacionCamposRazonSocial").show();
        } else if (Direccion.length == 0) {
            $("#validacionCamposDireccion").show();
        } else if (ContraceñaCertificado.length == 0) {
            $("#validacionCamposCertificado").show();
        } else if (Archivo == '') {
            $("#validationArchivo").show();
        } else { event.target.submit(); }
        
        
    });
    var myModal = new bootstrap.Modal(document.getElementById("registroModal"), {});
    document.onreadystatechange = function () {
        myModal.show();
    };

});
