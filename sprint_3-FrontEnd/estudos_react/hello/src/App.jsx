import Title from './components/Title/Title'
import CardEvento from './components/CardEvento/CardEvento'
import Container from './components/Container/Container'

import './App.css';
import Rotas from './routes';

function App() {
  return (
    //Criar as propriedades titulo, texto, textolink
    //passar as propriedades em cada um dos 3 componentes
    <div className="App">
      <Rotas/>
      {/* <h1>Hello World!</h1>
      <Title nome="Enzo" sobrenome="Quarelo" />

      <br /><br />

      <Container>
        <CardEvento titulo="C# do Carlão" texto="Listinha de 10 exercício" link="Conecte-se" />
        <CardEvento titulo="Js com Dudu" texto="Bora codar em JS" link="Conecte-se" />
        <CardEvento titulo="SQL com Carlão" texto="Vamo modelar?" link="Conecte-se" />
      </Container> */}
    </div>
  );
}

export default App;
