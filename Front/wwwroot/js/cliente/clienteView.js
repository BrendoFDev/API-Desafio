const nome = document.getElementById("nome");
const cpf = document.getElementById("cpf");
const btnEnviar = document.getElementById("enviar");

const tableExibirClientes = getElementById("exibirClientes");

const dados;

try {
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
} catch (err) {
    console.log(err);
}

async function renderClientes() {
    const getClientes = await fetch("https://localhost:7063/api/cliente", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json; charset=utf-8' },
    });

    dados = await getClientes.json();
}