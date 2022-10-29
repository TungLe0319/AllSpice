<template>
  <div
    class="card banner mt-2 border-0 mb-5 elevation-3 d-flex align-items-end justify-content-end"
  >
    <Login />
    <div class="categoryBar position-absolute bg-light elevation-5 p-2 rounded">
      <div class="d-flex justify-content-between">
        <span>
          <button class="btn btn-primary" @click="getAllRecipes()">
            Home
          </button></span
        >
        <span>
          <button class="btn btn-primary" @click="getFavoriteRecipes()">
            Favorites
          </button></span
        >
        <span>
          <button class="btn btn-primary" @click="getMyRecipes()">
            Cheese
          </button></span
        >
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import Login from "./Login.vue";

export default {
  setup() {
    return {
      async filterByCategory(filter) {
        console.log("hi");
        if (filter == "Cheese") {
          AppState.recipes = AppState.recipes.filter(
            (r) => r.category == "Cheese"
          );
        }
      },
      async getFavoriteRecipes() {
        try {
          await accountService.getFavoriteRecipes();
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },

      async getAllRecipes() {
        try {
          await recipesService.getAllRecipes();
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },

    async  getMyRecipes() {
        try {
            await recipesService.getRecipesByAccountId()
          } catch (error) {
            Pop.error(error)
          }
   
      },
    };
  },
  components: { Login },
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
  width: 40vw;
  bottom: -20px;
  left: 26vw;
}
</style>
