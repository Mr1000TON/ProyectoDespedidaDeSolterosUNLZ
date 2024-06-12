document.getElementById('fetchServicios').addEventListener('click', () => {
    console.log("Click");
    fetch('https://localhost:7282/ControladorPersona/ObtenerPersonas')
        .then(response => response.json())
        .then(data => {
            document.getElementById('resultServicios').textContent = JSON.stringify(data);
        })
        .catch(error => console.error('Error:', error));
}); 