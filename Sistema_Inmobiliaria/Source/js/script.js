function mostrarContenido(opcion) {
    var contenido = document.getElementById("contenido");
    if (opcion === 'opcion1') {
        contenido.innerHTML = "<h2>Opción 1</h2><p>Contenido de la opción 1.</p>";
    } else if (opcion === 'opcion2') {
        contenido.innerHTML = "<h2>Opción 2</h2><p>Contenido de la opción 2.</p>";
    } else if (opcion === 'opcion3') {
        contenido.innerHTML = "<h2>Opción 3</h2><p>Contenido de la opción 3.</p>";
    }
}


function toggleSidebar() {
    var sidebar = document.getElementById("sidebar");
    sidebar.classList.toggle("sidebar-hidden");
}
