<template>
  <div
    class="modal fade"
    id="instructionsModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered ">
      <div class="modal-content ">
        <div class="modal-body FORM d-flex justify-content-center flex-column align-items-center">
         <div class="row justify-content-center" >

          <div class="col-md-6 " >
          <h6 v-if="recipe">   {{recipe.instructions}}</h6>
          <h6 >  {{editable.instructions}}</h6>
          </div>
         </div>
         
          <!-- -------------------SECTION FORM----------------------------------- -->
          <form @submit.prevent="addInstruction()">
     <div class="input-group">

    <textarea type="text" name="instructions" class="rounded" v-model="editable.instructions"></textarea>
    <button class="btn btn-success" type="submit">submit</button>
  </div>
  </form>
 
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({});

    watchEffect(() => {
      // editable.value = { ...AppState.account };
    });
    return {
      
      recipe : computed(()=>AppState.activeRecipe),
      editable,
      async addInstruction() {
        try {
          await recipesService.editRecipe(editable.value,AppState.activeRecipe.id);
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
  //background-image: url();
  // background-size: cover;
  //background-position: center;
  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}
</style>
