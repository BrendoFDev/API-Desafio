//GERAL
let inputEmail = document.getElementById("inputEmail");
let inputSenha = document.getElementById("inputSenha");
const btnLogin = document.getElementById("btnLogin");

try {

    btnLogin.addEventListener('click', () => {
        fazerLogin();
    });

} catch (err) {
    console.log(err);
}

async function fazerLogin() {

    const email = inputEmail.value;
    const senha = inputSenha.value;

    const payload = {
        email: email,
        senha: senha
    }

    const res = await fetch("https://localhost:7063/api/auth/login", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
    });

    inputEmail.value = "";
    inputSenha.value = "";

    if (!res.ok) {
        console.log("Erro")
        return
    }

    const resLogar = await fetch(`https://localhost:7227/login/Logar`, {
        method: 'POST',
        credentials: 'include',
        headers: { 'Content-Type': 'application/json' },
    })

    if (resLogar.ok) {
        // window.location.href = '/Home/Index';  ← redireciona
    } else {
        alert("Erro ao logar");
    }
}