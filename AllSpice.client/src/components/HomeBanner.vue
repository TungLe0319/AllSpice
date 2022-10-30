<template>
  <div
    class="card banner mt-2 border-0 mb-5 elevation-3 d-flex align-items-end justify-content-end"
  >
    <Login />
    <div class="categoryBar position-absolute bg-light elevation-5  rounded">
      <div class="d-flex justify-content-between">
        <span>
          <button
            class="btn filterbtn fbg-transparent "
            id="homeBtn"
            @click="getAllRecipes()"
          >
            <h3>Home</h3>
          </button></span
        >
        <span>
          <button
            class="btn filterbtn bg-transparent"
            @click="getFavoriteRecipes()"
          >
            <h3>Favorites</h3>
          </button></span
        >
        <span>
          <button class="btn filterbtn bg-transparent" @click="getMyRecipes()">
            <h3>My Recipes</h3>
          </button></span
        >
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import Login from "./Login.vue";

export default {
  setup() {
    function focus() {
      document.getElementById("homeBtn").focus();
    }
    onMounted(() => {
      focus();
    });

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

      async getMyRecipes() {
        try {
          await recipesService.getRecipesByAccountId();
        } catch (error) {
          Pop.error(error);
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
  width: 35vw;
  bottom: -30px;
  left: 26vw;
}


.filterbtn:focus {
  background: linear-gradient(to bottom right, #ffbb00, #ff5e00);

  color: #ffffff;
  cursor: pointer;
  display: inline-block;
  font-family: "Baloo 2", cursive;
  font-size: 16px;
  font-weight: 600;
  letter-spacing: 0.07em;
  line-height: 2.5;
  outline: transparent;
  text-align: center;
  text-decoration: none;
  transition: all 0.25s ease-in-out;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  box-shadow: rgba(0, 0, 0, 0.07) 0px 1px 1px, rgba(0, 0, 0, 0.07) 0px 2px 2px,
    rgba(0, 0, 0, 0.07) 0px 4px 4px, rgba(0, 0, 0, 0.07) 0px 8px 8px,
    rgba(0, 0, 0, 0.07) 0px 16px 16px;
}
</style>
