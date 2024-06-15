document.getElementById('fetchServicios').addEventListener('click', () => {
    fetch('https://localhost:7282/ControladorServicio/ObtenerServicios')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log(data); // Verifica la estructura de data en la consola
            const serviciosList = document.createElement('ul');
            data.forEach(servicio => {
                const servicioItem = document.createElement('li');
                servicioItem.textContent = `${servicio.idServicio} - ${servicio.descripcion}`;

                // Crear un div para el precio del servicio
                const precioDiv = document.createElement('div');
                precioDiv.textContent = `$${servicio.precioServicio}`;
                precioDiv.classList.add('precio-servicio'); // Agregar clase al div

                // Agregar el div de precio como hijo del servicioItem
                servicioItem.appendChild(precioDiv);

                serviciosList.appendChild(servicioItem);
            });

            document.getElementById('resultServicios').innerHTML = '';
            document.getElementById('resultServicios').appendChild(serviciosList);
        })
        .catch(error => console.error('Error:', error));
});

//Variables globales

// Se almacenan en las variables las clases y las Ids de las etiquetas
let inicio = document.querySelector(".inicio").classList;
let registro = document.querySelector(".registro").classList;
let formulario_validacion = document.getElementById("validacion_usuario").classList;
let formulario_registro = document.getElementById("registro_usuario").classList;
let parrafo_aux = document.querySelector(".aux")

////////////////////

/*
    Este metodo se encarga de obtener los datos del formulario,
    hacer la peticion a la api y validar el usuario en caso de inicio de sesion 
*/
document.getElementById('validacion_usuario').addEventListener("submit", function (evet) {

    //Evita que la web se recargue cuando se envia el formulario
    event.preventDefault();

    //Obtiene los datos cargados en el formulario
    const datoFormulario = new FormData(this);

    //Objeto que envia todos los datos a la API
    const inicio_sesion = {
        IdUsuario: 0,
        nombre_usuario: datoFormulario.get('usuario'),
        clave_usuario: datoFormulario.get('clave'),
        tipo_usuario: false
    };

    fetch('https://localhost:7282/ControladorUsuario/ValidarUsuario', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(inicio_sesion)
    })
        .then(response => response.text())
        .then(data => {
            console.log(data)
        })
        .catch(error => console.error('Error: ', error));

})

/*
    Este metodo se encarga de obtener los datos del formulario,
    hacer la peticion a la api y registrar el usuario en caso de registro
*/
document.getElementById('registro_usuario').addEventListener("submit", function (evet) {

    //Evita que la web se recargue cuando se envia el formulario
    event.preventDefault();

    //Obtiene los datos cargados en el formulario
    const datoFormulario = new FormData(this);

    //Objeto que envia todos los datos a la API
    const registro = {
        IdUsuario: 0,
        nombre_usuario: datoFormulario.get('usuario'),
        clave_usuario: datoFormulario.get('clave'),
        tipo_usuario: false
    };

    //Verifica si las claves de registro coinciden 
    if (datoFormulario.get('clave') === datoFormulario.get('clave_1')) {
        fetch('https://localhost:7282/ControladorUsuario/RegistrarUsuario', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(registro)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
            })
            .catch(error => console.error('Error: ', error));
    }
    else {
        parrafo_aux.classList.remove("desactivado")
        parrafo_aux.textContent = "Las claves no coinciden";
    }


})

/*  
    Esta funcion se encarga de modificar el documento
    para hacer aparecer o desaparecer los 
    formularios de registro o inicio de sesión
*/
function ModificarDOM(Id_btn) {

    // Espera a que un Id del boton genere el evento click
    document.getElementById(Id_btn).addEventListener("click", () => {

        // Agrega o saca la clase desactivado en las etiquetas para generar dinamismo en el documento 
        switch (Id_btn) {
            case "btn_ini":
                inicio.add("desactivado");
                formulario_validacion.remove("desactivado");

                registro.remove("desactivado");
                formulario_registro.add("desactivado")
                break;
            case "btn_reg":
                inicio.remove("desactivado");
                formulario_validacion.add("desactivado");

                registro.add("desactivado");
                formulario_registro.remove("desactivado")
                break;
        }

    })
}

// Se envian los Id de los botones como parametro 
ModificarDOM("btn_ini");
ModificarDOM("btn_reg");