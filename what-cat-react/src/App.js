import React, { Fragment, useState, useEffect } from 'react';
import './App.css';
import logo from './logo.svg';
import {apiClient} from './api/api-client';
import {InputCat} from './components/inputCat';

function App() {
  const [cat, setCat] = useState({name:'',url:logo});
//  const [name, setName] = useState("");

/*  const onSubmit = (event) => {
    event.preventDefault();
    apiClient.getCat(event.target.value).then(cat => setCat(cat));
    console.log(cat)
  }

   const onChange = event => {
    setName(event.target.value);
    //console.log(cat)
  } */


  return (
    <div className="App">
      <header className="App-header">
        <h1>Find your cat!</h1>
        <img src={cat.url} className="App-logo" alt="logo" />
        <h2>{cat.name}</h2>
        <InputCat
          setCat = {setCat}>
        </InputCat>
      </header>
    </div>
  );
}

export default App;
