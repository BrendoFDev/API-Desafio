const inputMarca = document.getElementById("inputMa");
const inputModelo = document.getElementById("inputMo");
const inputAnoF = document.getElementById("inputAF");
const inputCor = document.getElementById("inputC");
const inputPreco = document.getElementById("inputP");
//EDITAR CARRO MODAL
const inputEditMarca = document.getElementById("inputEditMa");
const inputEditModelo = document.getElementById("inputEditMo");
const inputEditAnoF = document.getElementById("inputEditAF");
const inputEditCor = document.getElementById("inputEditC");
const inputEditPreco = document.getElementById("inputEditP");
const editcarro = document.getElementById("editCarro");

const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const editCarroModal = document.getElementById("btnEditar");
const modalview = document.getElementById("staticBackdrop");
const divCarros = document.getElementById("divRenderCars");
const paginas = document.querySelectorAll(".page-item")
const voltar = document.getElementById("liVoltar");


const inputpage = document.getElementById("inputpage");

let dados = "";
let page = 1;
let carroSelecionado;

try {
    renderCarros(page);

    inputpage.addEventListener('change', () => {
        page = inputpage.value
        if (dados.proximaPagina < page) {
            renderCarros(page)
        }

    });


    adcarro.addEventListener('click', async () => {

        const marca = inputMarca.value;
        const modelo = inputModelo.value;
        const ano = inputAnoF.value;
        const cor = inputCor.value;
        const preco = inputPreco.value;

        if (!validacaoForm())
            return;

        const payload = {
            "marca": marca,
            "modelo": modelo,
            "ano": ano,
            "cor": cor,
            "preco": preco
        }


        const sendRequest = await fetch("https:localhost:7063/api/carro", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        });
    });

    divCarros.addEventListener('click', (event) => {
        const btnEditar = event.target.closest('.editar');
        if (btnEditar) {
            carroSelecionado = btnEditar.getAttribute("data-id");
        }
    });

    editcarro.addEventListener('click', async () => {

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


        const atualizar = await fetch(`https:localhost:7063/api/carro/${carroSelecionado}`, {
           method: 'PUT',
           headers: { 'Content-Type': 'application/json' },
           body: JSON.stringify(payload),
        });

        

        
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
    const requisicaoRender = await fetch(`https://localhost:7063/api/carro?paginaAtual=${page}&tamanhoPagina=10`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });

    dados = await requisicaoRender.json();

    let cardCarros = "";
    dados.items.forEach((item) => {

        cardCarros += `
            <div class="card mt-5 rounded-3 col-4" style="width: 18rem; background: #FFDEAD;" id='${item.id}'>
                <div class="card-body rounded-3">
                    <h3 class="card-title">${item.modelo}</h3>
                    <h6 class="card-subtitle mb-2 text-body-secondary">${item.marca}</h6>
                    <p class="card-text text-start fw-bold mb-1">Ano: ${item.ano}</p>
                    <p class="card-text text-start fw-bold mb-1">Cor: ${item.cor}</p>
                    <h3 class="card-title mb-3">R$ ${item.preco}</h3>
                    <div class="justify-content-between d-flex">
                        <button id="btnEditar" class="btn editar btn-warning fs-6 fw-bold rounded-pill" data-bs-toggle="modal" data-id=${item.id} data-bs-target="#modalEditar">Editar</button>
                        <button class="btn reservar btn-success fs-6 fw-bold rounded-pill">Reservar</button>
                    </div>
                </div>
            </div>
        `;
    });

    divCarros.innerHTML = cardCarros;
}

async function getCarros() {
    const requisicaoRender = await fetch(`https://localhost:7063/api/carro?paginaAtual=${page}&tamanhoPagina=10`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });

    dados = await requisicaoRender.json();
    return dados;
}