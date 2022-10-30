<template>
  <form @submit.prevent="addIngredient()">
    <div class="input-group">
      <input
        type="text"
        name="instructions"
        class="rounded border-success border-2"
        required
        placeholder="name"
        v-model="editable.name"
      />
      <input
        type="text"
        name="instructions"
        required
        class="rounded"
        placeholder="quantity"
        v-model="editable.quantity"
      />
    </div>
    <button class="btn btn-success" type="submit">submit</button>
  </form>
</template>

<script>
import { computed, ref } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default { 
  props: {},

  setup(props) {
    let editable = ref({recipeId:AppState.activeRecipe.id});
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      async addIngredient() {
        try {

           await ingredientsService.addIngredient(editable.value)
           editable.value = {}
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
  width: 300px;
  object-fit: cover;
}
</style>
