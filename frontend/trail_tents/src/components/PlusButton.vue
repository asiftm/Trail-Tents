<template>
  <div v-on:mouseover="showText = true" @mouseleave="showText = false">
    <p id="txt" v-if="showText">{{text}}</p>
    <button>+</button>
  </div>
</template>

<script>
export default {
  name: "PlusButton",
  data(){
    return{ 
      showText: false
    }
  },
  props:{
    text:{
      type: String,
      required: true,
    }
  },
}
</script>

<style scoped>
div{
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  position: fixed;
  height: 90px;
  width: 90px;
  bottom: 100px;
  right: 100px;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: center;
  text-align: center;
}

button{
  height: 50px;
  width: 50px;
  background-color: rgb(143, 143, 46);
  border-radius: 50%;
  font-size: 40px;
  color: white;
  transition: .5s;
  border: none;
  margin-top: 5px;
}

button:hover{
  cursor: pointer;
  rotate: 90deg;
}

div :hover + p {
  display: block; /* Show the text when hovering over the button */
}
</style>