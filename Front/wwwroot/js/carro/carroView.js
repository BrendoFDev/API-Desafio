const inputMarca = document.getElementById("inputMa");
const inputModelo = document.getElementById("inputMo");
const inputAnoF = document.getElementById("inputAF");
const inputCor = document.getElementById("inputC");
const inputPreco = document.getElementById("inputP");
const formValidation = document.querySelector(".needs-validation");
const adcarro = document.getElementById("adcarro");
const modalview = document.getElementById("staticBackdrop");

try {
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


        const sendRequest = await fetch("https://localhost:7063/api/carro", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        });



        // modalview.close();
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
