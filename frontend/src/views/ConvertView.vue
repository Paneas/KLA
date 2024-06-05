<script setup>

import { inject } from 'vue'
import { ref } from 'vue';

const convertNumber = inject('ConvertNumber')
const numberToConvert = ref('')
const toggle = ref(false)
const words = ref('')

async function Convert(event) {
    event.preventDefault();

    try {
        let apiRes = await convertNumber(numberToConvert.value);
        toggle.value = true;
        words.value = apiRes?.words;
    }
    catch(err){
        toggle.value = true;
        words.value = err;
    }    
}
</script>

<template>

<body>
    
  <form>
        <h1>Convert Number to Words</h1>
        <label for="textInput">Enter number:</label>
        <input type="text" id="textInput" name="textInput" v-model="numberToConvert">
        <button type="button" v-on:click="Convert">Submit</button>
        <div id="output" class="output" v-show='toggle'>{{ words }}</div>
    </form>
</body>
    

</template>

<style>
    body {
        font-family: Arial, sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        background-color: #f0f0f0;
        margin: 0;
    }
    form {
        background: #fff;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        text-align: center;
    }
    label {
        display: block;
        margin-bottom: 8px;
        color: #555;
    }
    input[type="text"] {
        width: 80%;
        padding: 10px;
        margin-bottom: 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }
    button {
        padding: 10px 20px;
        background-color: #007BFF;
        border: none;
        border-radius: 4px;
        color: white;
        cursor: pointer;
    }
    button:hover {
        background-color: #0056b3;
    }
    .output {
        margin-top: 20px;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        background-color: #e9ecef;
    }
</style>

