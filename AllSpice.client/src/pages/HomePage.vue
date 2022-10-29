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
      <div class="col-md-2" v-for="r in recipes" v-if="recipes">
        <RecipeCard :recipe="r" :key="r.id" />
      </div>
    </div>
  </div>
  <RecipeModal :recipe="activeRecipe" />
  <RecipeForm />
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import RecipeForm from "../components/RecipeForm .vue";

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

    onMounted(() => {
      getAllRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      cheeseCategory: computed(() =>
        AppState.recipes.filter((r) => r.category == "cheese")
      ),
      ingredients: computed(() => AppState.ingredients),
      filterByCategory(filter) {
        console.log("hi");
        if (filter == "cheese") {
          this.recipes = this.cheeseCategory;
        }
      },
    };
  },
  components: { RecipeForm },
};
</script>

<style scoped lang="scss"></style>
