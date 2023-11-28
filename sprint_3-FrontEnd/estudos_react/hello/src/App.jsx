import React, { useContext, useState } from "react";
import "./App.css";
import Rotas from "./routes";

import ThemeContext from "./context/ThemeContext";

function App() {
  const [theme, setTheme] = useState("Light");

  return (
    <ThemeContext.Provider value={{ theme, setTheme }}>
      <div className={`App ${theme === "Dark" ? "App-dark" : ""}`}>
        <Rotas />
      </div>
    </ThemeContext.Provider>
  );
}

export default App;
