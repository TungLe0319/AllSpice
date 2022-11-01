<template>
  <div class="card" v-if="ingredient">
    <div class="card-title bg-info p-1 rounded-top elevation-1 text-center">
      <p class="p-md-0 m-md-0">Recipe Ingredients</p>
    </div>
    <ul class="card-body d-flex">
      <li class="d-flex">
        <p class="me-2">
          {{ ingredient.name }}
        </p>
        <p>({{ ingredient.quantity }})</p>
        <button @click="removeIngredient()" class="btn">
          <i class="mdi mdi-minus-box fs-5 text-danger"></i>
        </button>
      </li>
    </ul>

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
