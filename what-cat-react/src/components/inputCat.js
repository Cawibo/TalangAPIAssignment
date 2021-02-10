import React, { Component, useState } from 'react';
import {apiClient} from '../api/api-client';
import './inputCat.css';

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
    <div className="form__group field">
        <form autocomplete="off" onSubmit={onSubmit}>
            <input value={name} onChange={onChange} type="input" className="form__field" placeholder="Name" name="name" id='name' required ></input>
            <label htmlFor="name" className="form__label">Name</label>
        </form>
    </div>
  );
} 
