//CAD CARRO MODAL
const btnCarro = document.getElementById("btnCarro");
let inputAnoF = document.getElementById("inputAF");
let inputCor = document.getElementById("inputC");
let inputPreco = document.getElementById("inputP");
const selectMarcaCarro = document.getElementById("marcasCarro");
const selectModeloCarro = document.getElementById("modelosCarro");

//EDIT CARRO MODAL
const input = document.getElementById('imagemInput');
const fileName = document.getElementById('fileName');
const inputEditAnoF = document.getElementById("inputEditAF");
const inputEditCor = document.getElementById("inputEditC");
const inputEditPreco = document.getElementById("inputEditP");
const btnEditCarro = document.getElementById("editCarro");

const btnEnviarImg = document.getElementById("btnEnviarImg");
const inputImg = document.getElementById("imagemInputI");
const spanFileName = document.getElementById("fileName");
const btnAbrirModalImg = document.getElementById("modalAddImg");

//ADD MARCA CARRO MODAL
let inputMarca = document.getElementById("inputAddMod");
const btnAddMarca = document.getElementById("btnAddMarca");

//ADD MODELO CARRO MODAL
const selectMarca = document.getElementById("marcas");
let inputModelo = document.getElementById("inputAddModelo");
const btnModelo = document.getElementById("btnModelo");
const btnAddModelo = document.getElementById("btnAddModelo");

//RESERVAR
const cpfInput = document.getElementById("inputReserva");
const btnReservar = document.getElementById("btnReserva");

//EXCLUIR
const btnExcluir = document.getElementById("btnExcluir");
const excluir = document.getElementById("excluir");

//GERAL
const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const editCarroModal = document.getElementById("btnEditar");
const modalview = document.getElementById("staticBackdrop");
const divCarros = document.getElementById("divRenderCars");
const inputCPF = document.getElementById('inputReserva');

//IMG
const btnExcluirIMG = document.getElementById("btnExcluirIMG");
const btnEditarIMG = document.getElementById("btnEditarIMG");
const deletarIMG = document.getElementById("deletar");

//SPAN
const spanAlert = document.querySelector(".spanAlertCarros");
const spanAlertCad = document.querySelector(".spanAlertCad");
const spanAlertEdit = document.querySelector(".spanAlertEdit");
const spanAlertExcluirCarro = document.querySelector(".spanAlertExcluirCarro");
const spanAlertAddMarca = document.querySelector(".spanAlertAddMarca");
const spanAlertEnviarModelo = document.querySelector(".spanAlertEnviarModelo");
const spanAlertReserva = document.querySelector(".spanAlertReserva");
const spanAlertEnviarImagem = document.querySelector(".spanAlertEnviarImagem");
const spanAlertRenderImagem = document.querySelector(".spanAlertRenderImagem");
const spanAlertExcluirImagens = document.querySelector(".spanAlertExcluirImagens");

//PAGINACAO
const inputpage = document.getElementById("inputpage");
const btnVoltar = document.getElementById("btnVoltar");
const btnAvancar = document.getElementById("btnAvancar");
const paginaInfo = document.getElementById("paginaInfo");

let dados;
let page = 1;
let totalPaginas = 1;
let idCarro;
let idIMG;
let carouselItemsHTML = "";

//--------- FUNÇÕES -----------

//RENDERIZAÇÕES
async function renderCarros(page) {
    try {
        const requisicaoRender = await fetch(`https://localhost:7063/api/carro?pagina=${page}&tamanhoPagina=9`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            credentials: "include",
        });

        dados = await requisicaoRender.json();

        let cardCarros = "";

        for (const item of dados.items) {
            let precoAPI;
            // 1. Reseta a variável do HTML do carrossel para cada carro!
            let carouselItemsHTML = "";

            const altImagem = "data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%22208%22%20height%3D%22225%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%220%200%20208%20225%22%20preserveAspectRatio%3D%22none%22%3E%3Cdefs%3E%3Cstyle%20type%3D%22text%2Fcss%22%3E%23holder_1a091a20952%20text%20%7B%20fill%3A%23eceeef%3Bfont-weight%3Abold%3Bfont-family%3AArial%2C%20Helvetica%2C%20Open%20Sans%2C%20sans-serif%2C%20monospace%3Bfont-size%3A11pt%20%7D%20%3C%2Fstyle%3E%3C%2Fdefs%3E%3Cg%20id%3D%22holder_1a091a20952%22%3E%3Crect%20width%3D%22208%22%20height%3D%22225%22%20fill%3D%22%2355595c%22%3E%3C%2Frect%3E%3Cg%3E%3Ctext%20x%3D%2266.9453125%22%20y%3D%22117.3%22%3EThumbnail%3C%2Ftext%3E%3C%2Fg%3E%3C%2Fg%3E%3C%2Fsvg%3E";

            const reservasGet = await fetch(`https://localhost:7063/api/reservas?carroId=${item.id}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json', 'Authorization': token },
                credentials: "include",
            });

            if (!reservasGet.ok) {
                throw new Error(`Erro: ${reservasGet}`);
            }

            if (item.fotoCarro && item.fotoCarro.length > 0) {
                item.fotoCarro.forEach((foto, index) => {
                    const estaAtivo = index === 0 ? "active" : "";
                    const imgUrl = `data:image/jpeg;base64,${foto.fotoBytes}`;

                    carouselItemsHTML += `
                        <div class="carousel-item ${estaAtivo}">
                            <img onerror="this.src='${altImagem}'" src="${imgUrl}" class="d-block w-100 rounded-2" style="height: 200px; object-fit: cover;">
                        </div>
                    `;
                });
            } else {
                carouselItemsHTML = `
                    <div class="carousel-item active">
                        <img src="${altImagem}" class="d-block w-100 rounded-2" style="height: 200px; object-fit: cover;">
                    </div>
                `;
            }

            const dataR = await reservasGet.json();

            const temReserva = dataR.items && dataR.items.length > 0;
            const desabilitado = temReserva ? "disabled" : "";

            precoAPI = item.preco.toLocaleString('pt-BR', {
                style: 'currency',
                currency: 'BRL'
            });

            // 2. Usando um ID com prefixo para evitar erros de sintaxe CSS com números no Bootstrap
            const carouselId = `carousel-${item.id}`;

            cardCarros += `
                <div class="col-4 card shadow p-3 my-2">
                    <div id="${carouselId}" class="carousel slide carousel-fade carousel-dark">
                        <div class="carousel-inner">
                            ${carouselItemsHTML}
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#${carouselId}" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon bg-dark rounded-circle shadow" style="width: 2.3rem; height: 2.3rem; background-size: 45%;" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#${carouselId}" data-bs-slide="next">
                            <span class="carousel-control-next-icon bg-dark rounded-circle shadow" style="width: 2.3rem; height: 2.3rem; background-size: 45%;" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                    <div class="card-body">
                        <p class="card-text text-start m-1">Marca: ${item.nomeMarca}</p>
                        <p class="card-text text-start m-1">Modelo: ${item.nomeModelo}</p>
                        <p class="card-text text-start m-1">Ano: ${item.ano}</p>
                        <p class="card-text text-start m-1">Cor: ${item.cor}</p>
                        <p class="card-text text-center m-1 mb-3 fs-3 text-success">${precoAPI}</p>
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-outline-success reservar" ${desabilitado} data-id="${item.id}" data-bs-toggle="modal" data-bs-target="#modalReserva">Reservar</button>
                                <button type="button" class="btn btn-sm btn-outline-secondary editar" data-id="${item.id}" data-cor="${item.cor}" data-ano="${item.ano}" data-preco="${item.preco}" data-bs-toggle="modal" data-bs-target="#modalEditar">Editar</button>
                            </div>
                            <button type="button" class="btn btn-sm btn-outline-danger excluir" data-id="${item.id}" data-bs-toggle="modal" data-bs-target="#modalExcluirCarro">Excluir</button>
                        </div>
                    </div>
                </div>
            `;
        }

        divCarros.innerHTML = cardCarros;
        atualizarPaginacao(dados);

    } catch (error) {
        console.log(error);
        spanAlert.textContent = "Erro ao renderizar os cards de carro!";
        throw error;
    }
}
async function renderSelectModelo() {

    try {
        const requisicao = await fetch(`https://localhost:7063/api/modelo`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            credentials: "include",
        });

        const data = await requisicao.json();

        let optionsModelo = "<option selected disabled>Selecione um modelo</option>";
        data.items.forEach((item) => {
            optionsModelo += `
            <option data-marcaId=${item.marca.id} value=${item.id}>${item.nomeModelo}</option>
        `;
        });

        selectModeloCarro.innerHTML = optionsModelo;

    } catch (error) {
        console.log(error);
        throw error
    }
}
async function renderSelectMarca() {

    let optionsMarcas = "<option selected disabled>Selecione uma marca</option>";

    try {

        const requisicao = await fetch(`https://localhost:7063/api/marca`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            credentials: "include",
        });

        const data = await requisicao.json();


        data.items.forEach((item) => {
            optionsMarcas += `
            <option value=${item.id}>${item.nomeMarca}</option>
        `;
        });

        selectMarca.innerHTML = optionsMarcas;
    } catch (error) {
        console.log(error)
        optionsMarcas = '<option selected disabled >Erro ao renderizar marcas</option>';
        selectMarca.innerHTML = optionsMarcas;
        throw error;
    }
}

//CARRO
async function enviarCarro() {
    const marca = selectModeloCarro.options[selectModeloCarro.selectedIndex].getAttribute("data-marcaId");
    const modelo = selectModeloCarro.value;
    const ano = inputAnoF.value;
    const cor = inputCor.value;
    const preco = inputPreco.value;

    if (!validacaoForm()) return;

    const payload = {
        marcaId: marca,
        modeloId: modelo,
        ano: ano,
        cor: cor,
        preco: preco
    };
    try {
        adcarro.setAttribute("disabled", "");
        adcarro.textContent = "Carregando...";

        const sendRequest = await fetch("https://localhost:7063/api/carro", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            body: JSON.stringify(payload),
            credentials: "include",
        });

        if (!sendRequest.ok) {
            spanAlertCad.textContent = "Erro ao cadastrar carro!";
            return
        }

        inputAnoF.value = "";
        inputCor.value = "";
        inputPreco.value = "";
        spanAlertCad.textContent = "";
        const modal = bootstrap.Modal.getInstance(document.getElementById('staticBackdrop'));
        modal.hide();
        renderCarros(page);

    } catch (error) {
        throw error;
    } finally {
        adcarro.textContent = "ADICIONAR";
        adcarro.removeAttribute("disabled");
    }
}
async function atualizarCarro() {
    const ano = inputEditAnoF.value;
    const cor = inputEditCor.value;
    const preco = inputEditPreco.value;

    const carro = btnAbrirModalImg.getAttribute("data-id");

    const payload = {
        carroId: carro,
        ano: ano,
        cor: cor,
        preco: preco
    };

    try {
        btnEditCarro.setAttribute("disabled", "");
        btnEditCarro.textContent = "Carregando..."
        const atualizar = await fetch(`https://localhost:7063/api/carro/${carro}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            body: JSON.stringify(payload),
            credentials: "include",
        });

        if (!atualizar.ok) {
            spanAlertEdit.textContent = "Erro ao editar carro!";
            return
        }
        const modal2 = bootstrap.Modal.getInstance(document.getElementById('modalEditar'));
        modal2.hide();

        renderCarros(page);

    } catch (error) {
        throw error
    } finally {
        btnEditCarro.textContent = "Confirmar"
        btnEditCarro.removeAttribute("disabled");
    }
}
async function excluirCarro() {

    try {
        excluir.setAttribute("disabled", "");
        excluir.textContent = "Carregando..."

        const delCarro = await fetch(`https://localhost:7063/api/carro/${idCarro}`, {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json; charset=utf-8', 'Authorization': token },
            credentials: "include",
        });

        if (!delCarro.ok) {
            spanAlertExcluirCarro.textContent = "Este carro não pode ser excluído."
            return
        }
            const modal = bootstrap.Modal.getInstance(document.getElementById('modalExcluirCarro'));
            modal.hide();
            renderCarros(page);
    }
    catch (error) {
        throw error;
    }
    finally {
        excluir.removeAttribute("disabled");
        excluir.textContent = "Sim, excluir."
        excluir.classList.add("text-danger")
        excluir.classList.add("fw-bold")
    }

}

async function salvarMarca() {

    const marca = inputMarca.value;

    const payload = {
        nomeMarca: marca,
    };
    try {
        btnAddMarca.setAttribute("disabled", "");
        btnAddMarca.textContent = "Carregando..."

        const enviarMarca = await fetch(`https://localhost:7063/api/marca`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            body: JSON.stringify(payload),
            credentials: "include",
        });


        if (!enviarMarca.ok) {
            spanAlertAddMarca.textContent = "Erro ao adicionar marca!";
            return
        }
            const modal = bootstrap.Modal.getInstance(document.getElementById('modalAdicionarMarca'));
            modal.hide();
            inputMarca.value = "";
    } catch(error) {
        throw error
    }
    finally {
        btnAddMarca.removeAttribute("disabled");
        btnAddMarca.textContent = "ADICIONAR"

    }
}
async function salvarModelo() {
    const modelo = inputModelo.value;
    const idMarca = selectMarca.value;

    const payload = {
        marcaId: idMarca,
        nomeModelo: modelo,
    };

    try {
        btnAddModelo.textContent = "Carregando...";
        btnAddModelo.setAttribute("disabled", "");

        const enviarModelo = await fetch(`https://localhost:7063/api/modelo`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'Authorization': token },
            body: JSON.stringify(payload),
            credentials: "include",
        });

        inputModelo.value = "";

        if (!enviarModelo.ok) {
            spanAlertEnviarModelo.textContent = "Este modelo não pode ser enviado!"
            return
        }
        const modal = bootstrap.Modal.getInstance(document.getElementById('modalAdicionarModelo'));
        modal.hide();

    } catch (error) {
        throw error
    }
    finally {
        btnAddModelo.textContent = "ADICIONAR";
        btnAddModelo.removeAttribute("disabled");
    }
}

async function reservarCarro() {
    const cpf = cpfInput.value.replace(/\D/g, "");
    const carroID = btnReservar.getAttribute('data-id');

    try {
        btnReservar.textContent = "Carregando..."
        btnReservar.setAttribute("disabled", "")

    const response = await fetch(`https://localhost:7063/api/cliente?cpf=${cpf}`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json', 'Authorization': token },
        credentials: "include",
    });

    const data = await response.json();

    let clienteID = "";
    data.items.forEach((item) => {
        clienteID = item.id;
    });

    const payload = {
        clienteId: clienteID,
        carroId: carroID,
    };

    const reservar = await fetch(`https://localhost:7063/api/reservas`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Authorization': token },
        body: JSON.stringify(payload),
        credentials: "include",
    });

        if (!reservar.ok) {
            spanAlertReserva.textContent = "Esta reserva não pode ser feita."
        console.log("Erro ao reservar");
        return;
    }

    const modal = bootstrap.Modal.getInstance(document.getElementById('modalReserva'));
    modal.hide();

    renderCarros(page);
    } catch (error) {
        console.log(error)
        throw error
    } finally {
        btnReservar.textContent = "RESERVAR";
        btnReservar.removeAttribute("disabled");
    }
}

input.addEventListener('change', function () {
    fileName.textContent = this.files[0]?.name ?? 'Nenhuma imagem selecionada';
});

renderCarros(page);

adcarro.addEventListener('click', async () => {
    await enviarCarro();
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
    selecionarCarro(event);
});
btnEditCarro.addEventListener('click', async () => {
    await atualizarCarro();
});
btnEnviarImg.addEventListener('click', async () => {
    await enviarImagem();
});
input.addEventListener('change', (e) => {
    spanFileName.textContent = e.target.files[0]?.name || '';
});

btnAddMarca.addEventListener('click', async () => {
    await salvarMarca();
});
btnAddModelo.addEventListener('click', async () => {
    await salvarModelo();
});
btnModelo.addEventListener('click', async () => {
    await renderSelectMarca();
});
btnCarro.addEventListener('click', async () => {
    await renderSelectModelo();
});

btnReservar.addEventListener('click', async () => {
    await reservarCarro();
});

excluir.addEventListener('click', async () => {
    await excluirCarro();
});

btnAbrirModalImg.addEventListener('click', async () => {
    await renderImagensDiv();
});

deletarIMG.addEventListener('click', async () => {
    await excluirImagem();
});

document.getElementById("divImagensCarro").addEventListener('change', async (event) => {
    if (event.target.classList.contains('inputEditarFoto')) {
        const fotoId = event.target.dataset.id;
        const file = event.target.files[0];
        await editarImagem(fotoId, file);
    }
});

document.getElementById("divImagensCarro").addEventListener('click', (event) => {
    const btnExcluirImg = event.target.closest(".btnExcluirIMG");
    if (btnExcluirImg) {
        idIMG = btnExcluirImg.dataset.id;
    }
});

function validacaoForm() {
    if (!formValidation.checkValidity()) {
        formValidation.classList.add('was-validated');
        const input = formValidation.querySelector(":invalid");
        input.focus();
        return false;
    }

    formValidation.classList.add('was-validated');
    return true;
}

function atualizarPaginacao(dadosApi) {
    totalPaginas = dadosApi.totalPagina;
    page = dadosApi.paginaAtual;

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
        renderCarros(page);
    } else {
        inputpage.value = page;
    }
}
function pagAnterior() {
    if (page > 1 && !btnVoltar.classList.contains("disabled")) {
        page--;
        renderCarros(page);
    }
}
function proxPagina() {
    const proximaExiste = dados?.proximaPagina ?? dados?.ProximaPagina;
    if (proximaExiste && !btnAvancar.classList.contains("disabled")) {
        page++;
        renderCarros(page);
    }
}

function selecionarCarro(event) {
    const btnEditar = event.target.closest('.editar');
    const btnReserv = event.target.closest('.reservar');
    const btnExclu = event.target.closest('.excluir');

    if (btnEditar) {
        inputEditAnoF.value = btnEditar.getAttribute("data-ano");
        inputEditCor.value = btnEditar.getAttribute("data-cor");
        inputEditPreco.value = btnEditar.getAttribute("data-preco");

        idCarro = btnEditar.getAttribute("data-id");
        btnAbrirModalImg.setAttribute('data-id', idCarro);
    }

    if (btnReserv) {
        cpfInput.value = "";
        idCarro = btnReserv.getAttribute("data-id");
        btnReservar.setAttribute('data-id', idCarro);
        
    }

    if (btnExclu) {
        idCarro = btnExclu.getAttribute("data-id");
        spanAlertExcluirCarro.textContent = "";
    }
}

async function enviarImagem() {

    const arquivoImagem = input.files[0];
    const carroId = btnAbrirModalImg.getAttribute("data-id");

    const formData = new FormData();
    formData.append('carroId', carroId);
    formData.append('Conteudo', arquivoImagem);

    try {
        spanAlertEnviarImagem.textContent = ""

        btnEnviarImg.textContent = "Carregando...";
        btnEnviarImg.setAttribute("disabled", "");

        const response = await fetch(`https://localhost:7063/api/fotocarro`, {
            method: 'POST',
            headers: { 'Authorization': token },
            body: formData,
            credentials: "include",
        });


        if (!response.ok) {
            spanAlertEnviarImagem.textContent = "Erro ao enviar imagem!"
            console.log("Erro ao enviar imagem");
            return
        }

        const modal = bootstrap.Modal.getInstance(document.getElementById('modalAddImagem'));
        const modal2 = bootstrap.Modal.getInstance(document.getElementById('modalEditar'));
        modal.hide();
        modal2.hide();
        renderCarros(page);
        input.value = "";
        spanFileName.textContent = "";

    } catch (error) {
        console.log(error);
        throw error
    } finally {
        btnEnviarImg.textContent = "Enviar";
        btnEnviarImg.removeAttribute("disabled");
    }
}

async function renderImagensDiv() {
    const carroId = btnAbrirModalImg.getAttribute("data-id");
    const divImagens = document.getElementById("divImagensCarro");

    try {
        spanAlertRenderImagem.textContent = "";


            const response = await fetch(`https://localhost:7063/api/fotocarro/${carroId}`, {
                method: 'GET',
                headers: { 'Authorization': token },
                credentials: "include"
            });

            const dados = await response.json();
            const lista = dados.$values || dados;
            let htmlDiv = "";

            lista.forEach((item, index) => {
                const inputId = `imagemInputI_${item.id}`;

                htmlDiv += `
                <div class="col-4 text-center justify-content-between bg-secondary bg-opacity-50 p-1 rounded-2 border border-2" style="background-image: url('data:image/jpeg;base64,${item.fotoBytes}'); background-size: cover; background-position: center; background-repeat: no-repeat; height: 125px; width: 33%;">
                    <div class="d-flex justify-content-between align-self-center">
                        <p class="text-light fs-5 bg-secondary bg-opacity-50 rounded-1 p-1 pt-0 pb-0 m-0 shadow-none">${index + 1}</p>
                        <div class="fs-6 d-flex align-items-center gap-1">
                            <button type="button" class="btnEditarIMG btn bg-secondary bg-opacity-50 p-1 pt-0 pb-0 m-0 shadow-none border-0 d-inline-flex align-items-center justify-content-center" style="cursor: pointer;" data-id="${item.id}">
                                <input type="file" class="btn-check inputEditarFoto" id="${inputId}" accept="image/*" data-id="${item.id}">
                                <label for="${inputId}" class="p-0 m-0 border-0 bg-transparent" style="cursor: pointer;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="yellow" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z" />
                                    </svg>
                                </label>
                            </button>
                            <button type="button" class="btnExcluirIMG btn bg-secondary bg-opacity-50 p-1 pt-0 pb-0 m-0 shadow-none border-0 d-inline-flex align-items-center justify-content-center" data-id="${item.id}" data-bs-toggle="modal" data-bs-target="#modalExcluirImagem">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="red" class="bi bi-trash" viewBox="0 0 16 16">
                                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z" />
                                    <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z" />
                                </svg>
                            </button>
                        </div>
                    </div>
                </div>
            `});

            divImagens.innerHTML = htmlDiv;
    } catch (error){
        console.log(error);
        spanAlertRenderImagem.textContent = "Erro ao renderizar imagens!";
        throw error
        }
    }

async function excluirImagem() {

    try {
        deletarIMG.textContent = "Carregando...";
        deletarIMG.setAttribute("disabled", "");

        spanAlertExcluirImagens.textContent = "";

        const response = await fetch(`https://localhost:7063/api/fotocarro/${idIMG}`, {
            method: 'DELETE',
            headers: { 'Authorization': token },
            credentials: "include"
        });

        if (!response.ok) {
            spanAlertExcluirImagens.textContent = "Erro ao excluir imagem!";
            console.log(response);
            return
        }

        const modal = bootstrap.Modal.getInstance(document.getElementById('modalExcluirImagem'));
        modal.hide();
        renderCarros(page);

    } catch (error) {
        console.log(error);
        throw error
    } finally {
        deletarIMG.textContent = "Sim, excluir.";
        deletarIMG.removeAttribute("disabled");
        deletarIMG.classList.add("text-danger");
        deletarIMG.classList.add("fw-bold");
    }
}

async function editarImagem(fotoId, file) {
    if (!file) return;

    const formData = new FormData();
    formData.append('Conteudo', file);

    try {
        const response = await fetch(`https://localhost:7063/api/fotocarro/${fotoId}`, {
            method: 'PUT',
            headers: { 'Authorization': token },
            body: formData,
            credentials: "include",
        });

        if (!response.ok) {
            spanAlertEnviarImagem.textContent = "Erro ao editar imagem!";
            console.log("Erro ao atualizar imagem!");
            return;
        }

        await renderImagensDiv();
        renderCarros(page);
    } catch (error) {
        console.error("Erro na requisição:", error);
        throw error
    }
}

inputCPF.addEventListener('input', () => {
    let valor = inputCPF.value.replace(/\D/g, '').slice(0, 11); // Pega só números até 11 dígitos

    valor = valor.replace(/^(\d{3})(\d)/, '$1.$2');
    valor = valor.replace(/^(\d{3})\.(\d{3})(\d)/, '$1.$2.$3');
    valor = valor.replace(/\.(\d{3})(\d)/, '.$1-$2');

    inputCPF.value = valor;
});