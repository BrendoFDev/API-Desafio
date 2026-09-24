//GERAL
const tbReservas = document.getElementById("exibirReservas");
const btnExcluirReserva = document.getElementById("excluirReserva");

let reservaId;
let dados;

var token = localStorage.getItem("token").toString();

try {
    renderReservas();

    tbReservas.addEventListener('click', (event) => {
        const btnExcluir = event.target.closest('.excluir');
        if (btnExcluir) {
            reservaId = btnExcluir.getAttribute('data-id');
        }
    });

    btnExcluirReserva.addEventListener('click', () => {
        excluirReserva()
    });

} catch (err) {
    console.log(err)
}

async function renderReservas() {

    let tbodyReservas = "";

    const getReservas = await fetch('https://localhost:7063/api/reservas', {
        method: 'GET',
        headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
        credentials: "include",
    });

    const dados = await getReservas.json();

    dados.items.forEach((item) => {
        tbodyReservas += `
            <tr>
                <th scope="row">${item.id}</th>
                <td class="text-center">${item.nomeMarca}</td>
                <td class="text-center">${item.clienteId}</td>
                <td class="text-center">${item.nome}</td>
                <td class="text-center">16/09/2026</td>
                <td class="text-center">
                    <button class="btn btn-danger excluir" type="button" data-bs-toggle="modal" data-bs-target="#modalExcluirReserva" data-id=${item.id}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z" />
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z" />
                            <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z" />
                        </svg>
                    </button>
                </td>
            </tr>
        `;
    });

    tbReservas.innerHTML = tbodyReservas;
}  

async function excluirReserva() {

    if (!reservaId) {
        console.log("Err0!")
        return
    }

    const delReservas = await fetch(`https://localhost:7063/api/reservas/${reservaId}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
        credentials: "include",
    });

    if (delReservas.ok) {
        const modal = bootstrap.Modal.getInstance(document.getElementById('modalExcluirReserva'));
        modal.hide();
        renderReservas();
    }

}