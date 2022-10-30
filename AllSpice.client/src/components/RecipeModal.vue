<template>
  <div
    class="modal fade"
    id="recipeModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-xl">
      <div
        class="modal-content modal-dialog-centered modal-dialog-scrollable modal-xl"
      >
        <!-- --------------------------- -->
        <div class="modal-body FORM p-0 position-relative">
          <div class="container-fluid" v-if="recipe">
            <div class="row">
              <div class="col-md-4 p-0">
                <img
                  :src="recipe?.img"
                  alt=""
                  class="img-fluid rounded-start"
                />
              </div>
              <div class="col-md-8">
                <span
                  class="position-absolute  end-0 top-0 deleteIcon"
                  ><i
                    class="mdi mdi-alpha-x-circle-outline hoverOver  text-danger m-2 fs-2"
                    @click="removeRecipe()"
                    data-bs-dismiss="modal"
                  ></i
                ></span>
                <span class="d-flex align-items-center p-1 rounded no-select "
                  ><h3 class="text-custom p-2">{{ recipe?.title }}</h3>
                  <p class="bg-secondary p-1 mt-1 rounded fw-bold ">{{ recipe?.category }}</p></span
                >
                <div class="row h-100">
                  <div class="col-md-6">
                    <div class="card elevation-4 border-0 h-75">
                      <div
                        class="card-title bg-custom mb-0 p-1 rounded-top elevation-1 text-center"
                      >
                        <h3 class="p-md-0 m-md-0 text-light">Recipe Instructions</h3>
                      </div>
                      <div class="card-body bg-custom2">
                        <p>{{ recipe?.instructions }}</p>
                      </div>
                      <div class="bg-transparent d-flex justify-content-center  bg-custom3 p-md-0 m-md-0   ">
            
                        
                        <AddInstructions/>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="card elevation-4 border-0 h-75">
                      <div
                        class="card-title bg-custom p-1 mb-0 rounded-top elevation-1 text-center"
                      >
                        <h3 class="p-md-0 m-md-0 text-light">Recipe Ingredients</h3>
                      </div>
                      <div class="card-body  bg-custom2">
                        <div v-for="i in ingredients" :key="i.id">
                          <span class="me-2">{{ i.name }}</span>
                          <span>({{ i.quantity }})</span>
                        </div>
                      </div>

                      <div class="card-footer bg-custom3   ">
                        <AddIngredient />
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-md-12 d-flex justify-content-end align-items-end">
                  <div class="position-absolute bottom-0 d-flex align-items-center ">
                    <p class="text-secondary mb-md-0 ">published By   <b class=" text-decoration-underline"> @{{recipe?.creator.name.split("@")[0]}}</b> </p>
                    <img :src="recipe?.creator.picture" alt="creator profile picture " :title="recipe.creator.name +'picture'" class="rounded-circle  ms-2 mb-1" height="40">
                  </div>
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
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import AddIngredient from "./AddIngredient.vue";
import AddInstructions from "./AddInstructions.vue";


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
    watchEffect(() => {
      AppState.activeRecipe;
      getIngredientsByRecipeId();
    });
    return {
      ingredients: computed(() => AppState.ingredients),
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
            1000
          );
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
  components: { AddInstructions, AddIngredient, AddInstructions },
};
</script>

<style lang="scss" scoped>
.modal-body {
    box-shadow: rgba(240, 169, 46, 0.4) 5px 5px, rgba(240, 140, 46, 0.3) 10px 10px,
    rgba(240, 172, 46, 0.2) 15px 15px, rgba(240, 185, 46, 0.1) 20px 20px,
    
}

.bg-custom{
  background: #645273
}
.bg-custom2{
  background:#f2f0f4
}
.text-custom{
color: purple;
font-weight: 700;
}

</style>
