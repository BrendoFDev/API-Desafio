//GERAL
let inputEmail = document.getElementById("inputEmail");
let inputSenha = document.getElementById("inputSenha");
const btnLogin = document.getElementById("btnLogin");
const btnMostrarSenha = document.getElementById("btnMostrarSenha");
const iconeOlho = document.getElementById("iconeOlho");
const iconeOlhoFechado = document.getElementById("iconeOlhoFechado");


try {

    btnLogin.addEventListener('click', () => {
        fazerLogin();
    });

} catch (err) {
    console.log(err);
}

async function fazerLogin() {

    btnLogin.textContent = "Caregando..."

    const email = inputEmail.value;
    const senha = inputSenha.value;

    const payload = {
        email: email,
        senha: senha
    }

    const res = await fetch("https://localhost:7063/api/auth/login", {
        method: 'POST',
        credentials: "include",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });

    inputEmail.value = "";
    inputSenha.value = "";

    if (!res.ok) {
        console.log("Erro")
        mostrarToast('Email ou senha incorretos!');
        btnLogin.textContent = "Entrar"
        return
    }

    var response = await res.json();

    localStorage.setItem("token", response.token);

    const resLogar = await fetch(`https://localhost:7227/login/Logar`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
    })

    window.location.href = "/Home/Index";
}

function mostrarToast(msg) {
    const el = document.getElementById('toast');
    el.querySelector('.toast-body').textContent = msg;
    const toast = new bootstrap.Toast(el, { delay: 3000 });
    toast.show();
}   

btnMostrarSenha.addEventListener('click', () => {
    const campoSenha = inputSenha.getAttribute("type") === "password";

    inputSenha.setAttribute("type", campoSenha ? "text" : "password");

    iconeOlhoAberto.classList.toggle("d-none", campoSenha);
    iconeOlhoFechado.classList.toggle("d-none", !campoSenha);
});