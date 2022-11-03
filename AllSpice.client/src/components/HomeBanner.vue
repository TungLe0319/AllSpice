<template>
  <div
    class="card banner sticky-top mt-2 border-0 mb-5 elevation-3 d-flex align-items-end justify-content-end"
  >
    <div id="searchBar1" class="searchBar elevation-5 rounded">
      <!-- <SearchBar /> -->
    </div>

    <Login />

    <div class="categoryBar bg-light elevation-5 rounded">
      <div class="d-flex justify-content-center">
        <span>
          <button
            class="btn filterbtn fbg-transparent"
            id="homeBtn"
            @click="getAllRecipes()"
            :class="infinite == 0 ? 'focusedBtn' : ''"
          >
            <h3>Home</h3>
          </button></span
        >
        <span>
          <button
            class="btn bg-transparent"
            id="favoriteBtn"
            @click="getFavoriteRecipes()"
            :class="infinite == 1 ? 'focusedBtn' : ''"
          >
            <h3>Favorites</h3>
          </button></span
        >
        <span>
          <button
            class="btn filterbtn bg-transparent"
            id="myRecipeBtn"
            @click="getMyRecipes()"
            :class="infinite == 2 ? 'focusedBtn' : ''"
          >
            <h3>My Recipes</h3>
          </button></span
        >
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import Login from "./Login.vue";
import SearchBar from "./SearchBar.vue";

export default {
  setup() {
    onMounted(() => {
      // document.getElementById("homeBtn").focus();
    });

    watchEffect(() => {});

    return {
    
      offSet: computed(() => AppState.offSet),
      infinite: computed(() => AppState.infinite),
      async getAllRecipes() {
        try {
          let offSet = AppState.offSet;
          AppState.infinite = 0;
          AppState.offSet = 0;

          AppState.recipes = [];
          await recipesService.getRecipesInfiniteScroll(offSet);
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },
      async getFavoriteRecipes() {
        try {
          AppState.infinite = 1;

          AppState.recipes = [];
          await accountService.getFavoriteRecipes();
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },

      async getMyRecipes() {
        try {
          AppState.infinite = 2;
          AppState.offSet = 0;
          let offSet = AppState.offSet;
          AppState.recipes = [];
          await accountService.getMyRecipes(offSet);
        } catch (error) {
          Pop.error(error);
        }
      },

  
    };
  },
  components: { Login, SearchBar },
};
</script>

<style lang="scss" scoped>
.banner {
  position: relative;
  height: 200px;
  width: 95vw;
  background-image: url(http://yesofcorsa.com/wp-content/uploads/2018/06/4K-Kitchen-Herbs-Best-Wallpaper.jpg);
  background-size: cover;
  background-position: top;
}

.categoryBar {
  position: absolute;
  border: 0;
  width: auto;
  bottom: -30px;
  left: 34vw;
}

.searchBar {
  position: absolute;
  border: 0;
  width: 600px;
  bottom: 100px;
  left: 28vw;
}

//when screen is 700px OR LESS
@media only screen and (max-width: 700px) {
  .categoryBar {
    margin-left: 10px;
    position: relative;
    position: absolute;
    display: flex;
    justify-content: center;
    width: auto;
    bottom: 0px;
    left: 0px;
  }
}
</style>
