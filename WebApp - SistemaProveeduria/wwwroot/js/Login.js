function LoginUser() {

    this.ViewName = "LoginView";
    this.ApiService = "Usuario";
    console.log("Instanciado")

    this.InitView = function () {
        //Asignacion del evento de clic del boton
        $("#btn-Login").click(function () {
            var login = new LoginUser();
            login.Login();
        });

        $("#btn-Recovery").click(function () {
            window.location.href = "https://localhost:7071/passwordrecovery";

        });

        $("#btnAtras").click(function () {
            window.location.href = "https://localhost:7071/Tenders";
        });
    }

    this.Login = function () {

        var user = {};
        user.Email = $("#txtEmail").val();
        user.Password = $("#txtPassword").val();


        console.log("User Login" + JSON.stringify(user));


        var ctrlActions = new ControlActions();

        var serviceRetrieveById = this.ApiService + "/RetrieveByLogin?email=" + user.Email + "&password=" + user.Password;

        ctrlActions.GetToApi(serviceRetrieveById, function (response) {
            if (response !== null && response !== undefined) {
                // Accede a la información de la respuesta aquí
                console.log(response);
                console.log(response.id);
                localStorage.setItem("idUsuario", response.id);
                window.location.href = "https://localhost:7071/Tenders";
            }
            else {
                console.log("No se pudo obtener el usuario");
            }
        });



    }
}

//Instanciamiento inicial de la clase
//Se ejecuta siempre al finalizar la carga de la vista.
$(document).ready(function () {
    var view = new LoginUser();
    view.InitView();
});