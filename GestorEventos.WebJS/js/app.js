document.querySelectorAll('button[data-url]').forEach(button => {
    button.addEventListener('click', () => {
        const url = button.getAttribute('data-url');
        const target = button.getAttribute('data-target');
        const type = button.getAttribute('data-type');

        fetchDataAndDisplay(url, target, type);
    });
});

document.getElementById('localidadForm').addEventListener('submit', event => {
    event.preventDefault();

    document.querySelector("#resultLocalidades").innerHTML = "";
    const idLocalidad = document.getElementById('idLocalidad').value;
    const url = `https://localhost:7282/ControladorLocalidad/ObtenerLocalidad/${idLocalidad}`;
    fetchLocalidad(url, 'resultLocalidad');
});

function fetchDataAndDisplay(url, target, type) {
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('No se pudo conectar con la api');
            }
            return response.json();
        })
        .then(data => {
            console.log(data); // Necesito ver y controlar el json

            let html = '<ul class="fade-in">';
            data.forEach(item => {
                if (type === 'servicios') {
                    html += `
                        <li class="fade-in">
                            ${item.idServicio} - ${item.descripcion}
                            <div class="highlight">$${item.precioServicio}</div>
                        </li>
                    `;
                } else if (type === 'localidades') {
                    document.querySelector("#resultLocalidad").innerHTML = "";
                    html += `
                        <li class="fade-in">
                            ${item.idLocalidad} - ${item.nombreLocalidad}
                        </li>
                    `;
                }
            });
            html += '</ul>';

            const resultElement = document.getElementById(target);
            resultElement.innerHTML = '';
            resultElement.innerHTML = html;

            void resultElement.offsetWidth;
        })
        .catch(error => console.error('Error:', error));
}

function fetchLocalidad(url, target) {

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('No se pudo conectar con la api');
            }
            return response.json();
        })
        .then(data => {
            console.log(data);

            const resultElement = document.getElementById(target);
            resultElement.innerHTML = '';
            const html = `
                <ul class="fade-in">
                    <li class="fade-in">
                        ${data.idLocalidad} - ${data.nombreLocalidad}
                        <div class="highlight"></div>
                    </li>
                </ul>
            `;
            resultElement.innerHTML = html;
            void resultElement.offsetWidth;
        })
        .catch(error => console.error('Error:', error));
}

// nota 15 de junio: lo comento momentaneamente

// Variables globales
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
*//*
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
    formularios de registro o inicio de sesi�n
*//* 
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
*/