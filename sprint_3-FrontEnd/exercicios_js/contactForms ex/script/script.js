const urlViaCep = "https://viacep.com.br/ws";

async function cadastrar(e) {
    e.preventDefault();

    const dados = {
        nome: document.getElementById("nome").value,
        sobrenome: document.getElementById("sobrenome").value,
        email: document.getElementById("email").value,
        telefone: {
            pais: document.getElementById("pais").value,
            ddd: document.getElementById("ddd").value,
            numero: document.getElementById("telefone").value
        },
        endereco: {
            cep: document.getElementById("cep").value,
            rua: document.getElementById("rua").value,
            numero: document.getElementById("numero").value,
            complemento: document.getElementById("complemento").value,
            bairro: document.getElementById("bairro").value,
            cidade: document.getElementById("cidade").value,
            estado: document.getElementById("UF").value
        },
        anotacoes: document.getElementById("anotacoes").value
    };

    try {
        const response = await fetch('http://localhost:3000/contatos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dados)
        });

        const data = await response.json();

        if (response.ok) {
            alert("Dados cadastrados com sucesso!");
        } else {
            alert("Erro ao cadastrar os dados: " + data.message);
        }
    } catch (error) {
        console.error("Erro ao enviar os dados para a API:", error);
        alert("Erro ao enviar os dados para a API. Veja o console para mais detalhes.");
    }
}
