<template>
  <div
    class="card text-bg-dark my-2 position-relative elevation-5 border-0"
    v-if="recipe"
  >
    <img
      :src="recipe?.img"
      :alt="recipe?.title"
      :title="recipe?.title + 'Img'"
      class="forcedImg card-img favoriteShadow selectable"
    />

    <div
      class="card-img-overlay flex-column d-flex justify-content-end align-items-center"
    >
      <!-- NOTE SET ACTIVE RECIPE -->
      <span
        class="cardText p-1 no-select selectable"
        :title="'Show More Details '"
        @click="setActiveRecipe()"
        data-bs-target="#recipeModal"
        data-bs-toggle="modal"
      >
        <h6 class="card-title fw-bold">{{ recipe?.title }}</h6>
      </span>
      <!-- NOTE FAVORITE A RECIPE -->
      <TransitionGroup
        name=""
        enterActiveClass="animate__fadeInLeft animate__animated"
        leaveActiveClass="animate__fadeOutRight animate__animated"
      >
        <span
          class="position-absolute top-0 end-0 m-1 hoverOver deleteIcon"
          v-if="favorited"
        >
          <img
            id="favImg"
            src="https://cdn-icons-png.flaticon.com/512/458/458594.png"
            alt=""
            class="hoverOver"
            @click="removeFavoriteRecipe()"
            height="25"
            width="25"
            title="unfavorite this recipe"
          />
        </span>

        <span
          class="position-absolute top-0 end-0 m-1 bg-transparent deleteButton"
          v-else
          v-motion-fade
        >
          <img
            id="favImg"
            src="https://cdn-icons-png.flaticon.com/512/3237/3237420.png"
            alt=""
            class="hoverOver"
            @click="favoriteRecipe()"
            height="25"
            width="25"
            title="favorite this recipe"
          />
        </span>
      </TransitionGroup>
    </div>
    <div class="position-absolute start-0 px-1 rounded-end category">
      <h6 class="mb-0 p-1 text-light fw-bold text-shadow2">
        {{ recipe?.category }}
      </h6>
    </div>
  </div>
  <div v-else><LoadingSpinner /></div>
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
    // watchEffect(() => {
    //   AppState.recipes = AppState.recipes;
    // });
    return {
      creator: computed(() => AppState.account.id == props.recipe.creator.id),
      favorited: computed(() =>
        AppState.favorites.find((f) => f.recipeId == props.recipe.id)
      ),
      setActiveRecipe() {
        recipesService.setActiveRecipe(props.recipe);
      },

      async favoriteRecipe() {
        try {
          await favoritesService.favoriteRecipe(props.recipe);
          Pop.toast(
            `${props.recipe.title} added to favorites`,
            "success",
            "top-end",
            2000
          );
        } catch (error) {
          Pop.error(error);
        }
      },

      async removeFavoriteRecipe() {
        try {
          let id = this.favorited.favoriteId;

          const yes = await Pop.confirm(
            "Unfavorite Recipe?",
            "",
            "Unfavorite",
            "question"
          );
          if (!yes) {
            return;
          }
          await favoritesService.removeFavoriteRecipe(id);
          Pop.toast(
            `${props.recipe.title} removed favorites`,
            "success",
            "top-end",
            2000
          );
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
  height: 250px;
  width: auto;
  object-fit: cover;
}

.card {
  transition: all 0.5s ease;
}
.card:hover {
  filter: brightness(90%);
  transition: all 0.25s ease;
  box-shadow: rgba(240, 78, 46, 0.4) 5px 5px, rgba(240, 75, 46, 0.3) 10px 10px,
    rgba(240, 46, 46, 0.2) 15px 15px, rgba(240, 53, 46, 0.1) 20px 20px;
  .cardText {
    border-radius: 4px;
    padding: 3px;
    filter: brightness(114%);
    border-bottom: 4px solid red;
    text-decoration: underline red;
    transition: all 0.5s ease;
  }
}
.cardText {
  display: flex;
  justify-content: end;
  transition: all 0.5s ease;
  backdrop-filter: blur(3px);
  font-weight: 600;
  letter-spacing: 0.04rem;
  text-shadow: 2px 2px 0px #000000, 5px 4px 0px rgba(0, 0, 0, 0.15);
}

.category {
  background-color: rgba(0, 0, 0, 0.331);
}

.favoriteShadow {
  box-shadow: 1px 2px 16px 8px rgba(245, 179, 9, 0.75) inset;
  -webkit-box-shadow: 1px 2px 16px 8px rgba(245, 179, 9, 0.75) inset;
  -moz-box-shadow: 1px 2px 16px 8px rgba(245, 179, 9, 0.75) inset;
}

//when screen is 700px OR LESS
@media only screen and (max-width: 700px) {
  .card {
  }
}
</style>
