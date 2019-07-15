    $("#btnIngresar").on("click", function () {
    if ($("#txtUsuario").val().trim() == "" || $("#txtPassword").val().trim() == "") {
        alert("Ingrese los campos requeridos");
        return;
    }

    $.ajax({
        contentType: "application/json; charset=utf-8",
        type: "POST",
        url: "@Url.Action("Login", "Home")",
        data: JSON.stringify( { usuario: $("#txtUsuario").val(), password: $("#txtPassword").val()}),
        success: function (data) {
            if(data == 1)
            {
                var returnUrl = "@Request.QueryString["ReturnUrl"]";

                if (returnUrl == "") {
                    window.location.href = "@Url.Action("Index","Home")";
                }
                else {
                    window.location.href = returnUrl;
                }
            }
            else {
                alert("Usuario y/o password incorrectos");
            }
        }
    });
});