document.getElementById('fetchServicios').addEventListener('click', () => {
    fetch('https://localhost:7282/ControladorServicio/ObtenerServicios')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log(data);
            const serviciosList = document.createElement('ul');
            data.forEach(servicio => {
                const servicioItem = document.createElement('li');
                servicioItem.textContent = `${servicio.idServicio} - ${servicio.descripcion}`;
                serviciosList.appendChild(servicioItem);
            });
            document.getElementById('resultServicios').innerHTML = '';
            document.getElementById('resultServicios').appendChild(serviciosList);
        })
        .catch(error => console.error('Error:', error));
});
