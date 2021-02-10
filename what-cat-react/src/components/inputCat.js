import React, { Component, useState } from 'react';
import {apiClient} from '../api/api-client';

export const InputCat = (props) => {
  const [name, setName] = useState("");

  const onChange = event => {
    setName(event.target.value);
    //console.log(cat)
  }

  const onSubmit = (event) => {
    event.preventDefault();
    apiClient.getCat(name).then(cat => props.setCat(cat));
    setName('')
  }

  return (
    <div className="inputField">
        <form onSubmit={onSubmit}>
            <input type="text" value={name} onChange={onChange} placeholder="Cat name..."></input>
            <button>Find a cat!</button>
        </form>
    </div>
  );
} 
