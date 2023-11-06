$(document).ready(function () {
  
    $("#BuscarProducto").click(function () {

        $('#offcanvas').offcanvas('show');

    });


    var myModal = new bootstrap.Modal(document.getElementById("cliente-existenteModal"), {});
    document.onreadystatechange = function () {

        myModal.show();

    };
});