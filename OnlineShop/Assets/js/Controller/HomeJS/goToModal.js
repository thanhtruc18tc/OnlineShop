var isInLoginModal = true;
var isLogin = false;
function showLoginModal() {
    $("#loginModal").modal("show");
    $("#signUpModal").modal("hide");
    isInLoginModal = !isInLoginModal;
}

function showRegistrationModal() {
    $("#loginModal").modal("hide");
    $("#signUpModal").modal("show");
    isInLoginModal = !isInLoginModal;
}
