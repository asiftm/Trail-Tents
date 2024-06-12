<template>
  <div class="heading" id="welcome-txt">
    <p>Welcome to</p>
    <p id="main-title">Trail Tents</p>
    <p id="welcome-moto">Explore. Equip. Embrace the Outdoors.</p>
  </div>
</template>

<script>
export default {
  name: "WelcomeText"
}
</script>

<style>
p{
  margin: 0;
}
.heading {
  text-align: center;
}

#welcome-txt {
  font-size: 50px;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  color: black;
}

#main-title {
  font-size: 80px;
  font-family: "Stick", sans-serif;
}

#welcome-moto {
  font-size: 30px;
  font-weight: 400;
}
</style>