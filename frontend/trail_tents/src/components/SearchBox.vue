<template>
  <div class="main">
    <div id="search-area">
      <div id="search-box-container">
        <input id="search-box" type="text" placeholder="Search" v-model="name" v-on:input="SearchName()" />
      </div>
    </div>
    <div class="picker">
      <p class="picker-heading">Price</p>
      <div id="priceranges">
        <input v-model="priceFrom" v-on:change="SearchPriceFrom()" type="number" placeholder="From" name="pricerange"
          class="filter" id="pricerange">
        <input v-model="priceTo" v-on:change="SearchPriceTo()" type="number" placeholder="To" name="pricerange"
          class="filter" id="pricerange">
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "SearchBox",
  date() {
    return {
      name: '',
      priceFrom: 0,
      priceTo: 999999,
    }
  },
  methods: {
    SearchName() {
      this.$emit('searchName', this.name.trim())
    },
    SearchPriceFrom() {
      this.$emit('priceFrom', this.priceFrom)
    },
    SearchPriceTo() {
      this.$emit('priceTo', this.priceTo)
    },
  },
  mounted() {

  }
}
</script>


<style>
* {
  font-family: "Ysabeau Infant", sans-serif;
}

.main {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#search-area {
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
}

#search-box-container {
  margin-right: 10px;
}

#search-box {
  height: 46px;
  width: 400px;
  max-width: 400px;
  border-radius: 20px;
  border: none;
  outline: none;
  padding: 0px 12px;
  text-align: start;
  border: 2px solid #c2cbc9;
}

.section button {
  height: 46px;
  width: 100%;
  max-width: 200px;
  font-size: 25px;
}

#filter-area {
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  gap: 20px;
  margin-top: 20px;
}

.picker {
  height: auto;
  width: 200px;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.picker-heading {
  font-size: 24px;
  padding-bottom: 10px;
  margin: 0;
}

.filter {
  width: 100%;
  max-width: 170px;
  border: none;
  border-radius: 3px;
  padding: 5px 15px;
  transition: 0.2s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

input[type="date"]::-webkit-calendar-picker-indicator:hover {
  cursor: pointer;
  transform: scale(1.1);
}

#priceranges {
  display: flex;
  flex-direction: row;
}

#priceranges .filter {
  margin: 5px;
}
</style>
