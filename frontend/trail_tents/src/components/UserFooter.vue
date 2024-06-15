<template>
  <div class="footer">
    <ButtonWhite  text="Our Servies" />
    <ButtonWhite  text="Follow Us" />
    <ButtonWhite  text="FAQ" />
    <ButtonWhite  text="About Us" />
    <ButtonWhite  text="Contacts" />
    <ButtonWhite  text="Privecy Policy" />
  </div>
</template>

<script>
import ButtonWhite from "./ButtonWhite.vue"
export default {
  name: "UserFooter",
  components: {
    ButtonWhite,
  },
  methods: {
    
  },
}
</script>

<style scoped>
.footer {
  height: 40px;
  display: flex;
  justify-content:space-evenly;
  z-index: 100;
  background-color: #eaf7df;
  border-radius: 10px;
  margin: 15px;
}

</style>