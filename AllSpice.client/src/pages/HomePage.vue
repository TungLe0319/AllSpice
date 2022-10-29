<template>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center container-fluid"
  >
    <div class="row">
      <div class="col-md-12">
        <HomeBanner/>
      </div>
    </div>
    <div class="row">
      <div class="col-md-3" v-for="r in recipes">
        <RecipeCard :recipe="r" :key="r.id" />
      </div>
    </div>
    <button
      data-bs-target="#recipeModal"
      data-bs-toggle="modal"
      class="btn btn-success"
    >
      modal
    </button>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";

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
    };
  },
  components: {},
};
</script>

<style scoped lang="scss"></style>
