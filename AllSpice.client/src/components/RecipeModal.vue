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
                <img :src="recipe.img" alt="" class="img-fluid rounded-start" />
              </div>
              <div class="col-md-6">
                 <span class="position-absolute selectable no-select end-0 top-0 deleteIcon"><i class="mdi mdi-delete fs-2" @click="removeRecipe()" data-bs-dismiss="modal"></i></span>
                <span
                  ><h5>{{ recipe.title }}</h5>
                  <p>{{ recipe.category }}</p></span
                >
                <div class="row">
                  <div class="col-md-6">
                    <div class="card">
                     <div class="card-title bg-info p-1 rounded elevation-1 text-center"> <p class="p-md-0 m-md-0">Recipe Instructions</p></div>
                     <div class="card-body">
                      <p> {{recipe.instructions}}</p>
                     </div>
                    </div>
                  </div>
                  <div class="col-md-6"></div>
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
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup(props) {
    async function getIngredientsByRecipeId() {
      try {
        let id = AppState.activeRecipe.id;
        await recipesService.getIngredientsByRecipeId(id);
      } catch (error) {
        Pop.error(error);
      }
    }

    watchEffect(() => {
      // AppState.activeRecipe;
      // getIngredientsByRecipeId();
    });
    return {

          async removeRecipe() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }

         const recipeId = AppState.activeRecipe.id
          await recipesService.removeRecipe(recipeId);
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.modal-body {
  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}
</style>
