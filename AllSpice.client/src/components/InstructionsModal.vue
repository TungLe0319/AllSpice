<template>
  <div
    class="modal fade"
    id="instructionsModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content bg-dark">
        <div class="modal-body FORM">
          <!-- -------------------SECTION FORM----------------------------------- -->
          <form @submit.prevent="addInstructions()" class="">
            <div class="input-group">
              <input
                type="text"
                name="instructions"
                class="rounded"
                v-model="editable.name"
              />
              <input
                type="text"
                name="instructions"
                class="rounded"
                v-model="editable.quantity"
              />
            </div>

            <div class="my-3">
              <button
                class="btn btn-success selectable"
                type="submit"
                data-bs-toggle="modal"
                data-bs-target="#recipeModal"
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
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({});

    watchEffect(() => {
      // editable.value = { ...AppState.account };
    });
    return {
      editable,
      async addIngredient() {
        try {
          await ingredientsService.addIngredient(editable.value);
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
