//GERAL 
let inputNome = document.getElementById("inputNome");
let inputEmail = document.getElementById("inputEmail");
let inputSenha = document.getElementById("inputSenha");
let inputConfirmSenha = document.getElementById("inputConfirmSenha");
const btnCadastro = document.getElementById("btnCadastro");

try {
    btnCadastro.addEventListener('click', () => {
        cadastrarUser();
    });
} catch (err) {
    console.log(err);
}

async function cadastrarUser() {
    const nome = inputNome.value;
    const email = inputEmail.value;
    const senha1 = inputSenha.value;
    const senha2 = inputConfirmSenha.value;

    if (senha1 != senha2) {
        return
    }

    const payload = {
        username: nome,
        email: email,
        senha: senha2
    }

    const sendRequest = await fetch("https://localhost:7063/api/user", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
        credentials: "include",
    });

    inputNome.value = "";
    inputEmail.value = "";
    inputConfirmSenha.value = "";
    inputSenha.value = "";

    if (!sendRequest.ok) {
        console.log("Erro")
        return
    }

    window.location.href = "/Login/loginView";

}