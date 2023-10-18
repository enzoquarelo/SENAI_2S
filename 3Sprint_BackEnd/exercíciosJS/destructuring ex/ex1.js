//criar uma destruturação para objeto filmes
//trazer somente 3 propriedades
//crie um arquivo a parte e tente executar sem consulta

const filmes = {
    titulo: 'Velozes e Furiozos 11',
    dataLançamento : 2022-10-18,
    sinopse: 'Ação, aventura e muita fumaça tudo em alta velocidade.'
}

const {titulo, dataLançamento, sinopse} = filmes

console.log(`
Filme:

Título do Filme: ${titulo}
Data de Lançamento: ${dataLançamento}
Sinopse: ${sinopse}
`)