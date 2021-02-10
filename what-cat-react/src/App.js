import React, { Fragment, useState, useEffect } from 'react';
import './App.css';
import logo from './logo.svg';
import {apiClient} from './api/api-client';

function App() {
  const [cat, setCat] = useState({name:'', url:logo});
  const [name, setName] = useState("");

  const onSubmit = (event) => {
    event.preventDefault();
    apiClient.getCat(name).then(cat => setCat(cat));
    setName("");
    console.log(cat)
  }

  const onChange = event => {
    setName(event.target.value);
    //console.log(cat)
  }


  return (
    <div className="App">
      <header className="App-header">
        <h1>Find your cat!</h1>
        <img src={cat.url} className="App-logo" alt="logo" />
        <h2>{cat.name}</h2>
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
