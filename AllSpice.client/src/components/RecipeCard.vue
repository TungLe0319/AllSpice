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

      <span
        class="position-absolute top-0 end-0 m-1 hoverOver"
        v-if="recipe?.favorited"
        ><i
          class="mdi mdi-minus-box fs-1 text-danger no-select"
          @click="removeFavoriteRecipe()"
        ></i>
      </span>

      <span
        class="position-absolute top-0 end-0 m-1 bg-transparent"
        v-if="!recipe?.favorited"
      >
        <img
          id="favImg"
          src="https://cdn-icons-png.flaticon.com/512/3237/3237427.png"
          alt=""
          class="hoverOver"
          @click="favoriteRecipe()"
          height="30"
          width="30"
        />
      </span>
    </div>
    <div class="position-absolute start-0 px-1 rounded category">
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
import { watchEffect } from "vue";
export default {
  props: {
    recipe: { type: Recipe, required: true },
  },

  setup(props) {
    watchEffect(() => {
      AppState.recipes = AppState.recipes;
    });
    return {
      favorited: computed(() =>
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
          let foundRecipe = AppState.recipes.find(
            (r) => r.id == props.recipe.id
          );

          if (props.recipe.favorited == false) {
            foundRecipe.favorited = true;
            props.recipe.favorited = true;
            await favoritesService.favoriteRecipe(recipeId);
            Pop.success("Favorited");
          } else {
            await favoritesService.removeFavoriteRecipe(foundRecipe.favoriteId);
          }
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

.card {
  transition: all 0.5s ease;
}
.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(240, 169, 46, 0.4) 5px 5px, rgba(240, 140, 46, 0.3) 10px 10px,
    rgba(240, 172, 46, 0.2) 15px 15px, rgba(240, 185, 46, 0.1) 20px 20px;
}
.cardText {
  display: flex;
  justify-content: end;
  background-color: rgba(0, 0, 0, 0.331);
  backdrop-filter: blur(3px);
  text-shadow: 2px 2px 0px rgba(0, 0, 0, 0.459);
  font-weight: 600;
  letter-spacing: 0.04rem;

  transition: 1.5s ease;
}
.cardText:hover {
  filter: brightness(114%);
  border-bottom: 4px solid red;
  text-decoration: underline red;
  transition: all 0.5s ease;
}
.deleteIcon {
  z-index: 9999;
}
.category {
  background-color: rgba(0, 0, 0, 0.331);
}

.hoverOver {
  transition: all 0.75s ease;
}
.hoverOver:hover {
  transform: rotate(180deg) scale(1.1);
  transition: all 0.75s ease;
}
</style>
