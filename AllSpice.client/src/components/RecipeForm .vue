<template>
  <div
    class="modal fade"
    id="recipeFormModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content ">
        <div class="modal-body FORM">
          <div class="p-2 bg-success"><h4> New Recipe</h4></div>
          <!-- -------------------SECTION FORM----------------------------------- -->
          <form @submit.prevent="handleSubmit()" class="">
            <div class="row">
              <div class="col-md-8">
                <div class="mt-3 inputBox">
                  <span>Title</span>
                  <input type="text" required name="title" v-model="editable.title" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Image</span>
                  <input type="url" name="img" required v-model="editable.img" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Instructions</span>
                  <input type="text" name="instructions" v-model="editable.instructions" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Category</span>
                  <input type="text" name="instructions" v-model="editable.category" />
                </div>
         
              </div>
            </div>

            <div class="my-3">
              <button
                class="btn btn-success selectable"
                type="submit"
                data-bs-dismiss="modal"
              >
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {

  setup() {
    const editable = ref({});

    watchEffect(() => {
      editable.value = { ...AppState.account };
    });
    return {
      editable,
      async handleSubmit() {
        try {

          await recipesService.createRecipe(editable.value)
        } catch (error) {
          console.error(error);
          Pop.error(error, "[handleSubmit]");
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.modal-body {
  //background-image: url();
  // background-size: cover;
  //background-position: center;
  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}
</style>
