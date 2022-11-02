<template>
   <li class="d-flex align-items-center justify-content-between hover2 bg-light p-1">
     <img src="https://cdn-icons-png.flaticon.com/512/4142/4142975.png" alt="" height="25" width="25">
    <div class="d-flex">
      <p class="mb-0 me-2 ">
        {{ingredient?.name  }}
      </p>
      <p class="mb-0">({{ ingredient?.quantity }})</p>
    </div>
        <button @click="removeIngredient()" class="btn">
            <img
            id="favImg"
            src="https://cdn-icons-png.flaticon.com/512/458/458594.png"
            alt=""
            class="hoverOver"
       
            height="25"
            width="25"
          />
          
        </button>
      </li>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { ingredientsService } from "../services/IngredientsService.js";

export default {
  props: {
    ingredient: { type: Ingredient },
  },

  setup(props) {
    return {

      async removeIngredient(){
        try {
            await ingredientsService.removeIngredient(props.ingredient.id)
          } catch (error) {
            Pop.error(error)
          }
      }
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
