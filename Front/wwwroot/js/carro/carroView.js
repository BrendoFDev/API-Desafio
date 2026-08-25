const inputMarca = document.getElementById("inputMa").value;
const inputModelo = document.getElementById("inputMo").value;
const inputAnoF = document.getElementById("inputAF").value;
const inputCor = document.getElementById("inputC").value;
const inputPreco = document.getElementById("inputP").value;
const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const modalview = document.getElementById("staticBackdrop");

try {
    adcarro.addEventListener('click', async () => {
        if (!validacaoForm())
            return;

        const sendRequest = await fetch("https://localhost:7063/api/carro", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: {
                "marca": "Toyota",
                "modelo": "Corolla",
                "ano": 2025,
                "cor": "Prata",
                "preco": 150000.00
            },
        });



        // modalview.close();
    });

}
catch(err) {
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
