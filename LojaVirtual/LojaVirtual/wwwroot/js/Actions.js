$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Tem certeza que deseja realizar esta operacao?");

        if (resultado == false) {
            e.preventDefault();
        }        
    });
});