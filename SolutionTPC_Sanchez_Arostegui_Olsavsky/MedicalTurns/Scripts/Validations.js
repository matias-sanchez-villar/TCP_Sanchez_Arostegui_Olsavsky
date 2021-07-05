


//function validateForm() {
//    var nombre = document.getElementById("Nombre").value;
//    var apellido = document.getElementById("Apellido").value;
//    var nacimiento = document.getElementById("Nacimiento").value;
//    const fecha = new Date(nacimiento); //+ " 00:00"
//    const hoy = new Date();


//    if (nombre === "" || nombre.length < 1) {
//        alert("Debe escribir un Nombre");
//        return false;
//    }
//    if (apellido === "" || apellido.length < 1) {
//        alert("Debe escribir un Apellido");
//        return false;
//    }
//    if (fecha > hoy) {
//        alert("Debe ingresar una fecha válida");
//        return false;
//    }

//}

function validateText(str) {

    if (typeof (str) != 'string' && str.length == 0) {
        console.log('Error en validacion de textos')
        return false;
    }

    return true;
}

function validateEmail(email) {
    const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(String(email).toLowerCase());
}

function validateForm() {

    let validator = 0;

    validator += validateText(document.querySelector('#Nombre').textContent);

    validator += validateText(document.querySelector('#Apellido').textContent);

    validator += validateEmail(document.querySelector('#Email').textContent);

    validator == 0 ? return true : return false


}
