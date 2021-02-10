import React, { Fragment, useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import {apiClient} from './api/api-client';

function App() {
  const [cat, setCat] = useState({});
  const [name, setName] = useState("");

  const onSubmit = (event) => {
    event.preventDefault();
    apiClient.getCat(name).then(cat => setCat(cat));
    setName("");
    console.log(cat)
  }

  const onChange = event => {
    //console.log(event.target.value);
    setName(event.target.value);
  }


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <div className="inputField">
          <form onSubmit={onSubmit}>
            <input type="text" value={name} onChange={onChange} placeholder="Cat name..."></input>
            <button>Find a cat!</button>
          </form>
        </div>
      </header>
    </div>
  );
}

export default App;