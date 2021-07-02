function validateForm() {
    let nombre = document.getElementById("Nombre").value;

    if (nombre === "" || nombre.length > 1) {
        alert("Debe escribir un Nombre");
        return false;
    }


/*    COMENTARIO: ESTOS SON LOS INPUTS EN LOS QUE VOY A VALIDAR
               <label for="Nombre">Nombre: </label><br>
              <input type="text" id="Nombre" name="Nombre" value=""><br>
              <label for="Apellido">Apellido: </label><br>
              <input type="text" id="Apellido" name="Apellido" value=""><br>
              <label for="ID">ID: </label><br>
              <input type="text" id="ID" name="ID" value=""><br>
              <label for="IDUsuario">IDUsuario: </label><br>
              <input type="text" id="IDUsuario" name="IDUsuario" value=""><br>
              <label for="IDObraSocial">IDObraSocial: </label><br>
              <input type="text" id="IDObraSocial" name="IDObraSocial" value=""><br>
              <label for="FNacimiento">Fecha de Nacimiento: </label><br>
              <input type="text" id="FNacimiento" name="FNacimiento" value=""><br>
              <label for="Domicilio">Domicilio: </label><br>
              <input type="text" id="Domicilio" name="Domicilio" value=""><br>
              <label for="Celular">Celular: </label><br>
              <input type="text" id="Celular" name="Celular" value=""><br>
              <label for="Genero">Genero: </label><br>
              <input type="text" id="Genero" name="Genero" value=""><br>
              <label for="NroAfiliado">NroAfiliado: </label><br>
              <input type="text" id="NroAfiliado" name="NroAfiliado" value=""><br>
              */