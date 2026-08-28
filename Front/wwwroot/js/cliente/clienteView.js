const nome = document.getElementById("nome");
const cpf = document.getElementById("cpf");
const btnEnviar = document.getElementById("enviar");

btnEnviar.addEventListener('click', async () => {

    const payload = {
        nome: nome.value,
        cpf: cpf.value,
        dataDeCriacao: new Date().toISOString().slice(0, 10)
    }

    const cadCliente = await fetch("https://localhost:7063/api/cliente", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json; charset=utf-8' },
        body: JSON.stringify(payload),
    });

});