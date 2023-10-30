const Contador = () =>{
    const [contador, setContador] = useState(0); //dados do component

    function handleIncrementar() {
       setContador(contador + 1);
    }

    function handleDecrementar() {
        setContador( contador === 0 ? 0 : contador - 1) 
    }

    return(
        <div>
            
        </div>
    )
}