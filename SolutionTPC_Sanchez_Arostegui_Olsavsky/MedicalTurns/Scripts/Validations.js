


function validateForm() {
    var nombre = document.getElementById("Nombre").value;
    var apellido = document.getElementById("Apellido").value;
    var nacimiento = document.getElementById("Nacimiento").value;
    const fecha = new Date(nacimiento); //+ " 00:00"
    const hoy = new Date();


    if (nombre === "" || nombre.length < 1) {
        alert("Debe escribir un Nombre");
        return false;
    }
    if (apellido === "" || apellido.length < 1) {
        alert("Debe escribir un Apellido");
        return false;
    }
    if (fecha > hoy) {
        alert("Debe ingresar una fecha válida");
        return false;
    }

}


