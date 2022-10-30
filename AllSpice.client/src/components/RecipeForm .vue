<template>
  <div
    class="modal fade"
    id="recipeFormModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content  ">
        <div class="modal-body FORM">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-6">
                        <div class=" "><h2> New Recipe</h2></div>
          <!-- -------------------SECTION FORM----------------------------------- -->
          <form @submit.prevent="handleSubmit()" class="">
        
                <div class="mt-3 inputBox">
                  <span>Title</span>
                  <input type="text" required name="title" v-model="editable.title" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Image</span>
                  <input type="url" required name="img" v-model="editable.img" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Instructions</span>
                  <input type="text" required name="instructions" v-model="editable.instructions" />
                </div>
                <div class="mt-3 inputBox">
                  <span>Category</span>
                  <input type="text" required name="instructions" v-model="editable.category" />
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
        <div class="col-md-6 rounded" v-if="editable.img">
<img :src="editable?.img" alt="recipe image" title="recipe image" class="img-fluid ">
              </div>
              <div v-else></div>
              </div>
              
            </div>
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

.inputBox {
  position: relative;
  width: 250px;
}

.inputBox input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ffbb00;
  border-bottom: 3px solid #ff5e00;
  border-radius: 5px;
  outline: none;
  color: rgb(0, 0, 0);
  font-size: 1em;
  background-color: transparent;
  transition: all 1.5s ease;
  box-shadow: 0.25px 0.25px 10px rgba(243, 236, 236, 0.308);
}

.inputBox span {
  position: absolute;
  left: 0;
bottom: 35px;
  padding: 10px;
  pointer-events: none;
  font-size: 1em;
  text-transform: uppercase;
  color: #13121380;
  transition: all 1s ease;
}

.inputBox input:valid ~ span,.inputBox input:required ~ span,
.inputBox input:focus ~ span {
  color: #27132a;
  transform: translateX(10px) translateY(-7px);
  padding: 0 10px;
  font-size: 0.65em;
  border-radius: 4px;
  font-weight: bold;
  background: #ffbb00;
  border-left: 1px solid #ff5e00;
  border-right: 1px solid #ff5e00;
  letter-spacing: 0.2em;
  transition: all 1s ease;
}
</style>
