var user = {
    init: function () {
        user.registerEvents();
    },

    registerEvents: function () {
        var text = document.getElementById("error-message");
        text.innerHTML = "Begin";

        $("#btn-login").on("click", function (e) {
            e.preventDefault();
            text.innerHTML = "Loggin in...";
            $('.error-message').html("Logging in...");
            var data = {
                "username": $("#username").val(),
                "password": $("#password").val()
            }
            console.log(data);
            $.ajax({
                url: "/Home/SignIn",
                data: JSON.stringify(data),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    
                    if (response.status == true) {
                        alert("ok");
                    } else {
                        alert("no")
                    }

                }
            });
        });
    }
}
user.init();