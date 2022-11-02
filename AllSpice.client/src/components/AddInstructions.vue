<template>
  <div class="container">
    <form @submit.prevent="addInstruction()">
      <div class="p-1 px-0 d-flex">
        <textarea
          type="text"
          name="instructions"
          class="rounded"
          v-model="editable.step"
        ></textarea>
        <button class="btn editBtn" type="submit">Add Instruction</button>
      </div>
    </form>
  </div>
</template>

<script>
import { computed, ref } from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { instructionsService } from "../services/InstructionsService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {},

  setup(props) {
    watchEffect(() => {});
    const editable = ref({});
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      async editInstruction() {
        try {
          let recipe = AppState.activeRecipe;
          const yes = await Pop.confirm(
            `
 ${this.recipe.instructions}
`,
            "",
            "Edit",
            "warning"
          );
          if (!yes) {
            return;
          }
          await recipesService.editRecipe(recipe.id, editable.value);
        } catch (error) {
          Pop.error(error);
        }
      },

      async addInstruction() {
        try {
          editable.value.recipeId = AppState.activeRecipe.id;
          await instructionsService.addInstruction(editable.value);
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>

.editBtn:hover {
  transform: scale(1.03);
  transition: all 0.25s ease;
}
</style>
