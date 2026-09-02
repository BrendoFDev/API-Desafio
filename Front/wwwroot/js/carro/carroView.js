const inputMarca = document.getElementById("inputMa");
const inputModelo = document.getElementById("inputMo");
const inputAnoF = document.getElementById("inputAF");
const inputCor = document.getElementById("inputC");
const inputPreco = document.getElementById("inputP");

// EDITAR CARRO MODAL
const inputEditMarca = document.getElementById("inputEditMa");
const inputEditModelo = document.getElementById("inputEditMo");
const inputEditAnoF = document.getElementById("inputEditAF");
const inputEditCor = document.getElementById("inputEditC");
const inputEditPreco = document.getElementById("inputEditP");
const editcarro = document.getElementById("editCarro");

const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const divCarros = document.getElementById("divRenderCars");
const inputpage = document.getElementById("inputpage");
const btnPrevious = document.getElementById("btnPrevious");
const btnNext = document.getElementById("btnNext");
const paginaInfo = document.getElementById("paginaInfo");

const API_BASE = "https://localhost:7063/api/carro";
const TAMANHO_PAGINA = 10;

let dados;
let paginaAtual = 1;
let totalPaginas = 1;
let carroSelecionado;


try {
    renderCarros(paginaAtual);
    
    adcarro.addEventListener('click', adicionarCarro);
    editcarro.addEventListener('click', atualizarCarro);
    divCarros.addEventListener('click', selecionarCarro);
    inputpage.addEventListener('change', mudarPagina);
    btnPrevious.addEventListener('click', pagAnterior);
    btnNext.addEventListener('click', proxPagina);
} catch (err) {
    console.error("Erro ao inicializar:", err);
}


async function renderCarros(pagina = 1) {
    try {
        const requisicao = await fetch(
            `${API_BASE}?paginaAtual=${pagina}&tamanhoPagina=${TAMANHO_PAGINA}`,
            {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            }
        );

        if (!requisicao.ok) throw new Error('Erro ao buscar carros');
        
        dados = await requisicao.json();
        paginaAtual = dados.paginaAtual;
        totalPaginas = dados.totalPaginas || Math.ceil(dados.totalRegistro / TAMANHO_PAGINA);

        exibirCarros(dados.items);
        atualizarControlesPaginacao();

    } catch (err) {
        console.error("Erro ao renderizar carros:", err);
        mostrarMensagem("Erro ao carregar carros", "danger");
    }
}

function exibirCarros(carros) {
    let html = "";
    
    if (carros.length === 0) {
        divCarros.innerHTML = '<div class="col-12 text-center mt-5"><p class="fs-5">Nenhum carro encontrado</p></div>';
        return;
    }

    carros.forEach((item) => {
        html += `
            <div class="card h-100 shadow-sm rounded-3 col-12 col-sm-6 col-lg-4" style="background: linear-gradient(135deg, #fff9e6 0%, #ffe6cc 100%);" id="card-${item.id}">
                <div class="card-body d-flex flex-column">
                    <h5 class="card-title mb-1">${item.modelo}</h5>
                    <h6 class="card-subtitle mb-3 text-muted">${item.marca}</h6>
                    
                    <div class="flex-grow-1">
                        <div class="mb-2">
                            <small class="text-muted">Ano:</small>
                            <p class="mb-0 fw-bold">${item.ano}</p>
                        </div>
                        <div class="mb-2">
                            <small class="text-muted">Cor:</small>
                            <p class="mb-0 fw-bold">${item.cor}</p>
                        </div>
                        <div class="mb-3">
                            <small class="text-muted">Preço:</small>
                            <h5 class="text-success mb-0">R$ ${formatarPreco(item.preco)}</h5>
                        </div>
                    </div>

                    <div class="gap-2 d-flex">
                        <button 
                            class="btn btn-sm btn-warning flex-grow-1 fw-bold editar" 
                            data-bs-toggle="modal" 
                            data-bs-target="#modalEditar"
                            data-id="${item.id}"
                        >
                            ✎ Editar
                        </button>
                        <button class="btn btn-sm btn-success flex-grow-1 fw-bold">✓ Reservar</button>
                    </div>
                </div>
            </div>
        `;
    });

    divCarros.innerHTML = html;
}

function atualizarControlesPaginacao() {
    inputpage.value = paginaAtual;
    inputpage.max = totalPaginas;
    paginaInfo.textContent = `Página ${paginaAtual} de ${totalPaginas}`;
    
    btnPrevious.disabled = paginaAtual <= 1;
    btnNext.disabled = paginaAtual >= totalPaginas;
}

async function adicionarCarro() {
    if (!validacaoForm()) return;

    const payload = {
        marca: inputMarca.value,
        modelo: inputModelo.value,
        ano: inputAnoF.value,
        cor: inputCor.value,
        preco: inputPreco.value
    };

    try {
        const resposta = await fetch(API_BASE, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        });

        if (resposta.ok) {
            mostrarMensagem("Carro adicionado com sucesso!", "success");
            limparFormulario();
            bootstrap.Modal.getInstance(document.getElementById('staticBackdrop')).hide();
            renderCarros(1);
            console.log ("tipo")
        } else {
            mostrarMensagem("Erro ao adicionar carro", "danger");
            console.log("ndve")
        }
    } catch (err) {
        console.error("Erro:", err);
        mostrarMensagem("Erro ao adicionar carro", "danger");
        console.log("er")
    }
}

async function atualizarCarro() {
    if (!validacaoForm()) return;
    if (!carroSelecionado) {
        mostrarMensagem("Selecione um carro para editar", "warning");
        return;
    }

    const payload = {
        marca: inputEditMarca.value,
        modelo: inputEditModelo.value,
        ano: parseInt(inputEditAnoF.value),
        cor: inputEditCor.value,
        preco: parseFloat(inputEditPreco.value)
    };

    try {
        const resposta = await fetch(`${API_BASE}/${carroSelecionado}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        });

        if (resposta.ok) {
            mostrarMensagem("Carro atualizado com sucesso!", "success");
            bootstrap.Modal.getInstance(document.getElementById('modalEditar')).hide();
            renderCarros(paginaAtual);
            carroSelecionado = null;
        } else {
            mostrarMensagem("Erro ao atualizar carro", "danger");
        }
    } catch (err) {
        console.error("Erro:", err);
        mostrarMensagem("Erro ao atualizar carro", "danger");
    }
}

function selecionarCarro(event) {
    const btnEditar = event.target.closest('.editar');
    if (btnEditar) {
        carroSelecionado = btnEditar.getAttribute("data-id");
        carregarDadosEdicao(carroSelecionado);
    }
}

function carregarDadosEdicao(id) {
    const carro = dados.items.find(c => c.id == id);
    if (carro) {
        inputEditMarca.value = carro.marca;
        inputEditModelo.value = carro.modelo;
        inputEditAnoF.value = carro.ano;
        inputEditCor.value = carro.cor;
        inputEditPreco.value = carro.preco;
    }
}

function mudarPagina() {
    const novaPagina = parseInt(inputpage.value);
    if (novaPagina > 0 && novaPagina <= totalPaginas) {
        renderCarros(novaPagina);
    } else {
        inputpage.value = paginaAtual;
    }
}

function pagAnterior() {
    if (paginaAtual > 1) {
        renderCarros(paginaAtual - 1);
    }
}

function proxPagina() {
    if (paginaAtual < totalPaginas) {
        renderCarros(paginaAtual + 1);
    }
}

function validacaoForm() {
    const forms = document.querySelectorAll(".needs-validation");
    let valido = true;

    forms.forEach(form => {
        if (!form.checkValidity()) {
            form.classList.add('was-validated');
            const input = form.querySelector(":invalid");
            if (input) input.focus();
            valido = false;
        }
    });

    return valido;
}

function limparFormulario() {
    inputMarca.value = "";
    inputModelo.value = "";
    inputAnoF.value = "";
    inputCor.value = "";
    inputPreco.value = "";
    
    const form = document.querySelector("#staticBackdrop .needs-validation");
    form.classList.remove('was-validated');
}

function formatarPreco(preco) {
    return preco.toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

function mostrarMensagem(mensagem, tipo = "info") {
    const alerta = document.createElement('div');
    alerta.className = `alert alert-${tipo} alert-dismissible fade show`;
    alerta.role = "alert";
    alerta.innerHTML = `
        ${mensagem}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;
    
    const container = document.querySelector('.text-center');
    container.insertBefore(alerta, container.firstChild);
    
    setTimeout(() => {
        alerta.remove();
    }, 4000);
}
