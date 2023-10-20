//crie 2 arrays nomes e sobrenomes
//crie um terceiro array de nomeCompleto
//ao final exiba os nomes completos no console com foreach
//é necessário conter pelo menos 5 nomes
//utilize arrow functions como calback functions

const nome = ['Júlia', 'Enzo', 'Paulo', 'Lucas', 'Carlos', 'Eduardo'];
const sobrenome = ['aben-athar', 'Quarelo', 'Gonçalves', 'Gonçalves de Oliveira', 'Roque', 'Mendes'];

const nomeCompleto = nome.map((nome, index) => `${nome} ${sobrenome[index]}`);

nomeCompleto.forEach((nCompleto) => {
  console.log(nCompleto);
});