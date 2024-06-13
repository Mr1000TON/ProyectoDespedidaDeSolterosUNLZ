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
