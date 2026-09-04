const nome = document.getElementById("nome");
const cpf = document.getElementById("cpf");
const btnEnviar = document.getElementById("enviar");

const tableExibirClientes = document.getElementById("exibirClientes");

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
                <th scope="row">${item.cpf}</th>
                <td class="text-start">${item.nome}</td>
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