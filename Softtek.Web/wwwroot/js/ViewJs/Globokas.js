//Logout
$("#Logout").on("click", function () {
    var urlLogout = baseUrl + 'Login/Logout';

    Swal.fire({
        title: 'Confirmar?',
        text: "¿Está seguro de salir del sistema?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Salir'
    }).then((result) => {
        if (result.value) {
            window.location.href = urlLogout;
        }
    })
});