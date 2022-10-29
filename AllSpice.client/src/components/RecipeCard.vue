<template>
  <div
    class="card text-bg-dark my-2 position-relative"
    @click="setActiveRecipe()"
    data-bs-target="#recipeModal"
    data-bs-toggle="modal"
    v-if="recipe"
  >
    <img
      :src="recipe?.img"
      :alt="recipe?.title"
      :title="recipe?.title + 'Img'"
      class="forcedImg card-img"
    />

    <div
      class="card-img-overlay flex-column d-flex justify-content-end align-items-start"
    >
      <span class="cardText p-2 rounded">
        <p class="card-title">{{ recipe?.title }}</p>
      </span>
      <span class="position-absolute top-0 end-0"><i class="mdi mdi-heart fs-2 text-danger" @click="favoriteRecipe()"></i> </span>
    </div>
    <div class="bg-dark position-absolute start-0 px-1 rounded">
      <p class="mb-0">{{ recipe?.category }}</p>
    </div>
  </div>
</template>

<script>
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },

  setup(props) {
    return {
      setActiveRecipe() {
        recipesService.setActiveRecipe(props.recipe);
      },

      async favoriteRecipe(){
        try {
            
          } catch (error) {
            Pop.error(error)
          }
      }
  
    };
  },
};
</script>

<style lang="scss" scoped>
.text-shadow {
  color: aliceblue;
  text-shadow: 1px 1px black, 0px 0px 5px salmon;
  font-weight: bold;
  letter-spacing: 0.08rem;
  /* Second Color  in text-shadow is the blur */
}
.forcedImg {
  height: 300px;
  width: auto;
  object-fit: cover;
}
.cardText {
  display: flex;
  justify-content: end;
  background-color: rgba(0, 0, 0, 0.331);
  backdrop-filter: blur(3px);
}
.deleteIcon {
  z-index: 9999;
}
</style>
