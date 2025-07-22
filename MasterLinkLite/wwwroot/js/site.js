// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function filtrarTabla() {
            const input = document.getElementById("filtro");
    const filter = input.value.toLowerCase();
    const rows = document.querySelectorAll("table tbody tr");

            rows.forEach(row => {
                const nombre = row.cells[0].innerText.toLowerCase();
    const proposito = row.cells[1].innerText.toLowerCase();

    if (nombre.includes(filter) || proposito.includes(filter)) {
        row.style.display = "";
                } else {
        row.style.display = "none";
                }
            });
        }

function filtrar() {
    const input = document.getElementById("filtro");
    const filter = input.value.toLowerCase();
    const cards = document.querySelectorAll(".row .col");

    cards.forEach(card => {
        const titulo = card.querySelector(".card-title");
        const descripcion = card.querySelector(".card-text");

        // Obtener el texto del título
        const tituloText = titulo ? titulo.innerText.toLowerCase() : "";

        // Obtener el texto de la descripción (puede ser vacío)
        const descripcionText = descripcion ? descripcion.innerText.toLowerCase() : "";

        // Verificar si el filtro coincide con el título o la descripción
        if (tituloText.includes(filter) || descripcionText.includes(filter)) {
            card.style.display = "";
        } else {
            card.style.display = "none";
        }
    });
}