<template>
  <!-- <header>
    <Navbar />
  </header> -->
  <main class="Image">
    <router-view />
  </main>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
.Image{

  /* always scale the image to the appropriate size of your screen */
  background-size: cover;
  background-image: url('https://www.hdnicewallpapers.com/Walls/Big/Food%20and%20Drinks/Food_Meal_Dish_and_Fork_5K_Wallpaper.jpg');
  background-position: center;
  /* keeps the image fixed while scrolling , neat effect. */
  background-attachment: fixed; 
}

</style>
