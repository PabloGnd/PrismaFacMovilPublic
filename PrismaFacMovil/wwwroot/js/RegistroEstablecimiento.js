$(function MyFunction() {


    $(document).on("change", "input.CodigoEstablecimiento", function () {

        alert('entro');
        var valor = document.getElementById("CodigoEstablecimiento").value;
        if (valor.length > 0) {
            $("#validacionCodigoEstablecimiento").hide();
        } else {
            $("#validacionCodigoEstablecimiento").show();
        }

    });
    $(document).on("change", "input.NombreEstablecimiento", function () {

        var valor = document.getElementById("NombreEstablecimiento").value;
        if (valor.length > 0) {
            $("#validacionNombreEstablecimiento").hide();
        } else {
            $("#validacionNombreEstablecimiento").show();
        }
  

    });
    $(document).on("change", "input.CodigoSucursal", function () {

        var validate = true;
        var valor = document.getElementById("CodigoSucursal").value;
        if (valor.length > 0) {
            $("#validacionCodigoSucursal").hide();
        } else {
            $("#validacionCodigoSucursal").show();
        }
    

    });
      $("#FrmEstablecimiento").submit(function (e) {
          e.preventDefault();
          var CodigoEstablecimiento = document.getElementById("CodigoEstablecimiento").value;
          var NombreEstablecimiento = document.getElementById("NombreEstablecimiento").value;
          var CodigoSucursal = document.getElementById("CodigoSucursal").value;
          if (CodigoEstablecimiento.length == 0) {
              $("#validacionCodigoEstablecimiento").show();
          } else if (NombreEstablecimiento.length == 0) {
              $("#validacionNombreEstablecimiento").show();
          } else if (CodigoSucursal == 0) {
              $("#validacionCodigoSucursal").show();
          } else { event.target.submit(); }
    });
});
  