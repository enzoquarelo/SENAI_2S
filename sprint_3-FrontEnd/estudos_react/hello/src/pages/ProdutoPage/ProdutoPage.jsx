import React, {useContext} from 'react';
import ThemeContext from '../../context/ThemeContext';


const ProdutoPage = () => {

    const { theme } = useContext(ThemeContext);

    return (
        <div>
            <h1>Products Page</h1>
            <span>{ theme }</span>
            <ul style={{listStyle: "none"}}>
                <li>
                    <strong>Produto:</strong> Camisa| &nbsp;
                    <strong>Preço:</strong> 99.99 | &nbsp;
                    <strong>Promoção:</strong> Sim
                </li>
            </ul>
        </div>
    );
};

export default ProdutoPage;