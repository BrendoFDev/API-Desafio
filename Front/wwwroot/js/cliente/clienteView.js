const nome = document.getElementById("nome");
const cpf = document.getElementById("cpf");
const btnEnviar = document.getElementById("enviar");

const tableExibirClientes = document.getElementById("exibirClientes");
const btnExcluirCliente = document.getElementById("comfirmarExcluir");

//PAGINACAO
const inputpage = document.getElementById("inputpage");
const btnVoltar = document.getElementById("btnVoltar");
const btnAvancar = document.getElementById("btnAvancar");
const paginaInfo = document.getElementById("paginaInfo");

let dados = "";
let page = 1;
let totalPaginas = 1;

try {
    renderClientes()

    btnEnviar.addEventListener('click', async () => {

        const payload = {
            nome: nome.value,
            cpf: cpf.value
        }

        const cadCliente = await fetch("https://localhost:7063/api/cliente", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
            body: JSON.stringify(payload),
        });

    });

    btnAvancar.addEventListener('click', () => {
        proxPagina();
    });
    inputpage.addEventListener('change', () => {
        mudarPagina();
    });
    btnVoltar.addEventListener('click', () => {
        pagAnterior();
    });

    btnExcluirCliente.addEventListener('click', () => {
        selecionarExcluirCliente()
    });

} catch (err) {
    console.log(err);
}

async function renderClientes() {
    const getClientes = await fetch(`https://localhost:7063/api/cliente?paginaAtual=${page}&tamanhoPagina=10`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json; charset=utf-8' },
    });

    dados = await getClientes.json();

    let cliente = ""
    dados.items.forEach((item) => {

        cliente += `
            <tr>
                <th scope="row">${item.id}</th>
                <td class="text-center">${item.nome}</td>
                <td class="d-flex justify-content-center gap-3">
                    <button class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalEditarCliente">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                        </svg>
                    </button>
                    <button class="btn btn-danger excluir" data-bs-toggle="modal" data-bs-target="#modalExcluirCliente" data-id=${item.id}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                            <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                        </svg>
                    </button>
                </td>
            </tr>
        `

    });

    const totalPages = `
        <span> Página Atual: ${page} - Total de Páginas: ${dados.totalPagina} </span>
    `
    totalPaginas = dados.totalPagina;
    paginaInfo.innerHTML = totalPages;

    tableExibirClientes.innerHTML = cliente;
}

function mudarPagina() {
    const novaPagina = inputpage.value;
    if (novaPagina > 0 && novaPagina <= totalPaginas) {
        page = novaPagina;
        renderClientes(page);
    } else {
        inputpage.value = page;
    }
}
function pagAnterior() {
    if (page > 1) {
        page = page - 1;
        renderClientes(page);
    }
}
function proxPagina() {
    if (page < totalPaginas) {
        page++;
        renderClientes(page);
    }
}

async function selecionarExcluirCliente() {
    const btnModalExcluir = event.target.closest('.excluir');
    if (btnModalExcluir) {

        confirmacao = btnModalExcluir.getAttribute("data-id");


        const getClientes = await fetch(`https://localhost:7063/api/cliente/${comfirmacao}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
}