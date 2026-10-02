const nome = document.getElementById("nome");
const cpf = document.getElementById("cpf");
const btnEnviar = document.getElementById("enviar");
const nomeEditar = document.getElementById("nomeEditar");
const cpfEditar = document.getElementById("cpfEditar");
const btnConfirmarEdicao = document.getElementById("enviarAtualizacao");
const tableExibirClientes = document.getElementById("exibirClientes");
const btnExcluirCliente = document.getElementById("comfirmarExcluir");
const inputPesquisa = document.getElementById("pesquisarCliente");
const btnPesquisar = document.getElementById("buscar");
//PAGINACAO
const inputpage = document.getElementById("inputpage");
const btnVoltar = document.getElementById("btnVoltar");
const btnAvancar = document.getElementById("btnAvancar");
const paginaInfo = document.getElementById("paginaInfo");

//GERAL
const spanAlertCadCliente = document.querySelector(".spanCadCliente");
const spanAlertRenderClientes = document.querySelector(".spanAlertRenderClientes");
const spanAlertExcluirCliente = document.querySelector(".spanAlertExcluirCliente");
const spanAlertEditarCliente = document.querySelector(".spanAlertEditarCliente");

let dados = "";
let page = 1;
let totalPaginas = 1;
let idClienteParaExcluir;
let idClienteParaEditar;
let nomeClienteParaEditar;
let cpfClienteParaEditar;


renderClientes();
btnEnviar.addEventListener('click', async () => {
    await cadCliente()
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

tableExibirClientes.addEventListener('click', (event) => {
    const btnExcluir = event.target.closest('.excluir');
    if (btnExcluir) {
        idClienteParaExcluir = btnExcluir.getAttribute('data-id');
        spanAlertExcluirCliente.textContent = "";
    }
    const btnEditar = event.target.closest('.editar');
    if (btnEditar) {
        idClienteParaEditar = btnEditar.getAttribute('data-id');
        nomeClienteParaEditar = btnEditar.getAttribute('data-nome');
        cpfClienteParaEditar = btnEditar.getAttribute('data-cpf');
        nomeEditar.value = nomeClienteParaEditar;
        cpfEditar.value = cpfClienteParaEditar;
        spanAlertExcluirCliente.textContent = "";
    }
});
btnExcluirCliente.addEventListener('click', async () => {
    await selecionarExcluirCliente()
});
btnConfirmarEdicao.addEventListener('click', async () => {
    await selecionarEditarCliente();
    nomeEditar.value = "";
    cpfEditar.value = "";
});

inputPesquisa.addEventListener('change', async () => {
    await pesquisar();
});
btnPesquisar.addEventListener('click', async () => {
    await pesquisar();
});


async function cadCliente() {

    const payload = {
        nome: nome.value,
        cpf: cpf.value
    }
    try {
        btnEnviar.setAttribute("disabled", "");
        btnEnviar.textContent = "Carregando...";

        const cadCliente = await fetch("https://localhost:7063/api/cliente", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
            body: JSON.stringify(payload),
            credentials: "include",
        });

        nome.value = "";
        cpf.value = "";

        if (!cadCliente.ok) {
            spanAlertCadCliente.textContent = "Não foi possível cadastrar este cliente.";
            return
        }
        const modal = bootstrap.Modal.getInstance(document.getElementById('modalCadCliente'));
        modal.hide();
        renderClientes();
    } catch (error) {
        console.log(error);
        throw error
    } finally {
        btnEnviar.textContent = "Confirmar"
        btnEnviar.removeAttribute("disabled");
    }
}
async function renderClientes(dadosRecebidos) {
    let dados;

    try {
        if (dadosRecebidos) {
            dados = dadosRecebidos;
        } else {

            spanAlertRenderClientes.textContent = "";

            const res = await fetch(`https://localhost:7063/api/cliente?paginaAtual=${page}&tamanhoPagina=10`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
                credentials: "include",
            });

            if (!res.ok) {
                spanAlertRenderClientes.textContent = "Erro ao buscar os Clientes!";
                inputPesquisa.setAttribute("disabled", "");
                btnPesquisar.setAttribute("disabled", "");
                return
            }
            dados = await res.json();

        }

        let cliente = "";
        dados.items.forEach((item) => {

            cliente += `
                    <tr>
                        <th scope="row">${item.id}</th>
                        <td class="text-center">${item.nome}</td>
                        <td class="d-flex justify-content-center gap-3">
                            <button class="btn btn-warning editar" data-bs-toggle="modal" data-bs-target="#modalEditarCliente" data-id="${item.id}" data-nome="${item.nome}" data-cpf="${item.cpf}">
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
                    </tr>`;
        });

        tableExibirClientes.innerHTML = cliente;
        atualizarPaginacao(dados);

    } catch (error) {
        console.log(error);
        throw error;
    }
}

function atualizarPaginacao(dadosApi) {
    totalPaginas = dadosApi.totalPagina;
    page = dadosApi.paginaAtual ?? page;

    if (inputpage) inputpage.value = page;

    if (paginaInfo) {
        paginaInfo.innerHTML = `<span> Página Atual: ${page} - Total de Páginas: ${totalPaginas} </span>`;
    }

    if (page <= 1) {
        btnVoltar.classList.add("disabled");
    } else {
        btnVoltar.classList.remove("disabled");
    }

    const proximaExiste = dadosApi.proximaPagina ?? dadosApi.ProximaPagina;
    if (!proximaExiste) {
        btnAvancar.classList.add("disabled");
    } else {
        btnAvancar.classList.remove("disabled");
    }
}
function mudarPagina() {
    const novaPagina = Number(inputpage.value);
    if (novaPagina > 0 && novaPagina <= totalPaginas) {
        page = novaPagina;
        renderClientes();
    } else {
        inputpage.value = page;
    }
}
function pagAnterior() {
    if (page > 1 && !btnVoltar.classList.contains("disabled")) {
        page = page - 1;
        renderClientes();
    }
}
function proxPagina() {
    if (page < totalPaginas && !btnAvancar.classList.contains("disabled")) {
        page++;
        renderClientes();
    }
}

async function selecionarExcluirCliente() {
    try {
        btnExcluirCliente.textContent = "Carregando...";
        btnExcluirCliente.setAttribute("disabled", "");

        if (!idClienteParaExcluir) return;

        const res = await fetch(`https://localhost:7063/api/cliente/${idClienteParaExcluir}`, {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
            credentials: "include",
        });

        if (!res.ok) {
            spanAlertExcluirCliente.textContent = "Erro ao editar esse cliente!"
            return
        }

        const modal = bootstrap.Modal.getInstance(document.getElementById('modalExcluirCliente'));
        modal.hide();
        renderClientes();

    } catch (error) {
        console.log(error);
        throw error
    } finally {
        btnExcluirCliente.classList.add("text-danger");
        btnExcluirCliente.classList.add("fw-bold");
        btnExcluirCliente.textContent = "Sim, excluir.";
        btnExcluirCliente.removeAttribute("disabled");
    }
}
async function selecionarEditarCliente() {
    try {
        btnConfirmarEdicao.textContent = "Carregando...";
        btnConfirmarEdicao.setAttribute("disabled", "");

        if (!idClienteParaEditar) return;

        const payload = {
            nome: nomeEditar.value,
            cpf: cpfEditar.value
        }

        const res = await fetch(`https://localhost:7063/api/cliente/${idClienteParaEditar}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
            credentials: "include",
            body: JSON.stringify(payload),
        });

        if (!res.ok) {
            spanAlertEditarCliente.textContent = "Erro ao editar cliente!"
            return
        }

        const modal = bootstrap.Modal.getInstance(document.getElementById('modalEditarCliente'));
        modal.hide();
        renderClientes();

    } catch (error) {
        console.log(error);
        throw error
    } finally {
        btnConfirmarEdicao.textContent = "Confirmar";
        btnConfirmarEdicao.removeAttribute("disabled");
    }
}

async function pesquisar() {
    try {
        const nomePesquisa = inputPesquisa.value.trim();
        if (!nomePesquisa) {
            renderClientes();
            return;
        }

        const res = await fetch(`https://localhost:7063/api/cliente?nome=${encodeURIComponent(nomePesquisa)}&paginaAtual=${page}&tamanhoPagina=10`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
            credentials: "include",
        });

        const dados = await res.json();

        if (dados.items) {
            spanAlertRenderClientes.textContent = "Cliente não encontrado!";
        }

        renderClientes(dados);

    } catch (error) {
        console.log(error);
        throw error
    }
}