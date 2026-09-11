//CAD CARRO MODAL
const btnCarro = document.getElementById("btnCarro");
let inputAnoF = document.getElementById("inputAF");
let inputCor = document.getElementById("inputC");
let inputPreco = document.getElementById("inputP");
const selectMarcaCarro = document.getElementById("marcasCarro");
const selectModeloCarro = document.getElementById("modelosCarro");
//EDIT CARRO MODAL
const inputEditAnoF = document.getElementById("inputEditAF");
const inputEditCor = document.getElementById("inputEditC");
const inputEditPreco = document.getElementById("inputEditP");
const editcarro = document.getElementById("editCarro");
//ADD MARCA CARRO MODAL
let inputMarca = document.getElementById("inputAddMod");
const btnAddMarca = document.getElementById("btnAddMarca");
//ADD MODELO CARRO MODAL
const selectMarca = document.getElementById("marcas");
let inputModelo = document.getElementById("inputAddModelo");
const btnModelo = document.getElementById("btnModelo");
const btnAddModelo = document.getElementById("btnAddModelo");
//GERAL
const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const editCarroModal = document.getElementById("btnEditar");
const modalview = document.getElementById("staticBackdrop");
const divCarros = document.getElementById("divRenderCars");

//PAGINACAO
const inputpage = document.getElementById("inputpage");
const btnVoltar = document.getElementById("btnVoltar");
const btnAvancar = document.getElementById("btnAvancar");
const paginaInfo = document.getElementById("paginaInfo");


let dados;
let page = 1;
let totalPaginas = 1;

try {
    renderCarros(page);
    adcarro.addEventListener('click', async () => {
        enviarCarro()
        inputAnoF.value = "";
        inputCor.value = "";
        inputPreco.value = "";
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

    divCarros.addEventListener('click', (event) => {
        selecionarCarro();
    });
    editcarro.addEventListener('click', () => {
        atualizarCarro();
    });

    btnAddMarca.addEventListener('click', () => {
        salvarMarca();
    });
    btnAddModelo.addEventListener('click', () => {
        salvarModelo();
    });
    btnModelo.addEventListener('click', () => {
        renderSelectMarca();
    });
    btnCarro.addEventListener('click', () => {
        renderSelectModelo();
    });
}
catch (err) {
    console.log(err);
}


function validacaoForm() {
    if (!formValidation.checkValidity()) {
        formValidation.classList.add('was-validated')
        const input = formValidation.querySelector(":invalid");
        input.focus();
        return false;
    };

    formValidation.classList.add('was-validated')
    return true;
}

async function renderCarros() {
    const requisicaoRender = await fetch(`https://localhost:7063/api/carro?pagina=${page}&itensPorPagina=10`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });

    dados = await requisicaoRender.json();


    let cardCarros = "";
    dados.items.forEach((item) => {

        cardCarros += `
            <div class="card mt-5 rounded-3 col-3" style="width: 18rem; background: #FFDEAD;">
                <div class="card-body rounded-3">
                    <h3 class="card-title">${item.nomeModelo}</h3>
                    <h6 class="card-subtitle mb-2 text-body-secondary" >${item.nomeMarca}</h6>
                    <p class="card-text text-start fw-bold mb-1" >Ano: ${item.ano}</p>
                    <p class="card-text text-start fw-bold mb-1" >Cor: ${item.cor}</p>
                    <h3 class="card-title mb-3" >R$ ${item.preco}</h3>
                    <div class="justify-content-between d-flex">
                        <button id="btnEditar" data-modelo=${item.modelo} data-marca=${item.marca} data-ano=${item.ano}  data-preco=${item.preco} class="btn editar btn-warning fs-6 fw-bold rounded-3" data-bs-toggle="modal" data-bs-target="#modalEditar">Editar</button>
                        <button class="btn reservar btn-success fs-6 fw-bold rounded-3" data-bs-toggle="modal" data-bs-target="#modalReserva">Reservar</button>
                    </div>
                </div>
            </div>
        `;
    });

    const totalPages = `
        <span> Página Atual: ${page} - Total de Páginas: ${dados.totalPagina} </span>
    `
    totalPaginas = dados.totalPagina;
    PageVarAvancar = dados.proximaPagina;
    paginaInfo.innerHTML = totalPages;
    divCarros.innerHTML = cardCarros;
}

async function enviarCarro() {
    const marca = selectModeloCarro.options[selectModeloCarro.selectedIndex].getAttribute("data-marcaId");
    const modelo = selectModeloCarro.value;
    const ano = inputAnoF.value;
    const cor = inputCor.value;
    const preco = inputPreco.value;

    if (!validacaoForm())
        return;

    const payload = {
        marcaId: marca,
        modeloId: modelo,
        ano: ano,
        cor: cor,
        preco: preco
    }

    const sendRequest = await fetch("https://localhost:7063/api/carro", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });

    if (sendRequest.ok) {
        const modal = bootstrap.Modal.getInstance(document.getElementById('staticBackdrop'));
        modal.hide();
        renderCarros(page);
    }
}

function mudarPagina() {
    const novaPagina = inputpage.value;
    if (novaPagina > 0 && novaPagina <= totalPaginas) {
        page = novaPagina;
        renderCarros(page);
    } else {
        inputpage.value = page;
    }
}
function pagAnterior() {
    if (page > 1) {
        page = page - 1;
        renderCarros(page);
    }
    if (page <= 1) {
        btnVoltar.classList.add("disabled");
        return
    }
    btnVoltar.classList.remove("disabled");
}
function proxPagina() {
    if (page < totalPaginas) {
        page++;
        renderCarros(page);
    }
    if (!PageVarAvancar) {
        btnAvancar.classList.add("disabled");
        return
    }
    btnAvancar.classList.remove("disabled");
}

function selecionarCarro() {
    const btnEditar = event.target.closest('.editar');
    if (btnEditar) {

        inputEditMarca.value = btnEditar.getAttribute("data-marca");
        inputEditModelo.value = btnEditar.getAttribute("data-modelo");
        inputEditAnoF.value = btnEditar.getAttribute("data-ano");
        inputEditCor.value = btnEditar.getAttribute("data-cor");
        inputEditPreco.value = btnEditar.getAttribute("data-preco");
    }
}
async function atualizarCarro() {
    const marca = inputEditMarca.value;
    const modelo = inputEditModelo.value;
    const ano = inputEditAnoF.value;
    const cor = inputEditCor.value;
    const preco = inputEditPreco.value;

    if (!validacaoForm())
        return;

    const payload = {
        marca: marca,
        modelo: modelo,
        ano: ano,
        cor: cor,
        preco: preco
    }


    const atualizar = await fetch(`https:localhost:7063/api/carro/${marca}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });
}

async function salvarMarca() {
    const marca = inputMarca.value

    const payload = {
        nomeMarca: marca,
    }

    const enviarMarca = await fetch(`https://localhost:7063/api/marca`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });

    inputMarca.value = "";

    if (enviarMarca.ok) {
        const modal = bootstrap.Modal.getInstance(document.getElementById('modalAdicionarMarca'));
        modal.hide();
    }
}
async function renderSelectMarca() {
    const requisicao = await fetch(`https://localhost:7063/api/marca`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });

    const data = await requisicao.json();

    let optionsMarcas = "<option selected disabled>Selecione uma marca</option>";
    data.items.forEach((item) => {

        optionsMarcas += `
            <option value=${item.id}>${item.nomeMarca}</option>
        `;
    });

    selectMarca.innerHTML = optionsMarcas;
}
async function salvarModelo() {
    const modelo = inputModelo.value
    const idMarca = selectMarca.value;

    const payload = {
        marcaId: idMarca,
        nomeModelo: modelo,
    }

    const enviarModelo = await fetch(`https://localhost:7063/api/modelo`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });

    inputModelo.value = "";

    if (enviarModelo.ok) {
        const modal = bootstrap.Modal.getInstance(document.getElementById('modalAdicionarModelo'));
        modal.hide();
    }
}

async function renderSelectModelo() {
    const requisicao = await fetch(`https://localhost:7063/api/modelo`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });

    const data = await requisicao.json();

    let optionsModelo = "<option selected disabled>Selecione um modelo</option>";
    data.items.forEach((item) => {

        optionsModelo += `
            <option data-marcaId=${item.marca.id} value=${item.id}>${item.nomeModelo}</option>
        `;
    });

    // let optionsMarcas = "<option selected disabled>Selecione uma marca</option>";
    // data.items.forEach((item) => {

    //     optionsMarcas += `
    //         <option value=${item.marca.id}>${item.marca.nomeMarca}</option>
    //     `;
    // });

    // selectMarcaCarro.innerHTML = optionsMarcas;

    selectModeloCarro.innerHTML = optionsModelo;
}