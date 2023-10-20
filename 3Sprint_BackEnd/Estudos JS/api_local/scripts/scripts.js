const url = "https://viacep.com.br/ws";

function cadastrar(e) {
    e.preventDefault();
    alert("Cadastrar");
}

async function buscarEndereco(cep) {
    const resource = `/${cep}/json/`

    try {
        const promise = await fetch(url + resource);

        const endereco = await promise.json();

        document.getElementById("endereco").value = endereco.logradouro || "";
        document.getElementById("cidade").value = endereco.localidade || "";
        document.getElementById("estado").value = endereco.uf || "";

    } catch (e) {
        alert(e);
    }
}