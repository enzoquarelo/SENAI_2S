const url = "https://viacep.com.br/ws";
const urlCepProfessor = "http://172.16.35.155:3000/myceps"

function cadastrar(e) {
    e.preventDefault();
    
    const nome = document.getElementById("nome").value;
    const email = document.getElementById("email").value;
    const cep = document.getElementById("cep").value;
    const endereco = document.getElementById("endereco").value;
    const complemento = document.getElementById("complemento").value;
    const cidade = document.getElementById("cidade").value;
    const estado = document.getElementById("estado").value;
}

async function buscarEndereco(cep) {
    const resource = `/${cep}/json/`

    try {
        // const promise = await fetch(url + resource);

        const promise = await fetch(`${urlCepProfessor}/${cep}`);

        const endereco = await promise.json();

        console.log(endereco)
        return;

        document.getElementById("endereco").value = endereco.logradouro || "";
        document.getElementById("cidade").value = endereco.localidade || "";
        document.getElementById("estado").value = endereco.uf || "";

        document.getElementById("not-found").innerText = "";

    } catch (e) {
        alert(e);
    }
    document.getElementById("not-found").innerText = "cep inválido"
}