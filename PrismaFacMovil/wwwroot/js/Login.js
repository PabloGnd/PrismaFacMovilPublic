$(document).ready(function () {
    
      $("#FrmLogin").submit(function (e) {
          
          if (!validate_Usuario()) {
              $("#validacionNickName").show();
              return false;
          }else if(!validate_Contracena()){
            $("#validacionNickName").hide();
            $("#validacionpassword").show();
            return false;
          }
           else { event.target.submit(); }
         
    });
    
    function validate_Usuario(){
        var validate = true;
        var valor = document.getElementById("NickName").value;
        if(valor.length > 0){
            validate = true;
        }else{
            validate = false;
        }
        return validate;

    }
    function validate_Contracena(){
        var validate = true;
        var valor = document.getElementById("password").value;
        if(valor.length > 0){
            validate = true;
        }else{
            validate = false;
        }
        return validate;

    }
    var myModal = new bootstrap.Modal(document.getElementById("loginModal"), {});
                                document.onreadystatechange = function () {
                            
                                myModal.show();
                            
                            };
            
          
  });
  