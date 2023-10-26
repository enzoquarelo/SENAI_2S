const frutas = []

async function cadastrar(e) {
    e.preventDefault();

    const valorFruta = document.getElementById("nomeFruta").value;
    valorFruta.trim()
    valorFruta.toLowerCase()

    if (valorFruta !== "") {
        frutas.push(valorFruta)
        frutas.sort()

        atualizarListarFrutas()
        valorFruta.value = ""
    } 
    else {
        console.log(error)
    }
}

function atualizarListarFrutas(){
    const lista = document.getElementById("listaFrutas");
    lista.innerHTML = "";

    frutas.forEach(fruta => {
        const li = document.createElement("li")
        li.textContent = fruta
        lista.appendChild(li)
    })
}

if(frutas.length > 0) {
    atualizarListarFrutas();
}