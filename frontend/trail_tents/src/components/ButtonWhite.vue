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
  border: none;
  border-radius: 20px;
  transition: 0.3s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  font-family: "Ysabeau Infant", sans-serif;
}

button:hover {
  cursor: pointer;
  transform: scale(1.05);
}
</style>