<template>
  <div
    class="modal fade recipe"
    id="recipeModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div
      class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable"
    >
      <div class="modal-content">
        <!-- --------------------------- -->
        <div class="modal-body FORM p-0 position-relative">
          <div class="container-fluid" v-if="recipe">
            <div class="row">
              <div class="col-md-4 p-0">
                <img
                  :src="recipe?.img"
                  alt=""
                  class="img-fluid rounded-start img1"
                />

                <div class="card-img-overlay">
                  <div class="col-md-3 ms-2">
                    <CommentsCard v-for="c in comments" :comment="c" />
                  </div>
                </div>
              </div>
              <div class="col-md-8">
                <span class="position-absolute end-0 top-0 deleteIcon"
                  ><i
                    class="mdi mdi-alpha-x-circle-outline hoverOver text-danger m-2 fs-2"
                    @click="removeRecipe()"
                  ></i
                ></span>

                <span class="d-flex align-items-center p-1 rounded no-select"
                  ><h3 class="text-custom p-2">{{ recipe?.title }}</h3>
                  <p class="bg-secondary p-1 mt-1 rounded fw-bold">
                    {{ recipe?.category }}
                  </p></span
                >
                <div class="row">
                  <div class="col-md-6">
                    <div class="card elevation-4 border-0">
                      <div
                        class="card-title bg-custom justify-content-between mb-0 p-1 rounded-top elevation-4 text-center d-flex"
                      >
                        <h3 class="ms-2 text-light">
                          Recipe Instructions
                        </h3>
                        <button
                          class="btn p-0 m-0"
                          type="button"
                          data-bs-toggle="collapse"
                          data-bs-target="#instructionCollapse"
                          aria-expanded="false"
                          aria-controls="collapseExample"
                        >
                          <i class="mdi mdi-plus-box fs-4"> </i>
                        </button>
                      </div>
                      <div class="card-body bg-custom2 p-0 yScroll">
                               <div class="bg-transparent  p-md-0 m-md-0">
                        <div
                          class="collapse animate__animated animate__fadeIn"
                          id="instructionCollapse"
                        >
                          <AddInstructions />
                        </div>
                      </div>
                        <TransitionGroup
                          name=""
                          enterActiveClass="animate__fadeIn animate__animated "
                          leaveActiveClass="animate__fadeOut animate__animated"
                        >
                          <InstructionsCard
                            :instruction="i"
                            v-for="i in instructions"
                            :key="i.id"
                          />
                        </TransitionGroup>
                      </div>
               
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="card elevation-4 border-0">
                      <div
                        class="card-title bg-custom mb-0 p-1 rounded-top elevation-1 d-flex justify-content-between"
                      >
               
                        <h3 class="ms-2 text-light">
                          Recipe Ingredients
                        </h3>
                                      <button
                          class="btn p-0 m-0"
                          type="button"
                          data-bs-toggle="collapse"
                          data-bs-target="#ingredientCollapse"
                          aria-expanded="false"
                          aria-controls="collapseExample"
                        >
                          <i class="mdi mdi-plus-box fs-4"> </i>
                        </button>

                      </div>
                      <div class="card-body p-0  bg-custom2 yScroll">
                          <div
                          class="collapse animate__animated animate__fadeIn"
                          id="ingredientCollapse"
                        >
                          <AddIngredient />
                        </div>
                        <ul class="ps-0 m-0">
                          <TransitionGroup
                            name=""
                            enterActiveClass="animate__fadeIn animate__animated"
                            leaveActiveClass="animate__fadeOut animate__animated"
                          >
                            <IngredientsCard
                              :ingredient="i"
                              v-for="i in ingredients"
                              :key="i.id"
                            />
                          </TransitionGroup>
                        </ul>
                      </div>

                      <div class="mx-2">
                 
                      
                      </div>
                    </div>
                  </div>
                </div>
                <div
                  class="col-md-12 d-flex justify-content-end align-items-end"
                >
                  <div
                    class="position-absolute bottom-0 d-flex align-items-center"
                  >
                    <div class="me-4 text-dark">
                      <i
                        class="mdi mdi-comment-text fs-1"
                        @click="showComments()"
                      ></i>
                    </div>

                    <p class="text-secondary mb-md-0">
                      published By
                      <b class="text-decoration-underline">
                        @{{ recipe?.creator.name.split("@")[0] }}</b
                      >
                    </p>
                    <img
                      :src="recipe?.creator.picture"
                      alt="creator profile picture "
                      :title="recipe?.creator.name + 'picture'"
                      class="rounded-circle ms-2 mb-1"
                      height="40"
                    />
                  </div>
                  <div><AddComment /></div>
                </div>
              </div>
            </div>
          </div>
          <div v-else>LOADING....</div>
        </div>
        <!-- ---------------------------------- -->
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted, ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";

import { Recipe } from "../models/Recipe.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { instructionsService } from "../services/InstructionsService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import AddComment from "./AddComment.vue";
import AddIngredient from "./AddIngredient.vue";
import AddInstructions from "./AddInstructions.vue";
import CommentsCard from "./CommentsCard.vue";
import IngredientsCard from "./IngredientsCard.vue";
import InstructionsCard from "./InstructionsCard.vue";

export default {
  props: {
    recipe: { type: Recipe, required: false },
    ingredient: { type: Ingredient, required: false },
  },
  setup(props) {
    async function getIngredientsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await recipesService.getIngredientsByRecipeId(recipeId);
        }
      } catch (error) {
        Pop.error(error);
      }
    }
    async function getCommentsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await recipesService.getCommentsByRecipeId(recipeId);
        }
      } catch (error) {
        Pop.error(error);
      }
    }
    async function getInstructionsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await recipesService.getInstructionsByRecipeId(recipeId);
        }
      } catch (error) {
        Pop.error(error);
      }
    }
    watchEffect(() => {
      AppState.activeRecipe;
      getIngredientsByRecipeId();
      getCommentsByRecipeId();
      getInstructionsByRecipeId();
    });
    return {
      ingredients: computed(() => AppState.ingredients),
      comments: computed(() => AppState.comments),
      instructions: computed(() => AppState.instructions),
      async removeRecipe() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          const recipeId = AppState.activeRecipe.id;
          await recipesService.removeRecipe(recipeId);
          Pop.toast(
            `${AppState.activeRecipe.title} Removed`,
            "success",
            "top-end",
            2000
          );
          AppState.activeRecipe = null;
        } catch (error) {
          Pop.error(error);
        }
      },
      async removeIngredient() {
        try {
          let id = props.ingredient.id;
          await ingredientsService.removeIngredient(id);
        } catch (error) {
          Pop.error(error);
        }
      },

      test() {
        console.log("hi");
      },
    };
  },
  components: {
    AddInstructions,
    AddIngredient,
    AddInstructions,
    CommentsCard,
    AddComment,
    InstructionsCard,
    IngredientsCard,
  },
};
</script>

<style lang="scss" scoped>
:root{

}
.modal-body {
  box-shadow: rgba(240, 169, 46, 0.4) 5px 5px, rgba(240, 140, 46, 0.3) 10px 10px,
    rgba(240, 172, 46, 0.2) 15px 15px, rgba(240, 185, 46, 0.1) 20px 20px;
}

.bg-custom {
   background: #ffbb00
    linear-gradient(22deg, #fcff53, #f8ce14, #ffbb00, #ff5e00, #ffffff) fixed;
}
.bg-custom2 {
  background: #f2f0f4;
}
.text-custom {
  color: purple;
  font-weight: 700;
}

.img1 {
  height: 80vh;
  width: auto;
  object-fit: cover;
}
@media screen and (max-width: 600px) {
}

.recipe {
  // background-image: url(https://www.9-elephants.co.uk/wp-content/uploads/thai-food.jpg);
  transition: all 0.25s ease;
}

.yScroll {
  overflow-y: auto;
  overflow-x: hidden;
  height: 400px;
}
</style>
