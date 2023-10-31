import React from "react";
import { Route, BrowserRouter, Routes } from 'react-router-dom';

//Imports dos componentes - Páginas
import HomePage from "./pages/HomePage/HomePage";
import TipoEventosPage from "./pages/TipoEventosPage/TipoEventos";
import EventosPage from "./pages/EventosPage/EventosPage"

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<HomePage/>} path={"/"} exact />
                <Route element={<TipoEventosPage/>} path={"/tipoeventos"} exact />
                <Route element={<EventosPage/>} path={"/evento"} exact />
            </Routes>
        </BrowserRouter>
    );
}

export default Rotas;