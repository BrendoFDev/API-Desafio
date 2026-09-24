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
        mostrarToast('Sua senha precsa ter pelo menos 1 caractere especial e 1 letra Maiúscula!')
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

    if (!sendRequest.ok) {
        console.log("Erro")
        mostrarToast('Nome de Usuario ou Email inválidos ou já cadastrados!');
        return
    }

    inputNome.value = "";
    inputEmail.value = "";
    inputConfirmSenha.value = "";
    inputSenha.value = "";

    window.location.href = "/Login/loginView";
}

function mostrarToast(msg) {
    const toastElemento = document.getElementById('toast');
    toastElemento.querySelector('.toast-body').textContent = msg;
    const toast = new bootstrap.Toast(toastElemento, { delay: 4000 });
    toast.show();
}   