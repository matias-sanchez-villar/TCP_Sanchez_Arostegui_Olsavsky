function validateForm() {
    let nombre = document.getElementById("Nombre").value;

    if (nombre === "" || nombre.length > 1) {
        alert("Debe escribir un Nombre");
        return false;
    }

}

console.log(document.querySelector('#Nombre'));


function validateForm2() {
    let nombre = document.getElementById("Nombre").value;
    console.log(nombre);
    if (nombre === "" || nombre.length < 1) {

        alert("Debe escribir un Nombre");
        return false;

    }
    return true
}
