<template>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center container-fluid"
  >
    <div class="row">
      <div class="col-md-12">
        <HomeBanner />
        <button
          data-bs-target="#recipeFormModal"
          data-bs-toggle="modal"
          class="btn btn-success"
        >
          CreateRecipe
        </button>
      </div>
      <div class="col-md-12"></div>
    </div>
    <div class="row">
      <div class="col-md-4" v-for="r in recipes" v-if="recipes">
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
      cheeseCategory: computed(() =>
        AppState.recipes.filter((r) => r.category == "cheese")
      ),
      ingredients: computed(() => AppState.ingredients),
    };
  },
  components: { RecipeForm, InstructionsModal },
};
</script>

<style scoped lang="scss"></style>
