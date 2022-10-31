<template>
  <div
    class="card banner mt-2 border-0 mb-5 elevation-3 d-flex align-items-end justify-content-end"
  >
  <div>
    <SearchBar/>
  </div>
    <Login />
    <div class="categoryBar  bg-light elevation-5  rounded">
      <div class="d-flex justify-content-center ">
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
            class="btn filterbtn  bg-transparent"
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
import SearchBar from "./SearchBar.vue";

export default {
  setup() {
    function focus() {
      document.getElementById("homeBtn").focus();
    }
    onMounted(() => {
      focus();
    });

    return {

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
  position: absolute ;
  border: 0;
  width: auto;
  bottom: -30px;
  left: 34vw;
}


.filterbtn:focus {
  background: linear-gradient(to bottom right, #ffbb00, #ff5e00);
border-radius: 0px;
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


//when screen is 700px OR LESS
@media only screen and (max-width: 700px){
.categoryBar{
  margin-left: 10px;
  position: relative;
   position: absolute ;
 display: flex;
 justify-content: center;
  width: auto;
  bottom: 0px;
  left: 0px;
}
}
</style>
