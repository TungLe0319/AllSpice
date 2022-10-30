<template>
  <div
    class="card text-bg-dark my-2 position-relative elevation-5 border-0"
    v-if="recipe"
  >
    <img
      :src="recipe?.img"
      :alt="recipe?.title"
      :title="recipe?.title + 'Img'"
      class="forcedImg card-img"
    />

    <div
      class="card-img-overlay flex-column d-flex justify-content-end align-items-center"
    >
      <!-- NOTE SET ACTIVE RECIPE -->
      <span
        class="cardText p-2 rounded no-select selectable"
        :title="'Show More Details '"
        @click="setActiveRecipe()"
        data-bs-target="#recipeModal"
        data-bs-toggle="modal"
      >
        <p class="card-title">{{ recipe?.title }}</p>
      </span>
      <!-- NOTE FAVORITE A RECIPE -->

      <span class="position-absolute top-0 end-50"
        ><i
          class="mdi mdi-star fs-2 text-primary no-select "
          @click="removeFavoriteRecipe()"
        ></i>
      </span>

      <span class="position-absolute top-0 end-0 me-2 hoverOver bg-transparent"
        ><i
          class="mdi mdi-heart-circle fs-2 text-danger no-select"
          @click="favoriteRecipe()"
        ></i>
      </span>
    </div>
    <div class=" position-absolute start-0 px-1 rounded category">
      <p class="mb-0 text-shadow2">{{ recipe?.category }}</p>
    </div>
  </div>
</template>

<script>
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { favoritesService } from "../services/FavoritesService.js";
import { computed } from "@vue/reactivity";
export default {
  props: {
    recipe: { type: Recipe, required: true },
  },

  setup(props) {
    return {
      favorites: computed(() =>
        AppState.favoriteIds.find((f) => f.recipeId == props.recipe.id)
      ),
      setActiveRecipe() {
        recipesService.setActiveRecipe(props.recipe);
      },

      async favoriteRecipe() {
        try {
          const recipeId = {
            recipeId: props.recipe.id,
          };

          await favoritesService.favoriteRecipe(recipeId);

          Pop.success("Favorited");
        } catch (error) {
          Pop.error(error);
        }
      },

      async removeFavoriteRecipe() {
        try {
          await favoritesService.removeFavoriteRecipe(props.recipe.favoriteId);
          Pop.success("Removed");
        } catch (error) {
          Pop.error(error);
        }
      },
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

.card{
  transition: all 0.5s ease;
}
.card:hover{
  transition: all 0.5s ease;
    box-shadow: rgba(240, 169, 46, 0.4) 5px 5px, rgba(240, 140, 46, 0.3) 10px 10px,
    rgba(240, 172, 46, 0.2) 15px 15px, rgba(240, 185, 46, 0.1) 20px 20px,
    

}
.cardText {
  display: flex;
  justify-content: end;
  background-color: rgba(0, 0, 0, 0.331);
  backdrop-filter: blur(3px);
    text-shadow: 2px 2px 0px rgba(0, 0, 0, 0.459);
    font-weight: 600;
    letter-spacing: 0.04rem;

    transition:  1.5s ease;
}
.cardText:hover{
 border-bottom:  4px solid red;
text-decoration: underline red;
transition: all 0.5s ease;


}
.deleteIcon {
  z-index: 9999;
}
.category{
    background-color: rgba(0, 0, 0, 0.331);
}

.hoverOver{
  transition: all 0.75s ease;
}
.hoverOver:hover{
  transform: rotate(360deg);
  transition: all 0.75s ease;
 

}
</style>
