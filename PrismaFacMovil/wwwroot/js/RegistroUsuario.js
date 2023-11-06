$(function MyFunction() {
    var CorreoInput = false;
    var ContraceniaInput = false;

    $(document).on("change", "input.Correo", function () {

        let valCorreo = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
        var valorEmail = document.getElementById("Correo").value;
        if (valCorreo.test(valorEmail)) {
            $("#validacionCorreo").hide();
            $("#validacionCorreoVacio").hide();
            CorreoInput = true;
        } else {
            $("#validacionCorreoVacio").hide();
            $("#validacionCorreo").show();
        }
    });
    $(document).on("change", "input.Usuario", function () {

        var valor = document.getElementById("Usuario").value;
        if (valor.length > 0) {
            $("#validacionCamposRazonSocial").hide();
        } else {
            $("#validacionCamposRazonSocial").show();
        }



    });
    $(document).on("change", "input.Contrasena", function () {


        var patron = /^(?=(?:.*\d){1})(?=(?:.*[A-Z]){1})(?=(?:.*[a-z]){1})\S{8,}$/;
        var valorContrasenia = document.getElementById("Contrasena").value;

        if (valorContrasenia.length >= 8) {

            if (patron.test(valorContrasenia)) {
                $("#validacionContracena").hide();
                $("#validacionContracenaVacia").hide();
                $("#validacionContracenaCaracteres").hide();
                ContraceniaInput = true;
            } else {
                $("#validacionContracenaCaracteres").hide();
                $("#validacionContracena").show();
                $("#validacionContracenaVacia").hide();
            }
        }
        else {
            $("#validacionContracenaCaracteres").show();
        }



    });
    $(document).on("change", "input.ConfirmarContracena", function () {

        var valorconfirmPassword = $("#ConfirmarContracena").val();
        var valorpassword = $("#Contrasena").val();
        
        console.log(valorconfirmPassword);
        console.log(valorpassword);
        if (valorconfirmPassword == valorpassword) {

            $("#validacionConfirmarContracena").hide();
        } else {

            $("#validacionConfirmarContracena").show();
        }



    });
    $("#FrmUsuario").submit(function (e) {

        e.preventDefault();
        var valorEmail = document.getElementById("Correo").value;
        var valorContrasenia = document.getElementById("Contrasena").value;
        var valorconfirmPassword = document.getElementById("ConfirmarContracena").value;
        var valor = document.getElementById("Usuario").value;
        if (valorEmail.length == 0) {
            $("#validacionCorreoVacio").show();
        } else if (valorContrasenia.length == 0) {
            $("#validacionContracenaVacia").show();
        } else if (valor.length == 0) {
            $("#validacionUsuario").show();
        } else if (CorreoInput == false) {
            $("#validacionCorreo").show();
        } else if (ContraceniaInput == false) {
            $("#validacionContracena").show();
        }else { event.target.submit(); }
        

    });

});
