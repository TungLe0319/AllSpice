<template>
  <div class="card" v-if="ingredient">
    <div class="card-title bg-info p-1 rounded elevation-1 text-center">
      <p class="p-md-0 m-md-0">Recipe Ingredients</p>
    </div>
    <div class="card-body d-flex">
      <p>{{ ingredient?.name }}</p>
    </div>

    <div class="card-footer">
      <AddIngredient />
    </div>
  </div>
</template>

<script>
import { Ingredient } from "../models/Ingredient.js";

export default {
  props: {
    ingredient: { type: Ingredient },
  },

  setup(props) {
    return {};
  },
};
</script>

<style lang="scss" scoped></style>
