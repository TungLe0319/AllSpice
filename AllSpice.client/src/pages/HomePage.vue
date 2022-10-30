<template>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center container"
  >
    <div class="row">
      <div class="col-md-12">
        <HomeBanner />
        <div class="fixed-bottom d-flex justify-content-end m-3">

          <button
            data-bs-target="#recipeFormModal"
            data-bs-toggle="modal"
            class="btn addBtn"
          >
          <i class="mdi mdi-food fs-5"></i><i class="mdi mdi-plus fs-5" ></i>
          </button>
        </div>
      </div>
      <div class="col-md-12"></div>
    </div>
    <div class="row">
      <div class="col-md-3" v-for="r in recipes" v-motion-fade-visible  :class="recipes.length <=2? 'col-md-12':'col-md-3'">
        <RecipeCard :recipe="r" :key="r.id" />
      </div>
    </div>
  </div>
  <RecipeModal :recipe="activeRecipe" />
  <RecipeForm />
  <InstructionsModal/>
</template>

<script>
import { onAuthLoaded } from "@bcwdev/auth0provider-client";
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import InstructionsModal from "../components/InstructionsModal.vue";
import RecipeForm from "../components/RecipeForm .vue";
import { accountService } from "../services/AccountService.js";
import { favoritesService } from "../services/FavoritesService.js";
 
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      } catch (error) {
        Pop.error(error);
      }
    }
    async function getAllFavorites() {
      try {
        if (AppState.account) {
          
          await accountService.getAllFavorites()
        }
      } catch (error) {
        Pop.error(error);
      }
    }

    onMounted(() => {
      getAllRecipes();
    });
    
    onAuthLoaded(()=>{
      getAllFavorites()

    })
    return {
    
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      favrecipe: computed(() => AppState.favoriteRecipes),
      cheeseCategory: computed(() =>
        AppState.recipes.filter((r) => r.category == "cheese")
      ),
      ingredients: computed(() => AppState.ingredients),
    };
  },
  components: { RecipeForm, InstructionsModal },
};
</script>

<style scoped lang="scss">

.addBtn{
 
    background: linear-gradient(to bottom right, #ffbb00, #ff5e00);
  border: 0;
  border-radius: 12px;
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
  transition: all 0.5s ease-in-out;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  box-shadow: rgba(0, 0, 0, 0.07) 0px 1px 1px, rgba(0, 0, 0, 0.07) 0px 2px 2px,
    rgba(0, 0, 0, 0.07) 0px 4px 4px, rgba(0, 0, 0, 0.07) 0px 8px 8px,
    rgba(0, 0, 0, 0.07) 0px 16px 16px;
}


</style>
