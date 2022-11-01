<template>
   <li class="d-flex">
        <p class="me-2">
          {{ingredient.name  }}
        </p>
        <p class="">({{ ingredient.quantity }})</p>
        <button @click="removeIngredient()" class="btn">
          <i class="mdi mdi-minus-box fs-5 text-danger"></i>
        </button>
      </li>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";

export default {
  props: {
    ingredient: { type: Ingredient },
  },

  setup(props) {
    return {
      // ingredients : computed(()=> AppState.ingredients)
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
