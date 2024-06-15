<template>
    <button>{{ text }}</button>
</template>

<script>
  export default {
    name: "ButtonWhite",
    props: {
      text : String,
    }
  }
</script>

<style scoped>
button {
  font-size: 18px;
  font-weight: 600;
  padding: 5px 10px;
  margin: 0 10px;
  border: 2px solid #c2cbc9;
  border-radius: 20px;
  transition: 0.3s;
  font-family: "Ysabeau Infant", sans-serif;
  background-color: #eaf7df;
  color: #252324;
}

button:hover {
  cursor: pointer;
  transform: scale(1.05);
}
</style>